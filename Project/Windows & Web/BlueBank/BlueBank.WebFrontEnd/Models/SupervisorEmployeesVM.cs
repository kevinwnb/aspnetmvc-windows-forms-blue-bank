using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBank.WebFrontEnd.Models
{
    public class SupervisorEmployeesVM
    {
        public string SupervisorFullName { get; set; }

        public List<Employee> employees { get; set; }
    }
}