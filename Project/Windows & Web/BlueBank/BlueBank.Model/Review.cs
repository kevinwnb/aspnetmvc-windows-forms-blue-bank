using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
	public class Review : Base
	{
		public int ReviewId { get; set; }

		public int EmployeeId { get; set; }

		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		public int SupervisorId { get; set; }
		public Performance Performance { get; set; }
		public string Comment { get; set; }

		public Review() { }
	}
}
