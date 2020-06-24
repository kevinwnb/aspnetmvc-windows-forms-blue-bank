namespace BlueBank.WindowsForm.UI.Pages
{
    partial class ProcessPO
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.grpPurchaseOrder = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.txtPOEmployee = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtPOStatus = new System.Windows.Forms.TextBox();
            this.txtPODate = new System.Windows.Forms.TextBox();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.btnClosePo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtDenyReason = new System.Windows.Forms.TextBox();
            this.rdoDeny = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.rdoPending = new System.Windows.Forms.RadioButton();
            this.rdoApprove = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSearchByPoNumber = new System.Windows.Forms.CheckBox();
            this.grpStatusSearch = new System.Windows.Forms.GroupBox();
            this.rdoSearchClosed = new System.Windows.Forms.RadioButton();
            this.rdoSearchPending = new System.Windows.Forms.RadioButton();
            this.rdoSearchAll = new System.Windows.Forms.RadioButton();
            this.grpDateSearch = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAllDates = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPoNumberSearch = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.grpPurchaseOrder.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpStatusSearch.SuspendLayout();
            this.grpDateSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPurchaseOrder
            // 
            this.grpPurchaseOrder.Controls.Add(this.label16);
            this.grpPurchaseOrder.Controls.Add(this.label13);
            this.grpPurchaseOrder.Controls.Add(this.label15);
            this.grpPurchaseOrder.Controls.Add(this.label12);
            this.grpPurchaseOrder.Controls.Add(this.label14);
            this.grpPurchaseOrder.Controls.Add(this.label11);
            this.grpPurchaseOrder.Controls.Add(this.label10);
            this.grpPurchaseOrder.Controls.Add(this.txtTotal);
            this.grpPurchaseOrder.Controls.Add(this.txtTax);
            this.grpPurchaseOrder.Controls.Add(this.txtPOEmployee);
            this.grpPurchaseOrder.Controls.Add(this.txtSubtotal);
            this.grpPurchaseOrder.Controls.Add(this.txtPOStatus);
            this.grpPurchaseOrder.Controls.Add(this.txtPODate);
            this.grpPurchaseOrder.Controls.Add(this.txtPONumber);
            this.grpPurchaseOrder.Location = new System.Drawing.Point(128, 577);
            this.grpPurchaseOrder.Name = "grpPurchaseOrder";
            this.grpPurchaseOrder.Size = new System.Drawing.Size(540, 139);
            this.grpPurchaseOrder.TabIndex = 12;
            this.grpPurchaseOrder.TabStop = false;
            this.grpPurchaseOrder.Text = "Purchase Order";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(266, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Total:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(372, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Employee:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(160, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Tax:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(266, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Status:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(54, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Subtotal:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(160, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Number:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(269, 99);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 11;
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(163, 99);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(100, 20);
            this.txtTax.TabIndex = 11;
            // 
            // txtPOEmployee
            // 
            this.txtPOEmployee.Location = new System.Drawing.Point(375, 50);
            this.txtPOEmployee.Name = "txtPOEmployee";
            this.txtPOEmployee.ReadOnly = true;
            this.txtPOEmployee.Size = new System.Drawing.Size(100, 20);
            this.txtPOEmployee.TabIndex = 11;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(57, 99);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(100, 20);
            this.txtSubtotal.TabIndex = 11;
            // 
            // txtPOStatus
            // 
            this.txtPOStatus.Location = new System.Drawing.Point(269, 50);
            this.txtPOStatus.Name = "txtPOStatus";
            this.txtPOStatus.ReadOnly = true;
            this.txtPOStatus.Size = new System.Drawing.Size(100, 20);
            this.txtPOStatus.TabIndex = 11;
            // 
            // txtPODate
            // 
            this.txtPODate.Location = new System.Drawing.Point(163, 50);
            this.txtPODate.Name = "txtPODate";
            this.txtPODate.ReadOnly = true;
            this.txtPODate.Size = new System.Drawing.Size(100, 20);
            this.txtPODate.TabIndex = 11;
            // 
            // txtPONumber
            // 
            this.txtPONumber.Location = new System.Drawing.Point(57, 50);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.ReadOnly = true;
            this.txtPONumber.Size = new System.Drawing.Size(100, 20);
            this.txtPONumber.TabIndex = 11;
            // 
            // btnClosePo
            // 
            this.btnClosePo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClosePo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClosePo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnClosePo.Location = new System.Drawing.Point(562, 1200);
            this.btnClosePo.Name = "btnClosePo";
            this.btnClosePo.Size = new System.Drawing.Size(106, 36);
            this.btnClosePo.TabIndex = 6;
            this.btnClosePo.Text = "Close PO";
            this.btnClosePo.UseVisualStyleBackColor = false;
            this.btnClosePo.Visible = false;
            this.btnClosePo.Click += new System.EventHandler(this.btnClosePo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtItemId);
            this.groupBox2.Controls.Add(this.txtDenyReason);
            this.groupBox2.Controls.Add(this.rdoDeny);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.rdoPending);
            this.groupBox2.Controls.Add(this.rdoApprove);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lblItemName);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Location = new System.Drawing.Point(128, 939);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 255);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Approve or Deny";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(131, 33);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.ReadOnly = true;
            this.txtItemId.Size = new System.Drawing.Size(100, 20);
            this.txtItemId.TabIndex = 3;
            this.txtItemId.Visible = false;
            // 
            // txtDenyReason
            // 
            this.txtDenyReason.Enabled = false;
            this.txtDenyReason.Location = new System.Drawing.Point(224, 116);
            this.txtDenyReason.Multiline = true;
            this.txtDenyReason.Name = "txtDenyReason";
            this.txtDenyReason.Size = new System.Drawing.Size(269, 91);
            this.txtDenyReason.TabIndex = 3;
            // 
            // rdoDeny
            // 
            this.rdoDeny.AutoSize = true;
            this.rdoDeny.Location = new System.Drawing.Point(224, 80);
            this.rdoDeny.Name = "rdoDeny";
            this.rdoDeny.Size = new System.Drawing.Size(50, 17);
            this.rdoDeny.TabIndex = 2;
            this.rdoDeny.TabStop = true;
            this.rdoDeny.Text = "Deny";
            this.rdoDeny.UseVisualStyleBackColor = true;
            this.rdoDeny.CheckedChanged += new System.EventHandler(this.rdoDeny_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(387, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rdoPending
            // 
            this.rdoPending.AutoSize = true;
            this.rdoPending.Location = new System.Drawing.Point(41, 80);
            this.rdoPending.Name = "rdoPending";
            this.rdoPending.Size = new System.Drawing.Size(64, 17);
            this.rdoPending.TabIndex = 0;
            this.rdoPending.TabStop = true;
            this.rdoPending.Text = "Pending";
            this.rdoPending.UseVisualStyleBackColor = true;
            this.rdoPending.CheckedChanged += new System.EventHandler(this.rdoPending_CheckedChanged);
            // 
            // rdoApprove
            // 
            this.rdoApprove.AutoSize = true;
            this.rdoApprove.Location = new System.Drawing.Point(131, 80);
            this.rdoApprove.Name = "rdoApprove";
            this.rdoApprove.Size = new System.Drawing.Size(65, 17);
            this.rdoApprove.TabIndex = 1;
            this.rdoApprove.TabStop = true;
            this.rdoApprove.Text = "Approve";
            this.rdoApprove.UseVisualStyleBackColor = true;
            this.rdoApprove.CheckedChanged += new System.EventHandler(this.rdoApprove_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(221, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Reason:";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(82, 36);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(43, 13);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "No item";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(19, 36);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(61, 13);
            this.label.TabIndex = 0;
            this.label.Text = "Item Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSearchByPoNumber);
            this.groupBox1.Controls.Add(this.grpStatusSearch);
            this.groupBox1.Controls.Add(this.grpDateSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtPoNumberSearch);
            this.groupBox1.Controls.Add(this.txtEmployeeName);
            this.groupBox1.Location = new System.Drawing.Point(128, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 220);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // chkSearchByPoNumber
            // 
            this.chkSearchByPoNumber.AutoSize = true;
            this.chkSearchByPoNumber.Location = new System.Drawing.Point(6, 42);
            this.chkSearchByPoNumber.Name = "chkSearchByPoNumber";
            this.chkSearchByPoNumber.Size = new System.Drawing.Size(132, 17);
            this.chkSearchByPoNumber.TabIndex = 11;
            this.chkSearchByPoNumber.Text = "Search by PO Number";
            this.chkSearchByPoNumber.UseVisualStyleBackColor = true;
            this.chkSearchByPoNumber.CheckedChanged += new System.EventHandler(this.chkSearchByPoNumber_CheckedChanged);
            // 
            // grpStatusSearch
            // 
            this.grpStatusSearch.Controls.Add(this.rdoSearchClosed);
            this.grpStatusSearch.Controls.Add(this.rdoSearchPending);
            this.grpStatusSearch.Controls.Add(this.rdoSearchAll);
            this.grpStatusSearch.Location = new System.Drawing.Point(384, 19);
            this.grpStatusSearch.Name = "grpStatusSearch";
            this.grpStatusSearch.Size = new System.Drawing.Size(150, 153);
            this.grpStatusSearch.TabIndex = 10;
            this.grpStatusSearch.TabStop = false;
            this.grpStatusSearch.Text = "Status";
            // 
            // rdoSearchClosed
            // 
            this.rdoSearchClosed.AutoSize = true;
            this.rdoSearchClosed.Location = new System.Drawing.Point(15, 54);
            this.rdoSearchClosed.Name = "rdoSearchClosed";
            this.rdoSearchClosed.Size = new System.Drawing.Size(57, 17);
            this.rdoSearchClosed.TabIndex = 5;
            this.rdoSearchClosed.Text = "Closed";
            this.rdoSearchClosed.UseVisualStyleBackColor = true;
            // 
            // rdoSearchPending
            // 
            this.rdoSearchPending.AutoSize = true;
            this.rdoSearchPending.Checked = true;
            this.rdoSearchPending.Location = new System.Drawing.Point(15, 31);
            this.rdoSearchPending.Name = "rdoSearchPending";
            this.rdoSearchPending.Size = new System.Drawing.Size(64, 17);
            this.rdoSearchPending.TabIndex = 5;
            this.rdoSearchPending.TabStop = true;
            this.rdoSearchPending.Text = "Pending";
            this.rdoSearchPending.UseVisualStyleBackColor = true;
            // 
            // rdoSearchAll
            // 
            this.rdoSearchAll.AutoSize = true;
            this.rdoSearchAll.Location = new System.Drawing.Point(15, 77);
            this.rdoSearchAll.Name = "rdoSearchAll";
            this.rdoSearchAll.Size = new System.Drawing.Size(36, 17);
            this.rdoSearchAll.TabIndex = 5;
            this.rdoSearchAll.Text = "All";
            this.rdoSearchAll.UseVisualStyleBackColor = true;
            // 
            // grpDateSearch
            // 
            this.grpDateSearch.Controls.Add(this.dtpStartDate);
            this.grpDateSearch.Controls.Add(this.label5);
            this.grpDateSearch.Controls.Add(this.label3);
            this.grpDateSearch.Controls.Add(this.chkAllDates);
            this.grpDateSearch.Controls.Add(this.dtpEndDate);
            this.grpDateSearch.Location = new System.Drawing.Point(144, 16);
            this.grpDateSearch.Name = "grpDateSearch";
            this.grpDateSearch.Size = new System.Drawing.Size(234, 156);
            this.grpDateSearch.TabIndex = 9;
            this.grpDateSearch.TabStop = false;
            this.grpDateSearch.Text = "Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Location = new System.Drawing.Point(22, 77);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Start Date:";
            // 
            // chkAllDates
            // 
            this.chkAllDates.AutoSize = true;
            this.chkAllDates.Checked = true;
            this.chkAllDates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllDates.Location = new System.Drawing.Point(22, 34);
            this.chkAllDates.Name = "chkAllDates";
            this.chkAllDates.Size = new System.Drawing.Size(37, 17);
            this.chkAllDates.TabIndex = 8;
            this.chkAllDates.Text = "All";
            this.chkAllDates.UseVisualStyleBackColor = true;
            this.chkAllDates.CheckedChanged += new System.EventHandler(this.chkAllDates_CheckedChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Location = new System.Drawing.Point(22, 121);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PO Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Employee Name:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(205, 178);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 36);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPoNumberSearch
            // 
            this.txtPoNumberSearch.Enabled = false;
            this.txtPoNumberSearch.Location = new System.Drawing.Point(22, 77);
            this.txtPoNumberSearch.Name = "txtPoNumberSearch";
            this.txtPoNumberSearch.Size = new System.Drawing.Size(100, 20);
            this.txtPoNumberSearch.TabIndex = 0;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(22, 137);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(100, 20);
            this.txtEmployeeName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "End Date:";
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(128, 768);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(540, 150);
            this.dgvItems.TabIndex = 7;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 752);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Items:";
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(128, 406);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(540, 150);
            this.dgvResults.TabIndex = 7;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Purchase Order results:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(890, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "Process Purchase Order";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(892, 61);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label19.Location = new System.Drawing.Point(0, 1239);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(892, 41);
            this.label19.TabIndex = 22;
            // 
            // ProcessPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpPurchaseOrder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClosePo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProcessPO";
            this.Size = new System.Drawing.Size(892, 1280);
            this.Load += new System.EventHandler(this.ProcessPO_Load);
            this.grpPurchaseOrder.ResumeLayout(false);
            this.grpPurchaseOrder.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpStatusSearch.ResumeLayout(false);
            this.grpStatusSearch.PerformLayout();
            this.grpDateSearch.ResumeLayout(false);
            this.grpDateSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.RadioButton rdoSearchPending;
        private System.Windows.Forms.RadioButton rdoSearchClosed;
        private System.Windows.Forms.RadioButton rdoSearchAll;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.RadioButton rdoDeny;
        private System.Windows.Forms.RadioButton rdoApprove;
        private System.Windows.Forms.TextBox txtDenyReason;
        private System.Windows.Forms.RadioButton rdoPending;
        private System.Windows.Forms.GroupBox grpDateSearch;
        private System.Windows.Forms.CheckBox chkAllDates;
        private System.Windows.Forms.GroupBox grpStatusSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.GroupBox grpPurchaseOrder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPOEmployee;
        private System.Windows.Forms.TextBox txtPOStatus;
        private System.Windows.Forms.TextBox txtPODate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnClosePo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPoNumberSearch;
        private System.Windows.Forms.CheckBox chkSearchByPoNumber;
        private System.Windows.Forms.Label label19;
    }
}
