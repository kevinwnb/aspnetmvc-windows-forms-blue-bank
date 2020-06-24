namespace BlueBank.WindowsForm.UI.Component
{
    partial class CreateEmployeeComponent
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.grpEmploymentInfo = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rdoRegular = new System.Windows.Forms.RadioButton();
            this.rdoHR = new System.Windows.Forms.RadioButton();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.dtpJobStartDate = new System.Windows.Forms.DateTimePicker();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboSupervisor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWorkPhone = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSIN = new System.Windows.Forms.TextBox();
            this.dtpSeniorityDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.grpPersonalInfo = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboStateProvince = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStreetAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.grpEmploymentInfo.SuspendLayout();
            this.grpPersonalInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F);
            this.btnCreate.Location = new System.Drawing.Point(405, 472);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(186, 46);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // grpEmploymentInfo
            // 
            this.grpEmploymentInfo.Controls.Add(this.label18);
            this.grpEmploymentInfo.Controls.Add(this.rdoRegular);
            this.grpEmploymentInfo.Controls.Add(this.rdoHR);
            this.grpEmploymentInfo.Controls.Add(this.chkIsActive);
            this.grpEmploymentInfo.Controls.Add(this.dtpJobStartDate);
            this.grpEmploymentInfo.Controls.Add(this.cboJob);
            this.grpEmploymentInfo.Controls.Add(this.label16);
            this.grpEmploymentInfo.Controls.Add(this.label11);
            this.grpEmploymentInfo.Controls.Add(this.cboSupervisor);
            this.grpEmploymentInfo.Controls.Add(this.label13);
            this.grpEmploymentInfo.Controls.Add(this.txtWorkPhone);
            this.grpEmploymentInfo.Controls.Add(this.label15);
            this.grpEmploymentInfo.Controls.Add(this.label14);
            this.grpEmploymentInfo.Controls.Add(this.cboDepartment);
            this.grpEmploymentInfo.Controls.Add(this.label9);
            this.grpEmploymentInfo.Controls.Add(this.txtSIN);
            this.grpEmploymentInfo.Controls.Add(this.dtpSeniorityDate);
            this.grpEmploymentInfo.Controls.Add(this.label12);
            this.grpEmploymentInfo.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F);
            this.grpEmploymentInfo.Location = new System.Drawing.Point(516, 72);
            this.grpEmploymentInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpEmploymentInfo.Name = "grpEmploymentInfo";
            this.grpEmploymentInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpEmploymentInfo.Size = new System.Drawing.Size(414, 365);
            this.grpEmploymentInfo.TabIndex = 7;
            this.grpEmploymentInfo.TabStop = false;
            this.grpEmploymentInfo.Text = "EMPLOYMENT INFORMATION";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(20, 289);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(238, 20);
            this.label18.TabIndex = 34;
            this.label18.Text = "Type  &&  Status";
            // 
            // rdoRegular
            // 
            this.rdoRegular.AutoSize = true;
            this.rdoRegular.Location = new System.Drawing.Point(19, 317);
            this.rdoRegular.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoRegular.Name = "rdoRegular";
            this.rdoRegular.Size = new System.Drawing.Size(72, 22);
            this.rdoRegular.TabIndex = 33;
            this.rdoRegular.TabStop = true;
            this.rdoRegular.Text = "Regular";
            this.rdoRegular.UseVisualStyleBackColor = true;
            this.rdoRegular.Click += new System.EventHandler(this.rdoType_Click);
            // 
            // rdoHR
            // 
            this.rdoHR.AutoSize = true;
            this.rdoHR.Location = new System.Drawing.Point(112, 316);
            this.rdoHR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoHR.Name = "rdoHR";
            this.rdoHR.Size = new System.Drawing.Size(44, 22);
            this.rdoHR.TabIndex = 32;
            this.rdoHR.TabStop = true;
            this.rdoHR.Text = "HR";
            this.rdoHR.UseVisualStyleBackColor = true;
            this.rdoHR.Click += new System.EventHandler(this.rdoType_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(180, 313);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(122, 23);
            this.chkIsActive.TabIndex = 6;
            this.chkIsActive.Text = "Active";
            this.chkIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // dtpJobStartDate
            // 
            this.dtpJobStartDate.Location = new System.Drawing.Point(188, 189);
            this.dtpJobStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpJobStartDate.Name = "dtpJobStartDate";
            this.dtpJobStartDate.Size = new System.Drawing.Size(215, 25);
            this.dtpJobStartDate.TabIndex = 24;
            this.dtpJobStartDate.ValueChanged += new System.EventHandler(this.JobSeniorityDate_ValueChanged);
            // 
            // cboJob
            // 
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Location = new System.Drawing.Point(17, 188);
            this.cboJob.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(133, 24);
            this.cboJob.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(14, 222);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 15);
            this.label16.TabIndex = 21;
            this.label16.Text = "Work Phone N°";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(14, 172);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Job Position";
            // 
            // cboSupervisor
            // 
            this.cboSupervisor.FormattingEnabled = true;
            this.cboSupervisor.Location = new System.Drawing.Point(180, 126);
            this.cboSupervisor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboSupervisor.Name = "cboSupervisor";
            this.cboSupervisor.Size = new System.Drawing.Size(133, 24);
            this.cboSupervisor.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(185, 173);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Job Start Date";
            // 
            // txtWorkPhone
            // 
            this.txtWorkPhone.Location = new System.Drawing.Point(17, 238);
            this.txtWorkPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtWorkPhone.Multiline = true;
            this.txtWorkPhone.Name = "txtWorkPhone";
            this.txtWorkPhone.Size = new System.Drawing.Size(133, 25);
            this.txtWorkPhone.TabIndex = 20;
            this.txtWorkPhone.Enter += new System.EventHandler(this.PlaceHolderText_Enter);
            this.txtWorkPhone.MouseLeave += new System.EventHandler(this.PlaceHolderText_Leave);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(177, 109);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "Supervisor";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 109);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 15);
            this.label14.TabIndex = 27;
            this.label14.Text = "Department";
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(9, 125);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(133, 24);
            this.cboDepartment.TabIndex = 26;
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(185, 42);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Seniority Date";
            // 
            // txtSIN
            // 
            this.txtSIN.Location = new System.Drawing.Point(12, 58);
            this.txtSIN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSIN.Multiline = true;
            this.txtSIN.Name = "txtSIN";
            this.txtSIN.Size = new System.Drawing.Size(138, 24);
            this.txtSIN.TabIndex = 20;
            this.txtSIN.Enter += new System.EventHandler(this.PlaceHolderText_Enter);
            this.txtSIN.MouseLeave += new System.EventHandler(this.PlaceHolderText_Leave);
            // 
            // dtpSeniorityDate
            // 
            this.dtpSeniorityDate.Location = new System.Drawing.Point(188, 58);
            this.dtpSeniorityDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpSeniorityDate.Name = "dtpSeniorityDate";
            this.dtpSeniorityDate.Size = new System.Drawing.Size(215, 25);
            this.dtpSeniorityDate.TabIndex = 20;
            this.dtpSeniorityDate.ValueChanged += new System.EventHandler(this.JobSeniorityDate_ValueChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(10, 42);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "SIN";
            // 
            // grpPersonalInfo
            // 
            this.grpPersonalInfo.Controls.Add(this.label19);
            this.grpPersonalInfo.Controls.Add(this.cboStateProvince);
            this.grpPersonalInfo.Controls.Add(this.label17);
            this.grpPersonalInfo.Controls.Add(this.label8);
            this.grpPersonalInfo.Controls.Add(this.cboCountry);
            this.grpPersonalInfo.Controls.Add(this.txtCellPhone);
            this.grpPersonalInfo.Controls.Add(this.label10);
            this.grpPersonalInfo.Controls.Add(this.txtEmail);
            this.grpPersonalInfo.Controls.Add(this.label7);
            this.grpPersonalInfo.Controls.Add(this.dtpBirthDate);
            this.grpPersonalInfo.Controls.Add(this.label4);
            this.grpPersonalInfo.Controls.Add(this.txtCity);
            this.grpPersonalInfo.Controls.Add(this.label5);
            this.grpPersonalInfo.Controls.Add(this.txtPostalCode);
            this.grpPersonalInfo.Controls.Add(this.label6);
            this.grpPersonalInfo.Controls.Add(this.txtStreetAddress);
            this.grpPersonalInfo.Controls.Add(this.label3);
            this.grpPersonalInfo.Controls.Add(this.txtMI);
            this.grpPersonalInfo.Controls.Add(this.label2);
            this.grpPersonalInfo.Controls.Add(this.txtLastName);
            this.grpPersonalInfo.Controls.Add(this.label1);
            this.grpPersonalInfo.Controls.Add(this.txtFirstName);
            this.grpPersonalInfo.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F);
            this.grpPersonalInfo.Location = new System.Drawing.Point(21, 72);
            this.grpPersonalInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpPersonalInfo.Name = "grpPersonalInfo";
            this.grpPersonalInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpPersonalInfo.Size = new System.Drawing.Size(460, 365);
            this.grpPersonalInfo.TabIndex = 6;
            this.grpPersonalInfo.TabStop = false;
            this.grpPersonalInfo.Text = "PERSONAL INFORMATION";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(149, 173);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(134, 15);
            this.label19.TabIndex = 38;
            this.label19.Text = "State / Province";
            // 
            // cboStateProvince
            // 
            this.cboStateProvince.FormattingEnabled = true;
            this.cboStateProvince.Location = new System.Drawing.Point(152, 189);
            this.cboStateProvince.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboStateProvince.Name = "cboStateProvince";
            this.cboStateProvince.Size = new System.Drawing.Size(133, 24);
            this.cboStateProvince.TabIndex = 37;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 173);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(134, 15);
            this.label17.TabIndex = 36;
            this.label17.Text = "Country";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 308);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Cell Phone N°";
            // 
            // cboCountry
            // 
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(10, 189);
            this.cboCountry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(133, 24);
            this.cboCountry.TabIndex = 35;
            this.cboCountry.SelectionChangeCommitted += new System.EventHandler(this.cboCountry_SelectionChangeCommitted);
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Location = new System.Drawing.Point(10, 324);
            this.txtCellPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCellPhone.Multiline = true;
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(124, 24);
            this.txtCellPhone.TabIndex = 18;
            this.txtCellPhone.Enter += new System.EventHandler(this.PlaceHolderText_Enter);
            this.txtCellPhone.MouseLeave += new System.EventHandler(this.PlaceHolderText_Leave);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(141, 310);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Email Address";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(144, 326);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(265, 22);
            this.txtEmail.TabIndex = 14;
            this.txtEmail.Enter += new System.EventHandler(this.PlaceHolderText_Enter);
            this.txtEmail.MouseLeave += new System.EventHandler(this.PlaceHolderText_Leave);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Birth Date";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(12, 109);
            this.dtpBirthDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(220, 25);
            this.dtpBirthDate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(300, 173);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(302, 189);
            this.txtCity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCity.Multiline = true;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(146, 22);
            this.txtCity.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(300, 225);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Postal Code\r\n";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(302, 241);
            this.txtPostalCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPostalCode.Multiline = true;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(146, 22);
            this.txtPostalCode.TabIndex = 8;
            this.txtPostalCode.Enter += new System.EventHandler(this.PlaceHolderText_Enter);
            this.txtPostalCode.MouseLeave += new System.EventHandler(this.PlaceHolderText_Leave);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 225);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Street Address";
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.Location = new System.Drawing.Point(8, 241);
            this.txtStreetAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStreetAddress.Multiline = true;
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.Size = new System.Drawing.Size(276, 22);
            this.txtStreetAddress.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(150, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Middle Initial";
            // 
            // txtMI
            // 
            this.txtMI.Location = new System.Drawing.Point(152, 58);
            this.txtMI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMI.Multiline = true;
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(80, 24);
            this.txtMI.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(246, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(248, 58);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLastName.Multiline = true;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(124, 24);
            this.txtLastName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(12, 58);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFirstName.Multiline = true;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(124, 24);
            this.txtFirstName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 52);
            this.panel1.TabIndex = 11;
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
            this.label20.Text = "CREATE EMPLOYEE";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblError);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 555);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 54);
            this.panel2.TabIndex = 12;
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Font = new System.Drawing.Font("Microsoft Tai Le", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(952, 50);
            this.lblError.TabIndex = 0;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateEmployeeComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.grpEmploymentInfo);
            this.Controls.Add(this.grpPersonalInfo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CreateEmployeeComponent";
            this.Size = new System.Drawing.Size(956, 609);
            this.Load += new System.EventHandler(this.CreateEmployee_Load);
            this.grpEmploymentInfo.ResumeLayout(false);
            this.grpEmploymentInfo.PerformLayout();
            this.grpPersonalInfo.ResumeLayout(false);
            this.grpPersonalInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox grpEmploymentInfo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rdoRegular;
        private System.Windows.Forms.RadioButton rdoHR;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.DateTimePicker dtpJobStartDate;
        private System.Windows.Forms.ComboBox cboJob;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboSupervisor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtWorkPhone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSIN;
        private System.Windows.Forms.DateTimePicker dtpSeniorityDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpPersonalInfo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboStateProvince;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblError;
    }
}
