using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class LoginDTO : Base
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public EmploymentStatus Status { get; set; }
        public string Department { get; set; }

        public LoginDTO()
        {

        }

        public LoginDTO(int employeeId, string employeeName, EmployeeType employeeType, EmploymentStatus status, string department)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            EmployeeType = employeeType;
            Status = status;
            Department = department;
        }
    }
}
