using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BlueBank.Model;

namespace BlueBank.WebFrontEnd.Models
{
    public class BrowseVM
    {
        public List<Error> Errors { get; set; } = new List<Error>();

        // Purchase Orders list
        public List<BlueBank.Model.PurchaseOrder> PurchaseOrders { get; set; } = new List<Model.PurchaseOrder>();

        // Browse Purchase Order search props

        [Display(Name = "Search by PO Number")]
        public bool SearchByPoNumber { get; set; }

        public string PurchaseOrderIdSearch { get; set; }

        //public bool AllDates { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Status")]
        [Required]
        public string POStatus { get; set; }
    }
}