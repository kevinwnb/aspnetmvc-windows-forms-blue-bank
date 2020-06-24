using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBank.WebFrontEnd.Models
{
    public class POItemVM
    {
        public PurchaseOrderDTO PurchaseOrder { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}