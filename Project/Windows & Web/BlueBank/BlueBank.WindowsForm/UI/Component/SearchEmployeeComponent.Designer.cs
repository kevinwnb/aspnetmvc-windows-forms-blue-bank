namespace BlueBank.WindowsForm.UI.Component
{
    partial class SearchEmployeeComponent
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
            this.dgvMatchingEmployees = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdoId = new System.Windows.Forms.RadioButton();
            this.rdoLn = new System.Windows.Forms.RadioButton();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpld = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFullAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWorkOhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchingEmployees)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMatchingEmployees
            // 
            this.dgvMatchingEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatchingEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatchingEmployees.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMatchingEmployees.Location = new System.Drawing.Point(0, 42);
            this.dgvMatchingEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMatchingEmployees.Name = "dgvMatchingEmployees";
            this.dgvMatchingEmployees.RowHeadersWidth = 82;
            this.dgvMatchingEmployees.RowTemplate.Height = 33;
            this.dgvMatchingEmployees.Size = new System.Drawing.Size(391, 340);
            this.dgvMatchingEmployees.TabIndex = 21;
            this.dgvMatchingEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatchingEmployees_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.rdoId);
            this.groupBox1.Controls.Add(this.rdoLn);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Location = new System.Drawing.Point(134, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(722, 86);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(546, 37);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 25);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoId
            // 
            this.rdoId.AutoSize = true;
            this.rdoId.Checked = true;
            this.rdoId.Location = new System.Drawing.Point(113, 40);
            this.rdoId.Margin = new System.Windows.Forms.Padding(4);
            this.rdoId.Name = "rdoId";
            this.rdoId.Size = new System.Drawing.Size(40, 22);
            this.rdoId.TabIndex = 1;
            this.rdoId.TabStop = true;
            this.rdoId.Text = "ID";
            this.rdoId.UseVisualStyleBackColor = true;
            this.rdoId.Click += new System.EventHandler(this.rdoFilter_Click);
            // 
            // rdoLn
            // 
            this.rdoLn.AutoSize = true;
            this.rdoLn.Location = new System.Drawing.Point(178, 40);
            this.rdoLn.Margin = new System.Windows.Forms.Padding(4);
            this.rdoLn.Name = "rdoLn";
            this.rdoLn.Size = new System.Drawing.Size(159, 22);
            this.rdoLn.TabIndex = 0;
            this.rdoLn.Text = "Full/Partial Last Name";
            this.rdoLn.UseVisualStyleBackColor = true;
            this.rdoLn.Click += new System.EventHandler(this.rdoFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(368, 37);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(151, 25);
            this.txtFilter.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 52);
            this.panel1.TabIndex = 23;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Copperplate Gothic Light", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.Control;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(956, 52);
            this.label20.TabIndex = 0;
            this.label20.Text = "SEARCH EMPLOYEE";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtCellPhone);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtWorkOhone);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtFullAddress);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtFullName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtEmpld);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(559, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 382);
            this.panel2.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "EMPLOYEE INFORMATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dgvMatchingEmployees);
            this.panel3.Location = new System.Drawing.Point(116, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 382);
            this.panel3.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 42);
            this.label2.TabIndex = 24;
            this.label2.Text = "MATCHING EMPLOYEES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmpld
            // 
            this.txtEmpld.Enabled = false;
            this.txtEmpld.Location = new System.Drawing.Point(20, 61);
            this.txtEmpld.Name = "txtEmpld";
            this.txtEmpld.Size = new System.Drawing.Size(291, 25);
            this.txtEmpld.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Employee Id";
            // 
            // txtFullName
            // 
            this.txtFullName.Enabled = false;
            this.txtFullName.Location = new System.Drawing.Point(20, 117);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(291, 25);
            this.txtFullName.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Full Name";
            // 
            // txtFullAddress
            // 
            this.txtFullAddress.Enabled = false;
            this.txtFullAddress.Location = new System.Drawing.Point(20, 172);
            this.txtFullAddress.Multiline = true;
            this.txtFullAddress.Name = "txtFullAddress";
            this.txtFullAddress.Size = new System.Drawing.Size(291, 45);
            this.txtFullAddress.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "Full Address";
            // 
            // txtWorkOhone
            // 
            this.txtWorkOhone.Enabled = false;
            this.txtWorkOhone.Location = new System.Drawing.Point(20, 241);
            this.txtWorkOhone.Name = "txtWorkOhone";
            this.txtWorkOhone.Size = new System.Drawing.Size(291, 25);
            this.txtWorkOhone.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "Work Phone N°";
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Enabled = false;
            this.txtCellPhone.Location = new System.Drawing.Point(20, 298);
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(291, 25);
            this.txtCellPhone.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "Cell Phone N°";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(20, 352);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(291, 25);
            this.txtEmail.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 18);
            this.label8.TabIndex = 35;
            this.label8.Text = "Email Address";
            // 
            // SearchEmployeeComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchEmployeeComponent";
            this.Size = new System.Drawing.Size(956, 609);
            this.Load += new System.EventHandler(this.SearchEmployeeComponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchingEmployees)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMatchingEmployees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdoId;
        private System.Windows.Forms.RadioButton rdoLn;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWorkOhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFullAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpld;
    }
}
