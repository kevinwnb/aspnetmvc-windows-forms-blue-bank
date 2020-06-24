namespace BlueBank.WindowsForm.UI.Component
{
    partial class ModifyEmployeeComponent
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMatchingEmployees = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdoId = new System.Windows.Forms.RadioButton();
            this.rdoLn = new System.Windows.Forms.RadioButton();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoEmploymentInfo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoJobInfo = new System.Windows.Forms.RadioButton();
            this.rdoPersonalInfo = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchingEmployees)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dgvMatchingEmployees);
            this.panel3.Location = new System.Drawing.Point(11, 300);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 302);
            this.panel3.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "MATCHING EMPLOYEES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvMatchingEmployees
            // 
            this.dgvMatchingEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatchingEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatchingEmployees.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMatchingEmployees.Location = new System.Drawing.Point(0, 23);
            this.dgvMatchingEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMatchingEmployees.Name = "dgvMatchingEmployees";
            this.dgvMatchingEmployees.RowHeadersWidth = 82;
            this.dgvMatchingEmployees.RowTemplate.Height = 33;
            this.dgvMatchingEmployees.Size = new System.Drawing.Size(391, 279);
            this.dgvMatchingEmployees.TabIndex = 21;
            this.dgvMatchingEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatchingEmployees_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 52);
            this.panel1.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Copperplate Gothic Light", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.Control;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(1085, 52);
            this.label20.TabIndex = 0;
            this.label20.Text = "MODIFY EMPLOYEE";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.rdoId);
            this.groupBox1.Controls.Add(this.rdoLn);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Location = new System.Drawing.Point(11, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(391, 91);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(241, 58);
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
            this.rdoId.Location = new System.Drawing.Point(19, 22);
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
            this.rdoLn.Location = new System.Drawing.Point(18, 56);
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
            this.txtFilter.Location = new System.Drawing.Point(225, 22);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(137, 25);
            this.txtFilter.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rdoEmploymentInfo);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.rdoJobInfo);
            this.panel4.Controls.Add(this.rdoPersonalInfo);
            this.panel4.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(11, 174);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(391, 111);
            this.panel4.TabIndex = 31;
            // 
            // rdoEmploymentInfo
            // 
            this.rdoEmploymentInfo.AutoSize = true;
            this.rdoEmploymentInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rdoEmploymentInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdoEmploymentInfo.Location = new System.Drawing.Point(15, 72);
            this.rdoEmploymentInfo.Margin = new System.Windows.Forms.Padding(2);
            this.rdoEmploymentInfo.Name = "rdoEmploymentInfo";
            this.rdoEmploymentInfo.Size = new System.Drawing.Size(152, 22);
            this.rdoEmploymentInfo.TabIndex = 2;
            this.rdoEmploymentInfo.Text = "Employement Status";
            this.rdoEmploymentInfo.UseVisualStyleBackColor = true;
            this.rdoEmploymentInfo.Click += new System.EventHandler(this.rdoType_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHOOSE TYPE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoJobInfo
            // 
            this.rdoJobInfo.AutoSize = true;
            this.rdoJobInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rdoJobInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdoJobInfo.Location = new System.Drawing.Point(15, 46);
            this.rdoJobInfo.Margin = new System.Windows.Forms.Padding(2);
            this.rdoJobInfo.Name = "rdoJobInfo";
            this.rdoJobInfo.Size = new System.Drawing.Size(75, 22);
            this.rdoJobInfo.TabIndex = 1;
            this.rdoJobInfo.Text = "Job Info";
            this.rdoJobInfo.UseVisualStyleBackColor = true;
            this.rdoJobInfo.Click += new System.EventHandler(this.rdoType_Click);
            // 
            // rdoPersonalInfo
            // 
            this.rdoPersonalInfo.AutoSize = true;
            this.rdoPersonalInfo.Checked = true;
            this.rdoPersonalInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rdoPersonalInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdoPersonalInfo.Location = new System.Drawing.Point(14, 20);
            this.rdoPersonalInfo.Margin = new System.Windows.Forms.Padding(2);
            this.rdoPersonalInfo.Name = "rdoPersonalInfo";
            this.rdoPersonalInfo.Size = new System.Drawing.Size(106, 22);
            this.rdoPersonalInfo.TabIndex = 0;
            this.rdoPersonalInfo.TabStop = true;
            this.rdoPersonalInfo.Text = "Personal Info";
            this.rdoPersonalInfo.UseVisualStyleBackColor = true;
            this.rdoPersonalInfo.Click += new System.EventHandler(this.rdoType_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlInfo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(444, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 488);
            this.panel2.TabIndex = 32;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(0, 23);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(623, 465);
            this.pnlInfo.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(623, 23);
            this.label9.TabIndex = 23;
            this.label9.Text = "EMPLOYEE INFORMATION";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(691, 571);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 31);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ModifyEmployeeComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModifyEmployeeComponent";
            this.Size = new System.Drawing.Size(1085, 615);
            this.Load += new System.EventHandler(this.ModifyEmployeeComponent_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchingEmployees)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvMatchingEmployees;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdoId;
        private System.Windows.Forms.RadioButton rdoLn;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoEmploymentInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoJobInfo;
        private System.Windows.Forms.RadioButton rdoPersonalInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlInfo;
    }
}
