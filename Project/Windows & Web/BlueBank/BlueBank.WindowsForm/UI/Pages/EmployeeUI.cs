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
using BlueBank.WindowsForm.UI.Component;

namespace BlueBank.WindowsForm.UI.Pages
{
    public partial class EmployeeUI : PageControl
    {
        public EmployeeUI()
        {
            InitializeComponent();

            createEmployee = new CreateEmployeeComponent()
            {
                Dock = DockStyle.Fill,
            };

            searchEmployee = new SearchEmployeeComponent()
            {
                Dock = DockStyle.Fill,
            };

            modifyEmployee = new ModifyEmployeeComponent()
            {
                Dock = DockStyle.Fill,
            };

            if (LoginData.EmployeeType != EmployeeType.HREmployee && LoginData.EmployeeType != EmployeeType.HRSupervisor)
            {
                panel2.Hide();
                Label label = new Label()
                {
                    Text = "Only HR Employees can Access this page.".ToUpper(),
                    ForeColor = Color.DarkRed,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    Font = new Font(new FontFamily("Segoe UI"), 40, FontStyle.Underline),
                    TextAlign = ContentAlignment.MiddleCenter,
                    

                };
                panel3.Controls.Add(label);

            }
            else
            {
                panel3.Controls.Add(createEmployee);
                panel3.Controls.Add(searchEmployee);
                panel3.Controls.Add(modifyEmployee);
            }



        }

        public static EmployeeUI _instance;

        public static EmployeeUI Instance
        {
            get
            {
                if (_instance == null || _instance.HasBeenClosed)
                {
                    _instance = new EmployeeUI();
                    _instance.Position = 0;
                }

                return _instance;
            }
        }

        CreateEmployeeComponent createEmployee = null;
        SearchEmployeeComponent searchEmployee = null;
        ModifyEmployeeComponent modifyEmployee = null;

        private void btnClose_Click(object sender, EventArgs e)
        {
            _instance.Close();
        }


        private void rdoAction_Click(object sender, EventArgs e)
        {
            if (sender == rdoCreate) createEmployee.BringToFront();
            createEmployee.Dock = DockStyle.Fill;

            if (sender == rdoSearch) searchEmployee.BringToFront();
            searchEmployee.Dock = DockStyle.Fill;

            if (sender == rdoModify) modifyEmployee.BringToFront();
        }

        private void EmployeeUI_Load(object sender, EventArgs e)
        {


            createEmployee.BringToFront();

        }
    }
}
