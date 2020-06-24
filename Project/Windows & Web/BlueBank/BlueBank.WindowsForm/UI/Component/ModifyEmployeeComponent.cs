using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlueBank.Model;
using BlueBank.Service;

namespace BlueBank.WindowsForm.UI.Component
{
    public partial class ModifyEmployeeComponent : UserControl
    {
        public ModifyEmployeeComponent()
        {
            InitializeComponent();

            personalInfo = new PersonalInfoComponent() { Dock = DockStyle.Fill };
            jobInfo = new JobInfoComponent() { Dock = DockStyle.Fill };
            employmentInfo = new EmploymentInfoComponent() { Dock = DockStyle.Fill };

            pnlInfo.Controls.Add(personalInfo);
            pnlInfo.Controls.Add(jobInfo);
            pnlInfo.Controls.Add(employmentInfo);
        }
        
        bool IsOwnRecord = false;

        int employeeToUpdateId = 0;
        Employee employeeToUpdate = null;

        PersonalInfoComponent personalInfo = null;
        JobInfoComponent jobInfo = null;
        EmploymentInfoComponent employmentInfo = null;

        private void rdoType_Click(object sender, EventArgs e)
        {
            if (sender == rdoPersonalInfo) personalInfo.BringToFront();
            if (sender == rdoJobInfo) jobInfo.BringToFront();
            if (sender == rdoEmploymentInfo) employmentInfo.BringToFront();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            rdoJobInfo.Enabled = true;
            rdoEmploymentInfo.Enabled = true;

            dgvMatchingEmployees.DataSource = null;
            ResetFields();

            if (txtFilter.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter a search text.");
                return;
            }

            EmployeeService employeeService = new EmployeeService();

            dynamic filter = null;

            if (int.TryParse(txtFilter.Text, out int id))
            {
                if (rdoLn.Checked)
                {
                    MessageBox.Show("Please enter a valid full/partial last name.");
                    return;
                }
                filter = id;
            }
            else
            {
                if (rdoId.Checked)
                {
                    MessageBox.Show("Employee Id must be 8 digits.");
                    return;
                }
                filter = txtFilter.Text;
            }

            List<Employee> employees = rdoId.Checked == true ? employeeService.GetEmployeesByFilter((int)filter) : employeeService.GetEmployeesByFilter((string)filter);

            if (employees.Count == 0)
            {
                MessageBox.Show("No matching employees. Please try again.");
            }
            else if (employees.Count == 1)
            {
                dgvMatchingEmployees.DataSource = null;

                EmployeeDTO employeeDTO = employeeService.GetEmployeeInformation(employees[0].EmployeeId);
                PopulateFields(employeeDTO);
                employeeToUpdateId = employeeDTO.EmployeeId;
                employeeToUpdate = employeeService.GetAllEmployees().FirstOrDefault(emp => emp.EmployeeId == employeeToUpdateId);
                if (LoginData.EmployeeId == Convert.ToInt32(employeeDTO.EmployeeId))
                {
                    rdoEmploymentInfo.Enabled = false;
                    rdoJobInfo.Enabled = false;
                    rdoPersonalInfo.Checked = true;
                    personalInfo.BringToFront();
                }
                //lstEmployeeInfo.DataSource = employeeInfo;
            }
            else
            {

                List<EmployeeLookup> employeesLookup = new List<EmployeeLookup>();

                foreach (Employee employee in employees)
                {
                    EmployeeLookup employeeLookup = new EmployeeLookup(employee.EmployeeId, $"{employee.FirstName}, {employee.LastName}");

                    employeesLookup.Add(employeeLookup);
                }

                dgvMatchingEmployees.DataSource = employeesLookup;



            }
        }

