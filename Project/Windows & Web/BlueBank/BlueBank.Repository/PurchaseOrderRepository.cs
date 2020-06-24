using BlueBank.DAL;
using BlueBank.Model;
using BlueBank.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Repository
{
    public class PurchaseOrderRepository
    {

        DataAccess db = new DataAccess();

        public string GetEmployeeEmail(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("EmployeeId", id, SqlDbType.Int)
            };
            return db.ExecuteScaler("GetEmployeeEmail", CommandType.StoredProcedure, parms).ToString();
        }

        public bool CreatePurchaseOrder(Model.PurchaseOrder po)
        {
            if (po.PurchaseOrderId == 0)
            {
                List<bool> statuses = new List<bool>();

                List<ParmStruct> parms = new List<ParmStruct>()
                {
                    new ParmStruct("@PurchaseOrderId", 0, SqlDbType.Int, ParameterDirection.InputOutput),
                    new ParmStruct("@CreationDate", po.CreationDate, SqlDbType.Date),
                    new ParmStruct("@EmployeeId", po.EmployeeId, SqlDbType.Int),
                    new ParmStruct("@Department", po.Department, SqlDbType.NVarChar, size:30),
                    new ParmStruct("@Status", po.Status, SqlDbType.Int),
                    new ParmStruct("@Subtotal", po.Subtotal, SqlDbType.Decimal),
                    new ParmStruct("@Tax", po.Tax, SqlDbType.Decimal),
                    new ParmStruct("@TotalAfterTax", po.TotalAfterTax, SqlDbType.Decimal),
                    new ParmStruct("@ItemName", po.Items[0].Name, SqlDbType.NVarChar, size:50),
                    new ParmStruct("@ItemDescription", po.Items[0].Description, SqlDbType.NVarChar, size:255),
                    new ParmStruct("@ItemPrice", po.Items[0].Price, SqlDbType.Decimal),
                    new ParmStruct("@ItemLocation", po.Items[0].Location, SqlDbType.NVarChar, size:255),
                    new ParmStruct("@ItemStatus", po.Items[0].Status, SqlDbType.Int),
                    new ParmStruct("@ItemJustification", po.Items[0].Justification, SqlDbType.NVarChar, size:255),
                    new ParmStruct("@ItemQuantity", po.Items[0].Quantity, SqlDbType.Int)
                };

                db.ExecuteNonQuery("PO_Insert", CommandType.StoredProcedure, parms);

                //po.PurchaseOrderId = Convert.ToInt32(db.ExecuteScaler("SELECT MAX(PurchaseOrderId) FROM PurchaseOrder", CommandType.Text));
                po.PurchaseOrderId = Convert.ToInt32(parms[0].Value);

                return statuses.Contains(false) ? false : true;
            }
            else
            {
                List<bool> statuses = new List<bool>();
                List<ParmStruct> parms1 = new List<ParmStruct>()
                {
                    new ParmStruct("@PurchaseOrderId", po.PurchaseOrderId, SqlDbType.Int),
                    new ParmStruct("@Subtotal", po.Subtotal, SqlDbType.Decimal),
                    new ParmStruct("@Tax", po.Tax, SqlDbType.Decimal),
                    new ParmStruct("@TotalAfterTax", po.TotalAfterTax, SqlDbType.Decimal)
                };

                statuses.Add(db.ExecuteNonQuery("PO_UpdateCreate", CommandType.StoredProcedure, parms1) > 0);

                foreach (Item item in po.Items)
                {
                    List<ParmStruct> parms = new List<ParmStruct>()
                    {
                        new ParmStruct("@PurchaseOrderId", po.PurchaseOrderId, SqlDbType.Int),
                        new ParmStruct("@ItemName", item.Name, SqlDbType.NVarChar, size:50)
                    };
                    DataTable dt = db.Execute("GetItem", CommandType.StoredProcedure, parms);
                    Item i = dt.Rows.Count > 0 ? PopulateItemObject(dt.Rows[0]) : null;
                    if (i != null && i.Name == item.Name)
                    {
                        statuses.Add(ItemUpdate(item));
                    }
                    else
                    {
                        statuses.Add(ItemInsert(item));
                    }
                }
                return statuses.Contains(false) ? false : true;
            }
        }

        public bool UpdatePurchaseOrder(Model.PurchaseOrder po)
        {
            List<bool> statuses = new List<bool>();

            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@TimeStamp", po.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput),
                new ParmStruct("@PurchaseOrderId", po.PurchaseOrderId, SqlDbType.Int),
                new ParmStruct("@Status", po.Status, SqlDbType.Int),
                new ParmStruct("@Subtotal", po.Subtotal, SqlDbType.Decimal),
                new ParmStruct("@Tax", po.Tax, SqlDbType.Decimal),
                new ParmStruct("@TotalAfterTax", po.TotalAfterTax, SqlDbType.Decimal)
            };

            statuses.Add(db.ExecuteNonQuery("PO_Update", CommandType.StoredProcedure, parms) > 0);

            po.TimeStamp = (byte[])(parms[0].Value);

            foreach (Item item in po.Items)
            {
                if (item.ItemId == 0)
                {
                    statuses.Add(ItemInsert(item));
                }
                else
                {
                    statuses.Add(ItemUpdate(item));
                }
            }

            return statuses.Contains(false) ? false : true;
        }

        public List<PurchaseOrderDTO> SearchPurchaseOrdersProcess(int employeeId, string searchCriteria, DateTime? startDate, DateTime? endDate, POStatus? status)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@EmployeeId", employeeId, SqlDbType.Int));
            if (!string.IsNullOrEmpty(searchCriteria))
            {
                parms.Add(new ParmStruct("@SearchCriteria", searchCriteria, SqlDbType.NVarChar, size: 255));
            }
            if (startDate != null && endDate != null)
            {
                parms.Add(new ParmStruct("@StartDate", startDate, SqlDbType.Date));
                parms.Add(new ParmStruct("@EndDate", endDate, SqlDbType.Date));
            }
            if (status != null)
            {
                parms.Add(new ParmStruct("@Status", status, SqlDbType.Int));
            }
            DataTable dt = db.Execute("PO_SearchProcess", CommandType.StoredProcedure, parms);
            List<Model.PurchaseOrderDTO> pos = new List<Model.PurchaseOrderDTO>();
            foreach (DataRow row in dt.Rows)
            {
                pos.Add(PopulatePurchaseOrderDTOObject(row));
            }

            return pos;
        }

        public ItemStatus GetItemStatus(int itemId)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("ItemId", itemId, SqlDbType.Int)
            };
            return (ItemStatus)(Convert.ToInt32(db.ExecuteScaler("GetItemStatus", CommandType.StoredProcedure, parms)));
        }

        public bool ItemUpdate(Item item)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@ItemId", item.ItemId, SqlDbType.Int),
                new ParmStruct("@Name", item.Name, SqlDbType.NVarChar, size:50),
                new ParmStruct("@Description", item.Description, SqlDbType.NVarChar, size:255),
                new ParmStruct("@Price", item.Price, SqlDbType.Decimal),
                new ParmStruct("@Location", item.Location, SqlDbType.NVarChar, size:255),
                new ParmStruct("@Status", item.Status, SqlDbType.Int),
                new ParmStruct("@Justification", item.Justification, SqlDbType.NVarChar, size:255),
                new ParmStruct("@Quantity", item.Quantity, SqlDbType.Int),
                new ParmStruct("@PurchaseOrderId", item.PurchaseOrderId, SqlDbType.Int)
            };
            bool result = db.ExecuteNonQuery("Item_Update", CommandType.StoredProcedure, parms) > 0;
            return result;
        }

        public bool ItemInsert(Item item)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@Name", item.Name, SqlDbType.NVarChar, size:50),
                new ParmStruct("@Description", item.Description, SqlDbType.NVarChar, size:255),
                new ParmStruct("@Price", item.Price, SqlDbType.Decimal),
                new ParmStruct("@Location", item.Location, SqlDbType.NVarChar, size:255),
                new ParmStruct("@Status", item.Status, SqlDbType.Int),
                new ParmStruct("@Justification", item.Justification, SqlDbType.NVarChar, size:255),
                new ParmStruct("@Quantity", item.Quantity, SqlDbType.Int),
                new ParmStruct("@PurchaseOrderId", item.PurchaseOrderId, SqlDbType.Int)
            };
            bool result = db.ExecuteNonQuery("Item_Insert", CommandType.StoredProcedure, parms) > 0;
            return result;
        }

        public bool UpdateItemReason(Item item)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("ItemId", item.ItemId, SqlDbType.Int),
                new ParmStruct("Reason", item.Reason, SqlDbType.NVarChar, size:255)
            };

            return db.ExecuteNonQuery("UpdateItemReason", CommandType.StoredProcedure, parms) > 0;
        }

        public List<PurchaseOrder> GetPurchaseOrders(int searchBy, int employeeId, int purchaseOrderId, DateTime startDate, DateTime endDate, POStatus? status)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@SearchBy", searchBy, SqlDbType.Int),
                new ParmStruct("@PurchaseOrderId", purchaseOrderId, SqlDbType.Int),
                new ParmStruct("@EmployeeId", employeeId, SqlDbType.Int),
                new ParmStruct("@StartDate", startDate, SqlDbType.Date),
                new ParmStruct("@EndDate", endDate, SqlDbType.Date)
            };
            if (status != null)
            {
                parms.Add(new ParmStruct("@Status", status, SqlDbType.Int));
            }
            DataTable dt = db.Execute("PO_Search", CommandType.StoredProcedure, parms);
            List<PurchaseOrder> pos = new List<PurchaseOrder>();
            foreach (DataRow row in dt.Rows)
            {
                pos.Add(PopulatePurchaseOrderObjectPartial(row));
            }

            // Get also the items associated with each purchase order in the list
            foreach (PurchaseOrder purchaseOrder in pos)
            {
                List<Item> items = new List<Item>();
                List<ParmStruct> itemParms = new List<ParmStruct>()
                {
                    new ParmStruct("@PurchaseOrderId", purchaseOrder.PurchaseOrderId, SqlDbType.Int)
                };
                DataTable itemsTable = db.Execute("PO_GetItems", CommandType.StoredProcedure, itemParms);
                foreach (DataRow row in itemsTable.Rows)
                {
                    items.Add(PopulateItemObject(row));
                }
                purchaseOrder.Items = items;
            }

            return pos;
        }

        public PurchaseOrder GetPurchaseOrder(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@PurchaseOrderId", id, SqlDbType.Int)
            };
            DataTable dt = db.Execute("PO_GetById", CommandType.StoredProcedure, parms);
            PurchaseOrder po = PopulatePurchaseOrderObject(dt.Rows[0]);
            dt = db.Execute("PO_GetItems", CommandType.StoredProcedure, parms);
            foreach (DataRow row in dt.Rows)
            {
                po.Items.Add(PopulateItemObject(row));
            }

            return po;
        }

        public EmployeeLookup GetEmployeeName(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", id, SqlDbType.Int)
            };

            return new EmployeeLookup() { EmployeeName = db.ExecuteScaler("GetEmployeeName", CommandType.StoredProcedure, parms).ToString() };
        }

        public SupervisorLookup GetSupervisorName(int employeeId)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", employeeId, SqlDbType.Int)
            };

            return new SupervisorLookup() { FullName = db.ExecuteScaler("GetSupervisorName", CommandType.StoredProcedure, parms).ToString() };
        }

        public List<PurchaseOrder> BrowseSearch(int employeeId, string purchaseOrderIdSearch, POStatus? poStatus, DateTime startDate, DateTime endDate)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", employeeId, SqlDbType.Int),
                new ParmStruct("@PurchaseOrderIdSearch", purchaseOrderIdSearch == string.Empty ? null : purchaseOrderIdSearch, SqlDbType.NVarChar, size:255),
                new ParmStruct("@POStatus", poStatus, SqlDbType.Int),
                new ParmStruct("@StartDate", startDate, SqlDbType.Date),
                new ParmStruct("@EndDate", endDate, SqlDbType.Date)
            };

            DataTable dt = db.Execute("PO_Browse_Search", CommandType.StoredProcedure, parms);

            List<PurchaseOrder> pos = new List<PurchaseOrder>();
            foreach (DataRow row in dt.Rows)
            {
                pos.Add(PopulatePurchaseOrderObject(row));
            }

            // Get also the items associated with each purchase order in the list
            foreach (PurchaseOrder purchaseOrder in pos)
            {
                List<Item> items = new List<Item>();
                List<ParmStruct> itemParms = new List<ParmStruct>()
                {
                    new ParmStruct("@PurchaseOrderId", purchaseOrder.PurchaseOrderId, SqlDbType.Int)
                };
                DataTable itemsTable = db.Execute("PO_GetItems", CommandType.StoredProcedure, itemParms);
                foreach (DataRow row in itemsTable.Rows)
                {
                    items.Add(PopulateItemObject(row));
                }
                purchaseOrder.Items = items;
            }

            return pos;
        }

        //public List<Item> GetItems()
        //{
        //    List<Item> items = new List<Item>();
        //    DataTable dt = db.Execute("GetItems", CommandType.StoredProcedure);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        items.Add(PopulateItemObject(row));
        //    }
        //    return items;
        //}

        private Item PopulateItemObject(DataRow row)
        {
            return new Item()
            {
                ItemId = Convert.ToInt32(row["ItemId"]),
                Name = row["Name"].ToString(),
                Description = row["Description"].ToString(),
                Price = Convert.ToDecimal(row["Price"]),
                Location = row["Location"].ToString(),
                Status = (ItemStatus)row["Status"],
                Justification = row["Justification"].ToString(),
                Quantity = Convert.ToInt32(row["Quantity"]),
                PurchaseOrderId = Convert.ToInt32(row["PurchaseOrderId"]),
                Reason = row["Reason"].ToString()
            };
        }

        private PurchaseOrderDTO PopulatePurchaseOrderDTOObject(DataRow row)
        {
            return new PurchaseOrderDTO()
            {
                PurchaseOrderId = Convert.ToInt32(row["PurchaseOrderId"]),
                CreationDate = Convert.ToDateTime(row["CreationDate"]),
                EmployeeName = row["Name"].ToString(),
                Total = Convert.ToDecimal(row["TotalAfterTax"])
            };
        }

        private PurchaseOrder PopulatePurchaseOrderObjectPartial(DataRow row)
        {
            return new PurchaseOrder()
            {
                PurchaseOrderId = Convert.ToInt32(row["PurchaseOrderId"]),
                CreationDate = Convert.ToDateTime(row["CreationDate"]),
                EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                TotalAfterTax = Convert.ToDecimal(row["TotalAfterTax"])
            };
        }

        private Model.PurchaseOrder PopulatePurchaseOrderObject(DataRow row)
        {
            return new Model.PurchaseOrder()
            {
                TimeStamp = (byte[])row["TimeStamp"],
                PurchaseOrderId = Convert.ToInt32(row["PurchaseOrderId"]),
                CreationDate = Convert.ToDateTime(row["CreationDate"]),
                EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                Department = row["Department"].ToString(),
                Status = (POStatus)row["Status"],
                Subtotal = Convert.ToDecimal(row["Subtotal"]),
                Tax = Convert.ToDecimal(row["Tax"]),
                TotalAfterTax = Convert.ToDecimal(row["TotalAfterTax"])
            };
        }
    }
}

