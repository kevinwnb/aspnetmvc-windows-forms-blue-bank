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
    public partial class ProcessPO : PageControl
    {
        PurchaseOrderService service = new PurchaseOrderService();
        Model.PurchaseOrder po = new Model.PurchaseOrder();
        List<Item> items = new List<Item>();

        public ProcessPO()
        {
            InitializeComponent();
        }

        public static ProcessPO _instance;

        public static ProcessPO Instance
        {
            get
            {
                if (_instance == null || _instance.HasBeenClosed)
                {
                    _instance = new ProcessPO();
                    _instance.Position = 0;
                }

                return _instance;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _instance.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ResetForm();
            SearchPurchaseOrders();
        }

        private void SearchPurchaseOrders()
        {
            // Set all search parameter variables
            int employeeId = LoginData.EmployeeId;
            string searchCriteria = string.IsNullOrEmpty(txtEmployeeName.Text) ? string.Empty : txtEmployeeName.Text;
            DateTime? startDate = null;
            DateTime? endDate = null;
            if (dtpStartDate.Enabled)
            {
                startDate = Convert.ToDateTime(dtpStartDate.Value);
            }
            if (dtpEndDate.Enabled)
            {
                endDate = Convert.ToDateTime(dtpEndDate.Value);
            }
            POStatus? status = null;
            if (rdoSearchClosed.Checked)
            {
                status = POStatus.Closed;
            }
            if (rdoSearchPending.Checked)
            {
                status = POStatus.Pending;
            }

            List<PurchaseOrderDTO> pos = new List<PurchaseOrderDTO>();
            bool searchOk = false;

            if (chkSearchByPoNumber.Checked)
            {
                status = null;
                startDate = DateTime.MinValue;
                endDate = DateTime.Now;
                searchCriteria = txtPoNumberSearch.Text;
                if (int.TryParse(searchCriteria, out int result))
                {
                    if (searchCriteria.Length == 8)
                    {
                        pos = service.SearchPurchaseOrdersProcess(employeeId, searchCriteria, startDate, endDate, status);
                        searchOk = true;
                    }
                    else
                    {
                        MessageBox.Show("The PO Number must be 8 digits long");
                    }
                }
                else
                {
                    MessageBox.Show("The PO Number must be a number");
                }
            }
            else
            {
                pos = service.SearchPurchaseOrdersProcess(employeeId, searchCriteria, startDate, endDate, status);
                searchOk = true;
            }


            if (searchOk && pos.Count == 0)
            {
                MessageBox.Show("No Purchase Orders found with the current search options");
            }
            else if (searchOk && pos.Count > 0)
            {
                dgvResults.DataSource = new BindingList<PurchaseOrderDTO>(pos);
                dgvResults.Columns["PurchaseOrderId"].HeaderText = "PO Number";
                dgvResults.Columns["EmployeeName"].HeaderText = "Employee";
                dgvResults.Columns["CreationDate"].HeaderText = "Date";
                dgvResults.Columns["Total"].DefaultCellStyle.Format = "c2";
            }
        }

        private void ResetForm()
        {
            dgvResults.Rows.Clear();
            dgvResults.DataSource = null;
            dgvItems.Rows.Clear();
            dgvItems.DataSource = null;
            txtDenyReason.Text = string.Empty;
            rdoApprove.Checked = false;
            rdoDeny.Checked = false;
            rdoPending.Checked = false;
            lblItemName.Text = "No item";
            rdoApprove.Enabled = false;
            rdoDeny.Enabled = false;
            rdoPending.Enabled = false;
            btnClosePo.Visible = false;
            btnSave.Enabled = false;
            foreach (Control control in grpPurchaseOrder.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
        }

        private void chkAllDates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllDates.Checked)
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }
            else
            {
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
        }

        private void ProcessPO_Load(object sender, EventArgs e)
        {
            SearchPurchaseOrders();
        }

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.CurrentRow != null)
            {
                po = service.GetPurchaseOrder(Convert.ToInt32(dgvResults.CurrentRow.Cells["PurchaseOrderId"].Value));
                // Set fields
                txtPONumber.Text = po.PurchaseOrderId.ToString();
                txtPODate.Text = po.CreationDate.ToString("yyyy-MM-dd");
                txtPOStatus.Text = po.Status.ToString();
                txtPOEmployee.Text = service.GetEmployeeName(po.EmployeeId).EmployeeName;
                txtSubtotal.Text = po.Subtotal.ToString("c2");
                txtTax.Text = po.Tax.ToString("c2");
                txtTotal.Text = po.TotalAfterTax.ToString("c2");
                BindingList<Item> items = new BindingList<Item>(po.Items);
                foreach (Item item in items.ToList())
                {
                    item.subtotal = item.Quantity * item.Price;
                }
                dgvItems.DataSource = items;
                dgvItems.Columns["DisplayStatus"].Visible = false;
                dgvItems.Columns["ItemId"].Visible = false;
                dgvItems.Columns["subtotal"].HeaderText = "Subtotal";
                dgvItems.Columns["PurchaseOrderId"].HeaderText = "PO Number";
                dgvItems.Columns["Price"].DefaultCellStyle.Format = "C";
                dgvItems.Columns["subtotal"].DefaultCellStyle.Format = "c2";

                bool showButtonToClose = true;
                if (po.Status == POStatus.Closed)
                {
                    showButtonToClose = false;
                }
                foreach (Item i in po.Items.ToList())
                {
                    if (i.Status != ItemStatus.Approved && i.Status != ItemStatus.Denied)
                    {
                        showButtonToClose = false;
                    }
                }

                btnClosePo.Visible = showButtonToClose ? true : false;
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow != null)
            {
                lblItemName.Text = dgvItems.CurrentRow.Cells["Name"].Value.ToString();
                txtItemId.Text = dgvItems.CurrentRow.Cells["ItemId"].Value.ToString();

                if ((ItemStatus)(dgvItems.CurrentRow.Cells["Status"].Value) == ItemStatus.Approved)
                {
                    rdoApprove.Checked = true;
                    txtDenyReason.Enabled = false;
                }
                else if ((ItemStatus)(dgvItems.CurrentRow.Cells["Status"].Value) == ItemStatus.Denied)
                {
                    rdoDeny.Checked = true;
                    txtDenyReason.Enabled = true;
                }
                else if ((ItemStatus)(dgvItems.CurrentRow.Cells["Status"].Value) == ItemStatus.Pending)
                {
                    rdoPending.Checked = true;
                    txtDenyReason.Enabled = false;
                }
                else if ((ItemStatus)(dgvItems.CurrentRow.Cells["Status"].Value) == ItemStatus.NoLongerRequired)
                {
                    rdoDeny.Checked = true;
                    txtDenyReason.Enabled = true;
                }

                txtDenyReason.Text = !string.IsNullOrEmpty(dgvItems.CurrentRow.Cells["Reason"].Value.ToString()) ? dgvItems.CurrentRow.Cells["Reason"].Value.ToString() : "";

                rdoApprove.Enabled = true;
                rdoDeny.Enabled = true;
                rdoPending.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Item item = UpdateItem();
            po.IsProcess = true;
            service.UpdateItemReason(item);
            service.UpdatePurchaseOrder(po);

            if (po.Errors.Count > 0)
            {
                string msg = "";
                foreach (Error error in po.Errors)
                {
                    msg += error.Description + "\n";
                }
                MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                po = service.GetPurchaseOrder(po.PurchaseOrderId);
                bool allItemsProcessed = true;
                foreach (Item i in po.Items)
                {
                    if (i.Status != ItemStatus.Approved && i.Status != ItemStatus.Denied)
                    {
                        allItemsProcessed = false;
                    }
                }

                MessageBox.Show("Changes saved successfully");

                if (allItemsProcessed && MessageBox.Show("Do you want to close this Purchase Order?", "Close?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    po.IsProcess = true;
                    po.ClosePurchaseOrder = true;
                    if (service.UpdatePurchaseOrder(po, LoginData.EmployeeId))
                    {
                        ResetForm();
                    }

                    if (po.Errors.Count > 0)
                    {
                        string msg = "";
                        foreach (Error error in po.Errors)
                        {
                            msg += error.Description + "\n";
                        }

                        MessageBox.Show(msg, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                bool showButtonToClose = true;
                if (po.Status == POStatus.Closed)
                {
                    showButtonToClose = false;
                }
                foreach (Item i in po.Items)
                {
                    if (i.Status != ItemStatus.Approved && i.Status != ItemStatus.Denied)
                    {
                        showButtonToClose = false;
                    }
                }

                if (po.Status != POStatus.Closed && po.Status != null)
                {
                    BindingList<Item> items = new BindingList<Item>(po.Items);
                    foreach (Item i in items)
                    {
                        i.subtotal = i.Quantity * i.Price;
                    }
                    dgvItems.DataSource = items;
                    dgvItems.Columns["subtotal"].DefaultCellStyle.Format = "c2";

                    btnClosePo.Visible = showButtonToClose ? true : false;
                }

                txtPOStatus.Text = po.Status.ToString();
            }

            po.IsProcess = false;
        }

        private Item UpdateItem()
        {
            foreach (Item item in po.Items)
            {
                if (dgvItems.CurrentRow != null && item.ItemId == Convert.ToInt32(dgvItems.CurrentRow.Cells["ItemId"].Value))
                {
                    if (rdoPending.Checked)
                    {
                        item.Status = ItemStatus.Pending;
                        item.Reason = "";
                    }

                    if (rdoApprove.Checked)
                    {
                        item.Status = ItemStatus.Approved;
                        item.Reason = "";
                    }

                    if (rdoDeny.Checked)
                    {
                        item.Status = ItemStatus.Denied;
                        item.Reason = txtDenyReason.Text;
                    }

                    return item;
                }
            }

            return null;
        }

        private void rdoDeny_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDeny.Checked)
            {
                txtDenyReason.Enabled = true;
            }
        }

        private void rdoApprove_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoDeny.Checked)
            {
                txtDenyReason.Enabled = false;
            }
        }

        private void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoDeny.Checked)
            {
                txtDenyReason.Enabled = false;
            }
        }

        private void btnClosePo_Click(object sender, EventArgs e)
        {
            po.IsProcess = true;
            po.ClosePurchaseOrder = true;
            if (service.UpdatePurchaseOrder(po, LoginData.EmployeeId))
            {
                MessageBox.Show("The Purchase Order has been closed");
                ResetForm();
            }

            if (po.Errors.Count > 0)
            {
                string msg = "";
                foreach (Error error in po.Errors)
                {
                    msg += error.Description + "\n";
                }

                MessageBox.Show(msg, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSearchByPoNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchByPoNumber.Checked)
            {
                txtPoNumberSearch.Enabled = true;
                grpDateSearch.Enabled = false;
                grpStatusSearch.Enabled = false;
                txtEmployeeName.Enabled = false;
            }
            else
            {
                txtPoNumberSearch.Enabled = false;
                grpDateSearch.Enabled = true;
                grpStatusSearch.Enabled = true;
                txtEmployeeName.Enabled = true;
            }
        }
    }
}
