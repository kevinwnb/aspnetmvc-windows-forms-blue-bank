using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBank.Model;
using BlueBank.Repository;

namespace BlueBank.Service
{
    public class LoginService
    {
        private LoginRepository repo = new LoginRepository();
        //public LoginDTO GetLoginInformation(Login login)
        //{
        //    return repo.GetLoginInformation(login);
        //}

        public LoginDTO GetLoginInformation(Login login)
        {
            return IsValid(login) ? repo.GetLoginInformation(login) : null;
        }

        public bool Create(Login login)
        {
            return repo.Create(login);
        }

        private bool IsValidEntity(Login login)
        {
            ValidationContext context = new ValidationContext(login);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(login, context, results, true);

            foreach (ValidationResult r in results)
            {
                login.AddError(new Error(login.Errors.Count, r.ErrorMessage, "Model"));
            }

            return isValid;
        }

        private bool IsValid(Login login)
        {
            return IsValidEntity(login);
        }
    }
}
