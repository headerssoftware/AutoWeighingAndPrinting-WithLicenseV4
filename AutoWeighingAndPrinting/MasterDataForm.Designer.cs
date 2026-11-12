namespace AutoWeighingAndPrinting
{
    partial class MasterDataForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Obsolete]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterDataForm));
            this.tcMasterData = new System.Windows.Forms.TabControl();
            this.tpManageChildParts = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChildPartRowCount = new System.Windows.Forms.Label();
            this.btnEditChildPart = new System.Windows.Forms.Button();
            this.btnAddChildParts = new System.Windows.Forms.Button();
            this.btnDeleteChildPart = new System.Windows.Forms.Button();
            this.dgvViewChildParts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnViewChildParts = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tpChangePassword = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbOldPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tpViewPrintingHistory = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblChildHistoryRowCount = new System.Windows.Forms.Label();
            this.btnChildExportToExcel = new System.Windows.Forms.Button();
            this.dgvChildPartsHistory = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnChildSubmit = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpChildToDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpChildFromDate = new System.Windows.Forms.DateTimePicker();
            this.tcMasterData.SuspendLayout();
            this.tpManageChildParts.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewChildParts)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.tpChangePassword.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tpViewPrintingHistory.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChildPartsHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMasterData
            // 
            this.tcMasterData.Controls.Add(this.tpManageChildParts);
            this.tcMasterData.Controls.Add(this.tpChangePassword);
            this.tcMasterData.Controls.Add(this.tpViewPrintingHistory);
            this.tcMasterData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMasterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMasterData.Location = new System.Drawing.Point(0, 0);
            this.tcMasterData.Name = "tcMasterData";
            this.tcMasterData.SelectedIndex = 0;
            this.tcMasterData.Size = new System.Drawing.Size(984, 662);
            this.tcMasterData.TabIndex = 0;
            this.tcMasterData.SelectedIndexChanged += new System.EventHandler(this.TcMasterData_SelectedIndexChanged);
            // 
            // tpManageChildParts
            // 
            this.tpManageChildParts.BackColor = System.Drawing.Color.Transparent;
            this.tpManageChildParts.Controls.Add(this.tableLayoutPanel1);
            this.tpManageChildParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpManageChildParts.Location = new System.Drawing.Point(4, 29);
            this.tpManageChildParts.Name = "tpManageChildParts";
            this.tpManageChildParts.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpManageChildParts.Size = new System.Drawing.Size(976, 629);
            this.tpManageChildParts.TabIndex = 0;
            this.tpManageChildParts.Text = "Manage Child Parts";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 415F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(970, 623);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblChildPartRowCount);
            this.panel1.Controls.Add(this.btnEditChildPart);
            this.panel1.Controls.Add(this.btnAddChildParts);
            this.panel1.Controls.Add(this.btnDeleteChildPart);
            this.panel1.Controls.Add(this.dgvViewChildParts);
            this.panel1.Controls.Add(this.btnViewChildParts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 617);
            this.panel1.TabIndex = 0;
            // 
            // lblChildPartRowCount
            // 
            this.lblChildPartRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChildPartRowCount.AutoSize = true;
            this.lblChildPartRowCount.Location = new System.Drawing.Point(123, 590);
            this.lblChildPartRowCount.Name = "lblChildPartRowCount";
            this.lblChildPartRowCount.Size = new System.Drawing.Size(92, 17);
            this.lblChildPartRowCount.TabIndex = 5;
            this.lblChildPartRowCount.Text = "Row Count: 0";
            // 
            // btnEditChildPart
            // 
            this.btnEditChildPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditChildPart.Location = new System.Drawing.Point(460, 582);
            this.btnEditChildPart.Name = "btnEditChildPart";
            this.btnEditChildPart.Size = new System.Drawing.Size(86, 33);
            this.btnEditChildPart.TabIndex = 4;
            this.btnEditChildPart.Text = "Edit";
            this.btnEditChildPart.UseVisualStyleBackColor = true;
            this.btnEditChildPart.Click += new System.EventHandler(this.BtnEditChildPart_Click);
            // 
            // btnAddChildParts
            // 
            this.btnAddChildParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChildParts.Location = new System.Drawing.Point(460, 14);
            this.btnAddChildParts.Name = "btnAddChildParts";
            this.btnAddChildParts.Size = new System.Drawing.Size(86, 33);
            this.btnAddChildParts.TabIndex = 1;
            this.btnAddChildParts.Text = "Add New";
            this.btnAddChildParts.UseVisualStyleBackColor = true;
            this.btnAddChildParts.Click += new System.EventHandler(this.BtnAddChildParts_Click);
            // 
            // btnDeleteChildPart
            // 
            this.btnDeleteChildPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteChildPart.Location = new System.Drawing.Point(3, 582);
            this.btnDeleteChildPart.Name = "btnDeleteChildPart";
            this.btnDeleteChildPart.Size = new System.Drawing.Size(86, 33);
            this.btnDeleteChildPart.TabIndex = 3;
            this.btnDeleteChildPart.Text = "Delete";
            this.btnDeleteChildPart.UseVisualStyleBackColor = true;
            this.btnDeleteChildPart.Click += new System.EventHandler(this.BtnDeleteChildPart_Click);
            // 
            // dgvViewChildParts
            // 
            this.dgvViewChildParts.AllowUserToAddRows = false;
            this.dgvViewChildParts.AllowUserToDeleteRows = false;
            this.dgvViewChildParts.AllowUserToResizeRows = false;
            this.dgvViewChildParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViewChildParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvViewChildParts.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvViewChildParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewChildParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvViewChildParts.Location = new System.Drawing.Point(3, 53);
            this.dgvViewChildParts.MultiSelect = false;
            this.dgvViewChildParts.Name = "dgvViewChildParts";
            this.dgvViewChildParts.RowHeadersVisible = false;
            this.dgvViewChildParts.RowHeadersWidth = 51;
            this.dgvViewChildParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViewChildParts.Size = new System.Drawing.Size(543, 522);
            this.dgvViewChildParts.TabIndex = 2;
            this.dgvViewChildParts.DataSourceChanged += new System.EventHandler(this.DgvViewChildParts_DataSourceChanged);
            this.dgvViewChildParts.SelectionChanged += new System.EventHandler(this.DgvViewChildParts_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // btnViewChildParts
            // 
            this.btnViewChildParts.Location = new System.Drawing.Point(3, 14);
            this.btnViewChildParts.Name = "btnViewChildParts";
            this.btnViewChildParts.Size = new System.Drawing.Size(86, 33);
            this.btnViewChildParts.TabIndex = 0;
            this.btnViewChildParts.Text = "View";
            this.btnViewChildParts.UseVisualStyleBackColor = true;
            this.btnViewChildParts.Click += new System.EventHandler(this.BtnViewChildParts_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pbImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(558, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 617);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Image";
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.LightGray;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(3, 89);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(400, 400);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 10;
            this.pbImage.TabStop = false;
            // 
            // tpChangePassword
            // 
            this.tpChangePassword.Controls.Add(this.panel5);
            this.tpChangePassword.Location = new System.Drawing.Point(4, 29);
            this.tpChangePassword.Name = "tpChangePassword";
            this.tpChangePassword.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpChangePassword.Size = new System.Drawing.Size(976, 629);
            this.tpChangePassword.TabIndex = 2;
            this.tpChangePassword.Text = "Change Password";
            this.tpChangePassword.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnChangePassword);
            this.panel5.Controls.Add(this.tbNewPassword);
            this.panel5.Controls.Add(this.tbOldPassword);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(970, 623);
            this.panel5.TabIndex = 0;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Location = new System.Drawing.Point(251, 97);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(184, 35);
            this.btnChangePassword.TabIndex = 2;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewPassword.Location = new System.Drawing.Point(251, 62);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(184, 29);
            this.tbNewPassword.TabIndex = 1;
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOldPassword.Location = new System.Drawing.Point(251, 24);
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.PasswordChar = '*';
            this.tbOldPassword.Size = new System.Drawing.Size(184, 29);
            this.tbOldPassword.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(38, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 24);
            this.label11.TabIndex = 1;
            this.label11.Text = "Enter New Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(38, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Enter Old Password";
            // 
            // tpViewPrintingHistory
            // 
            this.tpViewPrintingHistory.Controls.Add(this.panel6);
            this.tpViewPrintingHistory.Location = new System.Drawing.Point(4, 29);
            this.tpViewPrintingHistory.Name = "tpViewPrintingHistory";
            this.tpViewPrintingHistory.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpViewPrintingHistory.Size = new System.Drawing.Size(976, 629);
            this.tpViewPrintingHistory.TabIndex = 3;
            this.tpViewPrintingHistory.Text = "View Printed History";
            this.tpViewPrintingHistory.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(970, 623);
            this.panel6.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(970, 623);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(962, 590);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Child Parts Printed History";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblChildHistoryRowCount);
            this.panel7.Controls.Add(this.btnChildExportToExcel);
            this.panel7.Controls.Add(this.dgvChildPartsHistory);
            this.panel7.Controls.Add(this.btnChildSubmit);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.dtpChildToDate);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.dtpChildFromDate);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(956, 584);
            this.panel7.TabIndex = 0;
            // 
            // lblChildHistoryRowCount
            // 
            this.lblChildHistoryRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChildHistoryRowCount.AutoSize = true;
            this.lblChildHistoryRowCount.Location = new System.Drawing.Point(223, 552);
            this.lblChildHistoryRowCount.Name = "lblChildHistoryRowCount";
            this.lblChildHistoryRowCount.Size = new System.Drawing.Size(105, 20);
            this.lblChildHistoryRowCount.TabIndex = 7;
            this.lblChildHistoryRowCount.Text = "Row Count: 0";
            // 
            // btnChildExportToExcel
            // 
            this.btnChildExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChildExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChildExportToExcel.Location = new System.Drawing.Point(64, 546);
            this.btnChildExportToExcel.Name = "btnChildExportToExcel";
            this.btnChildExportToExcel.Size = new System.Drawing.Size(130, 33);
            this.btnChildExportToExcel.TabIndex = 6;
            this.btnChildExportToExcel.Text = "Export To Excel";
            this.btnChildExportToExcel.UseVisualStyleBackColor = true;
            this.btnChildExportToExcel.Click += new System.EventHandler(this.BtnChildExportToExcel_Click);
            // 
            // dgvChildPartsHistory
            // 
            this.dgvChildPartsHistory.AllowUserToAddRows = false;
            this.dgvChildPartsHistory.AllowUserToDeleteRows = false;
            this.dgvChildPartsHistory.AllowUserToResizeRows = false;
            this.dgvChildPartsHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChildPartsHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvChildPartsHistory.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvChildPartsHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChildPartsHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn3});
            this.dgvChildPartsHistory.Location = new System.Drawing.Point(3, 46);
            this.dgvChildPartsHistory.MultiSelect = false;
            this.dgvChildPartsHistory.Name = "dgvChildPartsHistory";
            this.dgvChildPartsHistory.RowHeadersVisible = false;
            this.dgvChildPartsHistory.RowHeadersWidth = 51;
            this.dgvChildPartsHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChildPartsHistory.Size = new System.Drawing.Size(950, 494);
            this.dgvChildPartsHistory.TabIndex = 5;
            this.dgvChildPartsHistory.DataSourceChanged += new System.EventHandler(this.DgvChildPartsHistory_DataSourceChanged);
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewCheckBoxColumn3.HeaderText = "";
            this.dataGridViewCheckBoxColumn3.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            // 
            // btnChildSubmit
            // 
            this.btnChildSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChildSubmit.Location = new System.Drawing.Point(425, 7);
            this.btnChildSubmit.Name = "btnChildSubmit";
            this.btnChildSubmit.Size = new System.Drawing.Size(110, 33);
            this.btnChildSubmit.TabIndex = 4;
            this.btnChildSubmit.Text = "Submit";
            this.btnChildSubmit.UseVisualStyleBackColor = true;
            this.btnChildSubmit.Click += new System.EventHandler(this.BtnChildSubmit_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(263, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 20);
            this.label13.TabIndex = 3;
            this.label13.Text = "To";
            // 
            // dtpChildToDate
            // 
            this.dtpChildToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpChildToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChildToDate.Location = new System.Drawing.Point(296, 11);
            this.dtpChildToDate.Name = "dtpChildToDate";
            this.dtpChildToDate.Size = new System.Drawing.Size(123, 26);
            this.dtpChildToDate.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "From";
            // 
            // dtpChildFromDate
            // 
            this.dtpChildFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpChildFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChildFromDate.Location = new System.Drawing.Point(112, 11);
            this.dtpChildFromDate.Name = "dtpChildFromDate";
            this.dtpChildFromDate.Size = new System.Drawing.Size(123, 26);
            this.dtpChildFromDate.TabIndex = 0;
            // 
            // MasterDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.tcMasterData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(999, 669);
            this.Name = "MasterDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Weighing and Printing V4 - Master Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MasterDataForm_Load);
            this.tcMasterData.ResumeLayout(false);
            this.tpManageChildParts.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewChildParts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.tpChangePassword.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tpViewPrintingHistory.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChildPartsHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMasterData;
        private System.Windows.Forms.TabPage tpManageChildParts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnViewChildParts;
        private System.Windows.Forms.DataGridView dgvViewChildParts;
        private System.Windows.Forms.Button btnDeleteChildPart;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddChildParts;
        private System.Windows.Forms.Button btnEditChildPart;
        private System.Windows.Forms.Label lblChildPartRowCount;
        private System.Windows.Forms.TabPage tpChangePassword;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbOldPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tpViewPrintingHistory;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnChildExportToExcel;
        private System.Windows.Forms.DataGridView dgvChildPartsHistory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.Button btnChildSubmit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpChildToDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpChildFromDate;
        private System.Windows.Forms.Label lblChildHistoryRowCount;
    }
}