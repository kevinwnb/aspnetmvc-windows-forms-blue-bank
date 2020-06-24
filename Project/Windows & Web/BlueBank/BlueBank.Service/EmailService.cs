using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Service
{
    public class EmailService
    {
        private string GetDestinator(Employee destinator)
        {
            return destinator.EmailAddress;
        }

        private bool IsValid(Email email)
        {
            email.Errors = new List<Error>();
            ValidationContext context = new ValidationContext(email);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(email, context, results, true);

            foreach (ValidationResult r in results)
            {
                email.AddError(new Error(email.Errors.Count, r.ErrorMessage, "Model"));
            }

            return isValid;
        }

        public bool SendEmail(Email email)
        {
            if (IsValid(email))
            {
                SmtpClient smtp = new SmtpClient();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email.SenderAddress);
                mail.To.Add(new MailAddress(email.ReceiverAddress));
                mail.Subject = email.Subject;
                mail.Body = email.Body;

                //smtp.Port = 587;
                smtp.Port = 25;
                //smtp.Host = "smtp.gmail.com";
                smtp.Host = "192.168.2.17";
                //smtp.Credentials = new NetworkCredential(email.SenderAddress, "Secret1234$@");
                //smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }

            return false;
        }
    }
}
