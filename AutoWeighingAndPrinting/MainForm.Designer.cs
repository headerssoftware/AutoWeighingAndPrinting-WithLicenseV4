namespace AutoWeighingAndPrinting
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcMainForm = new System.Windows.Forms.TabControl();
            this.tpChildPartWeighing = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tlImage = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.tlImageContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tlWeighStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblAutoWeighingStatus = new System.Windows.Forms.Label();
            this.tlLiveWeight = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblWeightStatus = new System.Windows.Forms.Label();
            this.tlWeightRange = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaximumWeight = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label33 = new System.Windows.Forms.Label();
            this.lblRequiredWeight = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMinimumWeight = new System.Windows.Forms.Label();
            this.tlCount = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTodayPrintCount = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSelectedLabelSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.btnSelectPrinter = new System.Windows.Forms.Button();
            this.txtPrinterName = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tbSideInfo = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tbExpiryDays = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tbReferenceNumber = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbPositiveTolPartWeight = new System.Windows.Forms.TextBox();
            this.tbPositiveTolPercent = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbTolPartWeight = new System.Windows.Forms.TextBox();
            this.tbTolPercent = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNegativeTolPartWeight = new System.Windows.Forms.TextBox();
            this.tbNegativeTolPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDBPartWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChildPartSubmit = new System.Windows.Forms.Button();
            this.tbChildPartDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRequiredQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbChildPartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbLicenseinfo = new System.Windows.Forms.PictureBox();
            this.lblLicenseExpirationInfo = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnMasterData = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this._serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.tcMainForm.SuspendLayout();
            this.tpChildPartWeighing.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlImage.SuspendLayout();
            this.tlImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.tlWeighStatus.SuspendLayout();
            this.tlLiveWeight.SuspendLayout();
            this.tlWeightRange.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlCount.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicenseinfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.tcMainForm);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 749);
            this.panel1.TabIndex = 0;
            // 
            // tcMainForm
            // 
            this.tcMainForm.Controls.Add(this.tpChildPartWeighing);
            this.tcMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMainForm.Location = new System.Drawing.Point(0, 50);
            this.tcMainForm.Name = "tcMainForm";
            this.tcMainForm.SelectedIndex = 0;
            this.tcMainForm.Size = new System.Drawing.Size(1048, 699);
            this.tcMainForm.TabIndex = 1;
            this.tcMainForm.SelectedIndexChanged += new System.EventHandler(this.TcMainForm_SelectedIndexChanged);
            // 
            // tpChildPartWeighing
            // 
            this.tpChildPartWeighing.Controls.Add(this.tableLayoutPanel1);
            this.tpChildPartWeighing.Location = new System.Drawing.Point(4, 29);
            this.tpChildPartWeighing.Name = "tpChildPartWeighing";
            this.tpChildPartWeighing.Padding = new System.Windows.Forms.Padding(3);
            this.tpChildPartWeighing.Size = new System.Drawing.Size(1040, 666);
            this.tpChildPartWeighing.TabIndex = 0;
            this.tpChildPartWeighing.Text = "Child Parts Weighing";
            this.tpChildPartWeighing.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 431F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1034, 660);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tlImage);
            this.panel5.Controls.Add(this.tlWeighStatus);
            this.panel5.Controls.Add(this.tlLiveWeight);
            this.panel5.Controls.Add(this.tlWeightRange);
            this.panel5.Controls.Add(this.tlCount);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(434, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(597, 654);
            this.panel5.TabIndex = 1;
            // 
            // tlImage
            // 
            this.tlImage.ColumnCount = 1;
            this.tlImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlImage.Controls.Add(this.tlImageContainer, 0, 1);
            this.tlImage.Controls.Add(this.label6, 0, 0);
            this.tlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlImage.Location = new System.Drawing.Point(0, 259);
            this.tlImage.Name = "tlImage";
            this.tlImage.RowCount = 2;
            this.tlImage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlImage.Size = new System.Drawing.Size(597, 395);
            this.tlImage.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Image";
            // 
            // tlImageContainer
            // 
            this.tlImageContainer.ColumnCount = 1;
            this.tlImageContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlImageContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlImageContainer.Controls.Add(this.pbImage, 0, 0);
            this.tlImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlImageContainer.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlImageContainer.Location = new System.Drawing.Point(3, 23);
            this.tlImageContainer.Name = "tlImageContainer";
            this.tlImageContainer.RowCount = 1;
            this.tlImageContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlImageContainer.Size = new System.Drawing.Size(591, 369);
            this.tlImageContainer.TabIndex = 15;
            this.tlImageContainer.Resize += new System.EventHandler(this.TlImageContainer_Resize);
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(585, 363);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 15;
            this.pbImage.TabStop = false;
            // 
            // tlWeighStatus
            // 
            this.tlWeighStatus.ColumnCount = 2;
            this.tlWeighStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlWeighStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlWeighStatus.Controls.Add(this.lblCountdown, 0, 0);
            this.tlWeighStatus.Controls.Add(this.lblAutoWeighingStatus, 1, 0);
            this.tlWeighStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlWeighStatus.Location = new System.Drawing.Point(0, 206);
            this.tlWeighStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tlWeighStatus.Name = "tlWeighStatus";
            this.tlWeighStatus.RowCount = 1;
            this.tlWeighStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlWeighStatus.Size = new System.Drawing.Size(597, 53);
            this.tlWeighStatus.TabIndex = 39;
            // 
            // lblCountdown
            // 
            this.lblCountdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(3, 0);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(47, 53);
            this.lblCountdown.TabIndex = 31;
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCountdown.Visible = false;
            this.lblCountdown.TextChanged += new System.EventHandler(this.LblCountdown_TextChanged);
            // 
            // lblAutoWeighingStatus
            // 
            this.lblAutoWeighingStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAutoWeighingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoWeighingStatus.Location = new System.Drawing.Point(56, 0);
            this.lblAutoWeighingStatus.Name = "lblAutoWeighingStatus";
            this.lblAutoWeighingStatus.Size = new System.Drawing.Size(538, 53);
            this.lblAutoWeighingStatus.TabIndex = 30;
            this.lblAutoWeighingStatus.Text = "WAITING FOR PART";
            this.lblAutoWeighingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlLiveWeight
            // 
            this.tlLiveWeight.ColumnCount = 1;
            this.tlLiveWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlLiveWeight.Controls.Add(this.label12, 0, 0);
            this.tlLiveWeight.Controls.Add(this.lblWeightStatus, 0, 1);
            this.tlLiveWeight.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlLiveWeight.Location = new System.Drawing.Point(0, 121);
            this.tlLiveWeight.Name = "tlLiveWeight";
            this.tlLiveWeight.RowCount = 2;
            this.tlLiveWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tlLiveWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tlLiveWeight.Size = new System.Drawing.Size(597, 85);
            this.tlLiveWeight.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(591, 24);
            this.label12.TabIndex = 35;
            this.label12.Text = "Live Weight (KG)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeightStatus
            // 
            this.lblWeightStatus.BackColor = System.Drawing.Color.Red;
            this.lblWeightStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWeightStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeightStatus.Location = new System.Drawing.Point(3, 24);
            this.lblWeightStatus.Name = "lblWeightStatus";
            this.lblWeightStatus.Size = new System.Drawing.Size(591, 61);
            this.lblWeightStatus.TabIndex = 32;
            this.lblWeightStatus.Text = "0.0000";
            this.lblWeightStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlWeightRange
            // 
            this.tlWeightRange.ColumnCount = 3;
            this.tlWeightRange.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlWeightRange.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlWeightRange.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlWeightRange.Controls.Add(this.panel8, 2, 0);
            this.tlWeightRange.Controls.Add(this.panel7, 1, 0);
            this.tlWeightRange.Controls.Add(this.panel6, 0, 0);
            this.tlWeightRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlWeightRange.Location = new System.Drawing.Point(0, 34);
            this.tlWeightRange.Name = "tlWeightRange";
            this.tlWeightRange.RowCount = 1;
            this.tlWeightRange.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlWeightRange.Size = new System.Drawing.Size(597, 87);
            this.tlWeightRange.TabIndex = 36;
            // 
            // panel8
            // 
            this.panel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel8.BackColor = System.Drawing.Color.Salmon;
            this.panel8.Controls.Add(this.tableLayoutPanel4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(399, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(195, 81);
            this.panel8.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblMaximumWeight, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(195, 81);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lblMaximumWeight
            // 
            this.lblMaximumWeight.BackColor = System.Drawing.Color.Salmon;
            this.lblMaximumWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaximumWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximumWeight.Location = new System.Drawing.Point(3, 40);
            this.lblMaximumWeight.Name = "lblMaximumWeight";
            this.lblMaximumWeight.Size = new System.Drawing.Size(189, 41);
            this.lblMaximumWeight.TabIndex = 11;
            this.lblMaximumWeight.Text = "0.0000";
            this.lblMaximumWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Salmon;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 40);
            this.label11.TabIndex = 10;
            this.label11.Text = "Maximum Wt (KG)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.BackColor = System.Drawing.Color.LightGreen;
            this.panel7.Controls.Add(this.tableLayoutPanel3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(201, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(192, 81);
            this.panel7.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label33, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblRequiredWeight, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(192, 81);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.LightGreen;
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(3, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(186, 40);
            this.label33.TabIndex = 19;
            this.label33.Text = "Required Wt (KG)";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequiredWeight
            // 
            this.lblRequiredWeight.BackColor = System.Drawing.Color.LightGreen;
            this.lblRequiredWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRequiredWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiredWeight.Location = new System.Drawing.Point(3, 40);
            this.lblRequiredWeight.Name = "lblRequiredWeight";
            this.lblRequiredWeight.Size = new System.Drawing.Size(186, 41);
            this.lblRequiredWeight.TabIndex = 20;
            this.lblRequiredWeight.Text = "0.0000";
            this.lblRequiredWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.BackColor = System.Drawing.Color.LightCoral;
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(192, 81);
            this.panel6.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMinimumWeight, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(192, 81);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightCoral;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 40);
            this.label10.TabIndex = 9;
            this.label10.Text = "Minimum Wt (KG)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinimumWeight
            // 
            this.lblMinimumWeight.BackColor = System.Drawing.Color.LightCoral;
            this.lblMinimumWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinimumWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimumWeight.Location = new System.Drawing.Point(3, 40);
            this.lblMinimumWeight.Name = "lblMinimumWeight";
            this.lblMinimumWeight.Size = new System.Drawing.Size(186, 41);
            this.lblMinimumWeight.TabIndex = 7;
            this.lblMinimumWeight.Text = "0.0000";
            this.lblMinimumWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlCount
            // 
            this.tlCount.ColumnCount = 2;
            this.tlCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.tlCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlCount.Controls.Add(this.label9, 0, 0);
            this.tlCount.Controls.Add(this.lblTodayPrintCount, 1, 0);
            this.tlCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlCount.Location = new System.Drawing.Point(0, 0);
            this.tlCount.Name = "tlCount";
            this.tlCount.RowCount = 1;
            this.tlCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlCount.Size = new System.Drawing.Size(597, 34);
            this.tlCount.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(524, 34);
            this.label9.TabIndex = 33;
            this.label9.Text = "Today\'s Print Count : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTodayPrintCount
            // 
            this.lblTodayPrintCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTodayPrintCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayPrintCount.ForeColor = System.Drawing.Color.Green;
            this.lblTodayPrintCount.Location = new System.Drawing.Point(533, 0);
            this.lblTodayPrintCount.Name = "lblTodayPrintCount";
            this.lblTodayPrintCount.Size = new System.Drawing.Size(61, 34);
            this.lblTodayPrintCount.TabIndex = 34;
            this.lblTodayPrintCount.Text = "0";
            this.lblTodayPrintCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.txtSelectedLabelSize);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.btnSelectCustomer);
            this.panel4.Controls.Add(this.txtCustomerName);
            this.panel4.Controls.Add(this.label40);
            this.panel4.Controls.Add(this.btnSelectPrinter);
            this.panel4.Controls.Add(this.txtPrinterName);
            this.panel4.Controls.Add(this.label39);
            this.panel4.Controls.Add(this.tbSideInfo);
            this.panel4.Controls.Add(this.label38);
            this.panel4.Controls.Add(this.tbExpiryDays);
            this.panel4.Controls.Add(this.label36);
            this.panel4.Controls.Add(this.tbReferenceNumber);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.tbPositiveTolPartWeight);
            this.panel4.Controls.Add(this.tbPositiveTolPercent);
            this.panel4.Controls.Add(this.label30);
            this.panel4.Controls.Add(this.tbTolPartWeight);
            this.panel4.Controls.Add(this.tbTolPercent);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.tbNegativeTolPartWeight);
            this.panel4.Controls.Add(this.tbNegativeTolPercent);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.tbDBPartWeight);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnChildPartSubmit);
            this.panel4.Controls.Add(this.tbChildPartDesc);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.tbRequiredQty);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.tbChildPartNumber);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(425, 654);
            this.panel4.TabIndex = 0;
            // 
            // txtSelectedLabelSize
            // 
            this.txtSelectedLabelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedLabelSize.Location = new System.Drawing.Point(138, 68);
            this.txtSelectedLabelSize.Name = "txtSelectedLabelSize";
            this.txtSelectedLabelSize.ReadOnly = true;
            this.txtSelectedLabelSize.Size = new System.Drawing.Size(193, 22);
            this.txtSelectedLabelSize.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Label Size";
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectCustomer.Location = new System.Drawing.Point(337, 37);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(76, 28);
            this.btnSelectCustomer.TabIndex = 33;
            this.btnSelectCustomer.Text = "Change";
            this.btnSelectCustomer.UseVisualStyleBackColor = true;
            this.btnSelectCustomer.Click += new System.EventHandler(this.BtnSelectCustomer_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(138, 40);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(193, 22);
            this.txtCustomerName.TabIndex = 31;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(11, 43);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(104, 16);
            this.label40.TabIndex = 32;
            this.label40.Text = "Customer Name";
            // 
            // btnSelectPrinter
            // 
            this.btnSelectPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPrinter.Location = new System.Drawing.Point(337, 6);
            this.btnSelectPrinter.Name = "btnSelectPrinter";
            this.btnSelectPrinter.Size = new System.Drawing.Size(76, 28);
            this.btnSelectPrinter.TabIndex = 30;
            this.btnSelectPrinter.Text = "Change";
            this.btnSelectPrinter.UseVisualStyleBackColor = true;
            this.btnSelectPrinter.Click += new System.EventHandler(this.BtnSelectPrinter_Click);
            // 
            // txtPrinterName
            // 
            this.txtPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrinterName.Location = new System.Drawing.Point(138, 9);
            this.txtPrinterName.Name = "txtPrinterName";
            this.txtPrinterName.ReadOnly = true;
            this.txtPrinterName.Size = new System.Drawing.Size(193, 22);
            this.txtPrinterName.TabIndex = 28;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(11, 12);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(85, 16);
            this.label39.TabIndex = 29;
            this.label39.Text = "Printer Name";
            // 
            // tbSideInfo
            // 
            this.tbSideInfo.BackColor = System.Drawing.Color.LightGray;
            this.tbSideInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSideInfo.Location = new System.Drawing.Point(276, 212);
            this.tbSideInfo.Name = "tbSideInfo";
            this.tbSideInfo.ReadOnly = true;
            this.tbSideInfo.Size = new System.Drawing.Size(137, 23);
            this.tbSideInfo.TabIndex = 26;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(207, 215);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 17);
            this.label38.TabIndex = 27;
            this.label38.Text = "Side Info";
            // 
            // tbExpiryDays
            // 
            this.tbExpiryDays.BackColor = System.Drawing.Color.LightGray;
            this.tbExpiryDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExpiryDays.Location = new System.Drawing.Point(138, 212);
            this.tbExpiryDays.Name = "tbExpiryDays";
            this.tbExpiryDays.ReadOnly = true;
            this.tbExpiryDays.Size = new System.Drawing.Size(63, 23);
            this.tbExpiryDays.TabIndex = 5;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(14, 215);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(82, 17);
            this.label36.TabIndex = 25;
            this.label36.Text = "Expiry Days";
            // 
            // tbReferenceNumber
            // 
            this.tbReferenceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReferenceNumber.Location = new System.Drawing.Point(138, 99);
            this.tbReferenceNumber.Name = "tbReferenceNumber";
            this.tbReferenceNumber.Size = new System.Drawing.Size(193, 22);
            this.tbReferenceNumber.TabIndex = 0;
            this.tbReferenceNumber.TextChanged += new System.EventHandler(this.TbReferenceNumber_TextChanged);
            this.tbReferenceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbReferenceNumber_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(11, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 16);
            this.label20.TabIndex = 24;
            this.label20.Text = "Reference Number";
            // 
            // tbPositiveTolPartWeight
            // 
            this.tbPositiveTolPartWeight.BackColor = System.Drawing.Color.LightGray;
            this.tbPositiveTolPartWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPositiveTolPartWeight.Location = new System.Drawing.Point(321, 325);
            this.tbPositiveTolPartWeight.Name = "tbPositiveTolPartWeight";
            this.tbPositiveTolPartWeight.ReadOnly = true;
            this.tbPositiveTolPartWeight.Size = new System.Drawing.Size(98, 23);
            this.tbPositiveTolPartWeight.TabIndex = 12;
            // 
            // tbPositiveTolPercent
            // 
            this.tbPositiveTolPercent.BackColor = System.Drawing.Color.LightGray;
            this.tbPositiveTolPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPositiveTolPercent.Location = new System.Drawing.Point(320, 296);
            this.tbPositiveTolPercent.Name = "tbPositiveTolPercent";
            this.tbPositiveTolPercent.ReadOnly = true;
            this.tbPositiveTolPercent.Size = new System.Drawing.Size(98, 23);
            this.tbPositiveTolPercent.TabIndex = 11;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(328, 276);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(81, 17);
            this.label30.TabIndex = 20;
            this.label30.Text = "Positive Tol";
            // 
            // tbTolPartWeight
            // 
            this.tbTolPartWeight.BackColor = System.Drawing.Color.LightGray;
            this.tbTolPartWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTolPartWeight.Location = new System.Drawing.Point(171, 325);
            this.tbTolPartWeight.Name = "tbTolPartWeight";
            this.tbTolPartWeight.ReadOnly = true;
            this.tbTolPartWeight.Size = new System.Drawing.Size(98, 23);
            this.tbTolPartWeight.TabIndex = 10;
            // 
            // tbTolPercent
            // 
            this.tbTolPercent.BackColor = System.Drawing.Color.LightGray;
            this.tbTolPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTolPercent.Location = new System.Drawing.Point(170, 296);
            this.tbTolPercent.Name = "tbTolPercent";
            this.tbTolPercent.ReadOnly = true;
            this.tbTolPercent.Size = new System.Drawing.Size(98, 23);
            this.tbTolPercent.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(183, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tolerance";
            // 
            // tbNegativeTolPartWeight
            // 
            this.tbNegativeTolPartWeight.BackColor = System.Drawing.Color.LightGray;
            this.tbNegativeTolPartWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNegativeTolPartWeight.Location = new System.Drawing.Point(21, 325);
            this.tbNegativeTolPartWeight.Name = "tbNegativeTolPartWeight";
            this.tbNegativeTolPartWeight.ReadOnly = true;
            this.tbNegativeTolPartWeight.Size = new System.Drawing.Size(98, 23);
            this.tbNegativeTolPartWeight.TabIndex = 8;
            // 
            // tbNegativeTolPercent
            // 
            this.tbNegativeTolPercent.BackColor = System.Drawing.Color.LightGray;
            this.tbNegativeTolPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNegativeTolPercent.Location = new System.Drawing.Point(20, 296);
            this.tbNegativeTolPercent.Name = "tbNegativeTolPercent";
            this.tbNegativeTolPercent.ReadOnly = true;
            this.tbNegativeTolPercent.Size = new System.Drawing.Size(98, 23);
            this.tbNegativeTolPercent.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Negative Tol";
            // 
            // tbDBPartWeight
            // 
            this.tbDBPartWeight.BackColor = System.Drawing.Color.LightGray;
            this.tbDBPartWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDBPartWeight.Location = new System.Drawing.Point(138, 241);
            this.tbDBPartWeight.Name = "tbDBPartWeight";
            this.tbDBPartWeight.ReadOnly = true;
            this.tbDBPartWeight.Size = new System.Drawing.Size(275, 23);
            this.tbDBPartWeight.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "DB Part Weight";
            // 
            // btnChildPartSubmit
            // 
            this.btnChildPartSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChildPartSubmit.Location = new System.Drawing.Point(337, 124);
            this.btnChildPartSubmit.Name = "btnChildPartSubmit";
            this.btnChildPartSubmit.Size = new System.Drawing.Size(76, 28);
            this.btnChildPartSubmit.TabIndex = 2;
            this.btnChildPartSubmit.Text = "Submit";
            this.btnChildPartSubmit.UseVisualStyleBackColor = true;
            this.btnChildPartSubmit.Click += new System.EventHandler(this.BtnChildPartSubmit_Click);
            // 
            // tbChildPartDesc
            // 
            this.tbChildPartDesc.BackColor = System.Drawing.Color.LightGray;
            this.tbChildPartDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChildPartDesc.Location = new System.Drawing.Point(138, 183);
            this.tbChildPartDesc.Name = "tbChildPartDesc";
            this.tbChildPartDesc.ReadOnly = true;
            this.tbChildPartDesc.Size = new System.Drawing.Size(275, 23);
            this.tbChildPartDesc.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description";
            // 
            // tbRequiredQty
            // 
            this.tbRequiredQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRequiredQty.Location = new System.Drawing.Point(138, 127);
            this.tbRequiredQty.Name = "tbRequiredQty";
            this.tbRequiredQty.Size = new System.Drawing.Size(193, 22);
            this.tbRequiredQty.TabIndex = 1;
            this.tbRequiredQty.TextChanged += new System.EventHandler(this.TbRequiredQty_TextChanged);
            this.tbRequiredQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbRequiredQty_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Required Qty";
            // 
            // tbChildPartNumber
            // 
            this.tbChildPartNumber.BackColor = System.Drawing.Color.LightGray;
            this.tbChildPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChildPartNumber.Location = new System.Drawing.Point(138, 155);
            this.tbChildPartNumber.Name = "tbChildPartNumber";
            this.tbChildPartNumber.ReadOnly = true;
            this.tbChildPartNumber.Size = new System.Drawing.Size(193, 22);
            this.tbChildPartNumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Part Number";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 624);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 24);
            this.label14.TabIndex = 15;
            this.label14.Text = "New Entry (Esc)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbLicenseinfo);
            this.panel2.Controls.Add(this.lblLicenseExpirationInfo);
            this.panel2.Controls.Add(this.lblWeight);
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnMasterData);
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1048, 50);
            this.panel2.TabIndex = 0;
            // 
            // pbLicenseinfo
            // 
            this.pbLicenseinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLicenseinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLicenseinfo.Image = global::AutoWeighingAndPrinting.Properties.Resources.info_icon;
            this.pbLicenseinfo.Location = new System.Drawing.Point(711, 12);
            this.pbLicenseinfo.Name = "pbLicenseinfo";
            this.pbLicenseinfo.Size = new System.Drawing.Size(29, 27);
            this.pbLicenseinfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLicenseinfo.TabIndex = 13;
            this.pbLicenseinfo.TabStop = false;
            this.pbLicenseinfo.Click += new System.EventHandler(this.PbLicenseinfo_Click);
            this.pbLicenseinfo.MouseLeave += new System.EventHandler(this.PbLicenseinfo_MouseLeave);
            this.pbLicenseinfo.MouseHover += new System.EventHandler(this.PbLicenseinfo_MouseHover);
            // 
            // lblLicenseExpirationInfo
            // 
            this.lblLicenseExpirationInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLicenseExpirationInfo.AutoSize = true;
            this.lblLicenseExpirationInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLicenseExpirationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseExpirationInfo.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblLicenseExpirationInfo.Location = new System.Drawing.Point(420, 17);
            this.lblLicenseExpirationInfo.Name = "lblLicenseExpirationInfo";
            this.lblLicenseExpirationInfo.Size = new System.Drawing.Size(272, 20);
            this.lblLicenseExpirationInfo.TabIndex = 12;
            this.lblLicenseExpirationInfo.Text = "Your License will expire in 0 days";
            this.lblLicenseExpirationInfo.Visible = false;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.BackColor = System.Drawing.Color.Red;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(164, 6);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(208, 36);
            this.lblWeight.TabIndex = 11;
            this.lblWeight.Text = "Disconnected";
            this.lblWeight.TextChanged += new System.EventHandler(this.LblWeight_TextChanged);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(750, 9);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(125, 35);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Port Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnMasterData
            // 
            this.btnMasterData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMasterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterData.Location = new System.Drawing.Point(881, 9);
            this.btnMasterData.Name = "btnMasterData";
            this.btnMasterData.Size = new System.Drawing.Size(125, 35);
            this.btnMasterData.TabIndex = 2;
            this.btnMasterData.Text = "Master Data";
            this.btnMasterData.UseVisualStyleBackColor = true;
            this.btnMasterData.Click += new System.EventHandler(this.BtnMasterData_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(24, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(125, 35);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // _serialPort
            // 
            this._serialPort.DiscardNull = true;
            this._serialPort.DtrEnable = true;
            this._serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 749);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Weighing and Printing -V4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.panel1.ResumeLayout(false);
            this.tcMainForm.ResumeLayout(false);
            this.tpChildPartWeighing.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tlImage.ResumeLayout(false);
            this.tlImage.PerformLayout();
            this.tlImageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.tlWeighStatus.ResumeLayout(false);
            this.tlLiveWeight.ResumeLayout(false);
            this.tlWeightRange.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tlCount.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicenseinfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnMasterData;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblWeight;
        private System.IO.Ports.SerialPort _serialPort;
        private System.Windows.Forms.TabControl tcMainForm;
        private System.Windows.Forms.TabPage tpChildPartWeighing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbChildPartDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRequiredQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbChildPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNegativeTolPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDBPartWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChildPartSubmit;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMaximumWeight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMinimumWeight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbPositiveTolPartWeight;
        private System.Windows.Forms.TextBox tbPositiveTolPercent;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbTolPartWeight;
        private System.Windows.Forms.TextBox tbTolPercent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbNegativeTolPartWeight;
        private System.Windows.Forms.Label lblRequiredWeight;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbReferenceNumber;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbExpiryDays;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lblLicenseExpirationInfo;
        private System.Windows.Forms.PictureBox pbLicenseinfo;
        private System.Windows.Forms.TextBox tbSideInfo;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button btnSelectPrinter;
        private System.Windows.Forms.TextBox txtPrinterName;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label lblAutoWeighingStatus;
        private System.Windows.Forms.Label lblWeightStatus;
        private System.Windows.Forms.TextBox txtSelectedLabelSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTodayPrintCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tlCount;
        private System.Windows.Forms.TableLayoutPanel tlWeightRange;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tlLiveWeight;
        private System.Windows.Forms.TableLayoutPanel tlWeighStatus;
        private System.Windows.Forms.TableLayoutPanel tlImage;
        private System.Windows.Forms.TableLayoutPanel tlImageContainer;
    }
}

