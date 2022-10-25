using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmLibraryRegistration : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmLibraryRegistration()
        {
            InitializeComponent();
        }

        private void AutocompleCourse()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Session) from Batch ";
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


        private void FeesDetails_Load(object sender, EventArgs e)
        {
            AutocompleCourse();
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
                string ct = "select distinct RTRIM(Category) from BookCategory";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    category.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label23.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { Delete.Enabled = true; } else { Delete.Enabled = false; }
                    if (pricess == "Yes") { Update_record.Enabled = true; } else { Update_record.Enabled = false; }
                }
                if (label23.Text == "ADMIN")
                {
                    Delete.Enabled = true;
                    Update_record.Enabled = true;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string cb = "insert into Library(author,title,subject,publicationdate,department,category,bookcost,Noofcopies,dateregistered,booksection,publisher,suppliers,StaffName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
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
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "StaffName"));
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
                cmd.Parameters["@d13"].Value = label23.Text.Trim();
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

        private void button2_Click(object sender, EventArgs e)
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
                if (rdr.Read())
                {
                    author.Text = rdr.GetString(0);
                    title.Text = rdr.GetString(1);
                    subject.Text = rdr.GetString(2);
                    publicationdate.Text = rdr.GetString(3);
                    department.Text = rdr.GetString(4);
                    category.Text = rdr.GetString(5);
                    cost.Text = rdr.GetInt32(6).ToString();
                    isbn.Text = rdr.GetInt32(7).ToString();
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

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            term.Items.Clear();
            term.Text = "";
            term.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Semester) from batch where  session='" + year.Text + "'";
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

        private void employeeid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