        private void PopulateFields(EmployeeDTO employee)
        {
            int countryIndex = countries.FirstOrDefault(x => x.Value == employee.Country).Key;
            string countryName = countries.FirstOrDefault(x => x.Value == employee.Country).Value;

            Dictionary<string, string> stateprovinces = null;

            if (countryName == "Canada")
            {
                stateprovinces = canadianProvinces;
            }
            else
            {
                stateprovinces = usStates;
            }

            personalInfo.cboStateProvince.DataSource = new BindingSource(stateprovinces, null);
            personalInfo.cboStateProvince.DisplayMember = "Value";
            personalInfo.cboStateProvince.ValueMember = "Key";

            jobInfo.cboStateProvince.DataSource = new BindingSource(stateprovinces, null);
            jobInfo.cboStateProvince.DisplayMember = "Value";
            jobInfo.cboStateProvince.ValueMember = "Key";

            employmentInfo.cboStateProvince.DataSource = new BindingSource(stateprovinces, null);
            employmentInfo.cboStateProvince.DisplayMember = "Value";
            employmentInfo.cboStateProvince.ValueMember = "Key";


            int stateprovinceIndex = stateprovinces.Values.ToList().IndexOf(employee.Province);


            List<DepartmentLookup> departments = (List<DepartmentLookup>)jobInfo.cboDepartment.DataSource;
            int departmentIndex = departments.FirstOrDefault(d => d.Name == employee.DepartmentName).Id;

            EmployeeService employeeService = new EmployeeService();
            var supervisors = employeeService.GetSupervisorsByDepartment(departmentIndex, (int)employee.EmployeeType);

            int supervisorId = employeeService.GetAllEmployees().FirstOrDefault(emp => emp.EmployeeId == employee.EmployeeId).SupervisorId;

            int jobIndex = new JobService().GetJobs().FirstOrDefault(j => j.Name == employee.JobPosition).Id;

            supervisors.Insert(0, new SupervisorLookup { EmployeeId = 0, FullName = "Select a Supervisor" });
            jobInfo.cboSupervisor.DataSource = supervisors;
            jobInfo.cboSupervisor.DisplayMember = "FullName";
            jobInfo.cboSupervisor.ValueMember = "EmployeeId";
            jobInfo.cboSupervisor.SelectedValue = supervisorId;


            //PERSONAL INFO
            personalInfo.txtFirstName.Text = employee.FirstName;
            personalInfo.txtMI.Text = employee.MiddleInitial;
            personalInfo.txtLastName.Text = employee.LastName;
            personalInfo.dtpBirthDate.Value = employee.DOB;
            personalInfo.txtCellPhone.Text = employee.CellPhoneNumber.ToString();
            personalInfo.cboCountry.SelectedIndex = countryIndex;
            personalInfo.txtCity.Text = employee.City.ToString();
            personalInfo.cboStateProvince.SelectedIndex = stateprovinceIndex;
            personalInfo.txtStreetAddress.Text = employee.StreetAddress.ToString();
            personalInfo.txtPostalCode.Text = employee.PostalCode.ToString();
            personalInfo.txtEmail.Text = employee.EmailAddress.ToString();


            //JOB INFO
            jobInfo.txtFirstName.Text = employee.FirstName;
            jobInfo.txtMI.Text = employee.MiddleInitial;
            jobInfo.txtLastName.Text = employee.LastName;
            jobInfo.dtpBirthDate.Value = employee.DOB;
            jobInfo.txtCellPhone.Text = employee.CellPhoneNumber.ToString();
            jobInfo.txtWorkOhone.Text = employee.WorkPhoneNumber.ToString();
            jobInfo.cboCountry.SelectedIndex = countryIndex;
            jobInfo.cboDepartment.SelectedIndex = departmentIndex;
            jobInfo.txtCity.Text = employee.City.ToString();
            jobInfo.cboStateProvince.SelectedIndex = stateprovinceIndex;
            jobInfo.txtStreetAddress.Text = employee.StreetAddress.ToString();
            jobInfo.txtPostalCode.Text = employee.PostalCode.ToString();
            jobInfo.txtEmail.Text = employee.EmailAddress.ToString();


            jobInfo.txtSIN.Text = employee.SIN.ToString();
            jobInfo.dtpSeniorityDate.Value = employee.SeniorityDate;
            jobInfo.cboDepartment.SelectedItem = employee.DepartmentName.ToString();
            jobInfo.cboSupervisor.SelectedItem = employee.SupervisorName.ToString();
            jobInfo.cboJob.SelectedIndex = jobIndex;
            jobInfo.dtpJobStartDate.Value = employee.JobStartDate;

            //EMPLOYMENT INFO
            employmentInfo.txtFirstName.Text = employee.FirstName;
            employmentInfo.txtMI.Text = employee.MiddleInitial;
            employmentInfo.txtLastName.Text = employee.LastName;
            employmentInfo.dtpBirthDate.Value = employee.DOB;
            employmentInfo.txtCellPhone.Text = employee.CellPhoneNumber.ToString();
            employmentInfo.cboCountry.SelectedIndex = countryIndex;
            employmentInfo.txtCity.Text = employee.City.ToString();
            employmentInfo.cboStateProvince.SelectedIndex = stateprovinceIndex;
            employmentInfo.txtStreetAddress.Text = employee.StreetAddress.ToString();
            employmentInfo.txtPostalCode.Text = employee.PostalCode.ToString();
            employmentInfo.txtEmail.Text = employee.EmailAddress.ToString();

            employmentInfo.txtSIN.Text = employee.SIN.ToString();
            employmentInfo.dtpSeniorityDate.Value = employee.SeniorityDate;
            employmentInfo.cboStatus.SelectedValue = (int)employee.Status;

            if(employee.TerminatedDate != null)
            {
                employmentInfo.lblTerminatedDate.Visible = true;
                employmentInfo.dtpTerminatedDate.Visible = true;
                employmentInfo.dtpTerminatedDate.Enabled = false;
                employmentInfo.dtpTerminatedDate.Value = employee.TerminatedDate.Value;
            }
            else
            {
                employmentInfo.lblTerminatedDate.Visible = false;
                employmentInfo.dtpTerminatedDate.Visible = false;
                employmentInfo.dtpTerminatedDate.Enabled = true;

            }

            if (employee.RetiredDate != null)
            {
                employmentInfo.lblRetiredDate.Visible = true;
                employmentInfo.dtpRetiredDate.Visible = true;
                employmentInfo.dtpRetiredDate.Enabled = false;
                employmentInfo.dtpRetiredDate.Value = employee.RetiredDate.Value;
            }
            else
            {
                employmentInfo.lblRetiredDate.Visible = false;
                employmentInfo.dtpRetiredDate.Visible = false;
                employmentInfo.dtpRetiredDate.Enabled = true;

            }

        }

