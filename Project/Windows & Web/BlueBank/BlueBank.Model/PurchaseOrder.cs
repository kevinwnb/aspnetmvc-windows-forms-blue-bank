using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class PurchaseOrder : Base
    {
		[Display(Name = "PO Number")]
		public int PurchaseOrderId { get; set; }
		
		[Required(ErrorMessage = "Creation date is required")]
		[Display(Name = "Creation Date")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime CreationDate { get; set; }

		[Required(ErrorMessage = "Department is required")]
		public string Department { get; set; }

		[Required(ErrorMessage = "EmployeeId is required")]
		public int EmployeeId { get; set; }
		
		[Required(ErrorMessage = "Status is required")]
		public POStatus Status { get; set; }

		[Display(Name = "Subtotal")]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal Subtotal { get; set; }

		[Display(Name = "Tax")]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal Tax { get; set; }

		[Display(Name = "Total")]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal TotalAfterTax { get; set; }

		public List<Item> Items { get; set; } = new List<Item>();

		[Display(Name = "Items")]
		public string DisplayItems { get; set; }

		[Display(Name = "Tax Rate")]
		[DisplayFormat(DataFormatString = "{0:P}")]
		public double TaxRate { get; set; } = 0.15;

		public byte[] TimeStamp { get; set; }

		public bool ClosePurchaseOrder { get; set; }

		public bool IsProcess { get; set; }

		public bool IsModifyItem { get; set; }

		public PurchaseOrder()
		{

		}

		public PurchaseOrder(int purchaseOrderId, DateTime creationDate, int employeeId, POStatus status, decimal subtotal, decimal tax, decimal totalAfterTax, List<Item> items, double taxRate, byte[] timeStamp)
		{
			PurchaseOrderId = purchaseOrderId;
			CreationDate = creationDate;
			EmployeeId = employeeId;
			Status = status;
			Subtotal = subtotal;
			Tax = tax;
			TotalAfterTax = totalAfterTax;
			Items = items;
			TaxRate = taxRate;
			TimeStamp = timeStamp;
		}
	}
}
