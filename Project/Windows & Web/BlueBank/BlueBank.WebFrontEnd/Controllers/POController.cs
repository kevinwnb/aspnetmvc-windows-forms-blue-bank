using BlueBank.Model;
using BlueBank.Service;
using BlueBank.WebFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace BlueBank.WebFrontEnd.Controllers
{
    public class POController : Controller
    {

        PurchaseOrderService service = new PurchaseOrderService();

        public ActionResult BrowseSearch()
        {

            if (Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            PurchaseOrderVM vm = new PurchaseOrderVM();
            vm.BrowseVM.POStatus = "Open";
            vm.BrowseVM.StartDate = DateTime.MinValue;
            vm.BrowseVM.EndDate = DateTime.Now;

            string purchaseOrderIdSearch = "";

            POStatus? poStatus = POStatus.Pending;

            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.Now;

            vm.BrowseVM.PurchaseOrders = service.BrowseSearch(Convert.ToInt32(Session["employeeId"]), purchaseOrderIdSearch, poStatus, startDate, endDate);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BrowseSearch(PurchaseOrderVM vm)
        {
            string purchaseOrderIdSearch = !string.IsNullOrEmpty(vm.BrowseVM.PurchaseOrderIdSearch) ? vm.BrowseVM.PurchaseOrderIdSearch : "";

            POStatus? poStatus = POStatus.Pending;
            if (vm.BrowseVM.POStatus == "Closed")
            {
                poStatus = POStatus.Closed;
            }
            if (vm.BrowseVM.POStatus == "Both")
            {
                poStatus = null;
            }

            DateTime startDate = vm.BrowseVM.StartDate;
            DateTime endDate = vm.BrowseVM.EndDate;

            if (vm.BrowseVM.SearchByPoNumber)
            {
                poStatus = null;
                startDate = DateTime.MinValue;
                endDate = DateTime.Now;
                if (!string.IsNullOrEmpty(vm.BrowseVM.PurchaseOrderIdSearch))
                {
                    if (purchaseOrderIdSearch.Length < 8)
                    {
                        vm.BrowseVM.Errors.Add(new Error(150, "The PO number must be 8 digits long", "Model"));
                    }
                    if (!int.TryParse(purchaseOrderIdSearch, out int result))
                    {
                        vm.BrowseVM.Errors.Add(new Error(151, "The PO number must be numeric", "Model"));
                    }
                }
                else
                {
                    vm.BrowseVM.Errors.Add(new Error(156, "The PO Number is required", "Model"));
                }
            }
            else
            {
                purchaseOrderIdSearch = "";
            }

            if (!(vm.BrowseVM.Errors.Count > 0))
            {
                vm.BrowseVM.PurchaseOrders = service.BrowseSearch(Convert.ToInt32(Session["employeeId"]), purchaseOrderIdSearch, poStatus, startDate, endDate);
            }

            return View(vm);
        }

        public ActionResult Browse(int purchaseOrderId)
        {
            if (Session["employeeId"] == null)
            {
                Session.Add("browsePoId", purchaseOrderId);
                return RedirectToAction("Index", "Login");
            }

            PurchaseOrderVM vm = new PurchaseOrderVM();
            vm.PurchaseOrder = service.GetPurchaseOrder(purchaseOrderId);
            vm.EmployeeName = service.GetEmployeeName(vm.PurchaseOrder.EmployeeId).EmployeeName;
            vm.SupervisorName = service.GetSupervisorName(vm.PurchaseOrder.EmployeeId).FullName;
            foreach (Item item in vm.PurchaseOrder.Items)
            {
                item.subtotal = item.Price * item.Quantity;
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Browse(PurchaseOrderVM vm)
        {
            return View(vm);
        }

        public ActionResult ProcessSearch()
        {
            if (Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            PurchaseOrderVM vm = new PurchaseOrderVM();

            vm.ProcessSearchVM.EmployeeNameSearch = null;
            vm.ProcessSearchVM.StartDate = DateTimePicker.MinimumDateTime;
            vm.ProcessSearchVM.EndDate = DateTime.Now;
            vm.ProcessSearchVM.Status = "Pending";

            int employeeIdParam = Convert.ToInt32(Session["employeeId"]);
            DateTime startDateParam = vm.ProcessSearchVM.StartDate;
            DateTime endDateParam = vm.ProcessSearchVM.EndDate;
            POStatus? statusParam = POStatus.Pending;

            List<PurchaseOrderDTO> pos = service.SearchPurchaseOrdersProcess(employeeIdParam, vm.EmployeeName, startDateParam, endDateParam, statusParam);
            vm.ProcessPurchaseOrders = pos;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessSearch(PurchaseOrderVM vm)
        {
            if (Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int employeeIdParam = Convert.ToInt32(Session["employeeId"]);
            string searchCriteria = vm.ProcessSearchVM.EmployeeNameSearch;
            DateTime startDateParam = vm.ProcessSearchVM.StartDate;
            DateTime endDateParam = vm.ProcessSearchVM.EndDate;
            POStatus? statusParam = POStatus.Pending;
            if (vm.ProcessSearchVM.Status == "Pending")
            {
                statusParam = POStatus.Pending;
            }
            if (vm.ProcessSearchVM.Status == "Closed")
            {
                statusParam = POStatus.Closed;
            }
            if (vm.ProcessSearchVM.Status == "All")
            {
                statusParam = null;
            }

            List<PurchaseOrderDTO> pos = new List<PurchaseOrderDTO>();

            if (vm.ProcessSearchVM.SearchByPoNumber)
            {
                startDateParam = DateTime.MinValue;
                endDateParam = DateTime.Now;
                statusParam = null;
                searchCriteria = vm.ProcessSearchVM.PoNumberSearch;
                if (int.TryParse(searchCriteria, out int result))
                {
                    if (searchCriteria.Length == 8)
                    {
                        pos = service.SearchPurchaseOrdersProcess(employeeIdParam, searchCriteria, startDateParam, endDateParam, statusParam);
                        vm.ProcessPurchaseOrders = pos;
                    }
                    else
                    {
                        vm.PurchaseOrder.Errors.Add(new Error(1, "The PO Number must be 8 digits long", "Model"));
                    }
                }
                else
                {
                    vm.PurchaseOrder.Errors.Add(new Error(1, "The PO Number must be a number", "Model"));
                }
            }
            else
            {
                pos = service.SearchPurchaseOrdersProcess(employeeIdParam, searchCriteria, startDateParam, endDateParam, statusParam);
                vm.ProcessPurchaseOrders = pos;
            }

            return View(vm);
        }

        public ActionResult Process(int id, int? itemId = null, bool allItemsProcessed = false)
        {
            if (Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            PurchaseOrderVM vm = new PurchaseOrderVM();
            vm.PurchaseOrder = service.GetPurchaseOrder(id);
            foreach (Item item in vm.PurchaseOrder.Items)
            {
                item.subtotal = item.Quantity * item.Price;
            }
            vm.ProcessPurchaseOrder = new PurchaseOrderDTO();
            vm.ProcessPurchaseOrder.PurchaseOrderId = vm.PurchaseOrder.PurchaseOrderId;
            vm.ProcessPurchaseOrder.EmployeeName = service.GetEmployeeName(vm.PurchaseOrder.EmployeeId).EmployeeName;
            vm.ProcessPurchaseOrder.CreationDate = vm.PurchaseOrder.CreationDate;
            vm.ProcessPurchaseOrder.Total = vm.PurchaseOrder.TotalAfterTax;
            vm.Item = new Item();

            if (itemId != null)
            {
                foreach (Item i in vm.PurchaseOrder.Items)
                {
                    if (i.ItemId == itemId)
                    {
                        vm.Item = i;
                    }
                }

            }

            if (allItemsProcessed)
            {
                vm.ShowPromptToClose = true;
            }

            vm.ShowButtonToClose = true;
            foreach (Item item in vm.PurchaseOrder.Items)
            {
                if (item.Status != ItemStatus.Approved && item.Status != ItemStatus.Denied)
                {
                    vm.ShowButtonToClose = false;
                }
            }

            Session.Add("vm", vm);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Process(PurchaseOrderVM vm)
        {
            if (Request.Form["closeOrder"] != null)
            {
                int poId = Convert.ToInt32(Request.Form["purchaseOrderId"]);
                PurchaseOrder po = service.GetPurchaseOrder(poId);
                po.Status = POStatus.Closed;
                po.IsProcess = true;
                if (service.UpdatePurchaseOrder(po, (int)Session["employeeId"]))
                {
                    return RedirectToAction("Process", new { id = po.PurchaseOrderId });
                }
                else
                {
                    vm.PurchaseOrder = po;
                    return View(vm);
                }
            }
            else
            {
                PurchaseOrder po = (Session["vm"] as PurchaseOrderVM).PurchaseOrder;
                Item item = (Session["vm"] as PurchaseOrderVM).Item;
                if (Request.Form["status"] == "Pending")
                {
                    item.Status = ItemStatus.Pending;
                    item.Reason = "";
                }
                else if (Request.Form["status"] == "Approve")
                {
                    item.Status = ItemStatus.Approved;
                    item.Reason = "";
                }
                else if (Request.Form["status"] == "Deny")
                {
                    item.Status = ItemStatus.Denied;
                    item.Reason = Request.Form["reason"];
                }
                foreach (Item i in po.Items.ToList())
                {
                    if (i.ItemId == item.ItemId)
                    {
                        po.Items.Remove(i);
                        po.Items.Add(item);
                    }
                }

                po.IsProcess = true;

                if (service.UpdatePurchaseOrder(po) && service.UpdateItemReason(item))
                {
                    vm.IsSuccessProcess = true;
                }
                else
                {
                    vm.IsSuccessProcess = false;
                    vm.PurchaseOrder.Errors = po.Errors;
                    return View(vm);
                }

                //vm = Session["vm"] as PurchaseOrderVM;
                //vm.PurchaseOrder = po;
                //foreach (Item i in vm.PurchaseOrder.Items)
                //{
                //    i.subtotal = i.Quantity * i.Price;
                //}

                bool allItemsProcessed = true;
                foreach (Item i in po.Items)
                {
                    if (i.Status != ItemStatus.Approved && i.Status != ItemStatus.Denied)
                    {
                        allItemsProcessed = false;
                    }
                }

                return RedirectToAction("Process", new { id = po.PurchaseOrderId, allItemsProcessed = allItemsProcessed ? true : false });
            }
        }

        public ActionResult ResetItemForm(string from)
        {
            PurchaseOrderVM vm = Session["vm"] as PurchaseOrderVM;
            if (vm == null)
            {
                vm = new PurchaseOrderVM();
                vm.PurchaseOrder = new PurchaseOrder()
                {
                    CreationDate = DateTime.Today,
                    EmployeeId = Convert.ToInt32(System.Web.HttpContext.Current.Session["employeeId"]),
                    Department = System.Web.HttpContext.Current.Session["department"].ToString(),
                    Status = (POStatus.Pending)
                };

                vm.EmployeeName = service.GetEmployeeName(Convert.ToInt32(Session["employeeId"])).EmployeeName;
                vm.SupervisorName = service.GetSupervisorName(Convert.ToInt32(Session["employeeId"])).FullName;
            }
            vm.ItemToAdd = new Item();
            Session.Add("vm", vm);
            return from == "create" ? RedirectToAction("Create", new { isNew = false }) : RedirectToAction("Edit", new { id = 0, reset = true });
        }

        public ActionResult EditSearch()
        {
            if (Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string search = string.Empty;
            string searchBy = "CreationDate";
            string startDate = DateTime.MinValue.ToString();
            string endDate = DateTime.Now.ToString();
            string status = "Pending";

            PurchaseOrderVM vm = new PurchaseOrderVM();

            vm.EditSearchVM.PurchaseOrderIdSearch = search;
            vm.EditSearchVM.SearchBy = "CreationDate";
            vm.EditSearchVM.StartDate = DateTime.MinValue;
            vm.EditSearchVM.EndDate = DateTime.Now;
            vm.EditSearchVM.Status = status;

            PurchaseOrderService PurchaseOrderService = new PurchaseOrderService();

            if (System.Web.HttpContext.Current.Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.errorMessage = null;
            ViewBag.firstLoad = true;

            vm.PurchaseOrder = new PurchaseOrder();
            vm.EditPurchaseOrders = new List<PurchaseOrder>();

            if ((search == string.Empty && searchBy == "Id") || ((startDate == string.Empty || endDate == string.Empty) && searchBy == "CreationDate"))
            {
                ViewBag.errorMessage = "Please enter search criteria.";
                vm.PurchaseOrder.Errors.Add(new Error(1, "Please enter search criteria", "Model"));
            }

            if (ViewBag.errorMessage == null && search != null && searchBy == "Id")
            {
                if (search.Length == 8)
                {
                    ViewBag.firstLoad = false;
                    int determineSearchType = searchBy == "Id" ? 1 : 2;
                    int employeeId = (int)Session["employeeId"];
                    //int purchaseOrderId = Convert.ToInt32(search);
                    //vm.PurchaseOrder.PurchaseOrderId = purchaseOrderId;
                    vm.EditPurchaseOrders = service.GetPurchaseOrders(determineSearchType, employeeId, Convert.ToInt32(search), DateTime.Today, DateTime.Today, null);
                    if ((EmployeeType)Session["employeeType"] == EmployeeType.RegularEmployee)
                    {
                        foreach (PurchaseOrder purchaseOrder in vm.EditPurchaseOrders)
                        {
                            if (purchaseOrder.Status != POStatus.Pending && purchaseOrder.Status != POStatus.Closed)
                            {
                                vm.EditPurchaseOrders.Remove(purchaseOrder);
                            }
                            if (purchaseOrder.EmployeeId != (int)Session["employeeId"])
                            {
                                vm.EditPurchaseOrders.Remove(purchaseOrder);
                            }
                        }
                    }
                    //vm.EditPurchaseOrders.Add(PurchaseOrderService.GetPurchaseOrder(purchaseOrderId));
                }
                else
                {
                    vm.PurchaseOrder.Errors.Add(new Error(111, "Purchase order id must be 8 digits long", "Model"));
                    return View(vm);
                }
            }

            if (ViewBag.errorMessage == null && startDate != null && endDate != null && searchBy == "CreationDate")
            {
                if (Convert.ToDateTime(startDate) <= Convert.ToDateTime(endDate))
                {
                    ViewBag.firstLoad = false;
                    int determineSearchType = searchBy == "Id" ? 1 : 2;
                    int employeeId = (int)Session["employeeId"];
                    POStatus? statusParam = POStatus.Pending;
                    //if (status == "Closed")
                    //{
                    //    statusParam = POStatus.Closed;
                    //}
                    //if (status == "Pending")
                    //{
                    //    statusParam = POStatus.Pending;
                    //}
                    //int purchaseOrderId = Convert.ToInt32(search);
                    //vm.PurchaseOrder.PurchaseOrderId = purchaseOrderId;
                    vm.EditPurchaseOrders = service.GetPurchaseOrders(determineSearchType, employeeId, 0, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), statusParam);
                    if ((EmployeeType)Session["employeeType"] == EmployeeType.RegularEmployee || (EmployeeType)Session["employeeType"] == EmployeeType.HREmployee)
                    {
                        foreach (PurchaseOrder purchaseOrder in vm.EditPurchaseOrders.ToList())
                        {
                            if (purchaseOrder.EmployeeId != (int)Session["employeeId"])
                            {
                                vm.EditPurchaseOrders.Remove(purchaseOrder);
                            }
                        }
                    }
                    //vm.EditPurchaseOrders.Add(PurchaseOrderService.GetPurchaseOrder(purchaseOrderId));
                }
                else
                {
                    vm.PurchaseOrder.AddError(new Error(111, "Start date cannot be greater than end date", "Model"));
                    return View(vm);
                }
            }

            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSearch(PurchaseOrderVM vm)
        {
            string search = string.IsNullOrEmpty(vm.EditSearchVM.PurchaseOrderIdSearch) ? "" : vm.EditSearchVM.PurchaseOrderIdSearch;
            string searchBy = vm.EditSearchVM.SearchBy;
            string startDate = vm.EditSearchVM.StartDate.ToString();
            string endDate = vm.EditSearchVM.EndDate.ToString();
            string status = null;

            PurchaseOrderService PurchaseOrderService = new PurchaseOrderService();

            if (System.Web.HttpContext.Current.Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.errorMessage = null;
            ViewBag.firstLoad = true;

            vm.PurchaseOrder = new PurchaseOrder();
            vm.EditPurchaseOrders = new List<PurchaseOrder>();

            if ((search == string.Empty && searchBy == "Id") || ((startDate == string.Empty || endDate == string.Empty) && searchBy == "CreationDate"))
            {
                ViewBag.errorMessage = "Please enter search criteria.";
                vm.PurchaseOrder.Errors.Add(new Error(1, "Please enter search criteria", "Model"));
            }

            if (ViewBag.errorMessage == null && search != null && searchBy == "Id")
            {
                if (search.Length == 8)
                {
                    if (int.TryParse(search, out int result))
                    {
                        ViewBag.firstLoad = false;
                        int determineSearchType = searchBy == "Id" ? 1 : 2;
                        int employeeId = Convert.ToInt32(Session["employeeId"]);
                        //int purchaseOrderId = Convert.ToInt32(search);
                        //vm.PurchaseOrder.PurchaseOrderId = purchaseOrderId;
                        vm.EditPurchaseOrders = service.GetPurchaseOrders(determineSearchType, employeeId, Convert.ToInt32(search), DateTime.Today, DateTime.Today, null);
                        if ((EmployeeType)Session["employeeType"] == EmployeeType.RegularEmployee || (EmployeeType)Session["employeeType"] == EmployeeType.HREmployee)
                        {
                            foreach (PurchaseOrder purchaseOrder in vm.EditPurchaseOrders.ToList())
                            {
                                if (purchaseOrder.EmployeeId != (int)Session["employeeId"])
                                {
                                    vm.EditPurchaseOrders.Remove(purchaseOrder);
                                }
                            }
                        }
                        //vm.EditPurchaseOrders.Add(PurchaseOrderService.GetPurchaseOrder(purchaseOrderId));
                    }
                    else
                    {
                        vm.PurchaseOrder.Errors.Add(new Error(112, "Purchase order id must be a number", "Model"));
                        return View(vm);
                    }
                }
                else
                {
                    vm.PurchaseOrder.Errors.Add(new Error(111, "Purchase order id must be 8 digits long", "Model"));
                    return View(vm);
                }
            }

            if (ViewBag.errorMessage == null && startDate != null && endDate != null && searchBy == "CreationDate")
            {
                if (Convert.ToDateTime(startDate) <= Convert.ToDateTime(endDate))
                {
                    ViewBag.firstLoad = false;
                    int determineSearchType = searchBy == "Id" ? 1 : 2;
                    int employeeId = (int)Session["employeeId"];
                    POStatus? statusParam = null;
                    //if (status == "Closed")
                    //{
                    //    statusParam = POStatus.Closed;
                    //}
                    //if (status == "Pending")
                    //{
                    //    statusParam = POStatus.Pending;
                    //}
                    //int purchaseOrderId = Convert.ToInt32(search);
                    //vm.PurchaseOrder.PurchaseOrderId = purchaseOrderId;
                    vm.EditPurchaseOrders = service.GetPurchaseOrders(determineSearchType, employeeId, 0, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), statusParam);
                    if ((EmployeeType)Session["employeeType"] == EmployeeType.RegularEmployee || (EmployeeType)Session["employeeType"] == EmployeeType.HREmployee)
                    {
                        foreach (PurchaseOrder purchaseOrder in vm.EditPurchaseOrders.ToList())
                        {
                            if (purchaseOrder.EmployeeId != (int)Session["employeeId"])
                            {
                                vm.EditPurchaseOrders.Remove(purchaseOrder);
                            }
                        }
                    }
                    //vm.EditPurchaseOrders.Add(PurchaseOrderService.GetPurchaseOrder(purchaseOrderId));
                }
                else
                {
                    vm.PurchaseOrder.AddError(new Error(111, "Start date cannot be greater than end date", "Model"));
                    return View(vm);
                }
            }

            return View(vm);
        }

        public ActionResult Edit(int? id, bool reset = false)
        {
            if (Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ModelState.Clear();
            // If the ID is 0 it means that we don't retrieve anew we just return the current purchase order under edit
            if (id == 0)
            {
                PurchaseOrderVM vm = Session["vm"] as PurchaseOrderVM;
                vm.PurchaseOrder.Items = Session["items"] as List<Item>;
                foreach (Item item in vm.PurchaseOrder.Items)
                {
                    item.subtotal = item.Price * item.Quantity;
                }
                vm.PurchaseOrder.Subtotal = service.CalculateSubtotal(vm.PurchaseOrder);
                vm.PurchaseOrder.Tax = service.CalculateTaxAmount(vm.PurchaseOrder);
                vm.PurchaseOrder.TotalAfterTax = service.CalculateTotal(vm.PurchaseOrder);
                if (reset == true)
                {
                    vm.editMode = false;
                }
                return View(vm);
            }
            else
            {
                PurchaseOrderService purchaseOrderService = new PurchaseOrderService();

                PurchaseOrderVM vm = new PurchaseOrderVM();

                vm.PurchaseOrder = purchaseOrderService.GetPurchaseOrder(id.Value);

                vm.EmployeeName = service.GetEmployeeName(vm.PurchaseOrder.EmployeeId).EmployeeName;
                vm.SupervisorName = service.GetSupervisorName(vm.PurchaseOrder.EmployeeId).FullName;
                foreach (Item item in vm.PurchaseOrder.Items)
                {
                    item.subtotal = item.Quantity * item.Price;
                }

                Session["vm"] = vm;
                Session["items"] = vm.PurchaseOrder.Items;
                return View(vm);
            }
        }

        [HttpPost]
        public ActionResult Edit(PurchaseOrderVM vm)
        {
            //Clear model state properties
            ModelState.Clear();
            if (Request.Form["modifyItem"] != null)
            {
                return View(ModifyItem(vm));
            }

            return View(AddItemEdit(vm));
        }

        public ActionResult CancelItem(int? id)
        {
            List<Item> items = Session["items"] as List<Item>;
            foreach (Item item in items.ToList())
            {
                if (item.ItemId == id)
                {
                    item.Status = ItemStatus.NoLongerRequired;
                }
            }
            Session["items"] = items;
            PurchaseOrderVM vm = Session["vm"] as PurchaseOrderVM;
            vm.PurchaseOrder.Items = items;

            if (UpdateItem(vm))
            {
                vm.PurchaseOrder = service.GetPurchaseOrder(vm.PurchaseOrder.PurchaseOrderId);
            }

            Session.Add("vm", vm);
            Session.Add("items", vm.PurchaseOrder.Items);

            return RedirectToAction("Edit", new { id = 0 });
        }

        public ActionResult EditItem(int id)
        {
            PurchaseOrderVM vm = Session["vm"] as PurchaseOrderVM;
            vm.editMode = true;
            foreach (Item item in vm.PurchaseOrder.Items)
            {
                if (item.ItemId == id)
                {
                    vm.ItemToAdd.ItemId = id;
                    vm.ItemToAdd.Name = item.Name;
                    vm.ItemToAdd.Description = item.Description;
                    vm.ItemToAdd.Price = item.Price;
                    vm.ItemToAdd.Quantity = item.Quantity;
                    vm.ItemToAdd.Justification = item.Justification;
                    vm.ItemToAdd.Location = item.Location;
                    vm.ItemToAdd.Status = item.Status;
                    vm.ItemToAdd.PurchaseOrderId = item.PurchaseOrderId;
                    vm.ItemToAdd.Reason = item.Reason;
                }
            }

            Session.Add("vm", vm);

            return RedirectToAction("Edit", new { id = 0 });
        }

        // GET: PO
        public ActionResult Create(bool isNew = true)
        {
            if (isNew)
            {
                Session["items"] = null;
            }

            if (System.Web.HttpContext.Current.Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            PurchaseOrderVM vm = new PurchaseOrderVM();

            if (isNew == false && Session["vm"] != null)
            {
                vm = Session["vm"] as PurchaseOrderVM;
            }
            else
            {
                Session["vm"] = null;
                vm.PurchaseOrder = new PurchaseOrder()
                {
                    CreationDate = DateTime.Today,
                    EmployeeId = Convert.ToInt32(System.Web.HttpContext.Current.Session["employeeId"]),
                    Department = System.Web.HttpContext.Current.Session["department"].ToString(),
                    Status = (POStatus.Pending)
                };

                vm.EmployeeName = service.GetEmployeeName(Convert.ToInt32(Session["employeeId"])).EmployeeName;
                vm.SupervisorName = service.GetSupervisorName(Convert.ToInt32(Session["employeeId"])).FullName;
            }

            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(PurchaseOrderVM vm)
        {
            //Clear model state properties
            ModelState.Clear();
            if (Request.Form["reset"] != null)
            {
                vm = new PurchaseOrderVM();

                vm.PurchaseOrder = new PurchaseOrder()
                {
                    CreationDate = DateTime.Today,
                    EmployeeId = Convert.ToInt32(System.Web.HttpContext.Current.Session["employeeId"]),
                    Department = System.Web.HttpContext.Current.Session["department"].ToString(),
                    Status = (POStatus.Pending)
                };

                vm.EmployeeName = service.GetEmployeeName(Convert.ToInt32(Session["employeeId"])).EmployeeName;
                vm.SupervisorName = service.GetSupervisorName(Convert.ToInt32(Session["employeeId"])).FullName;

                return View(vm);
            }

            return View(AddItemCreate(vm));
        }

        private PurchaseOrderVM ModifyItem(PurchaseOrderVM vm)
        {
            PurchaseOrder po = new PurchaseOrder();
            po = vm.PurchaseOrder;
            if (Session["items"] != null)
            {
                po.Items = Session["items"] as List<Item>;
            }
            vm.ItemToAdd.PurchaseOrderId = po.PurchaseOrderId;
            if (string.IsNullOrEmpty(vm.ItemToAdd.Reason))
            {
                vm.ItemToAdd.Reason = "";
            }
            if ((EmployeeType)Session["employeeType"] == EmployeeType.RegularSupervisor && vm.PurchaseOrder.EmployeeId != (int)Session["employeeId"])
            {
                if (!string.IsNullOrEmpty(vm.ItemToAdd.Reason))
                {
                    service.UpdateItemReason(vm.ItemToAdd);
                }
            }
            foreach (Item item in po.Items)
            {
                if (item.ItemId == vm.ItemToAdd.ItemId)
                {
                    item.Name = vm.ItemToAdd.Name;
                    item.Description = vm.ItemToAdd.Description;
                    item.Price = vm.ItemToAdd.Price;
                    item.Quantity = vm.ItemToAdd.Quantity;
                    item.Justification = vm.ItemToAdd.Justification;
                    item.Location = vm.ItemToAdd.Location;
                }
            }
            po.Items = service.MergeDuplicates(po).Items;



            po.Subtotal = service.CalculateSubtotal(vm.PurchaseOrder);
            po.Tax = service.CalculateTaxAmount(vm.PurchaseOrder);
            po.TotalAfterTax = service.CalculateTotal(vm.PurchaseOrder);

            bool success = service.UpdatePurchaseOrder(po);

            vm.PurchaseOrder = service.GetPurchaseOrder(po.PurchaseOrderId);

            if (po.Errors.Count > 0)
            {
                vm.PurchaseOrder.Errors = po.Errors;
            }

            foreach (Item item in vm.PurchaseOrder.Items)
            {
                item.subtotal = item.Price * item.Quantity;
            }
            vm.ItemToAdd = new Item();
            vm.editMode = false;
            Session.Add("vm", vm);
            Session.Add("items", vm.PurchaseOrder.Items);

            return vm;
        }

        private PurchaseOrderVM AddItemCreate(PurchaseOrderVM vm)
        {
            PurchaseOrder po = new PurchaseOrder();
            po = vm.PurchaseOrder;
            if (Session["items"] != null)
            {
                po.Items = Session["items"] as List<Item>;
            }
            vm.ItemToAdd.PurchaseOrderId = po.PurchaseOrderId;
            po.Items.Add(vm.ItemToAdd);
            po.Items = service.MergeDuplicates(po).Items;



            po.Subtotal = service.CalculateSubtotal(vm.PurchaseOrder);
            po.Tax = service.CalculateTaxAmount(vm.PurchaseOrder);
            po.TotalAfterTax = service.CalculateTotal(vm.PurchaseOrder);

            bool success = service.CreatePurchaseOrder(po);

            vm.PurchaseOrder = service.GetPurchaseOrder(po.PurchaseOrderId);

            foreach (Item item in vm.PurchaseOrder.Items)
            {
                item.subtotal = item.Price * item.Quantity;
            }
            vm.PurchaseOrder.Subtotal = service.CalculateSubtotal(vm.PurchaseOrder);
            vm.PurchaseOrder.Tax = service.CalculateTaxAmount(vm.PurchaseOrder);
            vm.PurchaseOrder.TotalAfterTax = service.CalculateTotal(vm.PurchaseOrder);
            Session.Add("vm", vm);
            Session.Add("items", vm.PurchaseOrder.Items);

            return vm;
        }

        private bool UpdateItem(PurchaseOrderVM vm)
        {
            return service.UpdatePurchaseOrder(vm.PurchaseOrder);
        }

        private PurchaseOrderVM AddItemEdit(PurchaseOrderVM vm)
        {
            PurchaseOrder po = new PurchaseOrder();
            po = vm.PurchaseOrder;
            if (Session["items"] != null)
            {
                po.Items = Session["items"] as List<Item>;
            }
            vm.ItemToAdd.PurchaseOrderId = po.PurchaseOrderId;
            po.Items.Add(vm.ItemToAdd);
            po.Items = service.MergeDuplicates(po).Items;



            po.Subtotal = service.CalculateSubtotal(vm.PurchaseOrder);
            po.Tax = service.CalculateTaxAmount(vm.PurchaseOrder);
            po.TotalAfterTax = service.CalculateTotal(vm.PurchaseOrder);

            bool success = service.UpdatePurchaseOrder(po);

            vm.PurchaseOrder = service.GetPurchaseOrder(po.PurchaseOrderId);

            foreach (Item item in vm.PurchaseOrder.Items)
            {
                item.subtotal = item.Price * item.Quantity;
            }
            Session.Add("vm", vm);
            Session.Add("items", vm.PurchaseOrder.Items);

            return vm;
        }
    }
}
