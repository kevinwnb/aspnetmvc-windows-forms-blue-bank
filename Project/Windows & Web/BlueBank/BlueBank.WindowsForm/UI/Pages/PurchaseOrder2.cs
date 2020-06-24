﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlueBank.Service;
using BlueBank.Model;

namespace BlueBank.WindowsForm.UI.Pages
{
    public partial class PurchaseOrder2 : PageControl
    {
        bool inCreateMode = true;
        PurchaseOrderService service = new PurchaseOrderService();
        Model.PurchaseOrder po = new Model.PurchaseOrder();
        List<Item> items = new List<Item>();
        bool isSupervisorEditing = false;

        public PurchaseOrder2()
        {
            InitializeComponent();
        }

        public static CreatePO _instance;

        public static CreatePO Instance
        {
            get
            {
                if (_instance == null || _instance.HasBeenClosed)
                {
                    _instance = new CreatePO();
                    _instance.Position = 0;
                }

                return _instance;
            }
        }

        public void btnClose_Click(object sender, EventArgs e)
        {
            _instance.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        public void AddItem()
        {
            try
            {
                if (txtItemName.Text != string.Empty && txtDescription.Text != string.Empty && txtPrice.Text != string.Empty && txtLocation.Text != string.Empty
                && txtItemStatus.Text != string.Empty && txtJustification.Text != string.Empty && txtQuantity.Text != string.Empty)
                {
                    if (decimal.TryParse(txtPrice.Text, out decimal result) && int.TryParse(txtQuantity.Text, out int result2))
                    {
                        if (!po.IsModifyItem)
                        {
                            Item item = new Item();
                            item.Name = txtItemName.Text;
                            item.Description = txtDescription.Text;
                            item.Price = Convert.ToDecimal(txtPrice.Text);
                            item.Location = txtLocation.Text;
                            ItemStatus itemStatus;
                            Enum.TryParse(txtItemStatus.Text, out itemStatus);
                            item.Status = itemStatus;
                            item.Justification = txtJustification.Text;
                            item.Quantity = Convert.ToInt32(txtQuantity.Text);
                            item.PurchaseOrderId = po.PurchaseOrderId;
                            po.Items.Add(item);
                        }
                        po.Items = service.MergeDuplicates(po).Items;




                        po.CreationDate = Convert.ToDateTime(txtCreationDate.Text);
                        po.EmployeeId = LoginData.EmployeeId;
                        po.Department = txtDepartment.Text;
                        POStatus pOStatus;
                        Enum.TryParse(txtPOStatus.Text, out pOStatus);
                        po.Status = pOStatus;
                        po.Subtotal = service.CalculateSubtotal(po);
                        po.Tax = service.CalculateTaxAmount(po);
                        po.TotalAfterTax = service.CalculateTotal(po);

                        string message = "";
                        int purchaseOrderId = po.PurchaseOrderId;
                        if (inCreateMode)
                        {
                            if (service.CreatePurchaseOrder(po))
                            {
                                foreach (Item i in po.Items)
                                {
                                    i.PurchaseOrderId = po.PurchaseOrderId;
                                }
                                if (purchaseOrderId == 0)
                                {
                                    message = $"The new generated id is: {po.PurchaseOrderId}";
                                    MessageBox.Show(message, "Purchase Order Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            if (service.UpdatePurchaseOrder(po))
                            {
                                po = service.GetPurchaseOrder(po.PurchaseOrderId);
                                MessageBox.Show("Purchase Order Updated", "Purchase Order Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        if (po.Errors.Count > 0)
                        {
                            string msg = "";
                            foreach (Error error in po.Errors)
                            {
                                msg += error.Description + "\n";
                            }
                            MessageBox.Show(msg);
                        }

                        po = service.GetPurchaseOrder(po.PurchaseOrderId);

                        foreach (Item i in po.Items.ToList())
                        {
                            i.subtotal = i.Price * i.Quantity;
                        }

                        BindingList<Item> itemList = new BindingList<Item>();
                        foreach (Item i in po.Items.ToList())
                        {
                            if (i.PurchaseOrderId != -1)
                            {
                                itemList.Add(i);
                            }
                        }
                        dgvItems.DataSource = null;
                        dgvItems.DataSource = itemList;
                        dgvItems.Columns["ItemId"].Visible = false;
                        dgvItems.Columns["PurchaseOrderId"].Visible = false;
                        dgvItems.Columns["Price"].DefaultCellStyle.Format = "c";
                        dgvItems.Columns["subtotal"].HeaderText = "Subtotal";
                        dgvItems.Columns["subtotal"].DefaultCellStyle.Format = "c";

                        txtSubtotal.Text = service.CalculateSubtotal(po).ToString("c2");
                        txtTax.Text = service.CalculateTaxAmount(po).ToString("c2");
                        txtTotalAfterTax.Text = service.CalculateTotal(po).ToString("c2");
                    }
                    else
                    {
                        MessageBox.Show("Price and/or Quantity are not numeric", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("All item fields are required", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        //private void CreatePO()
        //{
        //    po.CreationDate = Convert.ToDateTime(txtCreationDate.Text);
        //    po.EmployeeId = LoginData.EmployeeId;
        //    po.Department = txtDepartment.Text;
        //    POStatus pOStatus;
        //    Enum.TryParse(txtPOStatus.Text, out pOStatus);
        //    po.Status = pOStatus;
        //    decimal subtotal = 0.0m;
        //    decimal.TryParse(txtSubtotal.Text, out subtotal);
        //    po.Subtotal = subtotal;
        //    decimal tax = 0.0m;
        //    decimal.TryParse(txtTax.Text, out tax);
        //    po.Tax = tax;
        //    decimal total = 0.0m;
        //    decimal.TryParse(txtTotalAfterTax.Text, out total);
        //    po.TotalAfterTax = total;

        //    string message = "";

        //    if (service.CreatePurchaseOrder(po))
        //    {
        //        message = $"The new generated id is: {po.PurchaseOrderId}";
        //        MessageBox.Show(message, "Purchase Order Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        ResetForm();
        //    }
        //    else
        //    {
        //        foreach (Error error in po.Errors.OrderBy(err => err.Type))
        //        {

        //            message += $"Error Type: {error.Type}\nError Code : {error.Code:000}\nDescription: {error.Description}\n\n";
        //        }

        //        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnCreate_Click(object sender, EventArgs e)
        //{
        //    po.CreationDate = Convert.ToDateTime(txtCreationDate.Text);
        //    po.EmployeeId = LoginData.EmployeeId;
        //    po.Department = txtDepartment.Text;
        //    POStatus pOStatus;
        //    Enum.TryParse(txtPOStatus.Text, out pOStatus);
        //    po.Status = pOStatus;
        //    decimal subtotal = 0.0m;
        //    decimal.TryParse(txtSubtotal.Text, out subtotal);
        //    po.Subtotal = subtotal;
        //    decimal tax = 0.0m;
        //    decimal.TryParse(txtTax.Text, out tax);
        //    po.Tax = tax;
        //    decimal total = 0.0m;
        //    decimal.TryParse(txtTotalAfterTax.Text, out total);
        //    po.TotalAfterTax = total;

        //    string message = "";

        //    if (service.CreatePurchaseOrder(po))
        //    {
        //        message = $"Purchase Order created succesfuly. The new generated id is: {po.PurchaseOrderId}";
        //        MessageBox.Show(message, "Purchase Order Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        ResetForm();
        //    }
        //    else
        //    {
        //        foreach (Error error in po.Errors.OrderBy(err => err.Type))
        //        {

        //            message += $"Error Type: {error.Type}\nError Code : {error.Code:000}\nDescription: {error.Description}\n\n";
        //        }

        //        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvResults.DataSource = null;
            List<Model.PurchaseOrder> pos = new List<Model.PurchaseOrder>();

            // Check if search criteria is valid
            bool searchCriteriaOk = false;
            if (rdoById.Checked && txtSearch.Text.Length == 8)
            {
                pos = service.GetPurchaseOrders(1, LoginData.EmployeeId, Convert.ToInt32(txtSearch.Text), DateTime.Today, DateTime.Today, null);
                searchCriteriaOk = true;
            }
            else if (rdoById.Checked && txtSearch.Text.Length != 8)
            {
                MessageBox.Show("The purchase order id must be 8 digits long");
            }
            else if (rdoByDate.Checked && dtpStart.Value < dtpEnd.Value)
            {
                POStatus? status = null;
                if (rdoPending.Checked)
                {
                    status = POStatus.Pending;
                }
                if (rdoClosed.Checked)
                {
                    status = POStatus.Closed;
                }
                pos = service.GetPurchaseOrders(2, LoginData.EmployeeId, 0, dtpStart.Value, dtpEnd.Value, status);
                searchCriteriaOk = true;
            }
            else if (rdoByDate.Checked && !(dtpStart.Value < dtpEnd.Value))
            {
                MessageBox.Show("Start date must be less than end date");
            }

            if (searchCriteriaOk)
            {
                if (pos.Count > 0)
                {
                    if (LoginData.EmployeeType == EmployeeType.RegularEmployee)
                    {
                        foreach (var po in pos.ToList())
                        {
                            if (po.Status != POStatus.Pending && po.Status != POStatus.Closed)
                            {
                                pos.Remove(po);
                            }
                            if (po.EmployeeId != LoginData.EmployeeId)
                            {
                                pos.Remove(po);
                            }
                        }
                    }

                    dgvResults.DataSource = new BindingList<BlueBank.Model.PurchaseOrder>(pos);
                    dgvResults.Columns["TotalAfterTax"].DefaultCellStyle.Format = "c2";
                    foreach (DataGridViewColumn column in dgvResults.Columns)
                    {
                        if (column.Name != "PurchaseOrderId" && column.Name != "CreationDate" && column.Name != "TotalAfterTax")
                        {
                            column.Visible = false;
                        }

                        if (column.Name == "PurchaseOrderId")
                        {
                            column.HeaderText = "PO Number";
                        }

                        if (column.Name == "CreationDate")
                        {
                            column.HeaderText = "Date";
                        }

                        if (column.Name == "TotalAfterTax")
                        {
                            column.HeaderText = "Total";
                        }
                    }

                    if (dgvResults.Columns["Items"] != null)
                    {
                        dgvResults.Columns.Remove("Items");
                    }

                    dgvResults.Columns.Add("Items", "Items");
                    foreach (DataGridViewRow row in dgvResults.Rows)
                    {
                        string itemToAddToDgv = "";
                        int poId = Convert.ToInt32(row.Cells["PurchaseOrderId"].Value);
                        foreach (BlueBank.Model.PurchaseOrder purchaseOrder in pos)
                        {
                            if (purchaseOrder.PurchaseOrderId == poId)
                            {
                                foreach (Item item in purchaseOrder.Items)
                                {
                                    itemToAddToDgv += " *" + item.Name;
                                }
                            }
                        }
                        row.Cells["Items"].Value = itemToAddToDgv;
                    }

                    dgvResults.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("No Purchase Orders found");
                }
            }
        }

        //private void lstResults_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    po = service.GetPurchaseOrder(Convert.ToInt32(lstResults.SelectedItem));
        //    btnCreate.Enabled = false;
        //    btnUpdate.Enabled = po.Status == POStatus.Closed || po.Status == POStatus.UnderReview ? false : true;
        //    btnRemoveItems.Visible = true;
        //    btnReset.Enabled = true;
        //    txtCreationDate.Text = po.CreationDate.ToString();
        //    txtEmployeeName.Text = service.GetEmployeeName(po.EmployeeId).EmployeeName;
        //    txtDepartment.Text = po.Department;
        //    txtSupervisorName.Text = service.GetSupervisorName(po.EmployeeId).FullName;
        //    txtPOStatus.Text = po.Status.ToString();
        //    txtSubtotal.Text = po.Subtotal.ToString();
        //    txtTax.Text = po.Tax.ToString();
        //    txtTotalAfterTax.Text = po.TotalAfterTax.ToString();

        //    BindingList<Item> itemList = new BindingList<Item>(po.Items);

        //    dgvItems.DataSource = itemList;
        //    dgvItems.Columns["ItemId"].Visible = false;

        //    txtSubtotal.Text = service.CalculateSubtotal(po).ToString();
        //    txtTax.Text = service.CalculateTaxAmount(po).ToString();
        //    txtTotalAfterTax.Text = service.CalculateTotal(po).ToString();
        //}

        private void rdoById_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSearchMethod();
        }

        private void rdoByDate_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSearchMethod();
        }

        private void ChangeSearchMethod()
        {
            if (rdoById.Checked)
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                txtSearch.Enabled = true;
                rdoPending.Enabled = false;
                rdoClosed.Enabled = false;
                rdoAll.Enabled = false;
            }
            else
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
                txtSearch.Enabled = false;
                rdoPending.Enabled = true;
                rdoClosed.Enabled = true;
                rdoAll.Enabled = true;
            }
        }

        //private void btnRemoveItems_Click(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow row in dgvItems.Rows)
        //    {
        //        if (row.Selected)
        //        {
        //            foreach (Item item in po.Items.ToList())
        //            {
        //                if (item.ItemId == Convert.ToInt32(row.Cells["ItemId"].Value) && item.ItemId > 0)
        //                {
        //                    item.Status = ItemStatus.NoLongerRequired;
        //                }
        //                else if (item.ItemId == Convert.ToInt32(row.Cells["ItemId"].Value) && item.ItemId == 0)
        //                {
        //                    po.Items.Remove(item);
        //                }
        //            }

        //            dgvItems.Rows.Remove(row);
        //        }
        //    }

        //    txtSubtotal.Text = service.CalculateSubtotal(po).ToString();
        //    txtTax.Text = service.CalculateTaxAmount(po).ToString();
        //    txtTotalAfterTax.Text = service.CalculateTotal(po).ToString();
        //}

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            inCreateMode = true;
            ResetItemForm();
            btnNotRequired.Visible = false;
            //foreach (Control control in this.Controls)
            //{
            //    if (control is GroupBox)
            //    {
            //        foreach (Control c in control.Controls)
            //        {
            //            if (c is TextBox)
            //            {
            //                ((TextBox)c).Clear();
            //            }
            //        }
            //    }
            //}
            rdoById.Checked = true;
            txtEmployeeName.Text = LoginData.EmployeeName;
            txtSupervisorName.Text = service.GetSupervisorName(LoginData.EmployeeId).FullName.ToString();
            txtDepartment.Text = LoginData.Department;
            txtItemStatus.Text = "Pending";
            txtPOStatus.Text = "Pending";
            txtCreationDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtSubtotal.Text = "$0.00";
            txtTax.Text = "$0.00";
            txtTotalAfterTax.Text = "$0.00";
            dgvItems.DataSource = null;
            dgvResults.DataSource = null;
            if (dgvResults.Columns.Contains("Items"))
            {
                dgvResults.Columns.Remove("Items");
            }
            dgvItems.DataSource = null;
            txtSearch.Text = string.Empty;
            lblTitle.Text = "CREATE PURCHASE ORDER";
            po = new Model.PurchaseOrder();
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    string message = "";
        //    if (service.UpdatePurchaseOrder(po))
        //    {
        //        MessageBox.Show("Update was successful");
        //        ResetForm();
        //    }
        //    else
        //    {
        //        foreach (Error error in po.Errors.OrderBy(err => err.Type))
        //        {

        //            message += $"Error Type: {error.Type}\nError Code : {error.Code:000}\nDescription: {error.Description}\n\n";
        //        }

        //        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.CurrentRow != null)
            {
                inCreateMode = false;
                po = service.GetPurchaseOrder(Convert.ToInt32(dgvResults.CurrentRow.Cells["PurchaseOrderId"].Value));

                if (po.EmployeeId != LoginData.EmployeeId)
                {
                    isSupervisorEditing = true;
                    btnResetItem.Enabled = false;
                    btnAddItem.Enabled = false;
                    txtItemName.Enabled = false;
                    txtDescription.Enabled = false;
                    txtJustification.Enabled = false;
                    txtReason.Enabled = true;
                }
                else
                {
                    isSupervisorEditing = false;
                    btnResetItem.Enabled = true;
                    btnAddItem.Enabled = true;
                    btnResetItem.Enabled = true;
                    btnAddItem.Enabled = true;
                    txtItemName.Enabled = true;
                    txtDescription.Enabled = true;
                    txtJustification.Enabled = true;
                    txtReason.Enabled = false;
                }

                btnNotRequired.Visible = true;
                lblTitle.Text = "MODIFY PURCHASE ORDER";
                btnReset.Enabled = true;
                txtCreationDate.Text = po.CreationDate.ToString("yyyy-MM-dd");
                txtEmployeeName.Text = service.GetEmployeeName(po.EmployeeId).EmployeeName;
                txtDepartment.Text = po.Department;
                txtSupervisorName.Text = service.GetSupervisorName(po.EmployeeId).FullName;
                txtPOStatus.Text = po.Status.ToString();
                txtSubtotal.Text = po.Subtotal.ToString("c2");
                txtTax.Text = po.Tax.ToString("c2");
                txtTotalAfterTax.Text = po.TotalAfterTax.ToString("c2");
                panel2.Visible = true;

                foreach (Item item in po.Items)
                {
                    item.subtotal = item.Price * item.Quantity;
                }
                BindingList<Item> itemList = new BindingList<Item>(po.Items);

                dgvItems.DataSource = itemList;
                dgvItems.Columns["ItemId"].Visible = false;
                dgvItems.Columns["Status"].Visible = po.Status == POStatus.UnderReview ? false : true;
                dgvItems.Columns["Price"].DefaultCellStyle.Format = "c2";
                dgvItems.Columns["subtotal"].DefaultCellStyle.Format = "c2";
                dgvItems.Columns["subtotal"].HeaderText = "Subtotal";
                dgvItems.Columns["PurchaseOrderId"].HeaderText = "PO Number";

                txtSubtotal.Text = service.CalculateSubtotal(po).ToString("c2");
                txtTax.Text = service.CalculateTaxAmount(po).ToString("c2");
                txtTotalAfterTax.Text = service.CalculateTotal(po).ToString("c2");

                lblPOStatus.Text = po.Status.ToString();
            }
        }

        private void btnNotRequired_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Selected)
                {
                    foreach (Item item in po.Items.ToList())
                    {
                        if (item.ItemId == Convert.ToInt32(row.Cells["ItemId"].Value))
                        {
                            item.Status = ItemStatus.NoLongerRequired;
                        }
                    }
                }
            }
            service.UpdatePurchaseOrder(po);
            if (po.Errors.Count > 0)
            {
                string msg = string.Empty;
                foreach (Error error in po.Errors)
                {
                    msg += error.Description;
                }
                MessageBox.Show(msg);
            }
            else
            {
                BindingList<Item> itemList = new BindingList<Item>(po.Items);
                dgvItems.DataSource = itemList;
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (!inCreateMode && dgvItems.Rows.Count > 0)
            {
                foreach (Item item in po.Items)
                {
                    if (item.ItemId == Convert.ToInt32(dgvItems.CurrentRow.Cells["ItemId"].Value))
                    {
                        txtItemName.Text = item.Name;
                        txtDescription.Text = item.Description;
                        txtPrice.Text = item.Price.ToString();
                        txtQuantity.Text = item.Quantity.ToString();
                        txtLocation.Text = item.Location;
                        txtJustification.Text = item.Justification;
                        txtItemStatus.Text = item.Status.ToString();
                        txtItemId.Text = item.ItemId.ToString();
                        txtReason.Text = item.Reason;
                    }
                }
                btnAddItem.Enabled = false;
                btnModifyItem.Enabled = true;
            }
        }

        private void btnModifyItem_Click(object sender, EventArgs e)
        {
            po.IsModifyItem = true;
            foreach (Item item in po.Items.ToList())
            {
                if (isSupervisorEditing && item.Status == ItemStatus.Pending)
                {
                    item.Reason = txtReason.Text;
                    service.UpdateItemReason(item);
                }

                if (item.ItemId == Convert.ToInt32(txtItemId.Text) && item.Status == ItemStatus.Pending)
                {
                    item.Name = txtItemName.Text;
                    item.Description = txtDescription.Text;
                    item.Price = Convert.ToDecimal(txtPrice.Text);
                    item.Quantity = Convert.ToInt32(txtQuantity.Text);
                    item.Location = txtLocation.Text;
                    item.Justification = txtJustification.Text;
                    AddItem();
                    po.IsModifyItem = true;
                    if (!po.IsModifyItem)
                    {
                        ResetItemForm();
                    }
                }

                if (item.Status != ItemStatus.Pending)
                {
                    MessageBox.Show("The item has been processed and cannot be modified");
                }
            }
        }

        private void ResetItemForm()
        {
            po.IsModifyItem = false;
            txtItemName.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtLocation.Text = "";
            txtJustification.Text = "";
            txtItemStatus.Text = "Pending";
            txtItemId.Text = "";

            btnAddItem.Enabled = true;
            btnModifyItem.Enabled = false;
            panel2.Visible = false;
        }

        private void btnResetItem_Click(object sender, EventArgs e)
        {
            ResetItemForm();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void CreatePO_Load(object sender, EventArgs e)
        {

        }
    }
}
