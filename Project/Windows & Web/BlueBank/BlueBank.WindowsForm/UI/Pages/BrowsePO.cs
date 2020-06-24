using System;
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
    public partial class BrowsePO : PageControl
    {
        PurchaseOrderService service = new PurchaseOrderService();
        Model.PurchaseOrder po = new Model.PurchaseOrder();
        List<Item> items = new List<Item>();

        public BrowsePO()
        {
            InitializeComponent();
        }

        public static BrowsePO _instance;

        public static BrowsePO Instance
        {
            get
            {
                if (_instance == null || _instance.HasBeenClosed)
                {
                    _instance = new BrowsePO();
                    _instance.Position = 0;
                }

                return _instance;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _instance.Close();
        }

        private void BrowsePO_Load(object sender, EventArgs e)
        {
            rdoOpen.Checked = true;
            dtpStartDate.Value = DateTimePicker.MinimumDateTime;
            dtpEndDate.Value = DateTime.Now;
            Search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            List<Error> errors = new List<Error>();

            List<BlueBank.Model.PurchaseOrder> pos = new List<BlueBank.Model.PurchaseOrder>();

            POStatus? poStatus = POStatus.Pending;

            if (rdoClosed.Checked)
            {
                poStatus = POStatus.Closed;
            }

            if (rdoBoth.Checked)
            {
                poStatus = null;
            }

            string purchaseOrderIdSearch = txtPoNumberSearch.Text;

            if (chkSearchByPoNumber.Checked)
            {
                if (!string.IsNullOrEmpty(txtPoNumberSearch.Text))
                {
                    if (txtPoNumberSearch.Text.Length != 8)
                    {
                        errors.Add(new Error(153, "The purchase order number must be 8 digits long", "Model"));
                    }
                    if (!int.TryParse(purchaseOrderIdSearch, out int result))
                    {
                        errors.Add(new Error(158, "The purchase order number must be numeric", "Model"));
                    }
                }
                else
                {
                    errors.Add(new Error(157, "The PO Number is required", "Model"));
                }
            }
            else
            {
                purchaseOrderIdSearch = "";
            }

            if (errors.Count == 0)
            {
                pos = service.BrowseSearch(LoginData.EmployeeId, purchaseOrderIdSearch, poStatus, dtpStartDate.Value, dtpEndDate.Value);
                if (pos.Count > 0)
                {
                    BindingList<PurchaseOrder> poList = new BindingList<PurchaseOrder>(pos);
                    dgvResults.DataSource = null;
                    dgvResults.DataSource = poList;
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

                        if (column.Name == "DisplayItems")
                        {
                            column.HeaderText = "Items";
                        }
                    }

                    foreach (DataGridViewRow row in dgvResults.Rows)
                    {
                        string itemToAddToDgv = "";
                        int poId = Convert.ToInt32(row.Cells["PurchaseOrderId"].Value);
                        foreach (PurchaseOrder purchaseOrder in pos.ToList())
                        {
                            if (purchaseOrder.PurchaseOrderId == poId)
                            {
                                foreach (Item item in purchaseOrder.Items)
                                {
                                    itemToAddToDgv += " *" + item.Name;
                                }
                            }
                        }
                        row.Cells["DisplayItems"].Value = itemToAddToDgv;
                    }
                }
                else
                {
                    ResetForm();
                    MessageBox.Show("No purchase orders found");
                }
            }
            else
            {
                string msg = "";
                foreach (Error error in errors)
                {
                    msg += "\n" + error.Description;
                }
                MessageBox.Show(msg);
            }
        }

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.CurrentRow != null)
            {
                po = service.GetPurchaseOrder(Convert.ToInt32(dgvResults.CurrentRow.Cells["PurchaseOrderId"].Value));
                txtPoNumber.Text = po.PurchaseOrderId.ToString();
                txtCreationDate.Text = po.CreationDate.ToString("yyyy-MM-dd");
                txtDepartment.Text = po.Department;
                txtEmployeeName.Text = service.GetEmployeeName(po.EmployeeId).EmployeeName;
                txtSupervisorName.Text = service.GetSupervisorName(po.EmployeeId).FullName;
                txtStatus.Text = po.Status.ToString();

                txtSubtotal.Text = service.CalculateSubtotal(po).ToString("c");
                txtTaxAmount.Text = service.CalculateTaxAmount(po).ToString("c");
                txtTotal.Text = service.CalculateTotal(po).ToString("c");
                txtTaxRate.Text = po.TaxRate.ToString("p");

                BindingList<Item> itemList = new BindingList<Item>(po.Items);
                foreach (Item item in itemList.ToList())
                {
                    item.subtotal = item.Quantity * item.Price;
                }
                dgvItems.DataSource = null;
                dgvItems.DataSource = itemList;
                dgvItems.Columns["ItemId"].Visible = false;
                dgvItems.Columns["subtotal"].HeaderText = "Subtotal";
                dgvItems.Columns["Price"].DefaultCellStyle.Format = "c";
                dgvItems.Columns["subtotal"].DefaultCellStyle.Format = "c";
                dgvItems.Columns["PurchaseOrderId"].HeaderText = "PO Number";
                dgvItems.Columns["DisplayStatus"].HeaderText = "Status";
                dgvItems.Columns["DisplayStatus"].Visible = false;
                
                if (po.Status == POStatus.UnderReview && LoginData.EmployeeId == po.EmployeeId)
                {
                    dgvItems.Columns["Status"].Visible = false;
                    dgvItems.Columns["DisplayStatus"].Visible = true;
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        foreach (Item item in po.Items.ToList())
                        {
                            if (item.ItemId == Convert.ToInt32(row.Cells["ItemId"].Value))
                            {
                                if (item.Status != ItemStatus.Pending && item.Description != "No longer needed")
                                {
                                    row.Cells["DisplayStatus"].Value = "Under Review";
                                    row.Cells["Reason"].Value = "";
                                }
                                else if (item.Description == "No longer needed")
                                {
                                    row.Cells["DisplayStatus"].Value = "Denied";
                                }
                                else
                                {
                                    row.Cells["DisplayStatus"].Value = "Pending";
                                }
                            }
                        }
                    }
                }
            }
        }

        private void chkSearchByPoNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchByPoNumber.Checked)
            {
                txtPoNumberSearch.Enabled = true;
                grpDate.Enabled = false;
                grpStatus.Enabled = false;
            }
            else
            {
                txtPoNumberSearch.Enabled = false;
                grpDate.Enabled = true;
                grpStatus.Enabled = true;
            }
        }

        private void ResetForm()
        {
            po = new PurchaseOrder();
            dgvItems.Rows.Clear();
            dgvItems.DataSource = null;
            dgvResults.Rows.Clear();
            dgvResults.DataSource = null;
            if (dgvResults.Columns.Contains("Items"))
            {
                dgvResults.Columns.Remove("Items");
            }
            txtEmployeeName.Text = "";
            txtSupervisorName.Text = "";
            txtStatus.Text = "";
            txtDepartment.Text = "";
            txtPoNumber.Text = "";
            txtCreationDate.Text = "";
            txtSubtotal.Text = "$0.00";
            txtTaxAmount.Text = "$0.00";
            txtTotal.Text = "$0.00";
        }
    }
}
