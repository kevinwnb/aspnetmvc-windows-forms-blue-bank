namespace BlueBank.WindowsForm.UI.Pages
{
    partial class ModifyPO
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
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCreationDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPoNumber = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.txtTotalAfterTax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.grpPoInfo = new System.Windows.Forms.GroupBox();
            this.txtSupervisorName = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtJustification = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnResetItem = new System.Windows.Forms.Button();
            this.btnModifyItem = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdoByDate = new System.Windows.Forms.RadioButton();
            this.rdoById = new System.Windows.Forms.RadioButton();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnNotRequired = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNotRequired = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPOStatus = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpPoInfo.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1166, 59);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.Location = new System.Drawing.Point(209, 62);
            this.txtCreationDate.Margin = new System.Windows.Forms.Padding(8);
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.ReadOnly = true;
            this.txtCreationDate.Size = new System.Drawing.Size(176, 25);
            this.txtCreationDate.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Creation Date:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtPoNumber
            // 
            this.txtPoNumber.Location = new System.Drawing.Point(456, 137);
            this.txtPoNumber.Margin = new System.Windows.Forms.Padding(8);
            this.txtPoNumber.Name = "txtPoNumber";
            this.txtPoNumber.ReadOnly = true;
            this.txtPoNumber.Size = new System.Drawing.Size(185, 25);
            this.txtPoNumber.TabIndex = 0;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(65, 1459);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(8);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(202, 25);
            this.txtSubtotal.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 1433);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Subtotal:";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(593, 1433);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tax:";
            this.label6.Click += new System.EventHandler(this.label2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(857, 1433);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "TotalAfterTax:";
            this.label7.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(137, 210);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(8);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(260, 37);
            this.btnAddItem.TabIndex = 8;
            this.btnAddItem.Text = "Add Item to order";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.Location = new System.Drawing.Point(327, 1459);
            this.txtTaxRate.Margin = new System.Windows.Forms.Padding(8);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.ReadOnly = true;
            this.txtTaxRate.Size = new System.Drawing.Size(209, 25);
            this.txtTaxRate.TabIndex = 4;
            this.txtTaxRate.Text = "15%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 1433);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 18);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tax Rate:";
            this.label9.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(209, 62);
            this.textBox2.Margin = new System.Windows.Forms.Padding(8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(176, 25);
            this.textBox2.TabIndex = 4;
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(593, 1459);
            this.txtTax.Margin = new System.Windows.Forms.Padding(8);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(209, 25);
            this.txtTax.TabIndex = 4;
            // 
            // txtTotalAfterTax
            // 
            this.txtTotalAfterTax.Location = new System.Drawing.Point(857, 1459);
            this.txtTotalAfterTax.Margin = new System.Windows.Forms.Padding(8);
            this.txtTotalAfterTax.Name = "txtTotalAfterTax";
            this.txtTotalAfterTax.ReadOnly = true;
            this.txtTotalAfterTax.Size = new System.Drawing.Size(222, 25);
            this.txtTotalAfterTax.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 18);
            this.label10.TabIndex = 5;
            this.label10.Text = "Creation Date:";
            this.label10.Click += new System.EventHandler(this.label2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(453, 111);
            this.label12.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 18);
            this.label12.TabIndex = 11;
            this.label12.Text = "PO Number:";
            this.label12.Click += new System.EventHandler(this.label2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(65, 1433);
            this.label13.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 18);
            this.label13.TabIndex = 5;
            this.label13.Text = "Subtotal:";
            this.label13.Click += new System.EventHandler(this.label2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(593, 1433);
            this.label14.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 18);
            this.label14.TabIndex = 5;
            this.label14.Text = "Tax:";
            this.label14.Click += new System.EventHandler(this.label2_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(857, 1433);
            this.label15.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 18);
            this.label15.TabIndex = 5;
            this.label15.Text = "TotalAfterTax:";
            this.label15.Click += new System.EventHandler(this.label2_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(327, 1433);
            this.label16.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 18);
            this.label16.TabIndex = 5;
            this.label16.Text = "Tax Rate:";
            this.label16.Click += new System.EventHandler(this.label2_Click);
            // 
            // grpPoInfo
            // 
            this.grpPoInfo.Controls.Add(this.txtSupervisorName);
            this.grpPoInfo.Controls.Add(this.txtEmployeeName);
            this.grpPoInfo.Controls.Add(this.txtCreationDate);
            this.grpPoInfo.Controls.Add(this.textBox2);
            this.grpPoInfo.Controls.Add(this.txtDepartment);
            this.grpPoInfo.Controls.Add(this.textBox1);
            this.grpPoInfo.Controls.Add(this.txtStatus);
            this.grpPoInfo.Controls.Add(this.txtPoNumber);
            this.grpPoInfo.Controls.Add(this.label22);
            this.grpPoInfo.Controls.Add(this.label25);
            this.grpPoInfo.Controls.Add(this.label20);
            this.grpPoInfo.Controls.Add(this.label21);
            this.grpPoInfo.Controls.Add(this.label12);
            this.grpPoInfo.Controls.Add(this.label2);
            this.grpPoInfo.Controls.Add(this.label10);
            this.grpPoInfo.Location = new System.Drawing.Point(48, 555);
            this.grpPoInfo.Margin = new System.Windows.Forms.Padding(8);
            this.grpPoInfo.Name = "grpPoInfo";
            this.grpPoInfo.Padding = new System.Windows.Forms.Padding(8);
            this.grpPoInfo.Size = new System.Drawing.Size(1086, 199);
            this.grpPoInfo.TabIndex = 1;
            this.grpPoInfo.TabStop = false;
            this.grpPoInfo.Text = "Purchase Order";
            this.grpPoInfo.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtSupervisorName
            // 
            this.txtSupervisorName.Location = new System.Drawing.Point(209, 137);
            this.txtSupervisorName.Margin = new System.Windows.Forms.Padding(8);
            this.txtSupervisorName.Name = "txtSupervisorName";
            this.txtSupervisorName.ReadOnly = true;
            this.txtSupervisorName.Size = new System.Drawing.Size(176, 25);
            this.txtSupervisorName.TabIndex = 15;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(456, 62);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(8);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(185, 25);
            this.txtEmployeeName.TabIndex = 14;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(712, 62);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(8);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(169, 25);
            this.txtDepartment.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(712, 62);
            this.textBox1.Margin = new System.Windows.Forms.Padding(8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 25);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Pending";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(712, 137);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(8);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(169, 25);
            this.txtStatus.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(206, 111);
            this.label22.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(115, 18);
            this.label22.TabIndex = 10;
            this.label22.Text = "Supervisor Name:";
            this.label22.Click += new System.EventHandler(this.label2_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(709, 36);
            this.label25.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 18);
            this.label25.TabIndex = 12;
            this.label25.Text = "Department:";
            this.label25.Click += new System.EventHandler(this.label2_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(711, 111);
            this.label20.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 18);
            this.label20.TabIndex = 11;
            this.label20.Text = "Status:";
            this.label20.Click += new System.EventHandler(this.label2_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(453, 36);
            this.label21.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 18);
            this.label21.TabIndex = 9;
            this.label21.Text = "Employee Name:";
            this.label21.Click += new System.EventHandler(this.label2_Click);
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.label8);
            this.grpItems.Controls.Add(this.label23);
            this.grpItems.Controls.Add(this.lblReason);
            this.grpItems.Controls.Add(this.label11);
            this.grpItems.Controls.Add(this.txtLocation);
            this.grpItems.Controls.Add(this.label18);
            this.grpItems.Controls.Add(this.txtPrice);
            this.grpItems.Controls.Add(this.txtItemId);
            this.grpItems.Controls.Add(this.txtDescription);
            this.grpItems.Controls.Add(this.label3);
            this.grpItems.Controls.Add(this.label17);
            this.grpItems.Controls.Add(this.txtJustification);
            this.grpItems.Controls.Add(this.txtReason);
            this.grpItems.Controls.Add(this.txtItemName);
            this.grpItems.Controls.Add(this.txtQuantity);
            this.grpItems.Controls.Add(this.btnResetItem);
            this.grpItems.Controls.Add(this.btnModifyItem);
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Location = new System.Drawing.Point(48, 770);
            this.grpItems.Margin = new System.Windows.Forms.Padding(8);
            this.grpItems.Name = "grpItems";
            this.grpItems.Padding = new System.Windows.Forms.Padding(8);
            this.grpItems.Size = new System.Drawing.Size(1086, 269);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Add/Modify Item";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Location:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(550, 28);
            this.label23.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 18);
            this.label23.TabIndex = 9;
            this.label23.Text = "Price:";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(554, 113);
            this.lblReason.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(55, 18);
            this.lblReason.TabIndex = 9;
            this.lblReason.Text = "Reason:";
            this.lblReason.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(348, 28);
            this.label11.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 9;
            this.label11.Text = "Description:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(145, 133);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(8);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(190, 25);
            this.txtLocation.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(348, 113);
            this.label18.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 18);
            this.label18.TabIndex = 0;
            this.label18.Text = "Justification:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(553, 54);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(8);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(185, 25);
            this.txtPrice.TabIndex = 2;
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(759, 133);
            this.txtItemId.Margin = new System.Windows.Forms.Padding(8);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.ReadOnly = true;
            this.txtItemId.Size = new System.Drawing.Size(185, 25);
            this.txtItemId.TabIndex = 7;
            this.txtItemId.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(350, 54);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(8);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(189, 25);
            this.txtDescription.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(755, 34);
            this.label17.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 18);
            this.label17.TabIndex = 9;
            this.label17.Text = "Qty:";
            // 
            // txtJustification
            // 
            this.txtJustification.Location = new System.Drawing.Point(351, 133);
            this.txtJustification.Margin = new System.Windows.Forms.Padding(8);
            this.txtJustification.Name = "txtJustification";
            this.txtJustification.Size = new System.Drawing.Size(189, 25);
            this.txtJustification.TabIndex = 5;
            // 
            // txtReason
            // 
            this.txtReason.Enabled = false;
            this.txtReason.Location = new System.Drawing.Point(557, 133);
            this.txtReason.Margin = new System.Windows.Forms.Padding(8);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(181, 25);
            this.txtReason.TabIndex = 6;
            this.txtReason.Visible = false;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(145, 54);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(8);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(189, 25);
            this.txtItemName.TabIndex = 0;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(754, 54);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(8);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(189, 25);
            this.txtQuantity.TabIndex = 3;
            // 
            // btnResetItem
            // 
            this.btnResetItem.Location = new System.Drawing.Point(689, 210);
            this.btnResetItem.Margin = new System.Windows.Forms.Padding(8);
            this.btnResetItem.Name = "btnResetItem";
            this.btnResetItem.Size = new System.Drawing.Size(260, 37);
            this.btnResetItem.TabIndex = 10;
            this.btnResetItem.Text = "Reset";
            this.btnResetItem.UseVisualStyleBackColor = true;
            this.btnResetItem.Click += new System.EventHandler(this.btnResetItem_Click);
            // 
            // btnModifyItem
            // 
            this.btnModifyItem.Enabled = false;
            this.btnModifyItem.Location = new System.Drawing.Point(413, 210);
            this.btnModifyItem.Margin = new System.Windows.Forms.Padding(8);
            this.btnModifyItem.Name = "btnModifyItem";
            this.btnModifyItem.Size = new System.Drawing.Size(260, 37);
            this.btnModifyItem.TabIndex = 9;
            this.btnModifyItem.Text = "Modify Item";
            this.btnModifyItem.UseVisualStyleBackColor = true;
            this.btnModifyItem.Click += new System.EventHandler(this.btnModifyItem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(43, 93);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(156, 25);
            this.txtSearch.TabIndex = 12;
            // 
            // rdoByDate
            // 
            this.rdoByDate.AutoSize = true;
            this.rdoByDate.Location = new System.Drawing.Point(215, 55);
            this.rdoByDate.Margin = new System.Windows.Forms.Padding(8);
            this.rdoByDate.Name = "rdoByDate";
            this.rdoByDate.Size = new System.Drawing.Size(55, 22);
            this.rdoByDate.TabIndex = 15;
            this.rdoByDate.TabStop = true;
            this.rdoByDate.Text = "Date";
            this.rdoByDate.UseVisualStyleBackColor = true;
            this.rdoByDate.CheckedChanged += new System.EventHandler(this.rdoByDate_CheckedChanged);
            // 
            // rdoById
            // 
            this.rdoById.AutoSize = true;
            this.rdoById.Location = new System.Drawing.Point(43, 55);
            this.rdoById.Margin = new System.Windows.Forms.Padding(8);
            this.rdoById.Name = "rdoById";
            this.rdoById.Size = new System.Drawing.Size(40, 22);
            this.rdoById.TabIndex = 15;
            this.rdoById.TabStop = true;
            this.rdoById.Text = "ID";
            this.rdoById.UseVisualStyleBackColor = true;
            this.rdoById.CheckedChanged += new System.EventHandler(this.rdoById_CheckedChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Enabled = false;
            this.dtpStart.Location = new System.Drawing.Point(215, 93);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(8);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(189, 25);
            this.dtpStart.TabIndex = 16;
            // 
            // btnNotRequired
            // 
            this.btnNotRequired.Location = new System.Drawing.Point(41, 151);
            this.btnNotRequired.Margin = new System.Windows.Forms.Padding(8);
            this.btnNotRequired.Name = "btnNotRequired";
            this.btnNotRequired.Size = new System.Drawing.Size(154, 43);
            this.btnNotRequired.TabIndex = 3;
            this.btnNotRequired.Text = "Not required";
            this.btnNotRequired.UseVisualStyleBackColor = true;
            this.btnNotRequired.Click += new System.EventHandler(this.btnNotRequired_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Location = new System.Drawing.Point(215, 122);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(8);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(189, 25);
            this.dtpEnd.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvItems);
            this.panel1.Location = new System.Drawing.Point(48, 1060);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 328);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.lblNotRequired);
            this.panel2.Controls.Add(this.btnNotRequired);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(855, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 328);
            this.panel2.TabIndex = 12;
            // 
            // lblNotRequired
            // 
            this.lblNotRequired.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNotRequired.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotRequired.Font = new System.Drawing.Font("Copperplate Gothic Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotRequired.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNotRequired.Location = new System.Drawing.Point(0, 0);
            this.lblNotRequired.Name = "lblNotRequired";
            this.lblNotRequired.Size = new System.Drawing.Size(231, 35);
            this.lblNotRequired.TabIndex = 2;
            this.lblNotRequired.Text = "CANCEL SELECTED ITEM";
            this.lblNotRequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(8);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersWidth = 82;
            this.dgvItems.Size = new System.Drawing.Size(855, 328);
            this.dgvItems.TabIndex = 11;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Light", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1166, 61);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MODIFY PURCHASE ORDER";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel3.Controls.Add(this.lblTitle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1166, 61);
            this.panel3.TabIndex = 19;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(492, 140);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(642, 376);
            this.dgvResults.TabIndex = 20;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label19.Location = new System.Drawing.Point(0, 1572);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(1166, 37);
            this.label19.TabIndex = 21;
            // 
            // lblPOStatus
            // 
            this.lblPOStatus.AutoSize = true;
            this.lblPOStatus.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblPOStatus.Location = new System.Drawing.Point(44, 524);
            this.lblPOStatus.Name = "lblPOStatus";
            this.lblPOStatus.Size = new System.Drawing.Size(0, 23);
            this.lblPOStatus.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(79, 216);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(261, 33);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.rdoByDate);
            this.groupBox1.Controls.Add(this.rdoById);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(29, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 361);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // ModifyPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPOStatus);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpPoInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalAfterTax);
            this.Controls.Add(this.txtTaxRate);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ModifyPO";
            this.Size = new System.Drawing.Size(1166, 1609);
            this.Load += new System.EventHandler(this.ModifyPO_Load);
            this.grpPoInfo.ResumeLayout(false);
            this.grpPoInfo.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCreationDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPoNumber;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox txtTaxRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtTotalAfterTax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox grpPoInfo;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtJustification;
        private System.Windows.Forms.TextBox txtSupervisorName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdoByDate;
        private System.Windows.Forms.RadioButton rdoById;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnNotRequired;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNotRequired;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnModifyItem;
        private System.Windows.Forms.Button btnResetItem;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPOStatus;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
