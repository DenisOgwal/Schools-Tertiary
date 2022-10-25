using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmStudentLibrary : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string requeststate = "Not approved Yet";
        public frmStudentLibrary()
        {
            InitializeComponent();
        }

        private void frmStudentLibrary_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmStudentAcess frm = new frmStudentAcess();
            frm.Show();*/
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
        private void auto()
        {
            label20.Text = "REQ-" + GetUniqueKey(5);
        }

        public DataView LoadList()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();

            dynamic SelectQry = "SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publisher)[Publisher],RTRIM(booksection)[Section] FROM Library where author like '%" + author.Text + "%' and title like '%" + title.Text + "%' ";
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

        private void button1_Click(object sender, EventArgs e)
        {
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
            if (stream.Text == "")
            {
                MessageBox.Show("Please select stream", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stream.Focus();
                return;
            }

            if (level.Text == "")
            {
                MessageBox.Show("Please select level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                level.Focus();
                return;
            }
            if (author.Text == "")
            {
                MessageBox.Show("Please input author", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                author.Focus();
                return;
            }
            if (title.Text == "")
            {
                MessageBox.Show("Please input title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                title.Focus();
                return;
            }

            try
            {
                dataGridView1.DataSource = LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(title) from Library where author = '" + author.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    selectbook.Items.Clear();
                    selectbook.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataView LoadList2()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();

            dynamic SelectQry = "SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publisher)[Publisher],RTRIM(booksection)[Section] FROM Library where author like '%" + author2.Text + "%' and subject like '%" + subject.Text + "%' ";
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

        private void button2_Click(object sender, EventArgs e)
        {
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
            if (stream.Text == "")
            {
                MessageBox.Show("Please select stream", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stream.Focus();
                return;
            }

            if (level.Text == "")
            {
                MessageBox.Show("Please select level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                level.Focus();
                return;
            }
            if (author2.Text == "")
            {
                MessageBox.Show("Please input author", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                author2.Focus();
                return;
            }
            if (subject.Text == "")
            {
                MessageBox.Show("Please input subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                subject.Focus();
                return;
            }
            try
            {
                dataGridView1.DataSource = LoadList2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(title) from library where author = '" + author2.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    selectbook.Items.Clear();
                    selectbook.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataView LoadList3()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();

            dynamic SelectQry = "SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],Rtrim(publisher)[Publisher],RTRIM(booksection)[Section] FROM Library where author like '%" + author3.Text + "%' and publicationdate like '%" + publicationdate.Text + "%' ";
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


        private void button3_Click(object sender, EventArgs e)
        {
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
            if (stream.Text == "")
            {
                MessageBox.Show("Please select stream", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stream.Focus();
                return;
            }

            if (level.Text == "")
            {
                MessageBox.Show("Please select level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                level.Focus();
                return;
            }
            if (author3.Text == "")
            {
                MessageBox.Show("Please input author", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                author3.Focus();
                return;
            }
            if (publicationdate.Text == "")
            {
                MessageBox.Show("Please input publication date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                publicationdate.Focus();
                return;
            }
            try
            {
                dataGridView1.DataSource = LoadList3();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stdno_TextChanged(object sender, EventArgs e)
        {
            year.Items.Clear();
            year.Text = "";
            year.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Session) from Student where ScholarNo= '" + stdno.Text + "'";
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
                string ct = "select distinct RTRIM(course) from Student where session = '" + year.Text + "' and ScholarNo = '" + stdno.Text + "' ";
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
                string ct = "select distinct RTRIM(Semester) from Batch where Session = '" + year.Text + "'";
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
            stream.Items.Clear();
            stream.Text = "";
            stream.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Section) from Student where ScholarNo = '" + stdno.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    stream.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stream_SelectedIndexChanged(object sender, EventArgs e)
        {
            level.Items.Clear();
            level.Text = "";
            level.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Branch) from Student where Course = '" + classes.Text + "'";
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

        int authorrequest = 0;
        int authortotal = 0;
        private void button4_Click(object sender, EventArgs e)
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
            if (stream.Text == "")
            {
                MessageBox.Show("Please select stream", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stream.Focus();
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
                String inquery3 = "SELECT COUNT (*) FROM Librarybookrequest WHERE author = '" + author12.Text + "' and bookname='" + selectbook.Text + "' and requeststate ='Approved'";
                cmd = new SqlCommand(inquery3, con);
                authorrequest = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();
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
                string cb = "insert into Librarybookrequest(requestId,studentno,year,class,term,stream,level,date,bookname,requeststate,author,subject,section) VALUES (@d13,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                // Add Parameters to Command Parameters collection
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 15, "requeatId"));
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "studentno"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "class"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "term"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "stream"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "level"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 30, "date"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "bookname"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "requeststate"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.VarChar, 30, "author"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "subject"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 30, "section"));
                cmd.Parameters["@d1"].Value = stdno.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = classes.Text.Trim();
                cmd.Parameters["@d4"].Value = term.Text.Trim();
                cmd.Parameters["@d5"].Value = stream.Text.Trim();
                cmd.Parameters["@d6"].Value = level.Text.Trim();
                cmd.Parameters["@d7"].Value = requestdate.Text.Trim();
                cmd.Parameters["@d8"].Value = selectbook.Text.Trim();
                cmd.Parameters["@d9"].Value = requeststate.Trim();
                cmd.Parameters["@d10"].Value = author12.Text.Trim();
                cmd.Parameters["@d11"].Value = subject12.Text.Trim();
                cmd.Parameters["@d12"].Value = section12.Text.Trim();
                cmd.Parameters["@d13"].Value = label20.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Student request submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                approval();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void approval()
        {
            try
            {
                label18.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT requeststate FROM Librarybookrequest WHERE requestId= '" + requestid.Text + "' and studentno='" + stdno.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    label18.Text = rdr.GetString(0);
                }
                if ((con.State == ConnectionState.Open))
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                label18.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT RTRIM(requeststate) FROM Librarybookrequest WHERE requestId = '"+requestid.Text+"' and studentno='" +stdno.Text+"'";
                cmd = new SqlCommand(inquery3, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    label18.Text = rdr.GetString(0);
                }
                if ((con.State == ConnectionState.Open))
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            requestid.Items.Clear();
            requestid.Text = "";
            requestid.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(requestId) from Librarybookrequest where studentno = '" + stdno.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    requestid.Items.Add(rdr[0]);
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

        private void level_SelectedIndexChanged(object sender, EventArgs e)
        {
            requestid.Items.Clear();
            requestid.Text = "";
            requestid.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(requestId) from Librarybookrequest where studentno = '" + stdno.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    requestid.Items.Add(rdr[0]);
                    label20.Text = rdr[0].ToString();
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmStudentLibrary_Load(object sender, EventArgs e)
        {

        }

        private void requestid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
