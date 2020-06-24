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
    public partial class CreateDepartmentComponent : UserControl
    {
        public CreateDepartmentComponent()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DepartmentService departmentService = new DepartmentService();

            Department department = new Department(txtName.Text, txtDescription.Text, dtpInvocationDate.Value);

            string message = "";

            if (departmentService.CreateDepartment(department))
            {
                //message += $"Department Id: {department.DepartmentId} \n";
                message += $"Name: {department.Name}\n";
                message += $"Description: {department.Description}";

                MessageBox.Show(message, "Department Created", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                foreach (Error error in department.Errors)
                {
                    message += $"Error Code : {error.Code:000}\n Description: {error.Description}\n\n";
                }

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
