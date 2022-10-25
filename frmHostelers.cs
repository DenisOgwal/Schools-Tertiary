using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmHostelers : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        string FeePaymentID = null;
        SqlCommand cmd = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
       
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
              FeePaymentID = "HF-" + GetUniqueKey(8);
          }
        public frmHostelers()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            ScholarNo.Text = "";
            StudentName.Text = "";
            Course.Text = "";
            Branch.Text = "";
            cmbHostelName.Text = "";
            dtpJoiningDate.Text = DateTime.Today.ToString();
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            ScholarNo.Focus();
        }
        private void Autocomplete()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(Hostelname) from Hostel ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbHostelName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompleScholarNo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(ScholarNo) from student ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ScholarNo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmHostelers_Load(object sender, EventArgs e)
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
                    Year.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Autocomplete();
            AutocompleScholarNo();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label3.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { btnDelete.Enabled = true; } else { btnDelete.Enabled = false; }
                    if (pricess == "Yes") { btnUpdate_record.Enabled = true; } else { btnUpdate_record.Enabled = false; }
                }
                if (label3.Text == "ADMIN")
                {
                    btnDelete.Enabled = true;
                    btnUpdate_record.Enabled = true;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int Hosteltution = 0;
        private void FeesSelect()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                cmd = new SqlCommand("SELECT HostelFees,HostelName FROM Hostel where HostelName='" + cmbHostelName.Text + "'", CN);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Hosteltution = Convert.ToInt32(rdr["HostelFees"]);
                }
                else
                {
                    cmbHostelName.Text = "";
                    MessageBox.Show("Hostel fees not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //FeesSelect();
                if (cmbHostelName.Text == "")
                {
                    MessageBox.Show("Unsuccessful Transaction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbHostelName.Focus();
                    return;
                }
                auto();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Hostelfeepayment(HFeePaymentID,ScholarNo,HostelFees,DateOfPayment,TotalPaid,Fine,DueFees,class,Term,Year,HostelFees1) VALUES (@d1,@d2,@d3,@d4,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "HFeePaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 10, "HostelFees"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "Class"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Term"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Fine"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "DueFees"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "HostelFees1"));
                cmd.Parameters["@d1"].Value = FeePaymentID;
                cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                cmd.Parameters["@d3"].Value = Hosteltution;
                cmd.Parameters["@d4"].Value = dtpJoiningDate.Text;
                cmd.Parameters["@d10"].Value = (Course.Text);
                cmd.Parameters["@d11"].Value = (Term.Text);
                cmd.Parameters["@d12"].Value = (Year.Text);
                cmd.Parameters["@d7"].Value = 0;
                cmd.Parameters["@d8"].Value = 0;
                cmd.Parameters["@d9"].Value = hostelfee.Text;
                cmd.Parameters["@d13"].Value = hostelfee.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ScholarNo.Text == "")
            {
                MessageBox.Show("Please select scholar no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScholarNo.Focus();
                return;
            }
            if (Year.Text == "")
            {
                MessageBox.Show("Please Enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Year.Focus();
                return;
            }
            if (cmbHostelName.Text == "")
            {
                MessageBox.Show("Please select hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbHostelName.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ScholarNo,Year,Class,Term from Hostelers where ScholarNo= '" + ScholarNo.Text + "' and Term='"+Term.Text+"' and Year='"+Year.Text+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScholarNo.Text = "";
                    ScholarNo.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Hostelers(ScholarNo,HostelName,JoiningDate,BedNo,Year,Class,Term,FeePayable,DuePayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,'"+hostelfee.Text+ "','" + hostelfee.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.VarChar, 250, "HostelName"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "JoiningDate"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "BedNo"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "Class"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "Term"));
                cmd.Parameters["@d1"].Value = ScholarNo.Text;
                cmd.Parameters["@d2"].Value = cmbHostelName.Text;
                cmd.Parameters["@d3"].Value = dtpJoiningDate.Text;
                cmd.Parameters["@d4"].Value = bedno.Text;
                cmd.Parameters["@d5"].Value = Year.Text;
                cmd.Parameters["@d6"].Value = Course.Text;
                cmd.Parameters["@d7"].Value = Term.Text;
                cmd.ExecuteNonQuery();
                btnSave.Enabled = false;
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Student_Name,Course,Branch FROM student WHERE ScholarNo = '" + ScholarNo.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    StudentName.Text = rdr.GetString(0).Trim();
                    Course.Text = rdr.GetString(1).Trim();
                    Branch.Text = rdr.GetString(2).Trim();
                    cmbHostelName.Focus();
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

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string cb = "update hostelers set HostelName=@d2,year=@d5,Class=@d6,JoiningDate=@d3 ,BedNo=@d4 where Scholarno=@d1 and Year=@d5 and Class=@d6";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
            cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.VarChar, 250, "HostelName"));
            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "JoiningDate"));
            cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 50, "BedNo"));
            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Year"));
            cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "Class"));
            cmd.Parameters["@d1"].Value = ScholarNo.Text;
            cmd.Parameters["@d2"].Value = cmbHostelName.Text;
            cmd.Parameters["@d3"].Value = dtpJoiningDate.Text;
            cmd.Parameters["@d4"].Value = bedno.Text;
            cmd.Parameters["@d5"].Value = Year.Text;
            cmd.Parameters["@d6"].Value = Course.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully updated", "Hostelers Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnUpdate_record.Enabled = false;
            con.Close();
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHostelersRecord frm = new frmHostelersRecord();
            frm.label5.Text = label3.Text;
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHostelersRecord frm = new frmHostelersRecord();
            frm.label5.Text = label3.Text;
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ScholarNo,Class,Year from HostelFeePayment where ScholarNo= '" + ScholarNo.Text + "' and Class= '" + Course.Text + "' and Year='" + Year.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    Autocomplete();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Hostelers where ScholarNo= '" + ScholarNo.Text + "' and Class= '" + Course.Text + "' and Year='" + Year.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    Autocomplete();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    Autocomplete();
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

        private void Year_TextChanged(object sender, EventArgs e)
        {

        }

        private void Course_TextChanged(object sender, EventArgs e)
        {
            Term.Items.Clear();
            Term.Text = "";
            SqlDataReader rdr = null;
            //Term.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Semester) from Batch where Course = '" + Course.Text + "' and Session='"+Year.Text+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Term.Items.Add(rdr[0]);
                }
                if ((rdr != null))
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

        private void cmbHostelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(BedNumber) FROM Beds where PropertyName='"+ cmbHostelName.Text+ "'", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                bedno.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    bedno.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bedno_SelectedIndexChanged(object sender, EventArgs e)
        {
            hostelfee.Text = "";
            SqlDataReader rdr = null;
            //Term.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select distinct RTRIM(BedNo) from Hostelers where HostelName = '" + cmbHostelName.Text + "' and BedNo='" + bedno.Text + "' and Year='"+Year.Text+"' and Term='"+Term.Text+"'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Room Already Assigned to some one", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    //return;
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Price) from LodgeOrders where PropertyName = '" + cmbHostelName.Text + "' and units='" + bedno.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    hostelfee.Text = rdr[0].ToString(); 
                }
                if ((rdr != null))
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

        private void bedno_TextChanged(object sender, EventArgs e)
        {
            hostelfee.Text = "";
            SqlDataReader rdr = null;
            //Term.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select distinct RTRIM(BedNo) from Hostelers where HostelName = '" + cmbHostelName.Text + "' and BedNo='" + bedno.Text + "' and Year='" + Year.Text + "' and Term='" + Term.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Room Already Assigned to some one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Price) from LodgeOrders where PropertyName = '" + cmbHostelName.Text + "' and units='" + bedno.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    hostelfee.Text = rdr[0].ToString();
                }
                if ((rdr != null))
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
