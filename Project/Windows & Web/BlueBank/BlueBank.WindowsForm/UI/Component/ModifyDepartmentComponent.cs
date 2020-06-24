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
    public partial class ModifyDepartmentComponent : UserControl
    {
        Department departmentToUpdate = null;

        public ModifyDepartmentComponent()
        {
            InitializeComponent();


            if (LoginData.EmployeeType != EmployeeType.HREmployee && LoginData.EmployeeType != EmployeeType.HRSupervisor && LoginData.EmployeeType != EmployeeType.RegularSupervisor)
            {
                panel1.Hide();
                Label label = new Label()
                {
                    Text = "Only HR Employees and Regular Supervisors can Access this page.".ToUpper(),
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

            if(LoginData.EmployeeType == EmployeeType.RegularSupervisor)
            {
                dgvDepartments.Visible = false;
                panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
                txtName.Visible = false;
                dtpInvocationDate.Visible = false;
                label1.Visible = false;
                label3.Visible = false;

            }
            else
            {
                var departments = new DepartmentService().GetDepartmentLookups();

                dgvDepartments.DataSource = departments;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DepartmentService departmentService = new DepartmentService();
           

            //Department department = new Department(txtName.Text, txtDescription.Text, dtpInvocationDate.Value);
            //if (dgvDepartments.Visible == true)
            //{
            //    department.DepartmentId = Convert.ToInt32(dgvDepartments.CurrentRow.Cells["Id"].FormattedValue);

            //}
            //else
            //{
            //    department.DepartmentId = new DepartmentService().GetDepartment(LoginData.EmployeeId).DepartmentId;

            //}
            string message = "";

            if (departmentService.UpdateDepartment(departmentToUpdate))
            {
                MessageBox.Show("Update Succesful", "Department Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var departments = new DepartmentService().GetDepartmentLookups();

                dgvDepartments.DataSource = departments;

            }
            else
            {
                foreach (Error error in departmentToUpdate.Errors)
                {
                    message += $"Error Code : {error.Code:000}\n Description: {error.Description}\n\n";
                }

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ModifyDepartmentComponent_Load(object sender, EventArgs e)
        {
            if (LoginData.EmployeeType == EmployeeType.RegularSupervisor)
            {
                departmentToUpdate = new DepartmentService().GetDepartment(LoginData.EmployeeId);
                txtDescription.Text = departmentToUpdate.Description;
                txtName.Text = departmentToUpdate.Name;
                dtpInvocationDate.Value = departmentToUpdate.InvocationDate;
            }
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                departmentToUpdate = new DepartmentService().GetDepartmentById(Convert.ToInt32(dgvDepartments["Id", e.RowIndex].Value));
                txtDescription.Text = departmentToUpdate.Description;
                txtName.Text = departmentToUpdate.Name;
                dtpInvocationDate.Value = departmentToUpdate.InvocationDate;
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DepartmentService departmentService = new DepartmentService();

            if (departmentService.DeleteDepartment(departmentToUpdate))
            {
                MessageBox.Show("Department Deleted");
            }
            else
            {
                string msg = "";

                foreach(Error error in departmentToUpdate.Errors)
                {
                    msg += error.Description + "\n";
                }
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
