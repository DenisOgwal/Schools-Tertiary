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
    public partial class frmStudentFeesDetails : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmStudentFeesDetails()
        {
            InitializeComponent();
        }

        private void frmStudentFeesDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmStudentAcess frm = new frmStudentAcess();
            frm.Show();*/
        }

        public DataView LoadList()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
           
            dynamic SelectQry = "select TutionFees[School Fees],LibraryFees[Library Fees],UniversityStudentWelfareFees[Welfare Fees],registration[Registration Fees],TotalFees1[Total Fees],TotalPaid[Total Paid],DateOfPayment[Payment Date],Fine[Fine],DueFees[Balance] from FeePayment where ScholarNo = '" + stdno.Text + "' and FDCourse = '" + classes.Text + "' and Semester= '" + term.Text + "' and FDBranch='" + level.Text + "'";

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
            try
            {
                dataGridView1.DataSource = LoadList(); 
               
              
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
                string ct = "select distinct RTRIM(Section) from Student where  ScholarNo = '" + stdno.Text + "'";
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
                string ct = "select distinct RTRIM(Branch) from Student where  Course= '" + classes.Text + "' and ScholarNo = '" + stdno.Text + "'";
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

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            classes.Items.Clear();
            classes.Text = "";
            classes.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(course) from Student where Session = '" + year.Text + "' and ScholarNo = '" + stdno.Text + "'";
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
    }
}
