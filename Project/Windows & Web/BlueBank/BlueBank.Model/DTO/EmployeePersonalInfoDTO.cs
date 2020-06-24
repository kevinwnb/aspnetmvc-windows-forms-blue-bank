using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class EmployeePersonalInfoDTO : Base
    {
		[Display(Name = "Employee Id")]
		public int EmployeeId { get; set; }

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

		[Display(Name = "Work Phone N°")]
		[Phone(ErrorMessage = "Please enter a valid work phone number")]
		public string WorkPhoneNumber { get; set; }

		[Display(Name = "Cell Phone N°")]
		[Phone(ErrorMessage = "Please enter a valid cell phone number")]
		public string CellPhoneNumber { get; set; }

		public byte[] TimeStamp { get; set; }
	}
}
