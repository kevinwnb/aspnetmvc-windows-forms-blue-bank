using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlueBank.Model;
using BlueBank.Service;

namespace BlueBank.WindowsForm.UI.Pages
{
    public partial class CreatePO : PageControl
    {
        bool inCreateMode = true;
        PurchaseOrderService service = new PurchaseOrderService();
        PurchaseOrder po = new PurchaseOrder();
        List<Item> items = new List<Item>();
        bool isSupervisorEditing = false;

        public CreatePO()
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

        private void CreatePO_Load(object sender, EventArgs e)
        {
            ResetForm();
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

        public void AddItem()
        {
            try
            {
                if (txtItemName.Text != string.Empty && txtDescription.Text != string.Empty && txtPrice.Text != string.Empty && txtLocation.Text != string.Empty
                && txtJustification.Text != string.Empty && txtQuantity.Text != string.Empty)
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
                            ItemStatus itemStatus = ItemStatus.Pending;
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
                        POStatus pOStatus = POStatus.Pending;
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
                        dgvItems.Columns["DisplayStatus"].Visible = false;

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
                    string msg = "";
                    if (string.IsNullOrWhiteSpace(txtItemName.Text))
                    {
                        msg += "\nItem name field is required";
                    }
                    if (string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        msg += "\nItem description field is required";
                    }
                    if (string.IsNullOrWhiteSpace(txtPrice.Text))
                    {
                        msg += "\nItem price field is required";
                    }
                    if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                    {
                        msg += "\nItem quantity field is required";
                    }
                    if (string.IsNullOrWhiteSpace(txtLocation.Text))
                    {
                        msg += "\nItem location field is required";
                    }
                    if (string.IsNullOrWhiteSpace(txtJustification.Text))
                    {
                        msg += "\nItem justification field is required";
                    }
                    MessageBox.Show(msg, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            inCreateMode = true;
            ResetItemForm();
            txtEmployeeName.Text = LoginData.EmployeeName;
            txtSupervisorName.Text = service.GetSupervisorName(LoginData.EmployeeId).FullName.ToString();
            txtDepartment.Text = LoginData.Department;
            txtCreationDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtSubtotal.Text = "$0.00";
            txtTax.Text = "$0.00";
            txtTotalAfterTax.Text = "$0.00";
            dgvItems.DataSource = null;
            dgvItems.DataSource = null;
            lblTitle.Text = "CREATE PURCHASE ORDER";
            po = new PurchaseOrder();
        }

        //private void dgvItems_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (!inCreateMode && dgvItems.Rows.Count > 0)
        //    {
        //        foreach (Item item in po.Items)
        //        {
        //            if (item.ItemId == Convert.ToInt32(dgvItems.CurrentRow.Cells["ItemId"].Value))
        //            {
        //                txtItemName.Text = item.Name;
        //                txtDescription.Text = item.Description;
        //                txtPrice.Text = item.Price.ToString();
        //                txtQuantity.Text = item.Quantity.ToString();
        //                txtLocation.Text = item.Location;
        //                txtJustification.Text = item.Justification;
        //                txtItemStatus.Text = item.Status.ToString();
        //                txtItemId.Text = item.ItemId.ToString();
        //                txtReason.Text = item.Reason;
        //            }
        //        }
        //        btnAddItem.Enabled = false;
        //        btnModifyItem.Enabled = true;
        //    }
        //}

        private void ResetItemForm()
        {
            po.IsModifyItem = false;
            txtItemName.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtLocation.Text = "";
            txtJustification.Text = "";

            btnAddItem.Enabled = true;
        }

        private void btnResetItem_Click(object sender, EventArgs e)
        {
            ResetItemForm();
        }
    }
}
