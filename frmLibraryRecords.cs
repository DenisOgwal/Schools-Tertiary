using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace College_Management_System
{
    public partial class frmLibraryRecords : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
       // SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        int authoravailable = 0;
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
        int titlerequest = 0;

        public frmLibraryRecords()
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
       
        public DataView LoadList()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            dynamic SelectQry = "SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publicationdate)[Publication Date],Rtrim(category)[Category],Rtrim(department)[Department],Rtrim(booksection)[Book Section],Rtrim(Noofcopies)[No. of Copies],RTRIM(bookcost)[Cost],Rtrim(publisher)[Publisher],RTRIM(suppliers)[Supplier],Rtrim(dateregistered)[Registration Date] FROM Library ";
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
        private void frmBusFeePaymentRecord_Load(object sender, EventArgs e)
        {    
            dataGridView1.DataSource = LoadList();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(author) from Library";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    author1.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(subject) from Library";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    subject1.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(title) from Library";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    title1.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(booksection) from Library";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    section1.Items.Add(rdr[0]);
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
                cmd = new SqlCommand("SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publicationdate)[Publication Date],Rtrim(category)[Category],Rtrim(department)[Department],Rtrim(booksection)[Book Section],Rtrim(Noofcopies)[No. of Copies],RTRIM(bookcost)[Cost],Rtrim(publisher)[Publisher],RTRIM(suppliers)[Supplier],Rtrim(dateregistered)[Registration Date] FROM Library where  author like '" + searchtext.Text + "%' OR title like '" + searchtext.Text + "%' OR Subject like '" + searchtext.Text + "%' OR department like '" + searchtext.Text + "%' OR category like '" + searchtext.Text + "%' OR booksection like '" + searchtext.Text + "%' OR publisher like '" + searchtext.Text + "%' OR suppliers like '" + searchtext.Text + "%' order by author ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Library");
                dataGridView1.DataSource = myDataSet.Tables["Library"].DefaultView;
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
            author1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (author1.Text == "")
            {
                MessageBox.Show("Please select author", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                author1.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Qty from Librarybookrequest where author = '" + author1.Text + "' and requeststate ='Approved'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    String inquery3 = "SELECT SUM (Qty) FROM Librarybookrequest WHERE author = '" + author1.Text + "' and requeststate ='Approved'";
                    cmd = new SqlCommand(inquery3, con);
                    label26.Text = cmd.ExecuteScalar().ToString();
                    authorrequest = int.Parse(label26.Text);
                    con.Close();
                }
                else
                {
                    label26.Text = "0";
                    authorrequest = int.Parse(label26.Text);
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
                String inquery3 = "SELECT Noofcopies FROM Library WHERE author ='" + author1.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                label28.Text = cmd.ExecuteScalar().ToString();
                authortotal = int.Parse(label28.Text);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            authoravailable = authortotal - authorrequest;
            label24.Text = Convert.ToString(authoravailable);
        }

        private void author1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publicationdate)[Publication Date],Rtrim(category)[Category],Rtrim(department)[Department],Rtrim(booksection)[Book Section],RTRIM(bookcost)[Cost],Rtrim(publisher)[Publisher],RTRIM(suppliers)[Supplier],Rtrim(dateregistered)[Registration Date] FROM Library where  author = '" + author1.Text + "' order by title ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Library");
                dataGridView2.DataSource = myDataSet.Tables["Library"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (subject1.Text == "")
            {
                MessageBox.Show("Please select Subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                subject1.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Qty from Librarybookrequest where subject ='" + subject1.Text + "' and requeststate ='Approved'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    String inquery3 = "SELECT SUM(Qty) FROM Librarybookrequest WHERE subject ='" + subject1.Text + "' and requeststate ='Approved' ";
                    cmd = new SqlCommand(inquery3, con);
                    label37.Text = cmd.ExecuteScalar().ToString();
                    subjectrequest = int.Parse(label37.Text);
                    con.Close();
                }
                else
                {
                    label37.Text = "0";
                    subjectrequest = int.Parse(label37.Text);
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
                String inquery3 = "SELECT Noofcopies FROM Library WHERE subject ='" + subject1.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                label35.Text = cmd.ExecuteScalar().ToString();
                subjecttotal = int.Parse(label35.Text);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            subjectavailable = subjecttotal - subjectrequest;
            label51.Text = Convert.ToString(subjectavailable);
        }

        private void subject1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publicationdate)[Publication Date],Rtrim(category)[Category],Rtrim(department)[Department],Rtrim(booksection)[Book Section],RTRIM(bookcost)[Cost],Rtrim(publisher)[Publisher],RTRIM(suppliers)[Supplier],Rtrim(dateregistered)[Registration Date] FROM Library where  subject = '" + subject1.Text + "' order by title ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Library");
                dataGridView3.DataSource = myDataSet.Tables["Library"].DefaultView;
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
            subject1.Text = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            title1.Text = null;
        }

        private void title1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publicationdate)[Publication Date],Rtrim(category)[Category],Rtrim(department)[Department],Rtrim(booksection)[Book Section],RTRIM(bookcost)[Cost],Rtrim(publisher)[Publisher],RTRIM(suppliers)[Supplier],Rtrim(dateregistered)[Registration Date] FROM Library where  title = '" + title1.Text + "' order by title ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Library");
                dataGridView4.DataSource = myDataSet.Tables["Library"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (title1.Text == "")
            {
                MessageBox.Show("Please select Subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                title1.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Qty from Librarybookrequest where bookname = '" + title1.Text + "' and requeststate ='Approved'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    String inquery3 = "SELECT SUM(Qty) FROM Librarybookrequest WHERE bookname = '" + title1.Text + "' and requeststate ='Approved' ";
                    cmd = new SqlCommand(inquery3, con);
                    label30.Text = cmd.ExecuteScalar().ToString();
                    titlerequest = int.Parse(label30.Text);
                    con.Close();
                }
                else
                {
                    label30.Text = "0";
                    titlerequest = int.Parse(label30.Text);
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
                String inquery3 = "SELECT Noofcopies FROM Library WHERE title ='" + title1.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                label21.Text = cmd.ExecuteScalar().ToString();
                titletotal = int.Parse(label21.Text);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            titleavailable = titletotal - titlerequest;
            label32.Text = Convert.ToString(titleavailable);
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

        private void button10_Click(object sender, EventArgs e)
        {
            if (section1.Text == "")
            {
                MessageBox.Show("Please select Subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                section1.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Qty from Librarybookrequest where section ='" + section1.Text + "' and requeststate ='Approved'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    String inquery3 = "SELECT SUM(Qty) FROM Librarybookrequest WHERE section ='" + section1.Text + "' and requeststate ='Approved'";
                    cmd = new SqlCommand(inquery3, con);
                    label44.Text = cmd.ExecuteScalar().ToString();
                    sectionrequest = int.Parse(label44.Text);
                    con.Close();
                }
                else
                {
                    label44.Text = "0";
                    sectionrequest = int.Parse(label44.Text);
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
                String inquery3 = "SELECT Noofcopies FROM Library WHERE booksection = '" + section1.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                label42.Text = cmd.ExecuteScalar().ToString();
                sectionttotal = int.Parse(label42.Text);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sectionavailable = sectionttotal - sectionrequest;
            label46.Text = Convert.ToString(sectionavailable);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            section1.Text = "";
            dataGridView5.DataSource = null;
        }

        private void section1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publicationdate)[Publication Date],Rtrim(category)[Category],Rtrim(department)[Department],Rtrim(booksection)[Book Section],RTRIM(bookcost)[Cost],Rtrim(publisher)[Publisher],RTRIM(suppliers)[Supplier],Rtrim(dateregistered)[Registration Date] FROM Library where  booksection = '" + section1.Text + "' order by title ASC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Library");
                dataGridView5.DataSource = myDataSet.Tables["Library"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}



