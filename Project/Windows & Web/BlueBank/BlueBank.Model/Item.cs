using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        //public byte[] TimeStamp { get; set; }

        [Required(ErrorMessage = "Justification is required")]
        public string Justification { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Display(Name = "PO Number")]
        public int PurchaseOrderId { get; set; }

        public ItemStatus Status { get; set; }

        [Display(Name = "Status")]
        public string DisplayStatus { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Subtotal")]
        public decimal subtotal { get; set; }

        [Required(ErrorMessage = "Reason is required")]
        public string Reason { get; set; }

        public Item()
        {

        }
    }
}
