using BlueBank.Model;
using BlueBank.WindowsForm.UI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBank.WindowsForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        internal int selectedPageIndex;
        internal List<PageControl> list = new List<PageControl>();
        private int formerPagePosistion;



        private void MainForm_Load(object sender, EventArgs e)
        {
            SidePanel.Height = 0;

            SplashScreen splash = new SplashScreen();
            LoginForm login = new LoginForm();

            splash.ShowDialog();

            login.ShowDialog();

            if (login.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.lblDepartment.Text = LoginData.Department;
                this.lblName.Text = LoginData.EmployeeName;
                switch (LoginData.EmployeeType)
                {
                    case EmployeeType.HREmployee:
                        this.lblType.Text = "HR Employee";
                        break;

                    case EmployeeType.HRSupervisor:
                        this.lblType.Text = "HR Supervisor";
                        break;

                    case EmployeeType.RegularEmployee:
                        this.lblType.Text = "Regular Employee";
                        break;

                    case EmployeeType.RegularSupervisor:
                        this.lblType.Text = "Regular Supervisor";
                        break;
                }

                this.Show();
            }
        }

        #region TabMethods
        public void DisplayPage(Panel panel, PageControl page)
        {

            list = panel2.Controls.OfType<PageControl>().ToList().OrderBy(pa => pa.Position).ToList();

            if (!panel.Contains(page))
            {
                panel2.Controls.Add(page);
            }

            page.Dock = DockStyle.Fill;
            page.BringToFront();
        }


        public void ChangeSelectedPage()
        {

            if (selectedPageIndex > list.Count - 1)
            {
                selectedPageIndex--;

            }
            int previousPageIndex;
            int nextPageIndex;
            switch (selectedPageIndex)
            {

                case 0:

                    nextPageIndex = selectedPageIndex;
                    previousPageIndex = selectedPageIndex - 1;
                    DetermineNextTab(panel2, nextPageIndex, previousPageIndex);
                    break;

                case 1:
                    nextPageIndex = selectedPageIndex;
                    previousPageIndex = selectedPageIndex - 1;
                    DetermineNextTab(panel2, previousPageIndex, nextPageIndex);
                    break;

                case 2:
                    nextPageIndex = selectedPageIndex;
                    previousPageIndex = selectedPageIndex - 1;
                    DetermineNextTab(panel2, previousPageIndex, nextPageIndex);

                    break;

                case 3:
                    nextPageIndex = selectedPageIndex;
                    previousPageIndex = selectedPageIndex - 1;
                    DetermineNextTab(panel2, previousPageIndex, nextPageIndex);
                    break;


                default:
                    nextPageIndex = 0;
                    previousPageIndex = selectedPageIndex - 1;
                    DetermineNextTab(panel2, nextPageIndex, previousPageIndex);

                    break;
            }


        }

        private void DetermineNextTab(Panel panel, int tabOne, int tabTwo)
        {
            list = panel2.Controls.OfType<PageControl>().ToList().OrderBy(pa => pa.Position).ToList();

            if (panel.Controls.OfType<PageControl>().Count() > 0)
            {

                if (panel.Controls.Contains(list[tabOne]))
                {
                    DisplayPage(panel, list[tabOne]);
                }
                else if (panel.Controls.Contains(list[tabTwo]))
                {
                    DisplayPage(panel, list[tabTwo]);
                }

            }

        }


        #endregion TabMethods

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnDepartment.Height;
            SidePanel.Top = btnDepartment.Top;

            formerPagePosistion = 0;
            DisplayPage(panel2, DepartmentUI.Instance);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnEmployee.Height;
            SidePanel.Top = btnEmployee.Top;

            formerPagePosistion = 0;
            DisplayPage(panel2, EmployeeUI.Instance);
        }

        private void btnCreatePo_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCreatePo.Height;
            SidePanel.Top = btnCreatePo.Top;

            formerPagePosistion = 0;
            DisplayPage(panel2, UI.Pages.CreatePO.Instance);
        }

        private void btnModifyPo_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnModifyPo.Height;
            SidePanel.Top = btnModifyPo.Top;

            formerPagePosistion = 0;
            DisplayPage(panel2, UI.Pages.ModifyPO.Instance);
        }

        private void btnProcessPO_Click(object sender, EventArgs e)
        {
            if (LoginData.EmployeeType == EmployeeType.RegularSupervisor || LoginData.EmployeeType == EmployeeType.HRSupervisor)
            {
                SidePanel.Height = btnProcessPO.Height;
                SidePanel.Top = btnProcessPO.Top;

                formerPagePosistion = 0;
                DisplayPage(panel2, UI.Pages.ProcessPO.Instance);
            }
            else
            {
                MessageBox.Show("This section is only for supervisors", "Only Supervisors", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBrowsePO_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnBrowsePO.Height;
            SidePanel.Top = btnBrowsePO.Top;

            formerPagePosistion = 0;
            DisplayPage(panel2, UI.Pages.BrowsePO.Instance);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //LoginData.EmployeeId = 0;
            //LoginData.EmployeeType = (EmployeeType)0;
            //LoginData.EmployeeName = null;
            //LoginData.Department = null;
            //LoginForm loginForm = new LoginForm();
            //this.Hide();

            //loginForm.ShowDialog();

            //if (loginForm.DialogResult == DialogResult.OK)
            //{
            //    this.lblDepartment.Text = LoginData.Department;
            //    this.lblName.Text = LoginData.EmployeeName;
            //    switch (LoginData.EmployeeType)
            //    {
            //        case EmployeeType.HREmployee:
            //            this.lblType.Text = "HR Employee";
            //            break;

            //        case EmployeeType.HRSupervisor:
            //            this.lblType.Text = "HR Supervisor";
            //            break;

            //        case EmployeeType.RegularEmployee:
            //            this.lblType.Text = "Regular Employee";
            //            break;

            //        case EmployeeType.RegularSupervisor:
            //            this.lblType.Text = "Regular Supervisor";
            //            break;
            //    }

            //    this.Show();
            //}

            //var mainForm = new Thread(() => Application.Run(new MainForm()));
            //mainForm.Start();
            //this.Close();

            Application.Restart();
        }
    }
}
