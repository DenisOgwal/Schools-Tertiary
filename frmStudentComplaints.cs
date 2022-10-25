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
    public partial class frmStudentComplaints : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmStudentComplaints()
        {
            InitializeComponent();
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
            label8.Text = "COMP-" + GetUniqueKey(5);
        }
        private void frmStudentComplaints_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmStudentAcess frm = new frmStudentAcess();
            frm.Show();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            auto();
            if (stdname.Text == "")
            {
                MessageBox.Show("Please enter student's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stdname.Focus();
                return;
            }
            if (times.Text == "")
            {
                MessageBox.Show("Please select the number of times you have complained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                times.Focus();
                return;
            }
            if (compsubject.Text == "")
            {
                MessageBox.Show("Please input your complaint subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                compsubject.Focus();
                return;
            }
            if (staff.Text == "")
            {
                MessageBox.Show("Please select staff who is concerned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                staff.Focus();
                return;
            }
            if (department.Text == "")
            {
                MessageBox.Show("Please select Department ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                department.Focus();
                return;
            }
            if (description.Text == "")
            {
                MessageBox.Show("Please describe for us the complaint", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                description.Focus();
                return;
            }
            
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Complaints(complaintsid,studentname,date,times,compsubject,staff,department,description) VALUES (@d8,@d1,@d2,@d3,@d4,@d5,@d6,@d7)";

                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                // Add Parameters to Command Parameters collection
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "studentname"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "date"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "times"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "compsubject"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "staff"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "department"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 250, "description"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.VarChar, 10, "complaintsid"));
                


                cmd.Parameters["@d1"].Value = stdname.Text.Trim();
                cmd.Parameters["@d2"].Value = complaintdate.Text.Trim();
                cmd.Parameters["@d3"].Value = times.Text.Trim();
                cmd.Parameters["@d4"].Value = compsubject.Text.Trim();
                cmd.Parameters["@d5"].Value = staff.Text.Trim();
                cmd.Parameters["@d6"].Value = department.Text.Trim();
                cmd.Parameters["@d7"].Value = description.Text.Trim();
                cmd.Parameters["@d8"].Value = label8.Text.Trim();
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "complaint submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmStudentComplaints_Load(object sender, EventArgs e)
        {
           complaintdate.Enabled = false;
            times.Enabled = false;
            compsubject.Enabled = false;
            staff.Enabled = false;
            department.Enabled = false;
            description.Enabled = false;   
            stdname.Focus();
        }

        private void stdname_TextChanged(object sender, EventArgs e)
        {
           complaintdate.Text = System.DateTime.Today.ToString();
            complaintdate.Enabled = true;
            
        }

        private void complaintdate_ValueChanged(object sender, EventArgs e)
        {
            times.Enabled = true;
        }

        private void times_SelectedIndexChanged(object sender, EventArgs e)
        {
            compsubject.Clear();
            compsubject.Text = "";
            compsubject.Enabled = true;
        }

        private void staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            department.Items.Clear();
            department.Text = "";
            department.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Department) from Employee where StaffName like '%"+staff.Text+"%'";
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
        }

        private void compsubject_TextChanged(object sender, EventArgs e)
        {
            staff.Items.Clear();
            staff.Text = "";
            staff.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(StaffName) from Employee";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    staff.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            description.Clear();
            description.Text = "";
            description.Enabled = true;
        }
    }
}
