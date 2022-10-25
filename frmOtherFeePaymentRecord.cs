using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;
namespace College_Management_System
{
    public partial class frmOtherFeePaymentRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmOtherFeePaymentRecord()
        {
            InitializeComponent();
        }
        private void AutocompleteCourse()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Course) FROM OtherFeePayment,Student where Student.ScholarNo=OtherFeePayment.ScholarNo", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                Course.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    Course.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompleteScholarNo()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(ScholarNo) FROM OtherFeePayment", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                ScholarNo.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    ScholarNo.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FeePaymentRecord_Load(object sender, EventArgs e)
        {
            AutocompleteCourse();
            //AutocompleteScholarNo();
        }

        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            Branch.Items.Clear();
            Branch.Text = "";
            Branch.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct rtrim(branch) from student,OtherFeepayment where Student.ScholarNo=OtherFeePayment.scholarNo and course= '" + Course.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Branch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Course.Text = "";
            Branch.Text = "";
            Date_from.Text = DateTime.Today.ToString();
            Date_to.Text = DateTime.Today.ToString();
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
            Branch.Enabled = false;
        }

        private void FeePaymentRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmOtherFeesPayment form2 = new frmOtherFeesPayment();
            form2.label23.Text = label13.Text;
            form2.label24.Text = label14.Text;
            form2.Show();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Calling DataGridView Printing
            PrintDGV.Print_DataGridView(dataGridView5);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmOtherFeesPayment frm = new frmOtherFeesPayment();
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;

                frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[2].Value.ToString();
                frm.Year.Text = dr.Cells[1].Value.ToString();
                frm.StudentName.Text = dr.Cells[3].Value.ToString();
                frm.Course.Text = dr.Cells[4].Value.ToString();
                frm.Branch.Text = dr.Cells[5].Value.ToString();
                frm.FeeID.Text = dr.Cells[6].Value.ToString();
                frm.FDCourse.Text = dr.Cells[4].Value.ToString();
                frm.FDBranch.Text = dr.Cells[5].Value.ToString();
                frm.Term.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.Fine.Text = dr.Cells[12].Value.ToString();
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.Print.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView2.SelectedRows[0];
                this.Hide();
                frmOtherFeesPayment frm = new frmOtherFeesPayment();
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[2].Value.ToString();
                frm.Year.Text = dr.Cells[1].Value.ToString();
                frm.StudentName.Text = dr.Cells[3].Value.ToString();
                frm.Course.Text = dr.Cells[4].Value.ToString();
                frm.Branch.Text = dr.Cells[5].Value.ToString();
                frm.FeeID.Text = dr.Cells[6].Value.ToString();
                frm.FDCourse.Text = dr.Cells[4].Value.ToString();
                frm.FDBranch.Text = dr.Cells[5].Value.ToString();
                frm.Term.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.Fine.Text = dr.Cells[12].Value.ToString();
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.Print.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView3.SelectedRows[0];
                this.Hide();
                frmOtherFeesPayment frm = new frmOtherFeesPayment();
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[2].Value.ToString();
                frm.Year.Text = dr.Cells[1].Value.ToString();
                frm.StudentName.Text = dr.Cells[3].Value.ToString();
                frm.Course.Text = dr.Cells[4].Value.ToString();
                frm.Branch.Text = dr.Cells[5].Value.ToString();
                frm.FeeID.Text = dr.Cells[6].Value.ToString();
                frm.FDCourse.Text = dr.Cells[4].Value.ToString();
                frm.FDBranch.Text = dr.Cells[5].Value.ToString();
                frm.Term.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.Fine.Text = dr.Cells[12].Value.ToString();
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.Print.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView4.SelectedRows[0];
                this.Hide();
                frmOtherFeesPayment frm = new frmOtherFeesPayment();
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[2].Value.ToString();
                frm.Year.Text = dr.Cells[1].Value.ToString();
                frm.StudentName.Text = dr.Cells[3].Value.ToString();
                frm.Course.Text = dr.Cells[4].Value.ToString();
                frm.Branch.Text = dr.Cells[5].Value.ToString();
                frm.FeeID.Text = dr.Cells[6].Value.ToString();
                frm.FDCourse.Text = dr.Cells[4].Value.ToString();
                frm.FDBranch.Text = dr.Cells[5].Value.ToString();
                frm.Term.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.Fine.Text = dr.Cells[12].Value.ToString();
                frm.DueFees.Text = dr.Cells[13].Value.ToString();
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.Print.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView5.SelectedRows[0];
                this.Hide();
                frmOtherFeesPayment frm = new frmOtherFeesPayment();
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.FeePaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[2].Value.ToString();
                frm.Year.Text = dr.Cells[1].Value.ToString();
                frm.StudentName.Text = dr.Cells[3].Value.ToString();
                frm.Course.Text = dr.Cells[4].Value.ToString();
                frm.Branch.Text = dr.Cells[5].Value.ToString();
                frm.FeeID.Text = dr.Cells[6].Value.ToString();
                frm.FDCourse.Text = dr.Cells[4].Value.ToString();
                frm.FDBranch.Text = dr.Cells[5].Value.ToString();
                frm.Term.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.Fine.Text = dr.Cells[12].Value.ToString();
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.Print.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.label23.Text = label13.Text;
                frm.label24.Text = label14.Text;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Course.Text == "")
                {
                    MessageBox.Show("Please select Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Course.Focus();
                    return;
                }
                if (Branch.Text == "")
                {
                    MessageBox.Show("Please select Level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Branch.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and Student.Course= '" + Course.Text + "'and Student.branch='" + Branch.Text + "' order by DateOfPayment", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = Date_from.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = Date_to.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView1.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Course.Text = "";
            Branch.Text = "";
            Date_from.Text = System.DateTime.Today.ToString();
            Date_to.Text = System.DateTime.Today.ToString();
            dataGridView1.DataSource = null;
            Branch.Enabled = false;
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
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
                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
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

        private void button9_Click(object sender, EventArgs e)
        {
            ScholarNo.Text = "";
            dataGridView2.DataSource = null;
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

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 order by DateOfPayment ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = PaymentDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = PaymentDateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView3.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PaymentDateFrom.Text = System.DateTime.Today.ToString();
            PaymentDateTo.Text = System.DateTime.Today.ToString();
            dataGridView3.DataSource = null;
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
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student.Student_Name)[Student Name],RTRIM(Student.Course)[Class],RTRIM(Student.Branch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Last Installment],RTRIM(Fine)[Fine],RTRIM(DueFees)[Due Fees] from OtherFeePayment,Student where Student.ScholarNo=OtherFeePayment.ScholarNo and Student.Session=OtherFeePayment.Year and Student.Course=OtherFeePayment.FDCourse and DateOfPayment between @date1 and @date2 and DueFees > 0 order by DateOfPayment ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView4.DataSource = myDataSet.Tables["Student"].DefaultView;
                dataGridView4.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DateFrom.Text = System.DateTime.Today.ToString();
            DateTo.Text = System.DateTime.Today.ToString();
            dataGridView4.DataSource = null;
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

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student.Student_Name)[Student Name],RTRIM(Student.Course)[Class],RTRIM(Student.Branch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment,Student where Student.ScholarNo=OtherFeePayment.ScholarNo  and Student.Session=OtherFeePayment.Year and Student.Course=OtherFeePayment.FDCourse and DateOfPayment between @date1 and @date2 and Fine > 0 order by DateOfPayment ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker2.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView5.DataSource = myDataSet.Tables["Student"].DefaultView;
                dataGridView5.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = System.DateTime.Today.ToString();
            dateTimePicker2.Text = System.DateTime.Today.ToString();
            dataGridView5.DataSource = null;
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
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
        string numberphone = null;
        string messages = null;
        string studentsnos = null;
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource == null)
            {
                MessageBox.Show("Sorry No body to sms, first set paramenters and get data", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var client2 = new WebClient())
                using (client2.OpenRead("http://client3.google.com/generate_204"))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        if (!row.IsNewRow)
                        {
                            if ((row.Cells[1].Value) != null)
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "SELECT distinct RTRIM(Contact_No) FROM StudentRegistration where ScholarNo='" + row.Cells[1].Value + "'";
                                rdr = cmd.ExecuteReader();
                                if (rdr.Read())
                                {
                                    numberphone = rdr.GetString(0).Trim();
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                                if (con.State == ConnectionState.Open)
                                {
                                    con.Close();
                                }
                                string usernamess = Properties.Settings.Default.smsusername;
                                string passwordss = Properties.Settings.Default.smspassword;
                                WebClient client = new WebClient();
                                string numbers = "+256" + numberphone;
                                messages = row.Cells[2].Value + " has a Due to us balance of " + row.Cells[12].Value + " on his" + row.Cells[5].Value + " for " + row.Cells[6].Value + " Term and your reminded to bring it.";
                                string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username=" + usernamess + "&password=" + passwordss + "&senderid=Geniussms&message=" + messages + "&numbers=" + numbers;
                                client.OpenRead(baseURL);
                                // MessageBox.Show("Successfully sent message");
                            }
                        }
                    }
                    MessageBox.Show("Successfully sent message");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not send message because your computer is not connected to internet");
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Identity Card' order by DateOfPayment ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker3.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker4.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView6.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dateTimePicker3.Text = System.DateTime.Today.ToString();
            dateTimePicker4.Text = System.DateTime.Today.ToString();
            dataGridView6.DataSource = null;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dataGridView6.DataSource == null)
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
                rowsTotal = dataGridView6.RowCount - 1;
                colsTotal = dataGridView6.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView6.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView6.Rows[I].Cells[j].Value;
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

        private void button16_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView6);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where  DateOfPayment between @date1 and @date2 and FeeName='Admission' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker5.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker6.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView7.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            dateTimePicker5.Text = System.DateTime.Today.ToString();
            dateTimePicker6.Text = System.DateTime.Today.ToString();
            dataGridView7.DataSource = null;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (dataGridView7.DataSource == null)
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
                rowsTotal = dataGridView7.RowCount - 1;
                colsTotal = dataGridView7.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView7.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView7.Rows[I].Cells[j].Value;
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

        private void button20_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView7);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='UAHEB' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker7.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker8.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView8.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            dateTimePicker7.Text = System.DateTime.Today.ToString();
            dateTimePicker8.Text = System.DateTime.Today.ToString();
            dataGridView8.DataSource = null;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (dataGridView8.DataSource == null)
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
                rowsTotal = dataGridView8.RowCount - 1;
                colsTotal = dataGridView8.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView8.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView8.Rows[I].Cells[j].Value;
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

        private void button24_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView8);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Medical Insurance' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker9.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker10.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView9.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            dateTimePicker9.Text = System.DateTime.Today.ToString();
            dateTimePicker10.Text = System.DateTime.Today.ToString();
            dataGridView9.DataSource = null;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (dataGridView9.DataSource == null)
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
                rowsTotal = dataGridView9.RowCount - 1;
                colsTotal = dataGridView9.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView9.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView9.Rows[I].Cells[j].Value;
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

        private void button28_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView9);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Guild' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker11.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker12.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView10.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            dateTimePicker11.Text = System.DateTime.Today.ToString();
            dateTimePicker12.Text = System.DateTime.Today.ToString();
            dataGridView10.DataSource = null;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (dataGridView10.DataSource == null)
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
                rowsTotal = dataGridView10.RowCount - 1;
                colsTotal = dataGridView10.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView10.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView10.Rows[I].Cells[j].Value;
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

        private void button32_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView10);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Uniform' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker13.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker14.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView11.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            dateTimePicker13.Text = System.DateTime.Today.ToString();
            dateTimePicker14.Text = System.DateTime.Today.ToString();
            dataGridView11.DataSource = null;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (dataGridView11.DataSource == null)
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
                rowsTotal = dataGridView11.RowCount - 1;
                colsTotal = dataGridView11.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView11.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView11.Rows[I].Cells[j].Value;
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

        private void button36_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView11);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Progressive Examination' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker15.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker16.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView12.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            dateTimePicker15.Text = System.DateTime.Today.ToString();
            dateTimePicker16.Text = System.DateTime.Today.ToString();
            dataGridView12.DataSource = null;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (dataGridView12.DataSource == null)
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
                rowsTotal = dataGridView12.RowCount - 1;
                colsTotal = dataGridView12.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView12.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView12.Rows[I].Cells[j].Value;
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

        private void button40_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView12);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Library' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker17.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker18.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView13.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            dateTimePicker17.Text = System.DateTime.Today.ToString();
            dateTimePicker18.Text = System.DateTime.Today.ToString();
            dataGridView13.DataSource = null;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (dataGridView13.DataSource == null)
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
                rowsTotal = dataGridView13.RowCount - 1;
                colsTotal = dataGridView13.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView13.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView13.Rows[I].Cells[j].Value;
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

        private void button44_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView13);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Document Verification' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker19.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker20.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView14.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            dateTimePicker19.Text = System.DateTime.Today.ToString();
            dateTimePicker20.Text = System.DateTime.Today.ToString();
            dataGridView14.DataSource = null;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (dataGridView14.DataSource == null)
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
                rowsTotal = dataGridView14.RowCount - 1;
                colsTotal = dataGridView14.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView14.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView14.Rows[I].Cells[j].Value;
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

        private void button48_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView14);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Hospital Attachment' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker21.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker22.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView15.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            dateTimePicker21.Text = System.DateTime.Today.ToString();
            dateTimePicker22.Text = System.DateTime.Today.ToString();
            dataGridView15.DataSource = null;
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (dataGridView15.DataSource == null)
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
                rowsTotal = dataGridView15.RowCount - 1;
                colsTotal = dataGridView15.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView15.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView15.Rows[I].Cells[j].Value;
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

        private void button52_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView15);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Development' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker23.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker24.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView16.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            dateTimePicker23.Text = System.DateTime.Today.ToString();
            dateTimePicker24.Text = System.DateTime.Today.ToString();
            dataGridView16.DataSource = null;
        }

        private void button57_Click(object sender, EventArgs e)
        {
            if (dataGridView16.DataSource == null)
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
                rowsTotal = dataGridView16.RowCount - 1;
                colsTotal = dataGridView16.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView16.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView16.Rows[I].Cells[j].Value;
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

        private void button56_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView16);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student_name)[Student Name],RTRIM(FDCourse)[Course],RTRIM(FDBranch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment where DateOfPayment between @date1 and @date2 and FeeName='Interview' order by ID Desc ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker25.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = dateTimePicker26.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView17.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            dateTimePicker25.Text = System.DateTime.Today.ToString();
            dateTimePicker26.Text = System.DateTime.Today.ToString();
            dataGridView17.DataSource = null;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            if (dataGridView17.DataSource == null)
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
                rowsTotal = dataGridView17.RowCount - 1;
                colsTotal = dataGridView17.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView17.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView17.Rows[I].Cells[j].Value;
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

        private void button60_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView17);
        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void ScholarNo_Click(object sender, EventArgs e)
        {
            frmClientDetails frm = new frmClientDetails();
            frm.ShowDialog();
            ScholarNo.Text = frm.clientnames.Text;
        }

        private void ScholarNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(FeePaymentID)[Fee Payment ID],RTrim(Year)[Year],RTrim(OtherFeePayment.ScholarNo)[Student No.], RTRIM(Student.Student_Name)[Student Name],RTRIM(OtherFeePayment.FDCourse)[CLass],RTRIM(Student.Branch)[Section],RTRIM(FeeName)[Fee Name],RTRIM(Semester)[Term],RTRIM(DateOfPayment)[Payment Date],RTRIM(ModeOfPayment)[Mode Of Payment],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(Fine)[Fine] from OtherFeePayment,Student where Student.ScholarNo=OtherFeePayment.ScholarNo and Student.Session=OtherFeePayment.Year and Student.Course=OtherFeePayment.FDCourse and OtherFeePayment.ScholarNo= '" + ScholarNo.Text + "' order by DateOfPayment ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                myDA.Fill(myDataSet, "OtherFeePayment");
                dataGridView2.DataSource = myDataSet.Tables["Student"].DefaultView;
                dataGridView2.DataSource = myDataSet.Tables["OtherFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}












