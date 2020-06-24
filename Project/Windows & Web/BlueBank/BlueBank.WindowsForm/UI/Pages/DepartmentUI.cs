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
using BlueBank.WindowsForm.UI.Component;

namespace BlueBank.WindowsForm.UI.Pages
{
    public partial class DepartmentUI : PageControl
    {
        public DepartmentUI()
        {
            InitializeComponent();

            createDepartment = new CreateDepartmentComponent()
            {
                Dock = DockStyle.Fill,
            };


            modifyDepartment = new ModifyDepartmentComponent()
            {
                Dock = DockStyle.Fill,
            };


            panel2.Controls.Add(createDepartment);
            panel2.Controls.Add(modifyDepartment);
            createDepartment.BringToFront();

        }

        public static DepartmentUI _instance;

        CreateDepartmentComponent createDepartment = new CreateDepartmentComponent();
        ModifyDepartmentComponent modifyDepartment = new ModifyDepartmentComponent();

        public static DepartmentUI Instance
        {
            get
            {
                if (_instance == null || _instance.HasBeenClosed)
                {
                    _instance = new DepartmentUI();
                    _instance.Position = 0;
                }

                return _instance;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _instance.Close();
        }

        private void rdoAction_Click(object sender, EventArgs e)
        {
            if (sender == rdoCreate) createDepartment.BringToFront();

            if (sender == rdoModify) modifyDepartment.BringToFront();
        }

        //private void btnCreate_Click(object sender, EventArgs e)
        //{
        //    DepartmentService departmentService = new DepartmentService();

        //    Department department = new Department(txtName.Text, txtDescription.Text, dtpInvocationDate.Value);

        //    string message = "";

        //    if (departmentService.CreateDepartment(department))
        //    {
        //        //message += $"Department Id: {department.DepartmentId} \n";
        //        message += $"Name: {department.Name}\n";
        //        message += $"Description: {department.Description}";

        //        MessageBox.Show(message, "Department Created", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //    }
        //    else
        //    {
        //        foreach (Error error in department.Errors)
        //        {
        //            message += $"Error Code : {error.Code:000}\n Description: {error.Description}\n\n";
        //        }

        //        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //}
    }
}
