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
namespace College_Management_System
{
    public partial class frmLibrary : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string request1 = "Approved";
        string request2 = "Request Rejected";
        string request3 = "Returned";
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

        public frmLibrary()
        {
            InitializeComponent();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT Sum (Noofcopies) FROM Library";
                cmd = new SqlCommand(inquery3, con);
                label50.Text = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmLibrary_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu form2 = new frmMainMenu();
            form2.UserType.Text = label14.Text;
            form2.User.Text = label15.Text;
            form2.Show();*/
        }
        private void Reset()
        {
            author.Text = "";
            title.Text = "";
            subject.Text = "";
            publicationdate.Text = "";
            department.Text = "";
            category.Text = "";
            cost.Text = "";
            publisher.Text = "";
            isbn.Text = "";
            booksection.Text = "";
            supplier.Text = "";
            registerdate.Text = System.DateTime.Today.ToString();
            btnSave.Enabled = true;
            Delete.Enabled = true;
            Update_record.Enabled = false;

        }
        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (author.Text == "")
            {
                MessageBox.Show("Please enter author", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                author.Focus();
                return;
            }
            if (title.Text == "")
            {
                MessageBox.Show("Please enter title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                title.Focus();
                return;
            }
            if (subject.Text == "")
            {
                MessageBox.Show("Please enter subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                subject.Focus();
                return;
            }
            if (category.Text == "")
            {
                MessageBox.Show("Please enter category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                category.Focus();
                return;
            }
            if (department.Text == "")
            {
                MessageBox.Show("Please enter department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                department.Focus();
                return;
            }
            if (publicationdate.Text == "")
            {
                MessageBox.Show("Please enter publication date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                publicationdate.Focus();
                return;
            }
            if (cost.Text == "")
            {
                MessageBox.Show("Please enter the book cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cost.Focus();
                return;
            }
            if (publisher.Text == "")
            {
                MessageBox.Show("Please enter booksection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                booksection.Focus();
                return;
            }
            if (supplier.Text == "")
            {
                MessageBox.Show("Please enter supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                supplier.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Library(author,title,subject,publicationdate,department,category,bookcost,Noofcopies,dateregistered,booksection,publisher,suppliers) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                // Add Parameters to Command Parameters collection
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 100, "author"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "title"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "subject"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "publicationdate"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "department"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 100, "category"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "bookcost"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 20, "Noofcopies"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "dateregistered"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 40, "booksection"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "publisher"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 50, "suppliers"));
                cmd.Parameters["@d1"].Value = author.Text.Trim();
                cmd.Parameters["@d2"].Value = title.Text.Trim();
                cmd.Parameters["@d3"].Value = subject.Text.Trim();
                cmd.Parameters["@d4"].Value = publicationdate.Text.Trim();
                cmd.Parameters["@d5"].Value = department.Text.Trim();
                cmd.Parameters["@d6"].Value = category.Text.Trim();
                cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Text);
                cmd.Parameters["@d8"].Value = isbn.Text.Trim();
                cmd.Parameters["@d9"].Value = registerdate.Text.Trim();
                cmd.Parameters["@d10"].Value = booksection.Text.Trim();
                cmd.Parameters["@d11"].Value = publisher.Text.Trim();
                cmd.Parameters["@d12"].Value = supplier.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Book registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataView LoadList()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            dynamic SelectQry = "SELECT RTRIM(author)[Author],RTRIM(title)[Title],Rtrim(subject)[Subject],RTRIM(bookcost)[Cost],Rtrim(publisher)[Publisher],RTRIM(suppliers)[Supplier] FROM Library ";
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

        private void button6_Click(object sender, EventArgs e)
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
                String inquery3 = "SELECT COUNT (*) FROM Librarybookrequest WHERE author = '" + author1.Text + "' and requeststate ='Approved'";
                cmd = new SqlCommand(inquery3, con);
                label26.Text = cmd.ExecuteScalar().ToString();
                authorrequest = int.Parse(label26.Text);
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



        private void button8_Click(object sender, EventArgs e)
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
                String inquery3 = "SELECT COUNT (*) FROM Librarybookrequest WHERE subject ='" + subject1.Text + "' and requeststate ='Approved' ";
                cmd = new SqlCommand(inquery3, con);
                label37.Text = cmd.ExecuteScalar().ToString();
                subjectrequest = int.Parse(label37.Text);
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

        private void button7_Click(object sender, EventArgs e)
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
                String inquery3 = "SELECT COUNT (*) FROM Librarybookrequest WHERE bookname = '" + title1.Text + "' and requeststate ='Approved' ";
                cmd = new SqlCommand(inquery3, con);
                label30.Text = cmd.ExecuteScalar().ToString();
                titlerequest = int.Parse(label30.Text);
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

        private void button9_Click(object sender, EventArgs e)
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
                String inquery3 = "SELECT COUNT (*) FROM Librarybookrequest WHERE section ='" + section1.Text + "' and requeststate ='Approved'";
                cmd = new SqlCommand(inquery3, con);
                label44.Text = cmd.ExecuteScalar().ToString();
                sectionrequest = int.Parse(label44.Text);
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

        public DataView Loadrequestlist()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();

            dynamic SelectQry = "SELECT RTRIM(requestId)[Request No.],RTRIM(studentno)[Scholar No.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Branch],Rtrim(level)[Section],RTRIM(date)[Request Date],Rtrim(bookname)[Title],RTRIM(requeststate)[Request Status] FROM Librarybookrequest ORDER BY ID DESC ";
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
        private void button4_Click(object sender, EventArgs e)
        {
            if (requestnumber.Text == "")
            {
                MessageBox.Show("Please select request number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                requestnumber.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "update Librarybookrequest set requeststate= '" + request1 + "' where  requestId=@d1";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.VarChar, 10, "requestnumber"));
                cmd.Prepare();
                cmd.Parameters["@d1"].Value = requestnumber.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Approved", "Student Request", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (requestnumber.Text == "")
            {
                MessageBox.Show("Please select request number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                requestnumber.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "update Librarybookrequest set requeststate= '" + request2 + "' where  requestId=@d1";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.VarChar, 10, "requestnumber"));
                cmd.Prepare();
                cmd.Parameters["@d1"].Value = requestnumber.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Rejected", "Student Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (requestnumber.Text == "")
            {
                MessageBox.Show("Please select request number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                requestnumber.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cd = "update Librarybookrequest set requeststate= '" + request3 + "' where  requestId=@d1 and requeststate='Approved'";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.VarChar, 10, "requestnumber"));
                cmd.Prepare();
                cmd.Parameters["@d1"].Value = requestnumber.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated Return", "Pupil returned book", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The book request was not approved");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete the records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void delete_records()
        {
            try
            {
                if (author.Text == "")
                {
                    MessageBox.Show("Please enter author", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    author.Focus();
                    return;
                }
                if (title.Text == "")
                {
                    MessageBox.Show("Please enter title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    title.Focus();
                    return;
                }
                if (subject.Text == "")
                {
                    MessageBox.Show("Please enter subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    subject.Focus();
                    return;
                }

                if (publicationdate.Text == "")
                {
                    MessageBox.Show("Please enter publication date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    publicationdate.Focus();
                    return;
                }

                if (publisher.Text == "")
                {
                    MessageBox.Show("Please enter the publisher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    publisher.Focus();
                    return;
                }
                if (booksection.Text == "")
                {
                    MessageBox.Show("Please enter booksection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    booksection.Focus();
                    return;
                }

                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from Library where author='" + author.Text + "' and title='" + title.Text + "' and subject='" + subject.Text + "' and publicationdate='" + publicationdate.Text + "'and publisher='" + publisher.Text + "' and booksection='" + booksection.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    Reset();
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Library set author=@d1,title=@d2,subject=@d3,publicationdate=@d4,department=@d5,category=@d6,bookcost=@d7,Noofcopies=@d8,dateregistered=@d9,publisher=@d11,booksection=@d10,suppliers=@d12 where author=@d1 and title=@d2 ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                // Add Parameters to Command Parameters collection
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 100, "author"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 100, "title"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "subject"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "publicationdate"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "department"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 100, "category"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "bookcost"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "Noofcopies"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "dateregistered"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 40, "booksection"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "publisher"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 50, "supplier"));
                // Prepare command for repeated execution
                cmd.Prepare();
                // Data to be inserted
                cmd.Parameters["@d1"].Value = author.Text;
                cmd.Parameters["@d2"].Value = title.Text;
                cmd.Parameters["@d3"].Value = subject.Text;
                cmd.Parameters["@d4"].Value = publicationdate.Text;
                cmd.Parameters["@d5"].Value = department.Text;
                cmd.Parameters["@d6"].Value = category.Text;
                cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Text);
                cmd.Parameters["@d8"].Value = isbn.Text;
                cmd.Parameters["@d9"].Value = registerdate.Text;
                cmd.Parameters["@d10"].Value = booksection.Text;
                cmd.Parameters["@d11"].Value = publisher.Text;
                cmd.Parameters["@d12"].Value = supplier.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Update_record.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLibrary_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadList();
            dataGridView2.DataSource = Loadrequestlist();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(AcademicDepartments) from AcademicUnits";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    department.Items.Add(rdr[0]);
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
                string ct = "select distinct RTRIM(Sectionname) from LibrarySections";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    booksection.Items.Add(rdr[0]);
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
                string ct = "select distinct RTRIM(requestId) from Librarybookrequest";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    requestnumber.Items.Add(rdr[0]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadList();
            try
            {
                author1.Items.Clear();
                author1.Text = "";
                label26.Text = "";
                label28.Text = "";
                label24.Text = "";
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
                subject1.Items.Clear();
                subject1.Text = "";
                label37.Text = "";
                label35.Text = "";
                label51.Text = "";
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
                title1.Items.Clear();
                title1.Text = "";
                label30.Text = "";
                label21.Text = "";
                label32.Text = "";
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
                section1.Items.Clear();
                section1.Text = "";
                label44.Text = "";
                label42.Text = "";
                label46.Text = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Loadrequestlist();
            try
            {
                requestnumber.Items.Clear();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(requestId) from Librarybookrequest";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    requestnumber.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                label50.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT SUM (Noofcopies) FROM Library";
                cmd = new SqlCommand(inquery3, con);
                label50.Text = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void isbn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            dataGridView1.DataSource = LoadList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (author.Text == "")
            {
                MessageBox.Show("Please input author names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                author.Focus();
                return;
            }
            if (title.Text == "")
            {
                MessageBox.Show("Please input book title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                title.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                 string libraryselect = "SELECT * FROM Library where author like '%" + author.Text + "%' and title like '%" + title.Text + "%' ";
                 cmd = new SqlCommand(libraryselect);
                 cmd.Connection = con;
                 rdr = cmd.ExecuteReader();
                 if(rdr.Read())
                 {
                    author.Text=rdr.GetString(0);
                    title.Text=rdr.GetString(1);
                    subject.Text=rdr.GetString(2);
                    publicationdate.Text=rdr.GetString(3);
                    department.Text=rdr.GetString(4);
                    category.Text = rdr.GetString(5);
                    cost.Text = rdr.GetInt32(6).ToString();
                    isbn.Text=rdr.GetInt32(7).ToString();
                    publisher.Text = rdr.GetString(10);
                    booksection.Text = rdr.GetString(9);
                    supplier.Text = rdr.GetString(10);
                    Delete.Enabled = true;
                    Update_record.Enabled = true;
                  
                 }
                 if (rdr != null)
                 {
                     rdr.Close();
                 }
                 con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

