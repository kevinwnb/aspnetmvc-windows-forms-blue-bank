using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class EmployeeDTO
    {
		[Display(Name = "Employee Id")]
		public int EmployeeId { get; set; }

		[Required]
		[Display(Name = "SIN")]
		[RegularExpression("^(\\d{3}-\\d{3}-\\d{3})|(\\d{9})$", ErrorMessage = "SIN is not valid format")]
		public string SIN { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		[StringLength(50, ErrorMessage = "Last Name length cannot exceed 50 characters")]
		public string LastName { get; set; }

		[Display(Name = "Middle Initial")]
		[StringLength(1, ErrorMessage = "Middle Initial must be one character if provided")]
		public string MiddleInitial { get; set; }

		[Required]
		[Display(Name = "First Name")]
		[StringLength(50, ErrorMessage = "First Name cannot length exceed 50 characters")]
		public string FirstName { get; set; }

		[Display(Name = "Birth Date")]
		[DataType(DataType.DateTime)]
		public DateTime DOB { get; set; }

		[Display(Name = "Country")]
		[Required(ErrorMessage = "You must select a country")]
		public string Country { get; set; }

		[Display(Name = "Province")]
		[Required(ErrorMessage = "You must select a province")]
		public string Province { get; set; }

		[Display(Name = "Street Address")]
		[Required]
		public string StreetAddress { get; set; }

		[Display(Name = "City")]
		[Required]
		public string City { get; set; }

		[Display(Name = "Postal Code")]
		[Required]
		[RegularExpression("^[A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d$", ErrorMessage = "Please enter a valid postal code")]
		public string PostalCode { get; set; }

		[Display(Name = "Seniority Date")]
		public DateTime SeniorityDate { get; set; }

		[Display(Name = "Work Phone N°")]
		[Phone(ErrorMessage = "Please enter a valid work phone number")]
		public string WorkPhoneNumber { get; set; }

		[Display(Name = "Cell Phone N°")]
		[Phone(ErrorMessage = "Please enter a valid cell phone number")]
		public string CellPhoneNumber { get; set; }

		[Display(Name = "Email Address")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address")]
		public string EmailAddress { get; set; }

		[Display(Name = "Department")]
		[Required(ErrorMessage = "Please select a department")]
		[Range(1, double.MaxValue, ErrorMessage = "Please select a department")]
		public string DepartmentName { get; set; }

		[Display(Name = "Employee Type")]
		[Required(ErrorMessage = "Please select an employee type")]
		public EmployeeType EmployeeType { get; set; }

		[Display(Name = "Supervisor")]
		public string SupervisorName { get; set; }

		[Display(Name = "Job Position")]
		[Required(ErrorMessage = "Please select a job")]
		[Range(1, double.MaxValue, ErrorMessage = "Please select a job")]
		public string JobPosition { get; set; }

		[Display(Name = "Job Start Date")]
		[DataType(DataType.DateTime)]
		public DateTime JobStartDate { get; set; }

		[Display(Name = "Status")]
		public EmploymentStatus Status { get; set; }


		[Display(Name = "Terminated Date")]
		[DataType(DataType.DateTime)]
		public DateTime? TerminatedDate { get; set; } = null;

		[Display(Name = "Retired Date")]
		[DataType(DataType.DateTime)]
		public DateTime? RetiredDate { get; set; } = null;

	}
}
