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
using System.Reflection;
using System.Drawing.Text;

namespace BlueBank.WindowsForm.UI.Component
{
    public partial class SearchEmployeeComponent : UserControl
    {
        public SearchEmployeeComponent()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
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
                //lstEmployeeInfo.DataSource = employeeInfo;
            }
            else
            {
               
                List<EmployeeLookup> employeesLookup = new List<EmployeeLookup>();

                foreach(Employee employee in employees)
                {
                    EmployeeLookup employeeLookup = new EmployeeLookup(employee.EmployeeId, $"{employee.FirstName}, {employee.LastName}");
        
                    employeesLookup.Add(employeeLookup);
                }

                dgvMatchingEmployees.DataSource = employeesLookup;



            }
        }

        private void PopulateFields(EmployeeDTO employee)
        {
            string fullName = string.IsNullOrEmpty(employee.MiddleInitial) ? $"{employee.FirstName}, {employee.LastName}" : $"{employee.FirstName}, {employee.MiddleInitial}, {employee.FirstName}";

            txtEmpld.Text = $"{employee.EmployeeId}";
            txtFullName.Text = $"{fullName} ";
            txtFullAddress.Text = $"{employee.StreetAddress} {employee.City}\n {employee.Province} {employee.PostalCode}, {employee.Country}";
            txtCellPhone.Text = $"{employee.CellPhoneNumber}";
            txtWorkOhone.Text = $"{employee.WorkPhoneNumber}";
            txtEmail.Text = $"{employee.EmailAddress}";
        }

        private void ResetFields()
        {
            txtEmpld.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtFullAddress.Text = string.Empty;
            txtCellPhone.Text = string.Empty;
            txtWorkOhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
    

        private void dgvMatchingEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();
            
            if(e.RowIndex >= 0)
            {
                int employeeId = Convert.ToInt32(dgvMatchingEmployees.Rows[e.RowIndex].Cells["EmployeeId"].Value);

                List<Employee> employees = employeeService.GetEmployeesByFilter(employeeId);

                EmployeeDTO employeeDTO = employeeService.GetEmployeeInformation(employees[0].EmployeeId);

                PopulateFields(employeeDTO);
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

        private void SearchEmployeeComponent_Load(object sender, EventArgs e)
        {
            rdoId.Checked = true;
            rdoId.Enabled = false;
        }
    }
}
