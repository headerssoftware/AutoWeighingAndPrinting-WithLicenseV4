using AutoWeighingAndPrinting.Helpers;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace AutoWeighingAndPrinting
{

    public partial class MainForm : Form
    {
        bool _continueReading = false;
        delegate void SetTextCallback(double value, string text);


        bool enableChildPartsWeighing = false;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessId);

        readonly Config config;
        AppSettings appSettings;
        string connectionString;


        [Obsolete]
        public MainForm()
        {
            InitializeComponent();


            this.DoubleBuffered = true;

            //To avoid flash on weight changes
            tlLiveWeight.GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                .SetValue(tlLiveWeight, true, null);

            tlWeighStatus.GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                .SetValue(tlWeighStatus, true, null);

            _autoPrintTimer = new Timer
            {
                Interval = 1000
            };

            _autoPrintTimer.Tick += AutoPrintTimer_Tick;

            _autoPrintTimer.Tick += AutoPrintTimer_Tick;

            config = new Config();
            appSettings = config.ReadSettings();
            connectionString = @"DataSource=" + appSettings.DBFilePath + ";foreign keys=true;";


            _stableWeightSeconds =
                Math.Max(1, appSettings.StableWeightSeconds);

            _zeroWeightSeconds =
                Math.Max(1, appSettings.ZeroWeightSeconds);

            SetWeighingStatus(WeighingStatus.WaitingForPart);

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ResizeImageBox();

            if (!CheckAppLicense())
            {
                this.Dispose();
                return;
            }

            LoadPrinterAndCustomer();


            DateTime historyDeletedDate = appSettings.HistoryDeletedDate;
            if (historyDeletedDate.Date >= DateTime.Now.Date)
            {
                //Do nothing
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    //Delete the history from database based on Delete History Days Value
                    DateTime deleteBeforeDate = DateTime.Now.AddDays(-appSettings.DeleteHistoryDays);


                    using (var conn = new SQLiteConnection(connectionString, true))
                    {
                        // Be sure you already created the Person Table!
                        conn.Open();
                        using (var cmd = new SQLiteCommand(conn))
                        {
                            using (var transaction = conn.BeginTransaction())
                            {
                                cmd.CommandText =
                                    @"DELETE FROM [2.childpart_history] where date_time <= @date_time;";
                                cmd.Parameters.AddWithValue("@date_time", deleteBeforeDate.ToString("yyyy-MM-dd 23:59:59"));

                                cmd.ExecuteNonQuery();

                                transaction.Commit();
                            }
                        }
                        conn.Close();
                    }

                    appSettings.HistoryDeletedDate = DateTime.Now.Date;
                    config.WriteSettings(appSettings);
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                Cursor = Cursors.Default;
            }
        }

        private bool ShowEnterLicenseKeyDialog(LicenseStatus licenseStatus, DateTime? licenseExpiryDate)
        {
            frmEnterLicenseKeyPopup licenseKeyPopup = new frmEnterLicenseKeyPopup(appSettings, licenseStatus, licenseExpiryDate);
            licenseKeyPopup.ShowDialog();
            if (licenseKeyPopup.IsLicenseKeyVerified)
            {
                appSettings = config.ReadSettings();
                SetLicenseInfoText(licenseKeyPopup.LicenseDetailResult);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckAppLicense()
        {
            try
            {
                string licensekey = appSettings.LicenseKey;

                if (string.IsNullOrEmpty(licensekey))
                {
                    return ShowEnterLicenseKeyDialog(LicenseStatus.NewUser, null);
                }

                var appLicensevalidator = new AppLicenseValidator();

                LicenseDetail licenseDetail = appLicensevalidator.GetAppLicenseDetails(licensekey);

                if (licenseDetail == null)
                {
                    return ShowEnterLicenseKeyDialog(LicenseStatus.NotValid, null);
                }
                else if (!licenseDetail.IsLicenseValid)
                {
                    return ShowEnterLicenseKeyDialog(LicenseStatus.NotValid, null);
                }
                else if (licenseDetail.DaysLeft < 0)
                {
                    return ShowEnterLicenseKeyDialog(LicenseStatus.Expired, licenseDetail.ExpiryDate);
                }
                else
                {
                    return SetLicenseInfoText(licenseDetail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Checking App License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }

        private bool SetLicenseInfoText(LicenseDetail licenseDetail)
        {
            var daysLeft = licenseDetail.DaysLeft;

            DateTime ExpiryDate = licenseDetail.ExpiryDate;

            if (daysLeft == 0)
            {
                lblLicenseExpirationInfo.ForeColor = Color.Red;
                lblLicenseExpirationInfo.Text = $"Your License will expire today ({ExpiryDate:dd-MM-yyyy}) ";
                lblLicenseExpirationInfo.Visible = true;
            }
            else if (daysLeft == 1)
            {
                lblLicenseExpirationInfo.ForeColor = Color.Red;
                lblLicenseExpirationInfo.Text = $"Your License will expire in {daysLeft} day ({ExpiryDate:dd-MM-yyyy}) ";
                lblLicenseExpirationInfo.Visible = true;

            }
            else if (daysLeft <= 15)
            {
                lblLicenseExpirationInfo.ForeColor = Color.DarkOrange;
                lblLicenseExpirationInfo.Text = $"Your License will expire in {daysLeft} days ({ExpiryDate:dd-MM-yyyy}) ";
                lblLicenseExpirationInfo.Visible = true;

            }
            else
            {
                lblLicenseExpirationInfo.ForeColor = Color.Black;
                lblLicenseExpirationInfo.Text = $"Your License is valid till {ExpiryDate:dd-MM-yyyy} ";
                lblLicenseExpirationInfo.Visible = true;
            }

            return true;
        }


        private void SetText(double value, string message)
        {

            try
            {
                if (message != "SUCCESS")
                {
                    lblWeight.Text = message;
                    lblWeight.BackColor = Color.Red;

                    _autoPrintTimer.Stop();

                    if (_weighingState == WeighingState.StabilizingWeight)
                    {
                        _weighingState =
                            WeighingState.WaitingForWeight;
                    }

                    lblCountdown.Text = "";


                    SetWeighingStatus(WeighingStatus.ScaleCommunicationError);

                    UpdateWeightStatusLabel(lblWeight.Text, false);
                    btnSettings.Enabled = true;

                    return;
                }

                int divideValue =
                    Convert.ToInt32(appSettings.DivideValue);

                _currentWeightKg = value / divideValue;

                lblWeight.Text = _currentWeightKg.ToString("0.0000") + " KG";

                lblWeight.BackColor = Color.Cyan;

                UpdateWeightStatusLabel(_currentWeightKg.ToString("0.0000"), true);

                btnSettings.Enabled = false;


                EvaluateAutomaticWeighing();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error - Set Text",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        [Obsolete]
        private void BtnMasterData_Click(object sender, EventArgs e)
        {
            MasterDataForm masterDataForm = new MasterDataForm();
            masterDataForm.ShowDialog();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {

            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();

            appSettings = config.ReadSettings();
            connectionString = @"DataSource=" + appSettings.DBFilePath + ";foreign keys=true;";
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            btnConnect.Enabled = false;

            if (btnConnect.Text == "Connect")
            {

                // If serial port is open, then close it
                if (_serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(SerialPort_DataReceived);

                    _serialPort.DiscardInBuffer();
                    _serialPort.DiscardOutBuffer();

                    _serialPort.BaseStream.Flush();
                    _serialPort.BaseStream.Dispose();


                    _serialPort.Close();
                    _serialPort.Dispose();
                }

                appSettings = config.ReadSettings();
                connectionString = @"DataSource=" + appSettings.DBFilePath + ";foreign keys=true;";
                _serialPort.PortName = appSettings.PortName;
                _serialPort.BaudRate = appSettings.BaudRate;
                _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), appSettings.Parity);
                _serialPort.DataBits = appSettings.DataBits;
                _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), appSettings.StopBits);
                if (appSettings.NewLine == "none")
                {
                    _serialPort.NewLine = "\r\n";
                }
                else
                {
                    _serialPort.NewLine = appSettings.NewLine;
                }
                _serialPort.ReadTimeout = 4000;

                // try to open the selected port:
                try
                {
                    // If serial port is not opened, then open it

                    if (!_serialPort.IsOpen)
                    {
                        _continueReading = true;
                        btnConnect.Text = "Disconnect";
                        SetWeighingStatus(WeighingStatus.WaitingForPart);
                        _serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(SerialPort_DataReceived);
                        _serialPort.Open();


                    }
                }
                catch
                {
                    _continueReading = false;
                    Cursor = Cursors.Default;
                    MessageBox.Show("Serial port " + _serialPort.PortName + " cannot be opened!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if (btnConnect.Text == "Disconnect")
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    _continueReading = false;

                    if (_serialPort.IsOpen)
                    {
                        _serialPort.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(SerialPort_DataReceived);

                        _serialPort.DiscardInBuffer();
                        _serialPort.DiscardOutBuffer();

                        _serialPort.BaseStream.Flush();
                        _serialPort.BaseStream.Dispose();


                        _serialPort.Close();
                        _serialPort.Dispose();
                    }


                    lblWeight.Text = "Disconnected";
                    lblWeight.BackColor = Color.Red;

                    btnConnect.Text = "Connect";

                }
                catch (Exception ex)
                {
                    _continueReading = false;
                    Cursor = Cursors.Default;
                    MessageBox.Show("Serial port " + _serialPort.PortName + " cannot be Closed!\n" + ex.Message, "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            Cursor = Cursors.Default;

            btnConnect.Enabled = true;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_serialPort.IsOpen || (_continueReading == false))
                return; // We can't receive data if the port has already been closed.  This prevents IO Errors from being half way through receiving data when the port is closed.

            string InputData = "";
            double value = 0;
            string NumbersOnlyString = "";

            try
            {
                if (_serialPort.IsOpen && _continueReading)
                {

                    InputData = _serialPort.ReadLine();

                    InputData = InputData.Trim();

                    if (InputData[0] == '-')
                        NumbersOnlyString += InputData[0];

                    for (int i = 0; i < InputData.Length; i++)
                    {
                        if (InputData[i] >= '0' && InputData[i] <= '9')
                            NumbersOnlyString += InputData[i];
                    }

                    if (NumbersOnlyString.Length > 0)
                    {
                        value = double.Parse(NumbersOnlyString);
                    }

                    BeginInvoke(new SetTextCallback(SetText), new object[] { value, "SUCCESS" });
                }

            }
            catch (System.TimeoutException)
            {
                BeginInvoke(new SetTextCallback(SetText), new object[] { 0, "Timeout Error" });
            }
            catch (System.IO.IOException)
            {
                BeginInvoke(new SetTextCallback(SetText), new object[] { 0, "IO Error" });
            }
            catch (System.InvalidOperationException)
            {
                BeginInvoke(new SetTextCallback(SetText), new object[] { 0, "Invalid Operation" });
            }
            catch (Exception ex)
            {
                BeginInvoke(new SetTextCallback(SetText), new object[] { 0, "Exception: " + ex.Message });
            }
        }

        private void BtnChildPartSubmit_Click(object sender, EventArgs e)
        {

            appSettings = config.ReadSettings();

            if (!IsPrinterInstalled(appSettings.PrinterName) ||
                string.IsNullOrWhiteSpace(appSettings.PrintingFileName) ||
                string.IsNullOrWhiteSpace(appSettings.SelectedSize))
            {
                MessageBox.Show(
                    "Please select a valid printer and customer before proceeding.",
                    "Selection Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                UpdateSelectionControls();
                return;
            }

            enableChildPartsWeighing = false;
            if (tbReferenceNumber.Text == string.Empty || tbRequiredQty.Text == string.Empty)
            {
                MessageBox.Show("Enter the reference number and required quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                string referenceNumber = tbReferenceNumber.Text;

                System.Data.DataTable dtChildParts = new System.Data.DataTable();
                string sql = @"SELECT reference_number as ReferenceNumber,childpart_id as ID, child_part_number as PartNumber, child_part_description as Description, part_weight as PartWeight,
                                tol_percent AS TolerancePercent, tol_part_weight as TolerancePartWeight, negative_tol_percent as NegativeTolPercent, negative_tol_part_weight as NegativeTolPartWeight, 
                                positive_tol_percent as PositiveTolPercent, positive_tol_part_weight as PositiveTolPartWeight, image as Image,expiry_days as ExpiryDays,side_info as SideInfo FROM [1.childpart] where reference_number=@REFERENCENUMBER order by ReferenceNumber";
                using (SQLiteConnection con = new SQLiteConnection(connectionString, true))
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, con))
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@REFERENCENUMBER", referenceNumber);
                    dataAdapter.Fill(dtChildParts);
                }

                if (dtChildParts.Rows.Count == 0)
                {
                    ResetChildPartsWeighing();

                    MessageBox.Show("Reference Number is not found", "Error: Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    tbReferenceNumber.Focus();
                    tbReferenceNumber.SelectionStart = tbReferenceNumber.Text.Length;

                    return;
                }
                else if (dtChildParts.Rows.Count == 1)
                {
                    tbChildPartNumber.Text = dtChildParts.Rows[0]["PartNumber"].ToString();
                    tbChildPartDesc.Text = dtChildParts.Rows[0]["Description"].ToString();
                    tbDBPartWeight.Text = dtChildParts.Rows[0]["PartWeight"].ToString();
                    tbTolPercent.Text = dtChildParts.Rows[0]["TolerancePercent"].ToString();
                    tbNegativeTolPercent.Text = dtChildParts.Rows[0]["NegativeTolPercent"].ToString() + " %";
                    tbNegativeTolPartWeight.Text = dtChildParts.Rows[0]["NegativeTolPartWeight"].ToString();
                    tbTolPercent.Text = dtChildParts.Rows[0]["TolerancePercent"].ToString();
                    tbTolPartWeight.Text = dtChildParts.Rows[0]["TolerancePartWeight"].ToString();
                    tbPositiveTolPercent.Text = dtChildParts.Rows[0]["PositiveTolPercent"].ToString() + " %";
                    tbPositiveTolPartWeight.Text = dtChildParts.Rows[0]["PositiveTolPartWeight"].ToString();
                    tbExpiryDays.Text = dtChildParts.Rows[0]["ExpiryDays"].ToString();
                    tbSideInfo.Text = dtChildParts.Rows[0]["SideInfo"].ToString();

                    if (dtChildParts.Rows[0]["Image"] == null || dtChildParts.Rows[0]["Image"] == DBNull.Value)
                    {
                        pbImage.Image = null;
                    }
                    else
                    {
                        pbImage.Image = Image.FromStream(new MemoryStream((byte[])dtChildParts.Rows[0]["Image"]));
                    }

                    int requiredQty = Convert.ToInt32(tbRequiredQty.Text);
                    double weightInKG = Convert.ToDouble(dtChildParts.Rows[0]["PartWeight"].ToString());

                    double requiredWeight = requiredQty * weightInKG;
                    lblRequiredWeight.Text = requiredWeight.ToString("0.0000");

                    double negativeTolPartWeight = Convert.ToDouble(tbNegativeTolPartWeight.Text);
                    double minimumWeight = requiredWeight - negativeTolPartWeight;
                    lblMinimumWeight.Text = minimumWeight.ToString("0.0000");

                    double positiveTolPartWeight = Convert.ToDouble(tbPositiveTolPartWeight.Text);
                    double maximumWeight = requiredWeight + positiveTolPartWeight;
                    lblMaximumWeight.Text = maximumWeight.ToString("0.0000");


                    enableChildPartsWeighing = true;

                    int todayCount = GetTodayPrintCount(referenceNumber);

                    lblTodayPrintCount.Text = todayCount.ToString();

                    UpdateAutoPrintButtonState();
                    LblWeight_TextChanged(sender, e);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TbReferenceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
            {
                e.SuppressKeyPress = true;
                if (tbReferenceNumber.Text != string.Empty)
                {
                    tbRequiredQty.Focus();
                    tbRequiredQty.SelectionStart = tbRequiredQty.Text.Length;
                }
            }
        }


        private void TbRequiredQty_TextChanged(object sender, EventArgs e)
        {
            ResetAutomaticWeighing();
            ResetChildPartsWeighing();
            this.AcceptButton = btnChildPartSubmit;
        }

        private void TbRequiredQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TbReferenceNumber_TextChanged(object sender, EventArgs e)
        {

            ResetAutomaticWeighing();
            ResetChildPartsWeighing();
            tbRequiredQty.Text = "";
            this.AcceptButton = null;
        }

        private void ResetChildPartsWeighing()
        {
            tbChildPartNumber.Text = "";
            tbChildPartDesc.Text = "";
            tbDBPartWeight.Text = "";
            tbNegativeTolPartWeight.Text = tbNegativeTolPercent.Text = "";
            tbTolPercent.Text = tbTolPartWeight.Text = "";
            tbPositiveTolPercent.Text = tbPositiveTolPartWeight.Text = "";
            pbImage.Image = null;
            tbExpiryDays.Text = tbSideInfo.Text = "";

            lblMinimumWeight.Text = "0.0000";
            lblRequiredWeight.Text = "0.0000";
            lblMaximumWeight.Text = "0.0000";
        }

        private void BtnSendToPrint_Click(object sender, EventArgs e)
        {

            // Only allow printing when the application is ready.
            if (_weighingState != WeighingState.WaitingForWeight)
                return;

            if (!enableChildPartsWeighing)
            {
                MessageBox.Show(
                    "Please select a valid reference number first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidatePrinterAndCustomer())
                return;

            double minimumWeight =
                Convert.ToDouble(lblMinimumWeight.Text);

            double maximumWeight =
                Convert.ToDouble(lblMaximumWeight.Text);

            if (_currentWeightKg <= 0 ||
                _currentWeightKg < minimumWeight ||
                _currentWeightKg > maximumWeight)
            {
                MessageBox.Show(
                    "Weight is outside the allowed range.",
                    "Weight Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            StartWeightCountdown();
        }


        private void LblWeight_TextChanged(object sender, EventArgs e)
        {

            if (lblWeight.Text == "Disconnected" || lblWeight.Text == "Timeout Error" || lblWeight.Text == "IO Error" || lblWeight.Text == "Invalid Operation" || lblWeight.Text.StartsWith("Exception"))
            {
                btnSettings.Enabled = true;
            }
            else
            {
                btnSettings.Enabled = false;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)    //New Entry
            {
                if (tcMainForm.SelectedTab == tpChildPartWeighing)
                {
                    tbReferenceNumber.Text = "";
                    tbRequiredQty.Text = "";
                    ResetChildPartsWeighing();
                    tbReferenceNumber.Focus();
                }
            }
        }


        private void TcMainForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableChildPartsWeighing = false;

            if (tcMainForm.SelectedTab == tpChildPartWeighing)
            {
                tbReferenceNumber.Text = "";
                tbReferenceNumber.Focus();
            }
        }

        public static bool SendTextFileToPrinter(string szFileName, string printerName)
        {
            var sb = new StringBuilder();

            using (var sr = new StreamReader(szFileName, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    sb.AppendLine(sr.ReadLine());
                }
            }

            return RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.DiscardInBuffer();
                    _serialPort.DiscardOutBuffer();

                    _serialPort.BaseStream.Flush();
                    _serialPort.BaseStream.Dispose();

                    _serialPort.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(SerialPort_DataReceived);
                    _serialPort.Close();
                    _serialPort.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Serial port " + _serialPort.PortName + " cannot be Closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnConnect.Text = "Connect";

        }

        private void PbLicenseinfo_MouseHover(object sender, EventArgs e)
        {
            pbLicenseinfo.BorderStyle = BorderStyle.FixedSingle;
            new System.Windows.Forms.ToolTip().SetToolTip(pbLicenseinfo, "License Info");
        }

        private void PbLicenseinfo_MouseLeave(object sender, EventArgs e)
        {
            pbLicenseinfo.BorderStyle = BorderStyle.None;
        }

        private void PbLicenseinfo_Click(object sender, EventArgs e)
        {
            try
            {
                string licensekey = appSettings.LicenseKey;

                if (!string.IsNullOrEmpty(licensekey))
                {
                    var appLicensevalidator = new AppLicenseValidator();
                    LicenseDetail licenseDetail = appLicensevalidator.GetAppLicenseDetails(licensekey);
                    ShowEnterLicenseKeyDialog(LicenseStatus.ChangeLicense, licenseDetail.ExpiryDate);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Checking App License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region New Code
        private void BtnSelectPrinter_Click(object sender, EventArgs e)
        {
            using (PrintDialog dialog = new PrintDialog())
            {
                dialog.PrinterSettings = new PrinterSettings();

                dialog.UseEXDialog = appSettings.IsUseExDialog;

                if (!string.IsNullOrWhiteSpace(appSettings.PrinterName))
                {
                    dialog.PrinterSettings.PrinterName =
                        appSettings.PrinterName;
                }

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    appSettings.PrinterName =
                        dialog.PrinterSettings.PrinterName;

                    config.WriteSettings(appSettings);

                    txtPrinterName.Text = appSettings.PrinterName;
                }
            }

            UpdateSelectionControls();
        }

        private void BtnSelectCustomer_Click(object sender, EventArgs e)
        {
            var sizeFolders = PrnHelper.GetSizeFolders();

            if (sizeFolders.Length == 0)
            {
                MessageBox.Show(
                    "No PRN size folders found.",
                    "Customer Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (sizeFolders.Length == 1)
            {
                appSettings.SelectedSize =
                    Path.GetFileName(sizeFolders[0]);

                config.WriteSettings(appSettings);

                using (CustomerSelectionForm customerForm =
                       new CustomerSelectionForm())
                {
                    customerForm.ShowDialog(this);
                }
            }
            else
            {
                using (SizeSelectionForm sizeForm =
                       new SizeSelectionForm())
                {
                    sizeForm.ShowDialog(this);
                }
            }

            appSettings = config.ReadSettings();

            txtCustomerName.Text =
                appSettings.PrintingFileName ?? "";

            txtSelectedLabelSize.Text = appSettings.SelectedSize ?? "-";

            UpdateSelectionControls();
        }

        private void LoadPrinterAndCustomer()
        {
            appSettings = config.ReadSettings();

            txtPrinterName.Text =
                appSettings.PrinterName ?? "";

            txtCustomerName.Text =
                appSettings.PrintingFileName ?? "";

            txtSelectedLabelSize.Text = appSettings.SelectedSize ?? "-";

            UpdateSelectionControls();
        }

        private bool ValidatePrinterAndCustomer()
        {
            if (string.IsNullOrWhiteSpace(appSettings.PrinterName))
            {
                MessageBox.Show(
                    "Please select a printer.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnSelectPrinter.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(appSettings.PrintingFileName))
            {
                MessageBox.Show(
                    "Please select a customer.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnSelectCustomer.Focus();
                return false;
            }

            return true;
        }

        private bool IsPrinterInstalled(string printerName)
        {
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
            {
                if (string.Equals(
                    installedPrinter,
                    printerName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private void UpdateSelectionControls()
        {
            bool printerSelected =
                IsPrinterInstalled(appSettings.PrinterName);

            bool customerSelected =
                !string.IsNullOrWhiteSpace(appSettings.PrintingFileName) &&
                !string.IsNullOrWhiteSpace(appSettings.SelectedSize);

            bool canStart = printerSelected && customerSelected;

            tbReferenceNumber.Enabled = canStart;
            tbRequiredQty.Enabled = canStart;
            btnChildPartSubmit.Enabled = canStart;
        }

        private void StartWeightCountdown()
        {
            if (_weighingState != WeighingState.WaitingForWeight)
                return;

            _weighingState = WeighingState.StabilizingWeight;

            _remainingSeconds = _stableWeightSeconds;

            lblCountdown.Text = _remainingSeconds.ToString();

            SetWeighingStatus(WeighingStatus.WeightStabilizing);

            _autoPrintTimer.Start();
        }

        private void CancelWeightCountdown()
        {
            _autoPrintTimer.Stop();

            _weighingState =
                WeighingState.WaitingForWeight;

            lblCountdown.Text = "";

            SetWeighingStatus(WeighingStatus.WeightChanged);

            UpdateAutoPrintButtonState();
        }

        private void EvaluateAutomaticWeighing()
        {
            if (!enableChildPartsWeighing)
                return;

            double minimumWeight =
                Convert.ToDouble(lblMinimumWeight.Text);

            double maximumWeight =
                Convert.ToDouble(lblMaximumWeight.Text);

            bool isWithinRange =
                _currentWeightKg > 0 &&
                _currentWeightKg >= minimumWeight &&
                _currentWeightKg <= maximumWeight;

            switch (_weighingState)
            {
                case WeighingState.WaitingForWeight:

                    if (isWithinRange)
                    {
                        // Automatically start countdown.
                        StartWeightCountdown();
                    }

                    break;


                case WeighingState.StabilizingWeight:

                    if (!isWithinRange)
                    {
                        // Cancel if weight leaves allowed range.
                        CancelWeightCountdown();
                    }

                    break;


                case WeighingState.WaitingForZero:

                    if (Math.Abs(_currentWeightKg) ==
                        _zeroWeightThreshold)
                    {
                        StartZeroCountdown();
                    }

                    break;


                case WeighingState.StabilizingZero:

                    if (Math.Abs(_currentWeightKg) >
                        _zeroWeightThreshold)
                    {
                        _autoPrintTimer.Stop();

                        _weighingState =
                            WeighingState.WaitingForZero;

                        lblCountdown.Text = "";

                        SetWeighingStatus(WeighingStatus.RemoveCurrentItem);
                    }

                    break;
            }
        }

        private void StartZeroCountdown()
        {
            if (_weighingState != WeighingState.WaitingForZero)
                return;

            _weighingState =
                WeighingState.StabilizingZero;

            _remainingSeconds = _zeroWeightSeconds;

            lblCountdown.Text =
                _remainingSeconds.ToString();

            SetWeighingStatus(WeighingStatus.ZeroWeightValidation);

            _autoPrintTimer.Start();
        }

        private bool PrintChildPartAutomatically()
        {
            appSettings = config.ReadSettings();

            if (!IsPrinterInstalled(appSettings.PrinterName))
                throw new Exception("Selected printer is not installed.");

            if (string.IsNullOrWhiteSpace(appSettings.PrintingFileName) ||
                string.IsNullOrWhiteSpace(appSettings.SelectedSize))
            {
                throw new Exception("Customer or label size is not selected.");
            }

            string sourceFolder = Path.Combine(
                PrnHelper.PrnRootPath,
                appSettings.SelectedSize);

            string sourceFile = Path.Combine(
                sourceFolder,
                appSettings.PrintingFileName + ".prn");

            if (!File.Exists(sourceFile))
                throw new FileNotFoundException(
                    "PRN template not found.", sourceFile);

            // Capture the current weighing data.
            string referenceNumber = tbReferenceNumber.Text;
            string partNo = tbChildPartNumber.Text;
            string partName = tbChildPartDesc.Text;
            string quantity = tbRequiredQty.Text;

            double netWeightValue = _currentWeightKg;

            int quantityValue = Convert.ToInt32(quantity);

            if (quantityValue <= 0)
                throw new Exception("Invalid required quantity.");

            string netWeight =
                netWeightValue.ToString("0.0000") + " KG";

            string partWeight =
                (netWeightValue / quantityValue).ToString("0.000000") + " KG";

            string negativeTolPercent = tbNegativeTolPercent.Text;
            string negativeTolPartWeight = tbNegativeTolPartWeight.Text;

            string dbPartWeight = tbDBPartWeight.Text;

            string positiveTolPercent = tbPositiveTolPercent.Text;
            string positiveTolPartWeight = tbPositiveTolPartWeight.Text;

            int expiryDays = string.IsNullOrWhiteSpace(tbExpiryDays.Text)
                ? 0
                : Convert.ToInt32(tbExpiryDays.Text);

            string expiryDate =
                DateTime.Now.AddDays(expiryDays).ToString("dd/MMM/yyyy");

            string sideInfo = tbSideInfo.Text;

            string customerName = appSettings.PrintingFileName;

            string date = DateTime.Now.ToString("dd/MMM/yyyy");
            string time24 = DateTime.Now.ToString("HH:mm");
            string time12 = DateTime.Now.ToString("hh:mm tt");

            // Pallet weighing has been removed.
            // Keep these placeholders for compatibility with existing PRN files.
            string palletWeight = "0.0000 KG";
            string grossWeight = netWeight;

            string outputFile = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString("N") + ".prn");

            try
            {
                File.Copy(sourceFile, outputFile, true);

                string text = File.ReadAllText(outputFile);

                text = text.Replace("{CUSTOMERNAME}", customerName);
                text = text.Replace("{PARTNO}", partNo);
                text = text.Replace("{PARTNAME}", partName);
                text = text.Replace("{QUANTITY}", quantity);

                text = text.Replace("{PARTINFO}", "Weight Per Part");
                text = text.Replace("{PARTINFOVALUE}", partWeight);

                text = text.Replace("{NETWEIGHT}", netWeight);
                text = text.Replace("{PALLETWEIGHT}", palletWeight);
                text = text.Replace("{GROSSWEIGHT}", grossWeight);

                text = text.Replace("{DATE}", date);
                text = text.Replace("{TIME24}", time24);
                text = text.Replace("{TIME12}", time12);

                text = text.Replace("{BOXNO}", "1");
                text = text.Replace("{TOTALBOXCOUNT}", "1");

                text = text.Replace("{BATCHNO}", "");
                text = text.Replace("{OTHERINFO}", "");

                text = text.Replace(
                    "{NEGATIVETOLPERCENT}", negativeTolPercent);

                text = text.Replace(
                    "{NEGATIVETOLPARTWEIGHT}", negativeTolPartWeight);

                text = text.Replace(
                    "{DBPARTWEIGHT}", dbPartWeight);

                text = text.Replace(
                    "{POSITIVETOLPERCENT}", positiveTolPercent);

                text = text.Replace(
                    "{POSITIVETOLPARTWEIGHT}", positiveTolPartWeight);

                text = text.Replace(
                    "{REFERENCENUMBER}", referenceNumber);

                text = text.Replace(
                    "{EXPIRYDAYS}", expiryDays.ToString());

                text = text.Replace(
                    "{EXPIRYDATE}", expiryDate);

                text = text.Replace(
                    "{SIDEINFO}", sideInfo);

                File.WriteAllText(outputFile, text, Encoding.Default);

                bool sent = SendTextFileToPrinter(
                    outputFile,
                    appSettings.PrinterName);

                if (!sent)
                    throw new Exception("Printer rejected the print request.");

                // Save history only after successful printer submission.
                if (appSettings.EnablePrintingHistory)
                {
                    try
                    {
                        SaveChildPartPrintingHistory(
                            customerName,
                            referenceNumber,
                            partNo,
                            partName,
                            quantityValue,
                            partWeight,
                            netWeight,
                            palletWeight,
                            grossWeight,
                            negativeTolPercent,
                            negativeTolPartWeight,
                            dbPartWeight,
                            positiveTolPercent,
                            positiveTolPartWeight,
                            expiryDays,
                            expiryDate,
                            sideInfo);
                    }
                    catch (Exception historyEx)
                    {
                        MessageBox.Show(
                            "Label printed successfully, but history could not be saved.\n" +
                            historyEx.Message,
                            "Printing History Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }

                return true;
            }
            finally
            {
                if (File.Exists(outputFile))
                    File.Delete(outputFile);
            }
        }

        private void SaveChildPartPrintingHistory(
    string customerName,
    string referenceNumber,
    string partNo,
    string partName,
    int quantity,
    string partWeight,
    string netWeight,
    string palletWeight,
    string grossWeight,
    string negativeTolPercent,
    string negativeTolPartWeight,
    string dbPartWeight,
    string positiveTolPercent,
    string positiveTolPartWeight,
    int expiryDays,
    string expiryDate,
    string sideInfo)
        {
            using (var conn = new SQLiteConnection(connectionString, true))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.Transaction = transaction;

                    cmd.CommandText = @"
                INSERT INTO [2.childpart_history]
                (
                    date_time,
                    customer_name,
                    reference_number,
                    child_part_number,
                    child_part_description,
                    quantity,
                    part_weight,
                    net_weight,
                    pallet_weight,
                    gross_weight,
                    batch_no,
                    other_info,
                    no_of_packet,
                    negative_tol_percent,
                    negative_tol_part_weight,
                    db_part_weight,
                    positive_tol_percent,
                    positive_tol_part_weight,
                    expiry_days,
                    expiry_date,
                    side_info
                )
                VALUES
                (
                    @date_time,
                    @customer_name,
                    @reference_number,
                    @child_part_number,
                    @child_part_description,
                    @quantity,
                    @part_weight,
                    @net_weight,
                    @pallet_weight,
                    @gross_weight,
                    @batch_no,
                    @other_info,
                    @no_of_packet,
                    @negative_tol_percent,
                    @negative_tol_part_weight,
                    @db_part_weight,
                    @positive_tol_percent,
                    @positive_tol_part_weight,
                    @expiry_days,
                    @expiry_date,
                    @side_info
                );";

                    cmd.Parameters.AddWithValue(
                        "@date_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    cmd.Parameters.AddWithValue("@customer_name", customerName);
                    cmd.Parameters.AddWithValue("@reference_number", referenceNumber);
                    cmd.Parameters.AddWithValue("@child_part_number", partNo);
                    cmd.Parameters.AddWithValue("@child_part_description", partName);
                    cmd.Parameters.AddWithValue("@quantity", quantity);

                    cmd.Parameters.AddWithValue("@part_weight", partWeight);
                    cmd.Parameters.AddWithValue("@net_weight", netWeight);

                    cmd.Parameters.AddWithValue("@pallet_weight", palletWeight);
                    cmd.Parameters.AddWithValue("@gross_weight", grossWeight);

                    cmd.Parameters.AddWithValue("@batch_no", "");
                    cmd.Parameters.AddWithValue("@other_info", "");
                    cmd.Parameters.AddWithValue("@no_of_packet", "1/1");

                    cmd.Parameters.AddWithValue(
                        "@negative_tol_percent", negativeTolPercent);

                    cmd.Parameters.AddWithValue(
                        "@negative_tol_part_weight",
                        negativeTolPartWeight + " KG");

                    cmd.Parameters.AddWithValue(
                        "@db_part_weight", dbPartWeight + " KG");

                    cmd.Parameters.AddWithValue(
                        "@positive_tol_percent", positiveTolPercent);

                    cmd.Parameters.AddWithValue(
                        "@positive_tol_part_weight",
                        positiveTolPartWeight + " KG");

                    cmd.Parameters.AddWithValue("@expiry_days", expiryDays);
                    cmd.Parameters.AddWithValue("@expiry_date", expiryDate);
                    cmd.Parameters.AddWithValue("@side_info", sideInfo);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        private void ProcessAutomaticPrinting()
        {
            if (_weighingState != WeighingState.StabilizingWeight)
                return;

            _weighingState = WeighingState.Printing;

            _autoPrintTimer.Stop();

            lblCountdown.Text = "";

            SetWeighingStatus(WeighingStatus.Printing);

            try
            {
                bool success = PrintChildPartAutomatically();

                if (!success)
                    throw new Exception("Printing was unsuccessful.");

                _weighingState =
                    WeighingState.WaitingForZero;

                SetWeighingStatus(WeighingStatus.PrintedSuccessfully);

                lblCountdown.Text = "";

                try
                {
                    int todayCount =
                        IncrementTodayPrintCount(tbReferenceNumber.Text);

                    lblTodayPrintCount.Text = todayCount.ToString();
                }
                catch (Exception countEx)
                {
                    MessageBox.Show(
                        "Label printed successfully, but today's count could not be updated.\n" +
                        countEx.Message,
                        "Count Update Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                _weighingState =
                    WeighingState.WaitingForWeight;

                SetWeighingStatus(WeighingStatus.PrintFailed);

                UpdateAutoPrintButtonState();

                MessageBox.Show(
                    ex.Message,
                    "Automatic Printing Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateAutoPrintButtonState()
        {
            if (!enableChildPartsWeighing ||
                _weighingState != WeighingState.WaitingForWeight)
            {
                return;
            }

            double minimumWeight =
                Convert.ToDouble(lblMinimumWeight.Text);

            double maximumWeight =
                Convert.ToDouble(lblMaximumWeight.Text);

            bool isValid =
                _currentWeightKg > 0 &&
                _currentWeightKg >= minimumWeight &&
                _currentWeightKg <= maximumWeight;


            if (isValid)
            {
                SetWeighingStatus(WeighingStatus.Ready);
            }
            else
            {
                SetWeighingStatus(WeighingStatus.WaitingForValidWeight);
            }
        }

        private void ResetAutomaticWeighing()
        {
            _autoPrintTimer.Stop();

            _weighingState =
                WeighingState.WaitingForWeight;

            _remainingSeconds = 0;

            lblCountdown.Text = "";

            SetWeighingStatus(WeighingStatus.WaitingForPart);

        }

        private void UpdateWeightStatusLabel(string lblWeightText, bool success)
        {
            Color backColor;
            Color foreColor;

            if (!success)
            {
                backColor = Color.Red;
                foreColor = Color.White;
            }
            else if (decimal.TryParse(lblWeightText, out decimal currentWeight))
            {
                decimal minimumWeight = Convert.ToDecimal(lblMinimumWeight.Text);
                decimal maximumWeight = Convert.ToDecimal(lblMaximumWeight.Text);

                if (currentWeight < minimumWeight)
                {
                    backColor = Color.Yellow;
                    foreColor = Color.Black;
                }
                else if (currentWeight > maximumWeight)
                {
                    backColor = Color.Red;
                    foreColor = Color.White;
                }
                else
                {
                    backColor = Color.Green;
                    foreColor = Color.White;
                }
            }
            else
            {
                return;
            }

            // Update only when the value or appearance changes
            if (lblWeightStatus.Text != lblWeightText)
                lblWeightStatus.Text = lblWeightText;

            if (lblWeightStatus.BackColor != backColor)
                lblWeightStatus.BackColor = backColor;

            if (lblWeightStatus.ForeColor != foreColor)
                lblWeightStatus.ForeColor = foreColor;
        }

        private void AutoPrintTimer_Tick(object sender, EventArgs e)
        {
            switch (_weighingState)
            {
                case WeighingState.StabilizingWeight:

                    double minimumWeight =
                        Convert.ToDouble(lblMinimumWeight.Text);

                    double maximumWeight =
                        Convert.ToDouble(lblMaximumWeight.Text);

                    bool validWeight =
                        _currentWeightKg > 0 &&
                        _currentWeightKg >= minimumWeight &&
                        _currentWeightKg <= maximumWeight;

                    if (!validWeight)
                    {
                        CancelWeightCountdown();
                        return;
                    }

                    _remainingSeconds--;

                    if (_remainingSeconds > 0)
                    {
                        lblCountdown.Text =
                            _remainingSeconds.ToString();
                    }
                    else
                    {
                        _autoPrintTimer.Stop();

                        ProcessAutomaticPrinting();
                    }

                    break;


                case WeighingState.StabilizingZero:

                    if (Math.Abs(_currentWeightKg) >
                        _zeroWeightThreshold)
                    {
                        _autoPrintTimer.Stop();

                        _weighingState =
                            WeighingState.WaitingForZero;

                        lblCountdown.Text = "";

                        SetWeighingStatus(WeighingStatus.RemoveCurrentItem);

                        return;
                    }

                    _remainingSeconds--;

                    if (_remainingSeconds > 0)
                    {
                        lblCountdown.Text =
                            _remainingSeconds.ToString();
                    }
                    else
                    {
                        _autoPrintTimer.Stop();

                        _weighingState =
                            WeighingState.WaitingForWeight;

                        lblCountdown.Text = "";

                        SetWeighingStatus(WeighingStatus.PlaceNextItem);

                        UpdateAutoPrintButtonState();
                    }

                    break;
            }
        }


        private void SetWeighingStatus(string status)
        {
            lblAutoWeighingStatus.Text = status;

            switch (status)
            {
                case WeighingStatus.WaitingForPart:
                case WeighingStatus.WaitingForValidWeight:

                    lblAutoWeighingStatus.BackColor = lblCountdown.BackColor = WeighingColors.Waiting;

                    lblAutoWeighingStatus.ForeColor = lblCountdown.ForeColor = Color.Black;

                    break;


                case WeighingStatus.WeightStabilizing:
                case WeighingStatus.ZeroWeightValidation:

                    lblAutoWeighingStatus.BackColor = lblCountdown.BackColor = WeighingColors.Stabilizing;

                    lblAutoWeighingStatus.ForeColor = lblCountdown.ForeColor = Color.Black;

                    break;


                case WeighingStatus.Printing:

                    lblAutoWeighingStatus.BackColor = lblCountdown.BackColor = WeighingColors.Information;

                    lblAutoWeighingStatus.ForeColor = lblCountdown.ForeColor = Color.White;

                    break;


                case WeighingStatus.PrintedSuccessfully:
                case WeighingStatus.PlaceNextItem:
                case WeighingStatus.Ready:

                    lblAutoWeighingStatus.BackColor = lblCountdown.BackColor = WeighingColors.Success;

                    lblAutoWeighingStatus.ForeColor = lblCountdown.ForeColor = Color.White;

                    break;


                case WeighingStatus.RemoveCurrentItem:
                case WeighingStatus.WeightChanged:

                    lblAutoWeighingStatus.BackColor = lblCountdown.BackColor = WeighingColors.Warning;

                    lblAutoWeighingStatus.ForeColor = lblCountdown.ForeColor = Color.White;

                    break;


                case WeighingStatus.PrintFailed:
                case WeighingStatus.ScaleCommunicationError:

                    lblAutoWeighingStatus.BackColor = lblCountdown.BackColor = WeighingColors.Error;

                    lblAutoWeighingStatus.ForeColor = lblCountdown.ForeColor = Color.White;

                    break;
            }
        }

        private int GetTodayPrintCount(string referenceNumber)
        {
            string today = DateTime.Now.ToString("dd-MM-yyyy");

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = transaction;

                        cmd.CommandText = @"
                        UPDATE [1.childpart]
                        SET
                            daily_print_count = 0,
                            last_print_count_date = @TODAY
                        WHERE
                            reference_number = @REFERENCE
                            AND (
                                last_print_count_date IS NULL
                                OR last_print_count_date <> @TODAY
                            );";

                        cmd.Parameters.AddWithValue("@TODAY", today);
                        cmd.Parameters.AddWithValue("@REFERENCE", referenceNumber);

                        cmd.ExecuteNonQuery();
                    }

                    int count = 0;

                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = transaction;

                        cmd.CommandText = @"
                        SELECT daily_print_count
                        FROM [1.childpart]
                        WHERE reference_number = @REFERENCE;";

                        cmd.Parameters.AddWithValue(
                            "@REFERENCE", referenceNumber);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            count = Convert.ToInt32(result);
                    }

                    transaction.Commit();

                    return count;
                }
            }
        }

        private int IncrementTodayPrintCount(string referenceNumber)
        {
            string today = DateTime.Now.ToString("dd-MM-yyyy");

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = transaction;

                        cmd.CommandText = @"
                        UPDATE [1.childpart]
                        SET
                            daily_print_count =
                                CASE
                                    WHEN last_print_count_date = @TODAY
                                    THEN daily_print_count + 1
                                    ELSE 1
                                END,
                            last_print_count_date = @TODAY
                        WHERE reference_number = @REFERENCE;";

                        cmd.Parameters.AddWithValue("@TODAY", today);
                        cmd.Parameters.AddWithValue("@REFERENCE", referenceNumber);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows != 1)
                            throw new Exception(
                                "Unable to update the part printing count.");
                    }

                    int count;

                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = transaction;

                        cmd.CommandText = @"
                        SELECT daily_print_count
                        FROM [1.childpart]
                        WHERE reference_number = @REFERENCE;";

                        cmd.Parameters.AddWithValue(
                            "@REFERENCE", referenceNumber);

                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    transaction.Commit();

                    return count;
                }
            }
        }



        private void SetCountdownVisibility(bool visible)
        {
            lblCountdown.Visible = visible;

            if (visible)
            {
                tlWeighStatus.ColumnStyles[0].SizeType = SizeType.Absolute;
                tlWeighStatus.ColumnStyles[0].Width = 120;
            }
            else
            {
                tlWeighStatus.ColumnStyles[0].SizeType = SizeType.AutoSize;
                tlWeighStatus.ColumnStyles[0].Width = 0;
            }
        }

        private void LblCountdown_TextChanged(object sender, EventArgs e)
        {
            if (lblCountdown.Text == "")
            {
                SetCountdownVisibility(false);
            }
            else
            {
                SetCountdownVisibility(true);
            }
        }


        private void ResizeImageBox()
        {
            // Get available panel dimensions
            int cellWidth = tlImageContainer.ClientSize.Width;
            int cellHeight = tlImageContainer.ClientSize.Height /
                             tlImageContainer.RowCount;

            int imageSize = Math.Min(cellWidth, cellHeight);

            foreach (Control control in tlImageContainer.Controls)
            {
                if (control is PictureBox pb)
                {
                    pb.Width = imageSize - 10;
                    pb.Height = imageSize - 10;

                    // Align image to left
                    pb.Left = 5;

                    pb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private enum WeighingState
        {
            WaitingForWeight,
            StabilizingWeight,
            Printing,
            WaitingForZero,
            StabilizingZero
        }


        private WeighingState _weighingState =
            WeighingState.WaitingForWeight;

        private readonly Timer _autoPrintTimer;

        private double _currentWeightKg = 0;

        private int _remainingSeconds = 0;

        private readonly int _stableWeightSeconds = 0;

        private readonly int _zeroWeightSeconds = 0;

        private readonly double _zeroWeightThreshold = 0.000;

        #endregion

        private void TlImageContainer_Resize(object sender, EventArgs e)
        {
            ResizeImageBox();
        }
    }
}
