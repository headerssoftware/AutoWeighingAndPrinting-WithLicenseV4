using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//For excel sheet
using ClosedXML.Excel;


namespace AutoWeighingAndPrinting
{
    public partial class MasterDataForm : Form
    {
        readonly Config config;
        readonly AppSettings appSettings;
        readonly string connectionString;

        [Obsolete]
        public MasterDataForm()
        {
            InitializeComponent();
            config = new Config();
            appSettings = config.ReadSettings();
            //string value from app.config
            connectionString = @"DataSource=" + appSettings.DBFilePath + ";foreign keys=true;";


        }

        DataTable dtViewChildPartsHistory = null;


        private void BtnViewChildParts_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dtViewChildParts = new DataTable();
                string sql = @"SELECT childpart_id as ID, reference_number as ReferenceNumber,child_part_number as PartNumber, child_part_description as Description, default_qty as DefaultQty, total_weight as TotalWeight,
                                part_weight as PartWeight, tol_percent as TolerancePercent, tol_part_weight as TolerancePartWeight,
                                negative_tol_percent as NegativeTolerancePercent, negative_tol_part_weight as NegativeTolerancePartWeight,
                                positive_tol_percent as PositiveTolerancePercent, positive_tol_part_weight as PositiveTolerancePartWeight,
                                image as Image, expiry_days as ExpiryDays,side_info as SideInfo,batch_no as LastBatchNumber,last_print_count_date as LastPrintCountDate,daily_print_count as PrintCount  FROM [1.childpart] order by ReferenceNumber";
                using (SQLiteConnection con = new SQLiteConnection(connectionString, true))
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, con))
                {
                    dataAdapter.Fill(dtViewChildParts);
                }

                dgvViewChildParts.DataSource = dtViewChildParts;
                dgvViewChildParts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                dgvViewChildParts.Columns["ID"].Visible = false;
                dgvViewChildParts.Columns["Image"].Visible = false;

                for (int i = 1; i < dgvViewChildParts.Columns.Count; i++)
                {
                    dgvViewChildParts.Columns[i].ReadOnly = true;
                }

                dgvViewChildParts.ClearSelection();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                dgvViewChildParts.DataSource = null;
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddChildParts_Click(object sender, EventArgs e)
        {
            AddChildPartForm addChildPartForm = new AddChildPartForm();
            addChildPartForm.ShowDialog();
            if (addChildPartForm.IsNewChildPartAdded)
            {
                BtnViewChildParts_Click(sender, e);
                foreach (DataGridViewRow row in dgvViewChildParts.Rows)
                {
                    if (row.Cells["ReferenceNumber"].Value.ToString().Equals(addChildPartForm.NewReferenceNumber))
                    {
                        int rowIndex = row.Index;
                        dgvViewChildParts.Rows[rowIndex].Selected = true;
                        break;
                    }
                }

                addChildPartForm.IsNewChildPartAdded = false;
            }
        }

        private void DgvViewChildParts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvViewChildParts.DataSource != null && dgvViewChildParts.SelectedRows.Count == 1)
            {

                if (dgvViewChildParts.SelectedRows[0].Cells["Image"].Value != DBNull.Value)
                {
                    var data = (Byte[])(dgvViewChildParts.SelectedRows[0].Cells["Image"].Value);
                    var stream = new MemoryStream(data);
                    pbImage.Image = Image.FromStream(stream);
                }
                else
                {
                    pbImage.Image = null;
                }
            }
            else
            {
                pbImage.Image = null;
            }
        }

        private void BtnEditChildPart_Click(object sender, EventArgs e)
        {
            if (dgvViewChildParts.SelectedRows.Count == 1 && dgvViewChildParts.DataSource != null)
            {
                EnterPasswordForm enterPasswordForm = new EnterPasswordForm();
                enterPasswordForm.ShowDialog();

                if (enterPasswordForm.IsPasswordCorrect)
                {
                    EditChildPartForm editChildPartForm = new EditChildPartForm(dgvViewChildParts.SelectedRows[0]);
                    editChildPartForm.ShowDialog();
                    if (editChildPartForm.IsChildPartUpdated)
                    {
                        BtnViewChildParts_Click(sender, e);
                        editChildPartForm.IsChildPartUpdated = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select the required row to open update form");
            }
        }

        private void BtnDeleteChildPart_Click(object sender, EventArgs e)
        {
            bool isCheckboxSelected = false;

            //Check if CheckBox are selected
            if (dgvViewChildParts.DataSource != null && dgvViewChildParts.Rows.Count >= 1)
            {
                for (int i = 0; i < dgvViewChildParts.Rows.Count; i++)
                {
                    if (dgvViewChildParts.Rows[i].Cells[0].Value != null)
                    {
                        bool cellValue = (bool)dgvViewChildParts.Rows[i].Cells[0].Value;
                        if (cellValue)
                        {
                            isCheckboxSelected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a checkbox to delete the data", "Error: None Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isCheckboxSelected)
            {
                //Check if password is correct, else return
                EnterPasswordForm enterPasswordForm = new EnterPasswordForm();
                enterPasswordForm.ShowDialog();

                if (!enterPasswordForm.IsPasswordCorrect)
                {
                    return;
                }
            }

            DialogResult dr = MessageBox.Show("Are you sure to delete the selected child part numbers?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                //delete row from database or datagridview...
                this.Cursor = Cursors.WaitCursor;
                SQLiteConnection con = new SQLiteConnection(connectionString, true);
                con.Open();

                for (int i = 0; i < dgvViewChildParts.Rows.Count; i++)
                {
                    if (dgvViewChildParts.Rows[i].Cells[0].Value != null)
                    {
                        bool cellValue = (bool)dgvViewChildParts.Rows[i].Cells[0].Value;
                        if (cellValue)
                        {
                            try
                            {
                                int childpart_id = Convert.ToInt32(dgvViewChildParts.Rows[i].Cells["ID"].Value.ToString());

                                SQLiteCommand cmd = new SQLiteCommand(con)
                                {
                                    //Continue with the child part deletion
                                    CommandText = @"DELETE FROM [1.childpart] where childpart_id=@ID"
                                };
                                cmd.Parameters.AddWithValue("@ID", childpart_id);
                                cmd.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {
                                this.Cursor = Cursors.Default;

                                con.Close();
                                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                con.Close();

                this.Cursor = Cursors.Default;
                BtnViewChildParts_Click(sender, e);
                MessageBox.Show("Data Deleted Succcessfully", "Delete Report", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void DgvViewChildParts_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvViewChildParts.DataSource == null)
            {
                lblChildPartRowCount.Text = "Row Count: 0";
            }
            else
            {
                lblChildPartRowCount.Text = "Row Count: " + dgvViewChildParts.Rows.Count.ToString();
            }
        }


        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = tbOldPassword.Text;
            string newPassword = tbNewPassword.Text;

            if (oldPassword == string.Empty || newPassword == string.Empty)
            {
                MessageBox.Show("Values cannot be empty. Please check the password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (oldPassword == newPassword)
            {
                MessageBox.Show("New Password cannot be same as Old Password. Please change the password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNewPassword.Text = "";
                tbNewPassword.Focus();
                return;
            }
            else
            {
                try
                {
                    bool result = false;

                    DataTable dtUsers = new DataTable();
                    string sql = @"SELECT password as PASSWORD FROM [3.users] where USERNAME='ADMIN'";
                    using (SQLiteConnection con = new SQLiteConnection(connectionString, true))
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, con))
                    {
                        dataAdapter.Fill(dtUsers);
                    }
                    if (dtUsers.Rows.Count == 1)
                    {
                        string dbPassword = dtUsers.Rows[0]["PASSWORD"].ToString();   //password in database
                        //comparing the passwords with case sensitive
                        result = dbPassword.Equals(oldPassword, System.StringComparison.Ordinal);

                        if (result)
                        {
                            //Update new password in DB
                            SQLiteConnection con = new SQLiteConnection(connectionString, true);

                            con.Open();
                            using (SQLiteCommand cmd = new SQLiteCommand(con)
                            {
                                CommandText = @"UPDATE [3.users] SET password = @PASSWORD
                                                     WHERE username = 'ADMIN'"
                            })
                            {
                                cmd.Parameters.AddWithValue("@PASSWORD", newPassword);
                                cmd.ExecuteNonQuery();
                            }
                            con.Close();

                            tbOldPassword.Text = tbNewPassword.Text = "";
                            MessageBox.Show("Password Updated Successfully.");
                        }
                        else
                        {
                            //Password error
                            MessageBox.Show("Old Password is wrong.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbOldPassword.Text = "";

                            tbOldPassword.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ADMIN User not found in database.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB Error.\nPlease contact the software vendor.\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TcMasterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMasterData.SelectedTab == tpChangePassword)
            {
                tbOldPassword.Text = "";
                tbNewPassword.Text = "";
                tbOldPassword.Focus();
            }
        }

        private void MasterDataForm_Load(object sender, EventArgs e)
        {
            bool enablePrintingHistory = appSettings.EnablePrintingHistory;
            if (!enablePrintingHistory)
            {
                tcMasterData.TabPages.Remove(tpViewPrintingHistory);
            }
        }

        private void BtnChildSubmit_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpChildFromDate.Value.Date;
            DateTime toDate = dtpChildToDate.Value.Date;

            if (fromDate > toDate)
            {
                dgvChildPartsHistory.DataSource = null;
                MessageBox.Show("[FROM DATE] is greater than [TO DATE] which is invalid");
            }
            else
            {

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    dtViewChildPartsHistory = new DataTable();
                    string sql = @"SELECT childpart_history_id as ID, strftime('%d-%m-%Y %H:%M:%S',date_time) as DateAndTime, customer_name as CustomerName,
                                child_part_number as PartNumber, child_part_description as Description, 
                                quantity as Quantity,part_weight as PartWeight, net_weight as NetWeight,
                                pallet_weight as PalletWeight, gross_weight as GrossWeight, batch_no as BatchNo, other_info as OtherInfo,
                                no_of_packet as NoOfPacket, negative_tol_percent as NegativeTolerancePercent, negative_tol_part_weight as NegativeTolerancePartWeight,
                                db_part_weight as DBPartWeight, positive_tol_percent as PositiveTolerancePercent, positive_tol_part_weight as PositiveTolerancePartWeight,
                                side_info as SideInfo
                                FROM [2.childpart_history] where date_time>= '" + fromDate.ToString("yyyy-MM-dd") + " 00:00:00' and date_time<='" + toDate.ToString("yyyy-MM-dd") + " 23:59:59' order by date_time";
                    using (SQLiteConnection con = new SQLiteConnection(connectionString, true))
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, con))
                    {
                        dataAdapter.Fill(dtViewChildPartsHistory);
                    }

                    dgvChildPartsHistory.DataSource = dtViewChildPartsHistory;
                    dgvChildPartsHistory.Columns["ID"].Visible = false;

                    for (int i = 0; i < dgvChildPartsHistory.Columns.Count; i++)
                    {
                        dgvChildPartsHistory.Columns[i].ReadOnly = true;
                    }

                    dgvChildPartsHistory.ClearSelection();
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    dgvChildPartsHistory.DataSource = null;
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvChildPartsHistory_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvChildPartsHistory.DataSource == null)
            {
                lblChildHistoryRowCount.Text = "Row Count: 0";
            }
            else
            {
                lblChildHistoryRowCount.Text = "Row Count: " + dgvChildPartsHistory.Rows.Count;
            }
        }

        [Obsolete]
        private void BtnChildExportToExcel_Click(object sender, EventArgs e)
        {
            if (dtViewChildPartsHistory == null || dtViewChildPartsHistory.Rows.Count <= 0)
            {
                MessageBox.Show("Report is empty. Export To Excel is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                DataTable dt = dtViewChildPartsHistory;
                dt.Columns.Remove("ID");

                //Exporting to Excel
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string folderPath = desktop + "\\AutoWeighing ExcelReport\\ChildPartsHistory\\";

                DateTime from_date = dtpChildFromDate.Value;
                DateTime to_date = dtpChildToDate.Value;
                string fromdate = from_date.ToString("dd.MM.yyyy");
                string todate = to_date.ToString("dd.MM.yyyy");

                string filename = "Exported from " + fromdate + " to " + todate;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("ChildParts Printed History");
                    ws.Cell(1, 1).InsertTable(dt);
                    ws.Worksheet.Table("Table1").ShowAutoFilter = false;
                    ws.Columns().AdjustToContents();
                    ws.AutoFilter.Clear();

                    wb.SaveAs(folderPath + filename + ".xlsx");
                }

                Cursor = Cursors.Default;

                MessageBox.Show("Exported in Desktop/AutoWeighing ExcelReport folder");
            }
        }

    }
}
