using BlueBank.Model;
using BlueBank.Model;
using BlueBank.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Service
{
    public class PurchaseOrderService
    {

        PurchaseOrderRepository repo = new PurchaseOrderRepository();

        public bool CreatePurchaseOrder(PurchaseOrder po)
        {
            return IsValid(po) && po.Items.Count > 0 ? repo.CreatePurchaseOrder(po) : false;
        }

        public bool UpdatePurchaseOrder(PurchaseOrder po, int senderId = -1)
        {
            try
            {
                bool allItemsProcessed = true;
                bool allItemsPending = true;
                
                foreach (Item item in po.Items)
                {
                    if (item.Status == ItemStatus.Pending)
                    {
                        allItemsProcessed = false;
                    }

                    if (item.Status != ItemStatus.Pending && item.Status != ItemStatus.NoLongerRequired && item.Description != "No longer needed")
                    {
                        allItemsPending = false;
                    }
                }

                if (allItemsProcessed && po.ClosePurchaseOrder)
                {
                    po.Status = POStatus.Closed;
                }
                else if (allItemsPending)
                {
                    po.Status = POStatus.Pending;
                }
                else if (allItemsProcessed && po.ClosePurchaseOrder == false && po.Status != POStatus.Closed)
                {
                    po.Status = POStatus.UnderReview;
                }
                else if (!allItemsProcessed && !allItemsPending)
                {
                    po.Status = POStatus.UnderReview;
                }

                if (IsValid(po) && po.Items.Count > 0 ? repo.UpdatePurchaseOrder(po.IsModifyItem ? po : MergeDuplicates(po)) : false)
                {
                    if (po.Status == POStatus.Closed)
                    {
                        EmployeeService empService = new EmployeeService();
                        EmployeeDTO emp = empService.GetEmployeeInformation(senderId);
                        if(SendPOProcessedEmailNotification(po: po, sender: emp))
                        {
                            return true;
                        }
                        po.AddError(new Error(120, "The process confirmation email was not sent", "Email not sent"));

                        return false;
                    }
                    return true;
                }

                po.AddError(new Error(10, "The Purchase Order was not updated", "Business"));
                return false;
            }
            catch (Exception ex)
            {
                po.AddError(new Error(2, ex.Message, ex.GetType().ToString()));
                return false;
            }
        }

        private bool SendPOProcessedEmailNotification(PurchaseOrder po, EmployeeDTO sender, string subject = "", string body = "")
        {
            EmailService emailService = new EmailService();
            Email email = new Email();
            email.Subject = "PO " + po.PurchaseOrderId + " has been processed";
            string items = "Items:";
            foreach (Item item in po.Items)
            {
                items += $"\n{item.Name}: {item.Status}";
            }
            email.Body = $"The Purchase Order {po.PurchaseOrderId} has been processed: \n" +
                $"PO Number: {po.PurchaseOrderId}\n" +
                $"Date: {po.CreationDate.ToShortDateString()}\n" +
                $"{items}\n" +
                $"Total: {po.TotalAfterTax.ToString("c")}\n" +
                $"Link: https://localhost:44315/PO/Browse?purchaseOrderId={po.PurchaseOrderId}";
            email.SenderAddress = sender.EmailAddress; //"kevinwnb@gmail.com";
            email.ReceiverAddress = GetEmployeeEmail(po.EmployeeId);//GetEmployeeEmail(po.EmployeeId);
            return emailService.SendEmail(email);
        }

        private string GetEmployeeEmail(int id)
        {
            return repo.GetEmployeeEmail(id);
        }

        public List<PurchaseOrderDTO> SearchPurchaseOrdersProcess(int employeeId, string searchCriteria, DateTime? startDate, DateTime? endDate, POStatus? status)
        {
            return repo.SearchPurchaseOrdersProcess(employeeId, searchCriteria, startDate, endDate, status);
        }

        public List<Model.PurchaseOrder> GetPurchaseOrders(int searchBy, int employeeId, int purchaseOrderId, DateTime startDate, DateTime endDate, POStatus? status)
        {
            return repo.GetPurchaseOrders(searchBy, employeeId, purchaseOrderId, startDate, endDate, status);
        }

        public bool UpdateItemReason(Item item)
        {
            return repo.UpdateItemReason(item);
        }

        public decimal CalculateTotal(Model.PurchaseOrder po)
        {
            return CalculateSubtotal(po) + CalculateTaxAmount(po);
        }

        public decimal CalculateSubtotal(Model.PurchaseOrder po)
        {
            decimal subtotal = 0.0m;
            foreach (Item item in po.Items)
            {
                if (item.PurchaseOrderId != -1)
                {
                    subtotal += item.Price * item.Quantity;
                }
            }
            return subtotal;
        }

        public decimal CalculateTaxAmount(Model.PurchaseOrder po)
        {
            decimal subtotal = CalculateSubtotal(po);
            return subtotal * 0.15m;
        }

        private bool IsValidEntity(Model.PurchaseOrder po)
        {
            po.Errors = new List<Error>();
            ValidationContext context = new ValidationContext(po);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(po, context, results, true);

            foreach (ValidationResult r in results)
            {
                po.AddError(new Error(po.Errors.Count, r.ErrorMessage, "Model"));
            }

            return isValid;
        }

        public EmployeeLookup GetEmployeeName(int id)
        {
            return repo.GetEmployeeName(id);
        }

        public SupervisorLookup GetSupervisorName(int employeeId)
        {
            return repo.GetSupervisorName(employeeId);
        }

        private bool IsValid(Model.PurchaseOrder po)
        {
            List<bool> validations = new List<bool>();
            validations.Add(IsValidEntity(po));
            foreach (Item item in po.Items)
            {
                if (item.Status == ItemStatus.NoLongerRequired)
                {
                    ItemStatus status = GetItemStatus(item.ItemId);
                    if (status != ItemStatus.Pending)
                    {
                        validations.Add(false);
                        po.AddError(new Error(111, "The item status cannot be changed, it has already been processed", "Business"));
                    }
                    else
                    {
                        item.Quantity = 0;
                        item.Price = 0;
                        item.Description = "No longer needed";
                        item.Status = ItemStatus.Denied;
                    }
                }
            }

            if (po.PurchaseOrderId > 0)
            {
                PurchaseOrder poFromDatabase = GetPurchaseOrder(po.PurchaseOrderId);

                //if (po.IsProcess == false && poFromDatabase.Status == POStatus.UnderReview)
                //{
                //    validations.Add(false);
                //    po.Errors.Add(new Error(111, "This Purchase Order is currently under review and cannot be modified", "Business"));
                //}

                if (poFromDatabase.Status == POStatus.Closed)
                {
                    validations.Add(false);
                    po.Errors.Add(new Error(112, "This Purchase Order is closed and cannot be modified", "Business"));
                }
            }

            return validations.Contains(false) ? false : true;
        }

        private ItemStatus GetItemStatus(int itemId)
        {
            return repo.GetItemStatus(itemId);
        }

        public PurchaseOrder GetPurchaseOrder(int id)
        {
            return repo.GetPurchaseOrder(id);
        }

        public Model.PurchaseOrder MergeDuplicates(PurchaseOrder po)
        {
            var combinedItems = po.Items
    .GroupBy(item => item.Name)
    .Select(group => new Item { ItemId = group.First().ItemId, Name = group.Key, Description = group.First().Description, Price = group.First().Price, Location = group.First().Location, Status = group.First().Status, Justification = group.First().Justification, Quantity = group.Sum(item => item.Quantity), PurchaseOrderId = group.First().PurchaseOrderId })
    .ToList();
            po.Items = combinedItems;
            return po;
        }

        public List<PurchaseOrder> BrowseSearch(int employeeId, string purchaseOrderIdSearch, POStatus? poStatus, DateTime startDate, DateTime endDate)
        {
            return repo.BrowseSearch(employeeId, purchaseOrderIdSearch, poStatus, startDate, endDate);
        }
    }
}
