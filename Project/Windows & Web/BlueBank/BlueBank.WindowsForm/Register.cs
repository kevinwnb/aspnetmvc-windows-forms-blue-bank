using BlueBank.Model;
using BlueBank.Service;
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public string Md5hash(byte[] value)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(value);

                return Convert.ToBase64String(hash);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtPassword.Text == txtReEnter.Text)
                {
                    LoginService loginService = new LoginService();
                    Login login = new Login();
                    login.EmployeeId = Convert.ToInt32(txtEmpId.Text);
                    byte[] passtohash = System.Text.Encoding.UTF8.GetBytes(txtPassword.Text.ToString());
                    login.Password = Md5hash(passtohash);
                    if (loginService.Create(login))
                    {
                        MessageBox.Show("Your account is created");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
