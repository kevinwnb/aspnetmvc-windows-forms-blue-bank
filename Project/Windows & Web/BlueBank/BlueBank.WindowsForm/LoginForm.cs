using BlueBank.Model;
using BlueBank.Service;
using BlueBank.WindowsForm.UI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBank.WindowsForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            LoginService loginService = new LoginService();

            if(txtEmpId.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                lblError.Text = "Employee Id and Password are required";
                return;
            }
            if(!int.TryParse(txtEmpId.Text, out int id))
            {
                lblError.Text += "Please enter a correct 8 digits Employee Id";
                return;
            }

         

            byte[] passtohash = System.Text.Encoding.UTF8.GetBytes(txtPassword.Text.ToString());

            Login login = new Login()
            {
                EmployeeId = Convert.ToInt32(txtEmpId.Text),
                Password = Md5hash(passtohash)
            };

            LoginDTO loginDTO = loginService.GetLoginInformation(login);

            if (loginDTO.Status != EmploymentStatus.Active)
            {
                lblError.Text += "Employee is not active";
                return;
            }

            if (loginDTO == null)
            {
                lblError.Text = "Employee Id or Password not correct. Please Try again";
            }
            else
            {
                LoginData.EmployeeId = loginDTO.EmployeeId;
                LoginData.EmployeeType = loginDTO.EmployeeType;
                LoginData.EmployeeName = loginDTO.EmployeeName;
                LoginData.Department = loginDTO.Department;
                DialogResult = DialogResult.OK;
            }


        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private string Md5hash(byte[] value)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(value);

                return Convert.ToBase64String(hash);
            }
        }


    }
}
