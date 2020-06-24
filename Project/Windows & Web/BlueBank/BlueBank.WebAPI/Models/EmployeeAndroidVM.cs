using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBank.WebAPI.Models
{
    public class EmployeeAndroidVM
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        public string LastName { get; set; }

        public string JobPosition { get; set; }

        public string OfficeLocation { get; set; }

        public string EmailAddress { get; set; }

        public string WorkPhoneNumber { get; set; }

        public string FullName { get { return (MiddleInitial == "NULL" || MiddleInitial == string.Empty) ?
                    FirstName + " " + LastName : FirstName + " " + MiddleInitial + " " + LastName  ; } }
    }
}