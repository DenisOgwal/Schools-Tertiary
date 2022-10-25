using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmOtherFeesDetails : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmOtherFeesDetails()
        {
            InitializeComponent();
        }

        private void AutocompleCourse()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(coursename) from course ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Course.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void auto()
        {
            FeeID.Text = "F-" + GetUniqueKey(5);
        }
        private void FeesDetails_Load(object sender, EventArgs e)
        {
            AutocompleCourse();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label13.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { Delete.Enabled = true; } else { Delete.Enabled = false; }
                    if (pricess == "Yes") { Update_record.Enabled = true; } else { Update_record.Enabled = false; }
                }
                if (label13.Text == "ADMIN")
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Course.Text == "")
                {
                    MessageBox.Show("Please select class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Course.Focus();
                    return;
                }
                if (year.Text == "")
                {
                    MessageBox.Show("Please enter year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    year.Focus();
                    return;
                }
                if (Branch.Text == "")
                {
                    MessageBox.Show("Please select Level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Branch.Focus();
                    return;
                }
                if (Semester.Text == "")
                {
                    MessageBox.Show("Please select Term", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Semester.Focus();
                    return;
                }
                if (TutionFees.Text == "")
                {
                    MessageBox.Show("Please enter School fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TutionFees.Focus();
                    return;
                }

                if (otherfeesname.Text == "")
                {
                    MessageBox.Show("Please Select Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    otherfeesname.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Semester,Course,Branch,Year from OtherFeesDetails where Semester= '" + Semester.Text + "' and Course = '" + Course.Text + "' and branch= '" + Branch.Text + "' and Year='" + year.Text + "' and RealFeesName='" + otherfeesname.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                auto();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "select FeeID from OtherFeesDetails where FeeID=@find";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 20, "FeeID"));
                cmd.Parameters["@find"].Value = FeeID.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Fee ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FeeID.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into OtherFeesDetails(FeeID,Course,Branch,Semester,RealFees,RealFeesName,Year) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeeID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "Course"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Branch"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Semester"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "RealFees"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 30, "RealFeesName"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Year"));

                cmd.Parameters["@d1"].Value = FeeID.Text.Trim();
                cmd.Parameters["@d2"].Value = Course.Text.Trim();
                cmd.Parameters["@d3"].Value = Branch.Text.Trim();
                cmd.Parameters["@d4"].Value = Semester.Text.Trim();
                cmd.Parameters["@d5"].Value = (TutionFees.Text);
                cmd.Parameters["@d7"].Value = Convert.ToInt32(year.Text);
                cmd.Parameters["@d6"].Value = (otherfeesname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Fees Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            Branch.Items.Clear();
            Semester.Items.Clear();
            Branch.Text = "";
            Semester.Text = "";
            Branch.Enabled = true;
            Semester.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(branchname) from course where coursename = '" + Course.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Branch.Items.Add(rdr[0]);
                }
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "select distinct RTRIM(SemesterName) from Semester where course = '" + Course.Text + "' order by 1";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Semester.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TutionFees_KeyPress(object sender, KeyPressEventArgs e)
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

        private void UDFees_KeyPress(object sender, KeyPressEventArgs e)
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

        private void LibraryFees_KeyPress(object sender, KeyPressEventArgs e)
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

        private void USFees_KeyPress(object sender, KeyPressEventArgs e)
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

        private void OtherFees_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CautionMoney_KeyPress(object sender, KeyPressEventArgs e)
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


        private void FeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delete.Enabled = true;
            Update_record.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM OtherFeesDetails WHERE FeeID = '" + FeeID.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Course.Text = ((String)rdr["Course"]);
                    Branch.Text = ((String)rdr["Branch"]).Trim();
                    Semester.Text = (rdr.GetString(5).Trim());
                    TutionFees.Text = (rdr.GetString(6).Trim());
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            FeeID.Text = "";
            Course.Text = "";
            Branch.Text = "";
            Semester.Text = "";
            TutionFees.Text = "";
            year.Text = "";
            Branch.Enabled = false;
            Semester.Enabled = false;
            Delete.Enabled = false;
            Update_record.Enabled = false;
            btnSave.Enabled = true;
            otherfeesname.Text = "";
            Course.Focus();
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (FeeID.Text == "")
                {
                    MessageBox.Show("Please select Fee ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Course.Focus();
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update OtherFeesDetails set Course=@d2,Year=@d7,Branch=@d3,Semester=@d4,RealFees=@d5,RealFeesName=@d6 where FeeID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeeID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 20, "Course"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Branch"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Semester"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "RealFees"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 30, "RealFeesName"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Year"));

                cmd.Parameters["@d1"].Value = FeeID.Text.Trim();
                cmd.Parameters["@d2"].Value = Course.Text.Trim();
                cmd.Parameters["@d3"].Value = Branch.Text.Trim();
                cmd.Parameters["@d4"].Value = Semester.Text.Trim();
                cmd.Parameters["@d5"].Value = (TutionFees.Text);
                cmd.Parameters["@d7"].Value = Convert.ToInt32(year.Text);
                cmd.Parameters["@d6"].Value = (otherfeesname.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Fees Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Update_record.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select FeeID from OtherFeePayment where FeeID=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "FeeID"));
                cmd.Parameters["@find"].Value = FeeID.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from OtherFeesDetails where FeeID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "FeeID"));
                cmd.Parameters["@DELETE1"].Value = FeeID.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void GetDetails_Click(object sender, EventArgs e)
        {
            frmOtherFeesDetailsRecord frm = new frmOtherFeesDetailsRecord();
            this.Hide();
            Reset();
            frm.label1.Text = label13.Text;
            frm.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmOtherFeesDetailsRecord frm = new frmOtherFeesDetailsRecord();
            this.Hide();
            Reset();
            frm.label1.Text = label13.Text;
            frm.ShowDialog();
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

        private void year_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}

