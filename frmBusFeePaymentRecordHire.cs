using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace College_Management_System
{
    public partial class frmBusFeePaymentRecordHire : Form
    {
        //SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmBusFeePaymentRecordHire()
        {
            InitializeComponent();
        }
    
        private void AutocompleteScholarNo()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(HirerName) FROM BusHireFeePayment", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                ScholarNo.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    ScholarNo.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = dataGridView2.RowCount - 1;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = dataGridView3.RowCount - 1;
                colsTotal = dataGridView3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView3.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(HireFeePaymentID)[Fee Payment ID], RTRIM(HirerName)[HirerName],RTRIM(HirerAddress)[Hirer Address],RTRIM(Destination)[Destination],RTRIM(Duration)[Duration Days],RTRIM(HireBusCharges1)[Bus Hire Charges],RTRIM(HireDateOfPayment)[Payment Date],RTRIM(HireModeOfPayment)[Mode Of Payment],RTRIM(HirePaymentModeDetails)[Payment Mode Details],RTRIM(HireTotalPaid)[Total Paid],RTRIM(HireFine)[Fine],RTRIM(HireDueFees)[Due Fees],RTRIM(Term)[Semester]  from BusHireFeePayment where HireDateOfPayment between @date1 and @date2 and HireDueFees > 0 order by HireDateOfPayment", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "HireDateOfPayment").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "HireDateOfPayment").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "BusHireFeePayment");
                dataGridView4.DataSource = myDataSet.Tables["BusHireFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = dataGridView4.RowCount - 1;
                colsTotal = dataGridView4.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView4.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView4.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView5.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = dataGridView5.RowCount - 1;
                colsTotal = dataGridView5.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView5.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView5.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
           
            ScholarNo.Text = "";
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
            dataGridView5.DataSource = null;
            PaymentDateFrom.Text = DateTime.Today.ToString();
            PaymentDateTo.Text = DateTime.Today.ToString();
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ScholarNo.Text = "";
            dataGridView2.DataSource = null;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PaymentDateFrom.Text = System.DateTime.Today.ToString();
            PaymentDateTo.Text = System.DateTime.Today.ToString();
            dataGridView3.DataSource = null;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DateFrom.Text = System.DateTime.Today.ToString();
            DateTo.Text = System.DateTime.Today.ToString();
            dataGridView4.DataSource = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = System.DateTime.Today.ToString();
            dateTimePicker2.Text = System.DateTime.Today.ToString();
            dataGridView5.DataSource = null;
        }

     

        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(HireFeePaymentID)[Fee Payment ID], RTRIM(HirerName)[HirerName],RTRIM(HirerAddress)[Hirer Address],RTRIM(Destination)[Destination],RTRIM(Duration)[Duration Days],RTRIM(HireBusCharges1)[Bus Hire Charges],RTRIM(HireDateOfPayment)[Payment Date],RTRIM(HireModeOfPayment)[Mode Of Payment],RTRIM(HirePaymentModeDetails)[Payment Mode Details],RTRIM(HireTotalPaid)[Total Paid],RTRIM(HireFine)[Fine],RTRIM(HireDueFees)[Due Fees],RTRIM(Term)[Semester]  from BusHireFeePayment where HirerName = '" + ScholarNo.Text + "' order by HireDateOfPayment", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "BusHireFeePayment");
                dataGridView2.DataSource = myDataSet.Tables["BusHireFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(HireFeePaymentID)[Fee Payment ID], RTRIM(HirerName)[Hirer Name],RTRIM(HirerAddress)[Hirer Address],RTRIM(Destination)[Destination],RTRIM(Duration)[Duration(Days)],RTRIM(HireBusCharges1)[Hire Bus Charges],RTRIM(HireDateOfPayment)[Payment Date],RTRIM(HireModeOfPayment)[Mode Of Payment],RTRIM(HirePaymentModeDetails)[Payment Mode Details],RTRIM(HireTotalPaid)[Total Paid],RTRIM(HireFine)[Fine],RTRIM(HireDueFees)[Due Fees],RTRIM(Term)[Semester]  from BusHireFeePayment where HireDateOfPayment between @date1 and @date2 order by HireDateOfPayment", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "HireDateOfPayment").Value = PaymentDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "HireDateOfPayment").Value = PaymentDateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "BusHireFeePayment");
                dataGridView3.DataSource = myDataSet.Tables["BusHireFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(HireFeePaymentID)[Fee Payment ID], RTRIM(HirerName)[HirerName],RTRIM(HirerAddress)[Hirer Address],RTRIM(Destination)[Destination],RTRIM(Duration)[Duration Days],RTRIM(HireBusCharges1)[Bus Hire Charges],RTRIM(HireDateOfPayment)[Payment Date],RTRIM(HireModeOfPayment)[Mode Of Payment],RTRIM(HirePaymentModeDetails)[Payment Mode Details],RTRIM(HireTotalPaid)[Total Paid],RTRIM(HireFine)[Fine],RTRIM(HireDueFees)[Due Fees],RTRIM(Term)[Semester]  from BusHireFeePayment where HireDateOfPayment between @date1 and @date2 and HireFine > 0 order by HireDateOfPayment", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "HireDateOfPayment").Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "HireDateOfPayment").Value = dateTimePicker2.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "BusHireFeePayment");
                dataGridView5.DataSource = myDataSet.Tables["BusHireFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView5.SelectedRows[0];
            this.Hide();
            frmBusFeePaymentHire frm = new frmBusFeePaymentHire();
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.Course.Text = dr.Cells[2].Value.ToString();
            frm.Branch.Text = dr.Cells[3].Value.ToString();
            frm.txtSourceLocation.Text = dr.Cells[4].Value.ToString();
            frm.txtBusCharges.Text = dr.Cells[5].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[6].Value.ToString();
            frm.ModeOfPayment.Text = dr.Cells[7].Value.ToString();
            frm.PaymentModeDetails.Text = dr.Cells[8].Value.ToString();
            frm.Fine.Text = dr.Cells[10].Value.ToString();
            frm.TotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.DueFees.Text = dr.Cells[11].Value.ToString();
            frm.term.Text = dr.Cells[12].Value.ToString();
                frm.label3.Text = label1.Text;
                frm.label4.Text = label2.Text;
                frm.Print.Enabled = true;
            frm.ShowDialog();
           
        }
   
        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView4.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView4.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView5_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView5.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView5.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void frmBusFeePaymentRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.UserType.Text = label1.Text;
            frm.User.Text = label2.Text;
            frm.Show();*/
        }

        private void frmBusFeePaymentRecord_Load(object sender, EventArgs e)
        {
            AutocompleteScholarNo();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            this.Hide();
            frmBusFeePaymentHire frm = new frmBusFeePaymentHire();
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.Course.Text = dr.Cells[2].Value.ToString();
            frm.Branch.Text = dr.Cells[3].Value.ToString();
            frm.txtSourceLocation.Text = dr.Cells[4].Value.ToString();
            frm.txtBusCharges.Text = dr.Cells[5].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[6].Value.ToString();
            frm.ModeOfPayment.Text = dr.Cells[7].Value.ToString();
            frm.PaymentModeDetails.Text = dr.Cells[8].Value.ToString();
            frm.Fine.Text = dr.Cells[10].Value.ToString();
            frm.TotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.DueFees.Text = dr.Cells[11].Value.ToString();
            frm.term.Text = dr.Cells[12].Value.ToString();
            frm.label3.Text = label1.Text;
            frm.label4.Text = label2.Text;
            frm.Print.Enabled = true;
            frm.ShowDialog();
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            this.Hide();
            frmBusFeePaymentHire frm = new frmBusFeePaymentHire();
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.Course.Text = dr.Cells[2].Value.ToString();
            frm.Branch.Text = dr.Cells[3].Value.ToString();
            frm.txtSourceLocation.Text = dr.Cells[4].Value.ToString();
            frm.txtBusCharges.Text = dr.Cells[5].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[6].Value.ToString();
            frm.ModeOfPayment.Text = dr.Cells[7].Value.ToString();
            frm.PaymentModeDetails.Text = dr.Cells[8].Value.ToString();
            frm.Fine.Text = dr.Cells[10].Value.ToString();
            frm.TotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.DueFees.Text = dr.Cells[11].Value.ToString();
            frm.term.Text = dr.Cells[12].Value.ToString();
            frm.label3.Text = label1.Text;
            frm.label4.Text = label2.Text;
            frm.Print.Enabled = true;
            frm.ShowDialog();
        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView4.SelectedRows[0];
            this.Hide();
            frmBusFeePaymentHire frm = new frmBusFeePaymentHire();
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.Course.Text = dr.Cells[2].Value.ToString();
            frm.Branch.Text = dr.Cells[3].Value.ToString();
            frm.txtSourceLocation.Text = dr.Cells[4].Value.ToString();
            frm.txtBusCharges.Text = dr.Cells[5].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[6].Value.ToString();
            frm.ModeOfPayment.Text = dr.Cells[7].Value.ToString();
            frm.PaymentModeDetails.Text = dr.Cells[8].Value.ToString();
            frm.Fine.Text = dr.Cells[10].Value.ToString();
            frm.TotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.DueFees.Text = dr.Cells[11].Value.ToString();
            frm.term.Text = dr.Cells[12].Value.ToString();
            frm.label3.Text = label1.Text;
            frm.label4.Text = label2.Text;
            frm.Print.Enabled = true;
            frm.ShowDialog();
        }

        private void dataGridView5_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView5.SelectedRows[0];
            this.Hide();
            frmBusFeePaymentHire frm = new frmBusFeePaymentHire();
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.Course.Text = dr.Cells[2].Value.ToString();
            frm.Branch.Text = dr.Cells[3].Value.ToString();
            frm.txtSourceLocation.Text = dr.Cells[4].Value.ToString();
            frm.txtBusCharges.Text = dr.Cells[5].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[6].Value.ToString();
            frm.ModeOfPayment.Text = dr.Cells[7].Value.ToString();
            frm.PaymentModeDetails.Text = dr.Cells[8].Value.ToString();
            frm.Fine.Text = dr.Cells[10].Value.ToString();
            frm.TotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.DueFees.Text = dr.Cells[11].Value.ToString();
            frm.term.Text = dr.Cells[12].Value.ToString();
            frm.label3.Text = label1.Text;
            frm.label4.Text = label2.Text;
            frm.Print.Enabled = true;
            frm.ShowDialog();
        }
    }
}



