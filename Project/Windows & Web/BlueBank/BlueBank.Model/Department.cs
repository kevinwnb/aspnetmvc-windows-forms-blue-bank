using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class Department : Base
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="Department name cannot exceed 30 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Department name cannot exceed 255 characters")]
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime InvocationDate { get; set; }

        public int SupervisorId { get; set; }

        public byte[] TimeStamp { get; set; }

        public Department() { }
        public Department(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public Department(string name, string description, DateTime invocationDate)
        {
            this.Name = name;
            this.Description = description;
            this.InvocationDate = invocationDate;
        }
    }
}