        private void ResetFields()
        {
            /* txtEmpld.Text = string.Empty;
             txtFullName.Text = string.Empty;
             txtFullAddress.Text = string.Empty;
             txtCellPhone.Text = string.Empty;
             txtWorkOhone.Text = string.Empty;
             txtEmail.Text = string.Empty;*/
        }


        private void dgvMatchingEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rdoEmploymentInfo.Enabled = true;
            rdoJobInfo.Enabled = true;

            EmployeeService employeeService = new EmployeeService();

            if (e.RowIndex >= 0)
            {
                int employeeId = Convert.ToInt32(dgvMatchingEmployees.Rows[e.RowIndex].Cells["EmployeeId"].Value);

                List<Employee> employees = employeeService.GetEmployeesByFilter(employeeId);

                EmployeeDTO employeeDTO = employeeService.GetEmployeeInformation(employees[0].EmployeeId);

                employeeToUpdateId = employeeDTO.EmployeeId;

                PopulateFields(employeeDTO);
                if (LoginData.EmployeeId == employeeDTO.EmployeeId)
                {
                    rdoEmploymentInfo.Enabled = false;
                    rdoJobInfo.Enabled = false;
                    rdoPersonalInfo.Checked = true;
                    personalInfo.BringToFront();
                }
            }


        }

