using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBank.WebFrontEnd.Models
{
    public class LoginLoginDTOVM
    {
        public LoginLoginDTOVM()
        {

        }

        public LoginLoginDTOVM(Login login, LoginDTO loginDTO)
        {
            this.login = login;
            this.loginDTO = loginDTO;
        }

        public Login login = new Login();
        public LoginDTO loginDTO = new LoginDTO();
    }
}