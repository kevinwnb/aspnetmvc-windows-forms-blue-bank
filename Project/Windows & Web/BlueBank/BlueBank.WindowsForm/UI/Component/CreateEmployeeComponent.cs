using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlueBank.Service;
using BlueBank.Model;

namespace BlueBank.WindowsForm.UI.Component
{
    public partial class CreateEmployeeComponent : UserControl
    {
        public CreateEmployeeComponent()
        {
            InitializeComponent();

            if (LoginData.EmployeeType != EmployeeType.HREmployee && LoginData.EmployeeType != EmployeeType.HRSupervisor)
            {
                panel1.Hide();
                Label label = new Label()
                {
                    Text = "Only HR Employees can Access this page.".ToUpper(),
                    ForeColor = Color.DarkRed,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    Font = new Font(new FontFamily("Segoe UI"), 40, FontStyle.Underline),
                    TextAlign = ContentAlignment.MiddleCenter,


                };
                this.Controls.Clear();
                label.BringToFront();
                this.Controls.Add(label);

            }
        }

        private void CreateEmployee_Load(object sender, EventArgs e)
        {
            cboSupervisor.SelectedValue = 0; ;
            cboSupervisor.Enabled = false;

            cboJob.SelectedValue = 0;
            cboJob.Enabled = false;

            dtpJobStartDate.Value = dtpSeniorityDate.Value;
            dtpJobStartDate.Enabled = false;

            //Add PlaceHolders

            AddPlaceHolder(txtPostalCode, "XXX XXX");
            AddPlaceHolder(txtEmail, "someone@gmail.com");
            AddPlaceHolder(txtSIN, "XXX-XXX-XXX");
            AddPlaceHolder(txtCellPhone, "(XXX) XXX-XXXX");
            AddPlaceHolder(txtWorkPhone, "(XXX) XXX-XXXX");


            rdoRegular.Checked = true;

            cboCountry.DataSource = new BindingSource(countries, null);
            cboCountry.DisplayMember = "Value";
            cboCountry.ValueMember = "Value";

            cboStateProvince.Enabled = false;

            var jobs = new JobService().GetJobs();
            jobs.Insert(0, new Job { Id = 0, Name = "Select a job" });
            cboJob.DataSource = jobs;
            cboJob.DisplayMember = "Name";
            cboJob.ValueMember = "Id";
            cboJob.SelectedValue = 0;

            var departments = new DepartmentService().GetDepartmentLookups();
            departments.Insert(0, new DepartmentLookup { Id = 0, Name = "Select a Department" });
            cboDepartment.DataSource = departments;
            cboDepartment.DisplayMember = "Name";
            cboDepartment.ValueMember = "Id";
            cboDepartment.SelectedValue = 0;




        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();

            Employee employee = new Employee();

            employee.FirstName = txtFirstName.Text;
            if(txtMI.Text.Trim() != "")
            {
                employee.MiddleInitial = txtMI.Text.Trim();

            }
            employee.LastName = txtLastName.Text;
            employee.DOB = dtpBirthDate.Value.Date;
            employee.Country = cboCountry.SelectedValue.ToString();
            employee.Province = cboStateProvince.Items.Count == 0 ? "" : cboStateProvince.SelectedValue.ToString();
            employee.StreetAddress = txtStreetAddress.Text;
            employee.City = txtCity.Text;
            employee.PostalCode = txtPostalCode.Text;
            employee.CellPhoneNumber = txtCellPhone.Text;
            employee.EmailAddress = txtEmail.Text;
            employee.EmployeeType = rdoRegular.Checked ? EmployeeType.RegularEmployee : EmployeeType.HREmployee;
            employee.SIN = txtSIN.Text;
            employee.SeniorityDate = dtpSeniorityDate.Value.Date;
            employee.JobId = Convert.ToInt32(cboJob.SelectedValue);
            employee.JobStartDate = dtpJobStartDate.Value.Date;
            employee.DepartmentId = Convert.ToInt32(cboDepartment.SelectedValue);
            employee.SupervisorId = Convert.ToInt32(cboSupervisor.SelectedValue);
            employee.WorkPhoneNumber = txtWorkPhone.Text;
            employee.Status = EmploymentStatus.Active;
            if (employeeService.NeedsNewSupervisor(employee))
            {
                employee.AddError(new Error(employee.Errors.Count() + 1, $"{cboSupervisor.Text} has already 10 employee. Please select another supervisor", "Buisiness"));
            }

            string message = "";

            if (employeeService.Create(employee))
            {
                if(employee.SupervisorId == 0)
                {
                    employeeService.SetEmployeeSupervisor(employee);
                }
                message = $"Employee created succesfuly\n EmployeeId: {employee.EmployeeId}";
                MessageBox.Show(message, "Employee Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFields();
            }
            else
            {
                foreach (Error error in employee.Errors.OrderBy(err => err.Type))
                {

                    message += $"Error Code : {error.Code:000}\nDescription: {error.Description}\n\n";
                }

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cboDepartment.SelectedValue != 0)
            {
                cboSupervisor.Enabled = true;
                cboJob.Enabled = true;
                dtpJobStartDate.Enabled = true;

                EmployeeService employeeService = new EmployeeService();

                int departmentId = Convert.ToInt32(cboDepartment.SelectedValue.ToString());
                /*
                                if (employeeService.IsNewSupervisor(departmentId))
                                {
                                    cboSupervisor.SelectedValue = 0;
                                    cboSupervisor.Visible = false;
                                }*/
                var supervisors = employeeService.GetSupervisorsByDepartment(departmentId, employeeType: rdoHR.Checked ? 3 : 4);
                supervisors.Insert(0, new SupervisorLookup { EmployeeId = 0, FullName = "Select a Supervisor" });
                cboSupervisor.DataSource = supervisors;
                cboSupervisor.DisplayMember = "FullName";
                cboSupervisor.ValueMember = "EmployeeId";
                cboSupervisor.SelectedValue = 0;

            }
            else
            {
                cboSupervisor.SelectedValue = 0; ;
                cboSupervisor.Enabled = false;

                cboJob.SelectedValue = 0;
                cboJob.Enabled = false;

                dtpJobStartDate.Value = dtpSeniorityDate.Value;
                dtpJobStartDate.Enabled = false;
            }

        }


        private void cboCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboCountry.SelectedIndex != 0)
            {
                cboStateProvince.Enabled = true;
                cboStateProvince.DataSource = cboCountry.SelectedValue == "Canada" ? new BindingSource(canadianProvinces, null) : new BindingSource(usStates, null);

                cboStateProvince.DisplayMember = "Value";
                cboStateProvince.ValueMember = "Value";
            }
            else
            {
                cboStateProvince.SelectedValue = 0; ;
                cboStateProvince.Enabled = false;
            }
        }

