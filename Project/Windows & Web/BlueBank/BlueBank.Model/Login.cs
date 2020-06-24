using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlueBank.Model
{
    public class Login : Base
    {
        [Required(ErrorMessage = "Employee Id is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Login()
        {

        }

        public Login(int employeeId, string password)
        {
            this.EmployeeId = employeeId;
            this.Password = password;
        }
    }
}
