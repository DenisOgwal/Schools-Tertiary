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
   
    public partial class frmStudentResults : Form
    {
         ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmStudentResults()
        {
            InitializeComponent();
        }

        private void frmStudentResults_Load(object sender, EventArgs e)
        {
            complaintpanel.Hide();
        }

        private void Viewcomplaits_Click(object sender, EventArgs e)
        {
            complaintpanel.Show();
        }

        private void frmStudentResults_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmStudentAcess frm = new frmStudentAcess();
            frm.Show();*/
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            classes.Items.Clear();
            classes.Text = "";
            classes.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(course) from Student where session = '" + year.Text + "' and ScholarNo = '" + stdno.Text + "'";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            year.Items.Clear();
            year.Text = "";
            year.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Session) from Student where ScholarNo = '" + stdno.Text + "'";
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

        private void classes_SelectedIndexChanged(object sender, EventArgs e)
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

        private void term_SelectedIndexChanged(object sender, EventArgs e)
        {
            stream.Items.Clear();
            stream.Text = "";
            stream.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Section) from Student where Course = '" + classes.Text + "'";
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
            subject.Items.Clear();
            subject.Text = "";
            subject.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                if (level.Text == "O Level")
                {
                    string ct = "select distinct RTRIM(subjectname) from Results where level = '" + level.Text + "'";
                    cmd = new SqlCommand(ct);
                }
                if (level.Text == "A Level")
                {
                    string ct = "select distinct RTRIM(subjectname) from Leveladvanced where level = '" + level.Text + "'";
                    cmd = new SqlCommand(ct);
                }
                cmd.Connection = con;
                
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    subject.Items.Add(rdr[0]);
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
          
        }

        private void viewresults_Click(object sender, EventArgs e)
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
            try
            {
                if (level.Text == "O Level")
                {

                    dataGridView1.DataSource = Loadrequestlist();
                }
                if (level.Text == "A Level")
                {

                    dataGridView1.DataSource = Loadrequestlist2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public DataView Loadrequestlist()
        {
           
                con = new SqlConnection(cs.DBConn);
                con.Open();
                
                dynamic SelectQry = "SELECT RTRIM(subjectcode)[Subject Code],RTRIM(subjectname)[Subject Name],Rtrim(begginingofterm)[Begining Of Term],RTRIM(midterm)[Mid Term],RTRIM(endofterm)[End of Term],Rtrim(Average)[Average],RTRIM(grade)[Grade] from Results where studentno = '" + stdno.Text + "' and class = '" + classes.Text + "' and stream= '" + stream.Text + "' and term= '" + term.Text + "' and year= '" + year.Text + "' and level='" + level.Text + "'";
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
        public DataView Loadrequestlist2()
        {

            con = new SqlConnection(cs.DBConn);
            con.Open();

            dynamic SelectQry = "SELECT RTRIM(subjectcode)[Subject Code],RTRIM(subjectname)[Subject Name],RTRIM(paper)[Paper],RTRIM(ExamName)[Exam Name],RTRIM(marks)[Marks] from Leveladvanced where studentno = '" + stdno.Text + "' and class = '" + classes.Text + "' and stream= '" + stream.Text + "' and term= '" + term.Text + "' and year= '" + year.Text + "' and level='" + level.Text + "' ";
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

        private void level_SelectedIndexChanged(object sender, EventArgs e)
        {
            term.Items.Clear();
            term.Text = "";
            term.Enabled = true;
            try
            {
                if (level.Text == "O Level")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select distinct RTRIM(term) from Results where year = '" + year.Text + "' and studentno = '" + stdno.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        term.Items.Add(rdr[0]);
                    }
                    con.Close();

                }

                if (level.Text == "A Level")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select distinct RTRIM(term) from Leveladvanced where year = '" + year.Text + "' and studentno = '" + stdno.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        term.Items.Add(rdr[0]);
                    }
                    con.Close();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void submitcomplaits_Click(object sender, EventArgs e)
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
            if (subject.Text == "")
            {
                MessageBox.Show("Please select subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                subject.Focus();
                return;
            }
            if (description.Text == "")
            {
                MessageBox.Show("Please describe the complaint", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                description.Focus();
                return;
            }
        
        try{
            con = new SqlConnection(cs.DBConn);
            con.Open();
         string cd = "insert Resultscomplaints(studentno,year,class,term,stream,level,date,subjectname,description) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";

                cmd = new SqlCommand(cd);

                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "studentno"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "class"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "term"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "stream"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 30, "level"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 30, "date"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "subjectname"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 250, "description"));

                cmd.Parameters["@d1"].Value = stdno.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = classes.Text.Trim();
                cmd.Parameters["@d4"].Value = term.Text.Trim();
                cmd.Parameters["@d5"].Value = stream.Text.Trim();
                cmd.Parameters["@d6"].Value = level.Text.Trim();
                cmd.Parameters["@d7"].Value = complaintdate.Text.Trim();
                cmd.Parameters["@d8"].Value = subject.Text.Trim();
                cmd.Parameters["@d9"].Value = description.Text.Trim();
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Student subject complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
                con.Close();
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
