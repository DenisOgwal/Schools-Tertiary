using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
namespace College_Management_System
{
    public partial class frmLibraryRequests : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
       // SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

       /* int authoravailable = 0;
        int authortotal = 0;
        int authorrequest = 0;
        int subjectavailable = 0;
        int subjectrequest = 0;
        int subjecttotal = 0;
        int sectionavailable = 0;
        int sectionrequest = 0;
        int sectionttotal = 0;
        int titleavailable = 0;
        int titletotal = 0;
        int titlerequest = 0;*/

        public frmLibraryRequests()
        {
            InitializeComponent();
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

        private void frmBusFeePaymentRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmItemUsageDetails frm = new frmItemUsageDetails();
            frm.label13.Text = label13.Text;
            frm.label21.Text = label14.Text;
            frm.Show();*/
        }
        public DataView Loadrequestlist()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();

            dynamic SelectQry = "SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(author)[Book Author],RTRIM(subject)[Subject],RTRIM(Qty)[No.of Copies],RTRIM(Times)[Time],RTRIM(requeststate)[Request Status] FROM Librarybookrequest ORDER BY ID DESC ";
            DataSet SampleSource = new DataSet();
            DataView TableView = null;
            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = con;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(SampleSource);
                TableView = SampleSource.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return TableView;

        }
        public void pendingreq()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(requestId) from Librarybookrequest where requeststate='Not approved Yet'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pendingrequest.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void approvedreq()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(requestId) from Librarybookrequest where requeststate='Approved'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    approvedrequest.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void datapendingrequests() {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(author)[Book Author],RTRIM(subject)[Subject],RTRIM(Qty)[No.of Copies],RTRIM(Times)[Time],RTRIM(requeststate)[Request Status] FROM Librarybookrequest where  requeststate = 'Pending' order by ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Librarybookrequest");
                dataGridView2.DataSource = myDataSet.Tables["Librarybookrequest"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void dataapprovedrequests()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(author)[Book Author],RTRIM(subject)[Subject],RTRIM(Qty)[No.of Copies],RTRIM(Times)[Time],RTRIM(requeststate)[Request Status] FROM Librarybookrequest where  requeststate = 'Approved' order by ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Librarybookrequest");
                dataGridView3.DataSource = myDataSet.Tables["Librarybookrequest"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void datareturnedrequests()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(author)[Book Author],RTRIM(subject)[Subject],RTRIM(Qty)[No.of Copies],RTRIM(Times)[Time],RTRIM(requeststate)[Request Status] FROM Librarybookrequest where  requeststate = 'Returned' order by ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Librarybookrequest");
                dataGridView4.DataSource = myDataSet.Tables["Librarybookrequest"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void datarejectedrequests()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(author)[Book Author],RTRIM(subject)[Subject],RTRIM(Qty)[No.of Copies],RTRIM(Times)[Time],RTRIM(requeststate)[Request Status] FROM Librarybookrequest where  requeststate = 'Rejected' order by ID ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Librarybookrequest");
                dataGridView5.DataSource = myDataSet.Tables["Librarybookrequest"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBusFeePaymentRecord_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Loadrequestlist();
            pendingreq();
            approvedreq();
            datapendingrequests();
            dataapprovedrequests();
            datareturnedrequests();
            datarejectedrequests();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(title) from Library";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                selectbook.Items.Clear();
                //requestid.Text = "";
                selectbook.Enabled = true;
                while (rdr.Read())
                {
                    selectbook.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            searchtext.Text = null;
        }

        private void searchtext_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(author)[Book Author],RTRIM(subject)[Subject],RTRIM(Qty)[No.of Copies],RTRIM(Times)[Time],RTRIM(requeststate)[Request Status] FROM Librarybookrequest where  author like '" + searchtext.Text + "%' OR bookname like '" + searchtext.Text + "%' OR studentno like '" + searchtext.Text + "%' OR date like '" + searchtext.Text + "%' OR section like '" + searchtext.Text + "%' OR requestId like '" + searchtext.Text + "%' OR class like '" + searchtext.Text + "%' OR stream like '" + searchtext.Text + "%' ORDER BY ID DESC ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Librarybookrequest");
                dataGridView1.DataSource = myDataSet.Tables["Librarybookrequest"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            pendingrequest.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pendingrequest.Text == "")
            {
                MessageBox.Show("Please Enter Request Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pendingrequest.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "update Librarybookrequest set requeststate= 'Approved' where  requestId=@d1";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.VarChar, 15, "requestId"));
                cmd.Prepare();
                cmd.Parameters["@d1"].Value = pendingrequest.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Approved", "Student Request", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = Loadrequestlist();
            pendingreq();
            approvedreq();
            datapendingrequests();
            dataapprovedrequests();
            datareturnedrequests();
            datarejectedrequests();
        }

        private void author1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(author)[Book Author],RTRIM(subject)[Subject],RTRIM(Qty)[No.of Copies],RTRIM(Times)[Time],RTRIM(requeststate)[Request Status] FROM Librarybookrequest where  requestId = '" + pendingrequest.Text + "' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Librarybookrequest");
                dataGridView2.DataSource = myDataSet.Tables["Librarybookrequest"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (approvedrequest.Text == "")
            {
                MessageBox.Show("Please Enter Request Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                approvedrequest.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "update Librarybookrequest set requeststate= 'Returned' where  requestId=@d1";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.VarChar, 15, "requestId"));
                cmd.Prepare();
                cmd.Parameters["@d1"].Value = approvedrequest.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Returned", "Student Request", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = Loadrequestlist();
            pendingreq();
            approvedreq();
            datapendingrequests();
            dataapprovedrequests();
            datareturnedrequests();
            datarejectedrequests();
        }

        private void subject1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(author)[Book Author],RTRIM(subject)[Subject],RTRIM(Qty)[No.of Copies],RTRIM(Times)[Time],RTRIM(requeststate)[Request Status] FROM Librarybookrequest where  requestId = '" + approvedrequest.Text + "' order by ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Librarybookrequest");
                dataGridView3.DataSource = myDataSet.Tables["Librarybookrequest"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            approvedrequest.Text = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
           
        }


        private void button12_Click(object sender, EventArgs e)
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

       

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (pendingrequest.Text == "")
            {
                MessageBox.Show("Please Enter Request Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pendingrequest.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "update Librarybookrequest set requeststate= 'Rejected' where  requestId=@d1";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.VarChar, 15, "requestId"));
                cmd.Prepare();
                cmd.Parameters["@d1"].Value = pendingrequest.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Rejected", "Student Request", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = Loadrequestlist();
            pendingreq();
            approvedreq();
            datapendingrequests();
            dataapprovedrequests();
            datareturnedrequests();
            datarejectedrequests();
        }

        private void stdno_Click(object sender, EventArgs e)
        {
            frmClientDetails frm = new frmClientDetails();
            frm.ShowDialog();
            stdno.Text = frm.clientnames.Text;
        }

        private void stdno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(session) from Student ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    year.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            classes.Items.Clear();
            classes.Text = "";
            classes.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(course) from Student where session = '" + year.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    classes.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            term.Items.Clear();
            term.Text = "";
            term.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Semester) from batch where Course = '" + classes.Text + "' and session='" + year.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    term.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void term_SelectedIndexChanged(object sender, EventArgs e)
        {
            level.Items.Clear();
            level.Text = "";
            level.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(branch) from Student where course = '" + classes.Text + "' and session='" + year.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    level.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectbook_SelectedIndexChanged(object sender, EventArgs e)
        {
            author12.Items.Clear();
            author12.Text = "";
            author12.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(author) from Library where title = '" + selectbook.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    author12.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void author12_SelectedIndexChanged(object sender, EventArgs e)
        {
            subject12.Items.Clear();
            subject12.Text = "";
            subject12.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(subject) from Library where author = '" + author12.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    subject12.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void subject12_SelectedIndexChanged(object sender, EventArgs e)
        {
            section12.Items.Clear();
            section12.Text = "";
            section12.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(booksection) from Library where title = '" + selectbook.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    section12.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        string requestids = null;
        int authorrequest = 0;
        int authortotal = 0;
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            requestids = "REQ-" + years + monthss + days + GetUniqueKey(5);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            auto();
            if (stdno.Text == "")
            {
                MessageBox.Show("Please input your students number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stdno.Focus();
                return;
            }
            if (year.Text == "")
            {
                MessageBox.Show("Please select year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                year.Focus();
                return;
            }
            if (classes.Text == "")
            {
                MessageBox.Show("Please select class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classes.Focus();
                return;
            }
            if (term.Text == "")
            {
                MessageBox.Show("Please select term", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                term.Focus();
                return;
            }

            if (level.Text == "")
            {
                MessageBox.Show("Please select level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                level.Focus();
                return;
            }
            if (selectbook.Text == "")
            {
                MessageBox.Show("Please select book", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectbook.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Qty from Librarybookrequest where author = '" + author12.Text + "' and bookname='" + selectbook.Text + "' and requeststate ='Approved'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    String inquery3 = "SELECT SUM (Qty) FROM Librarybookrequest WHERE author = '" + author12.Text + "' and bookname='" + selectbook.Text + "' and requeststate ='Approved'";
                    cmd = new SqlCommand(inquery3, con);
                    authorrequest = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
                else
                {
                    authorrequest = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT Noofcopies FROM Library WHERE author ='" + author12.Text + "' and title = '" + selectbook.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                authortotal = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            int authoravailable = authortotal - authorrequest;
            if (authoravailable <= 0)
            {
                selectbook.Text = "";
            }
            if (selectbook.Text == "")
            {
                MessageBox.Show("There is no copy of that Particular Book, all have been borrowed", "Student request failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectbook.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Librarybookrequest(requestId,studentno,year,class,term,level,date,bookname,requeststate,author,subject,section,Qty,Times) VALUES (@d13,@d1,@d2,@d3,@d4,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                // Add Parameters to Command Parameters collection
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 15, "requestId"));
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "studentno"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "class"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "term"));
                //cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "stream"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "level"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 20, "date"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 200, "bookname"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "requeststate"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.VarChar, 100, "author"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 100, "subject"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 100, "section"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.Int, 10, "Qty"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 20, "Times"));
                cmd.Parameters["@d1"].Value = stdno.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = classes.Text.Trim();
                cmd.Parameters["@d4"].Value = term.Text.Trim();
                //cmd.Parameters["@d5"].Value = stream.Text.Trim();
                cmd.Parameters["@d6"].Value = level.Text.Trim();
                cmd.Parameters["@d7"].Value = requestdate.Text.Trim();
                cmd.Parameters["@d8"].Value = selectbook.Text.Trim();
                cmd.Parameters["@d9"].Value = "Not Approved Yet";
                cmd.Parameters["@d10"].Value = author12.Text.Trim();
                cmd.Parameters["@d11"].Value = subject12.Text.Trim();
                cmd.Parameters["@d12"].Value = section12.Text.Trim();
                cmd.Parameters["@d13"].Value = requestids;
                cmd.Parameters["@d14"].Value = noofcopies.Text;
                cmd.Parameters["@d15"].Value =time.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Book request submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                this.Hide();
                frmLibraryRequests frm = new frmLibraryRequests();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