        private void rdoFilter_Click(object sender, EventArgs e)
        {
            if (sender == rdoId) { rdoId.Enabled = false; rdoLn.Enabled = true; }
            if (sender == rdoLn) { rdoId.Enabled = true; rdoLn.Enabled = false; }
            txtFilter.ResetText();
            txtFilter.Focus();
            dgvMatchingEmployees.DataSource = null;
            ResetFields();

        }

        private void cboCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cboCountry = (ComboBox)sender;

            ComboBox stateprovinces = null;

            if (cboCountry == personalInfo.cboCountry)
            {
                stateprovinces = personalInfo.cboStateProvince;
            }
            if (cboCountry == jobInfo.cboCountry)
            {
                stateprovinces = personalInfo.cboStateProvince;
            }
            if (cboCountry == employmentInfo.cboCountry)
            {
                stateprovinces = employmentInfo.cboStateProvince;
            }


            if (cboCountry.SelectedIndex != 0)
            {
                stateprovinces.Enabled = true;
                stateprovinces.DataSource = cboCountry.SelectedValue == "Canada" ? new BindingSource(canadianProvinces, null) : new BindingSource(usStates, null);

                stateprovinces.DisplayMember = "Value";
                stateprovinces.ValueMember = "Value";
            }
            else
            {
                stateprovinces.SelectedValue = 0; ;
                stateprovinces.Enabled = false;
            }
        }

        private void ModifyEmployeeComponent_Load(object sender, EventArgs e)
        {
            rdoId.Checked = true;
            rdoId.Enabled = false;

            #region LoadPersonalInfo
            personalInfo.cboCountry.DataSource = new BindingSource(countries, null);
            personalInfo.cboCountry.DisplayMember = "Value";
            personalInfo.cboCountry.ValueMember = "Value";
            #endregion

            #region LoadJobInfo
            jobInfo.cboSupervisor.SelectedValue = 0; ;

            jobInfo.cboJob.SelectedValue = 0;

            jobInfo.cboCountry.DataSource = new BindingSource(countries, null);
            jobInfo.cboCountry.DisplayMember = "Value";
            jobInfo.cboCountry.ValueMember = "Value";


            var jobs = new JobService().GetJobs();
            jobs.Insert(0, new Job { Id = 0, Name = "Select a job" });
            jobInfo.cboJob.DataSource = jobs;
            jobInfo.cboJob.DisplayMember = "Name";
            jobInfo.cboJob.ValueMember = "Id";
            jobInfo.cboJob.SelectedValue = 0;

            var departments = new DepartmentService().GetDepartmentLookups();
            departments.Insert(0, new DepartmentLookup { Id = 0, Name = "Select a Department" });
            jobInfo.cboDepartment.DataSource = departments;
            jobInfo.cboDepartment.DisplayMember = "Name";
            jobInfo.cboDepartment.ValueMember = "Id";
            jobInfo.cboDepartment.SelectedValue = 0;
            #endregion

            #region LoadEmploymentInfo

            var status = Enum.GetValues(typeof(EmploymentStatus))
               .Cast<EmploymentStatus>()
               .ToDictionary(t => (int)t, t => t.ToString());

            employmentInfo.cboStatus.DataSource = new BindingSource(status, null);
            employmentInfo.cboStatus.DisplayMember = "Value";
            employmentInfo.cboStatus.ValueMember = "Key";

            employmentInfo.cboCountry.DataSource = new BindingSource(countries, null);
            employmentInfo.cboCountry.DisplayMember = "Value";
            employmentInfo.cboCountry.ValueMember = "Value";

            #endregion

            personalInfo.cboCountry.SelectionChangeCommitted += new System.EventHandler(this.cboCountry_SelectionChangeCommitted);
            jobInfo.cboCountry.SelectionChangeCommitted += new System.EventHandler(this.cboCountry_SelectionChangeCommitted);
            employmentInfo.cboCountry.SelectionChangeCommitted += new System.EventHandler(this.cboCountry_SelectionChangeCommitted);


        }

        #region HomeAddressDropdowns
        private readonly Dictionary<int, string> countries = new Dictionary<int, string>
        {
            {0, "SELECT A COUNTRY" },
            { 1, "Canada" },
            {2, "USA" }
        };

        private readonly Dictionary<string, string> usStates = new Dictionary<string, string>
        {
             {"NULL", "SELECT A STATE" },
             { "AL", "Alabama" },
             { "AK", "Alaska" },
             { "AZ", "Arizona" },
             { "AR", "Arkansas" },
             { "CA", "California" },
             { "CO", "Colorado" },
             { "CT", "Connecticut" },
             { "DE", "Delaware" },
             { "DC", "District of Columbia" },
             { "FL", "Florida" },
             { "GA", "Georgia" },
             { "HI", "Hawaii" },
             { "ID", "Idaho" },
             { "IL", "Illinois" },
             { "IN", "Indiana" },
             { "IA", "Iowa" },
             { "KS", "Kansas" },
             { "KY", "Kentucky" },
             { "LA", "Louisiana" },
             { "ME", "Maine" },
             { "MD", "Maryland" },
             { "MA", "Massachusetts" },
             { "MI", "Michigan" },
             { "MN", "Minnesota" },
             { "MS", "Mississippi" },
             { "MO", "Missouri" },
             { "MT", "Montana" },
             { "NE", "Nebraska" },
             { "NV", "Nevada" },
             { "NH", "New Hampshire" },
             { "NJ", "New Jersey" },
             { "NM", "New Mexico" },
             { "NY", "New York" },
             { "NC", "North Carolina" },
             { "ND", "North Dakota" },
             { "OH", "Ohio" },
             { "OK", "Oklahoma" },
             { "OR", "Oregon" },
             { "PA", "Pennsylvania" },
             { "RI", "Rhode Island" },
             { "SC", "South Carolina" },
             { "SD", "South Dakota" },
             { "TN", "Tennessee" },
             { "TX", "Texas" },
             { "UT", "Utah" },
             { "VT", "Vermont" },
             { "VA", "Virginia" },
             { "WA", "Washington" },
             { "WV", "West Virginia" },
             { "WI", "Wisconsin" },
             { "WY", "Wyoming" }
        };

        private readonly Dictionary<string, string> canadianProvinces = new Dictionary<string, string>
        {
            {"NULL", "SELECT A PROVINCE" },
            {"AB", "Alberta"},
            {"BC", "British Columbia"},
            {"MB", "Manitoba"},
            {"NB", "New Brunswick"} ,
            {"NL", "Newfoundland and Labrador"},
            {"NS", "Nova Scotia"},
            {"NT", "Northwest Territories"},
            {"NU", "Nunavut"},
            {"ON", "Ontario"},
            {"PE", "Prince Edward Island"},
            {"QC", "Québec"},
            {"SK", "Saskatchewan"},
            {"YT", "Yukon"}

        };
        #endregion HomeAddressDropdowns

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();

            Employee employee = employeeToUpdate;

            if (rdoPersonalInfo.Checked)
            {
                PopulateEmployeePersonalInfo(employee);
            }
            else if (rdoJobInfo.Checked)
            {
                PopulateEmployeeJobInfo(employee);
            }
            else
            {
                if(employee.Status == EmploymentStatus.Retired)
                {
                    employee.AddError(new Error(employee.Errors.Count() + 1, "A retired employee cannot be modified", "Business"));
                }
                PopulateEmployeeEmploymentInfo(employee);
            }

            if (employeeService.Update(employee))
            {
                MessageBox.Show("Employee Updated", "Update Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string msg = "";

                foreach(Error error in employee.Errors)
                {
                    msg += "Error Description: " + error.Description + "\n";
                }
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void PopulateEmployeePersonalInfo(Employee employee)
        {
            employee.FirstName = personalInfo.txtFirstName.Text;
            employee.MiddleInitial = personalInfo.txtMI.Text;
            employee.LastName = personalInfo.txtLastName.Text;
            employee.DOB = personalInfo.dtpBirthDate.Value.Date;
            employee.Country = personalInfo.cboCountry.SelectedValue.ToString();
            employee.Province = personalInfo.cboStateProvince.Items.Count == 0 ? "" : personalInfo.cboStateProvince.Text.ToString();
            employee.StreetAddress = personalInfo.txtStreetAddress.Text;
            employee.City = personalInfo.txtCity.Text;
            employee.PostalCode = personalInfo.txtPostalCode.Text;
            employee.CellPhoneNumber = personalInfo.txtCellPhone.Text;
            employee.EmailAddress = personalInfo.txtEmail.Text;
        }
        private void PopulateEmployeeJobInfo(Employee employee)
        {
            employee.FirstName = jobInfo.txtFirstName.Text;
            employee.MiddleInitial = jobInfo.txtMI.Text;
            employee.LastName = jobInfo.txtLastName.Text;
            employee.DOB = jobInfo.dtpBirthDate.Value.Date;
            employee.Country = jobInfo.cboCountry.SelectedValue.ToString();
            employee.Province = jobInfo.cboStateProvince.Items.Count == 0 ? "" : jobInfo.cboStateProvince.Text.ToString();
            employee.StreetAddress = jobInfo.txtStreetAddress.Text;
            employee.City = jobInfo.txtCity.Text;
            employee.PostalCode = jobInfo.txtPostalCode.Text;
            employee.CellPhoneNumber = jobInfo.txtCellPhone.Text;
            employee.EmailAddress = jobInfo.txtEmail.Text;

            employee.SIN = jobInfo.txtSIN.Text;
            employee.SeniorityDate = jobInfo.dtpSeniorityDate.Value.Date;
            employee.JobId = Convert.ToInt32(jobInfo.cboJob.SelectedValue);
            employee.JobStartDate = jobInfo.dtpJobStartDate.Value.Date;
            employee.DepartmentId = Convert.ToInt32(jobInfo.cboDepartment.SelectedValue);
            employee.SupervisorId = Convert.ToInt32(jobInfo.cboSupervisor.SelectedValue);
            employee.WorkPhoneNumber = jobInfo.txtWorkOhone.Text;
        } 
        private void PopulateEmployeeEmploymentInfo(Employee employee)
        {
            employee.FirstName = employmentInfo.txtFirstName.Text;
            employee.MiddleInitial = employmentInfo.txtMI.Text;
            employee.LastName = employmentInfo.txtLastName.Text;
            employee.DOB = employmentInfo.dtpBirthDate.Value.Date;
            employee.Country = employmentInfo.cboCountry.SelectedValue.ToString();
            employee.Province = employmentInfo.cboStateProvince.Items.Count == 0 ? "" : personalInfo.cboStateProvince.Text.ToString();
            employee.StreetAddress = employmentInfo.txtStreetAddress.Text;
            employee.City = employmentInfo.txtCity.Text;
            employee.PostalCode = employmentInfo.txtPostalCode.Text;
            employee.CellPhoneNumber = employmentInfo.txtCellPhone.Text;
            employee.EmailAddress = employmentInfo.txtEmail.Text;

            employee.SIN = employmentInfo.txtSIN.Text;
            employee.SeniorityDate = employmentInfo.dtpSeniorityDate.Value.Date;
            employee.Status = (EmploymentStatus)employmentInfo.cboStatus.SelectedValue;
            
            if(employmentInfo.dtpTerminatedDate.Visible == true)
            { 
                employee.TerminatedDate = employmentInfo.dtpTerminatedDate.Value;
            }
            if(employmentInfo.dtpRetiredDate.Visible == true)
            {
                employee.RetiredDate = employmentInfo.dtpRetiredDate.Value;
            }

        }
    }


}

