using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBank.WebFrontEnd.Models
{
    public class ReviewVM
    {
        public string EmployeeFullName { get; set; }
        public string SupervisorFullName { get; set; }
        public int Quarter { get; set; }

        public Review review { get; set; }
    }
}