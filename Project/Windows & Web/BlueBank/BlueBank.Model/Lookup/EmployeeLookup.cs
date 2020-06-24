using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class EmployeeLookup
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public EmployeeLookup() { }

        public EmployeeLookup(int employeeId, string employeeName)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
        }
    }
}