        private void AddPlaceHolder(TextBox t, string value)
        {
            t.Text = value;
            t.ForeColor = Color.Gray;
        }

        private void PlaceHolderText_Enter(object sender, EventArgs e)
        {

            string[] placeholders = { "XXX XXX", "(XXX) XXX-XXXX", "XXX-XXX-XXX", "someone@gmail.com" };

            TextBox[] placeholerTextBoxes = { txtCellPhone, txtWorkPhone, txtSIN, txtPostalCode, txtEmail };

            foreach (TextBox placeholderTextBox in placeholerTextBoxes)
            {
                foreach (string placeholder in placeholders)
                {
                    if (this.ActiveControl == placeholderTextBox && placeholderTextBox.Text == placeholder)
                    {
                        placeholderTextBox.Text = "";
                        placeholderTextBox.ForeColor = Color.Black;
                    }
                }
            }

        }

        private void PlaceHolderText_Leave(object sender, EventArgs e)
        {

            TextBox[] placeholerTextBoxes = { txtCellPhone, txtWorkPhone, txtSIN, txtPostalCode, txtEmail };

            foreach (TextBox placeholderTextBox in placeholerTextBoxes)
            {

                if (placeholderTextBox.Text == "")
                {
                    switch (placeholderTextBox.Name)
                    {
                        case "txtCellPhone":
                        case "txtWorkPhone":
                            placeholderTextBox.Text = "(XXX) XXX-XXXX";
                            placeholderTextBox.ForeColor = Color.Gray;

                            break;
                        case "txtSIN":
                            placeholderTextBox.Text = "XXX-XXX-XXX";
                            placeholderTextBox.ForeColor = Color.Gray;
                            break;
                        case "txtPostalCode":
                            placeholderTextBox.Text = "XXX XXX";
                            placeholderTextBox.ForeColor = Color.Gray;
                            break;
                        case "txtEmail":
                            placeholderTextBox.Text = "someone@gmail.com";
                            placeholderTextBox.ForeColor = Color.Gray;
                            break;
                    }

                    this.ActiveControl = null;

                }
            }

        }


        private void JobSeniorityDate_ValueChanged(object sender, EventArgs e)
        {
            if (sender == dtpSeniorityDate) dtpJobStartDate.Value = dtpSeniorityDate.Value;
            if (sender == dtpJobStartDate) dtpSeniorityDate.Value = dtpJobStartDate.Value;
        }

        private void ResetFields()
        {
            txtLastName.Text = string.Empty;
            txtMI.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            dtpBirthDate.Value = DateTime.Now;
            cboCountry.SelectedValue = 0;
            cboStateProvince.SelectedValue = 0;
            txtStreetAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtCellPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;

            txtSIN.Text = string.Empty;
            dtpSeniorityDate.Value = DateTime.Now;
            cboDepartment.SelectedValue = 0;
            cboSupervisor.SelectedValue = 0;
            cboJob.SelectedValue = 0;
            dtpJobStartDate.Value = DateTime.Now;
            txtWorkPhone.Text = string.Empty;

            chkIsActive.Checked = false;
            rdoRegular.Checked = true;

            AddPlaceHolder(txtPostalCode, "XXX XXX");
            AddPlaceHolder(txtEmail, "someone@gmail.com");
            AddPlaceHolder(txtSIN, "XXX-XXX-XXX");
            AddPlaceHolder(txtCellPhone, "(XXX) XXX-XXXX");
            AddPlaceHolder(txtWorkPhone, "(XXX) XXX-XXXX");
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

        private void rdoType_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();
            int departmentId = Convert.ToInt32(cboDepartment.SelectedValue.ToString());
            int employeeType = sender == rdoHR ? 3 : 4;
            var supervisors = employeeService.GetSupervisorsByDepartment(departmentId, employeeType);
            supervisors.Insert(0, new SupervisorLookup { EmployeeId = 0, FullName = "Select a Supervisor" });
            cboSupervisor.DataSource = supervisors;
            cboSupervisor.DisplayMember = "FullName";
            cboSupervisor.ValueMember = "EmployeeId";
            cboSupervisor.SelectedValue = 0;
        }
    }
}
