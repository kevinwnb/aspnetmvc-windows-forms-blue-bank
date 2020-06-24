using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlueBank.WebFrontEnd.Models
{
    public class PurchaseOrderVM
    {
        public PurchaseOrder PurchaseOrder { get; set; } = new PurchaseOrder();

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }
        public Item ItemToAdd { get; set; } = new Item();
        public List<PurchaseOrder> EditPurchaseOrders { get; set; }
        public PurchaseOrderDTO ProcessPurchaseOrder { get; set; }
        public List<PurchaseOrderDTO> ProcessPurchaseOrders { get; set; }

        public Item Item { get; set; }

        public bool editMode { get; set; } = false;

        public bool SettedAsValid { get; set; } = false;

        public bool isSuccessEdit { get; set; }

        public bool IsSuccessProcess { get; set; }

        public bool ShowPromptToClose { get; set; }

        public bool ShowButtonToClose { get; set; }

        public BrowseVM BrowseVM { get; set; } = new BrowseVM();

        public EditSearchVM EditSearchVM { get; set; } = new EditSearchVM();

        public ProcessSearchVM ProcessSearchVM { get; set; } = new ProcessSearchVM();
    }
}