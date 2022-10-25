using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net;
namespace College_Management_System
{
    public partial class frmOtherFeesPayment : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmOtherFeesPayment()
        {
            InitializeComponent();
        }

        private void FeesPayment_Load(object sender, EventArgs e)
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
            //label21.Width = this.Width;
            //AutocompleScholarNo();
            dataGridView1.DataSource = GetData();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label24.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { Delete.Enabled = true; } else { Delete.Enabled = false; }
                    if (pricess == "Yes") { Update_record.Enabled = true; } else { Update_record.Enabled = false; }
                }
                if (label24.Text == "ADMIN")
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
        private void AutocompleFeeID()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct () from FeesDetails where Year='" + Year.Text + "' and Course='" + Course.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    FeeID.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from OtherFeePayment where FeePaymentID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "FeepaymentID"));
                cmd.Parameters["@DELETE1"].Value = FeePaymentID.Text;
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

        private void AutocompleScholarNo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ScholarNo) from Student ";
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

        private void FeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Semester) FROM Batch", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                Term.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    Term.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (FeeID.Text == "Others")
            {
                UDFees.ReadOnly = false;
                FDCourse.ReadOnly = false;
                FDBranch.ReadOnly = false;
            }
            else {
                UDFees.ReadOnly = true;
                FDCourse.ReadOnly = true;
                FDBranch.ReadOnly = true;
            }
            try
            {
                if (Year.Text == "")
                {
                    MessageBox.Show("Please Enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Year.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM OtherFeesDetails WHERE RealFeesName = '" + FeeID.Text + "' Order By ID Desc";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    FDCourse.Text = rdr.GetString(2).Trim();
                    FDBranch.Text = rdr.GetString(3).Trim();
                    Term.Text = rdr.GetString(5).Trim();
                    UDFees.Text = rdr.GetString(6).Trim();
                    
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

        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Student_Name,Course,Branch FROM Student WHERE ScholarNo = '" + ScholarNo.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    StudentName.Text = rdr.GetString(0).Trim();
                    Course.Text = rdr.GetString(1).Trim();
                    Branch.Text = rdr.GetString(2).Trim();
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
            FeePaymentID.Text = "";
            FeeID.Text = "";
            Course.Text = "";
            Branch.Text = "";
            Term.Text = "";
            UDFees.Text = "";
            FDBranch.Text = "";
            FDCourse.Text = "";
            ScholarNo.Text = "";
            StudentName.Text = "";
            ModeOfPayment.Text = "";
            PaymentModeDetails.Text = "";
            TotalPaid.Text = "";
            Fine.Text = "";
            Year.Text = "";
            DueFees.Text = "";
            PaymentDate.Text = DateTime.Today.ToString();
            Delete.Enabled = false;
            Update_record.Enabled = false;
            btnSave.Enabled = true;
            Print.Enabled = false;
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
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            FeePaymentID.Text = "F-" + years + monthss + days + GetUniqueKey(5);
        }
        string numberphone = null;
        string messages = null;
        public void sendmessage()
        {

            try
            {
                 using (var client2 = new WebClient())
                 using (client2.OpenRead("http://client3.google.com/generate_204"))
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     cmd = con.CreateCommand();
                     cmd.CommandText = "SELECT distinct RTRIM(Contact_No) FROM Student where ScholarNo='" + ScholarNo.Text + "'";
                     rdr = cmd.ExecuteReader();
                     if (rdr.Read())
                     {
                         numberphone = rdr.GetString(0).Trim();
                     }
                     if ((rdr != null))
                     {
                         rdr.Close();
                     }
                     if (con.State == ConnectionState.Open)
                     {
                         con.Close();
                     }
                     string usernamess = Properties.Settings.Default.smsusername;
                     string passwordss = Properties.Settings.Default.smspassword;
                     WebClient client = new WebClient();
                     string numbers = "+256" + numberphone;
                     messages = TotalPaid.Text + " Has been paid for clearing " + FeeID.Text + " for " + StudentName.Text + " and a balance of " + DueFees.Text + " is left for this " + Term.Text + " Term of year" + Year.Text;
                     string baseURL = "http://geniussmsgroup.com/api/http/messagesService/get?username=" + usernamess + "&password=" + passwordss + "&senderid=Geniussms&message=" + messages + "&numbers=" + numbers;
                     client.OpenRead(baseURL);
                     MessageBox.Show("Successfully sent message");
                 }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not send message because your computer is not connected to internet");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                auto();
                if (FeePaymentID.Text == "")
                {
                    MessageBox.Show("Please Enter Fees Payment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FeePaymentID.Focus();
                    return;
                }
                if (ScholarNo.Text == "")
                {
                    MessageBox.Show("Please select Scholar No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScholarNo.Focus();
                    return;
                }
                if (FeeID.Text == "")
                {
                    MessageBox.Show("Please select Fee ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FeeID.Focus();
                    return;
                }
                if (ModeOfPayment.Text == "")
                {
                    MessageBox.Show("Please select mode of payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ModeOfPayment.Focus();
                    return;
                }
                if (TotalPaid.Text == "")
                {
                    MessageBox.Show("Please enter total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TotalPaid.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select FeePaymentID,Year,ScholarNo,FDCourse,FDBranch,Semester,DueFees from OtherFeePayment where  FDCourse= '" + FDCourse.Text + "' and ScholarNo= '" + ScholarNo.Text + "' and Semester='" + Term.Text + "' and Year='" + Year.Text + "' and FeeName='"+FeeID.Text+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "update OtherFeePayment set DueFees=@d13 where ScholarNo=@d2 and Semester=@d9 and Year=@d23 and FDCourse=@d7 and FeeName=@d7  ";
                    cmd = new SqlCommand(cb3);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "FDCourse"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "FDBranch"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "RealFees"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 30, "FeeName"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Fine"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "DueFees"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 20, "Year"));
                   
                    cmd.Parameters["@d1"].Value = FeePaymentID.Text.Trim();
                    cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                    cmd.Parameters["@d3"].Value = FDCourse.Text.Trim();
                    cmd.Parameters["@d4"].Value = FDBranch.Text.Trim();
                    cmd.Parameters["@d5"].Value = Term.Text.Trim();
                    cmd.Parameters["@d6"].Value = UDFees.Text;
                    cmd.Parameters["@d7"].Value = FeeID.Text;
                    cmd.Parameters["@d8"].Value = (PaymentDate.Text);
                    cmd.Parameters["@d9"].Value = (ModeOfPayment.Text);
                    cmd.Parameters["@d10"].Value = (PaymentModeDetails.Text);
                    cmd.Parameters["@d11"].Value = Convert.ToInt32(TotalPaid.Text);
                    cmd.Parameters["@d13"].Value = (DueFees.Text);
                    cmd.Parameters["@d14"].Value = (Year.Text);
                  
                    if (Fine.Text == "")
                    {
                        cmd.Parameters["@d12"].Value = 0;
                    }
                    else
                    {
                        cmd.Parameters["@d12"].Value = Convert.ToInt32(Fine.Text);
                    }
                    cmd.ExecuteReader();
                    con.Close();

                    //auto();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into OtherFeePayment(FeePaymentID,ScholarNo,FDCourse,FDBranch,Semester,RealFees,FeeName,DateOfPayment,ModeOfPayment,PaymentModeDetails,TotalPaid,Fine,DueFees,Year,Student_name) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,'"+StudentName.Text+"')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "FDCourse"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "FDBranch"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "RealFees"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 30, "FeeName"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Fine"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "DueFees"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.Int, 10, "Year"));

                    cmd.Parameters["@d1"].Value = FeePaymentID.Text.Trim();
                    cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                    cmd.Parameters["@d3"].Value = FDCourse.Text.Trim();
                    cmd.Parameters["@d4"].Value = FDBranch.Text.Trim();
                    cmd.Parameters["@d5"].Value = Term.Text.Trim();
                    cmd.Parameters["@d6"].Value = UDFees.Text;
                    cmd.Parameters["@d7"].Value = FeeID.Text;
                    cmd.Parameters["@d8"].Value = (PaymentDate.Text);
                    cmd.Parameters["@d9"].Value = (ModeOfPayment.Text);
                    cmd.Parameters["@d10"].Value = (PaymentModeDetails.Text);
                    cmd.Parameters["@d11"].Value = Convert.ToInt32(TotalPaid.Text);
                    cmd.Parameters["@d13"].Value = (DueFees.Text);
                    cmd.Parameters["@d14"].Value = (Year.Text);

                    if (Fine.Text == "")
                    {
                        cmd.Parameters["@d12"].Value = 0;
                    }
                    else
                    {
                        cmd.Parameters["@d12"].Value = Convert.ToInt32(Fine.Text);
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved", "Fees Payment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string smsallow = Properties.Settings.Default.smsallow;
                    if (smsallow == "Yes")
                    {
                        sendmessage();
                    }
                    btnSave.Enabled = false;
                    Print.Enabled = true;
                    con.Close();
                }
                else
                {
                    //auto();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into OtherFeePayment(FeePaymentID,ScholarNo,FDCourse,FDBranch,Semester,RealFees,FeeName,DateOfPayment,ModeOfPayment,PaymentModeDetails,TotalPaid,Fine,DueFees,Year,Student_name) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,'"+StudentName.Text+"')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "FDCourse"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "FDBranch"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "RealFees"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 30, "FeeName"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Fine"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "DueFees"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.Int, 10, "Year"));

                    cmd.Parameters["@d1"].Value = FeePaymentID.Text.Trim();
                    cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                    cmd.Parameters["@d3"].Value = FDCourse.Text.Trim();
                    cmd.Parameters["@d4"].Value = FDBranch.Text.Trim();
                    cmd.Parameters["@d5"].Value = Term.Text.Trim();
                    cmd.Parameters["@d6"].Value = UDFees.Text;
                    cmd.Parameters["@d7"].Value = FeeID.Text;
                    cmd.Parameters["@d8"].Value = (PaymentDate.Text);
                    cmd.Parameters["@d9"].Value = (ModeOfPayment.Text);
                    cmd.Parameters["@d10"].Value = (PaymentModeDetails.Text);
                    cmd.Parameters["@d11"].Value = Convert.ToInt32(TotalPaid.Text);
                    cmd.Parameters["@d13"].Value = (DueFees.Text);
                    cmd.Parameters["@d14"].Value = (Year.Text);

                    if (Fine.Text == "")
                    {
                        cmd.Parameters["@d12"].Value = 0;
                    }
                    else
                    {
                        cmd.Parameters["@d12"].Value = Convert.ToInt32(Fine.Text);
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved", "Fees Payment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string smsallow = Properties.Settings.Default.smsallow;
                    if (smsallow == "Yes")
                    {
                        sendmessage();
                    }
                    btnSave.Enabled = false;
                    Print.Enabled = true;
                    con.Close();
                }
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

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update OtherFeePayment set ScholarNo=@d2,Year=@d14,FDCourse=@d3,FDBranch=@d4,Semester=@d5,RealFees=@d6,FeeName=@d7,DateOfPayment=@d8,ModeOfPayment=@d9,PaymentModeDetails=@d10,TotalPaid=@d11,Fine=@d12,DueFees=@d23 where FeePaymentID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 50, "FDCourse"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "FDBranch"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Semester"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.Int, 10, "RealFees"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 30, "FeeName"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Fine"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "DueFees"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.Int, 10, "Year"));

                cmd.Parameters["@d1"].Value = FeePaymentID.Text.Trim();
                cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                cmd.Parameters["@d3"].Value = FDCourse.Text.Trim();
                cmd.Parameters["@d4"].Value = FDBranch.Text.Trim();
                cmd.Parameters["@d5"].Value = Term.Text.Trim();
                cmd.Parameters["@d6"].Value = UDFees.Text;
                cmd.Parameters["@d7"].Value = FeeID.Text;
                cmd.Parameters["@d8"].Value = (PaymentDate.Text);
                cmd.Parameters["@d9"].Value = (ModeOfPayment.Text);
                cmd.Parameters["@d10"].Value = (PaymentModeDetails.Text);
                cmd.Parameters["@d11"].Value = Convert.ToInt32(TotalPaid.Text);
                cmd.Parameters["@d13"].Value = (DueFees.Text);
                cmd.Parameters["@d14"].Value = (Year.Text);

                if (Fine.Text == "")
                {
                    cmd.Parameters["@d12"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(Fine.Text);
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Fees Payment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Update_record.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FeesPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmMainMenu form2 = new frmMainMenu();
            form2.User.Text = label24.Text;
            form2.UserType.Text = label23.Text;
            form2.Show();*/
        }

        private SqlConnection Connection
        {
            get
            {
                SqlConnection ConnectionToFetch = new SqlConnection(cs.DBConn);
                ConnectionToFetch.Open();
                return ConnectionToFetch;
            }
        }
        public DataView GetData()
        {
            dynamic SelectQry = "SELECT RTRIM(FeeID)[Fee ID],RTRIM(Year)[Year],RTRIM(Course)[Class], RTRIM(Semester)[Term], RTRIM(Branch)[Section], RTRIM(RealFeesName)[Fee Name], RTRIM(RealFees)[Fee] from OtherFeesDetails order by course,Semester ";
            DataSet SampleSource = new DataSet();
            DataView TableView = null;
            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
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
        public void company()
        {
            try
            {
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct6 = "select * from CompanyNames";
                cmd = new SqlCommand(ct6);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyname = rdr.GetString(1).Trim();
                    companyaddress = rdr.GetString(5).Trim();
                    companyslogan = rdr.GetString(2).Trim();
                    companycontact = rdr.GetString(4).Trim();
                    companyemail = rdr.GetString(3).Trim();
                }
                else
                {
                    // BarPrinter = "no printer";
                    // KitchenPrinter = "no printer";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Print_Click(object sender, EventArgs e)
        {
            try
            {
                company();
                if (ScholarNo.Text == "")
                {
                    MessageBox.Show("Please select Scholar No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScholarNo.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                frmFeePaymentReceipt frm = new frmFeePaymentReceipt();
                rptFeePaymentReceipt2 rpt = new rptFeePaymentReceipt2();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from OtherFeePayment where ScholarNo= '" + ScholarNo.Text + "' and Year= '" + Year.Text + "' and Semester= '" + Term.Text + "' and FDCourse= '" + Course.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "OtherFeePayment");
                rpt.SetDataSource(myDS);
                rpt.SetParameterValue("comanyname", companyname);
                rpt.SetParameterValue("companyemail", companyemail);
                rpt.SetParameterValue("companycontact", companycontact);
                rpt.SetParameterValue("companyslogan", companyslogan);
                rpt.SetParameterValue("companyaddress", companyaddress);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           /* try
            {
                if (ScholarNo.Text == "")
                {
                    MessageBox.Show("Please select Scholar No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScholarNo.Focus();
                    return;
                }
                printPreviewDialog1.Document = printDocument2;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOtherFeePaymentRecord frm = new frmOtherFeePaymentRecord();
            this.Hide();
            frm.dataGridView1.DataSource = null;
            frm.Course.Text = "";
            frm.Branch.Text = "";
            frm.Date_from.Text = DateTime.Today.ToString();
            frm.Date_to.Text = DateTime.Today.ToString();
            frm.ScholarNo.Text = "";
            frm.dataGridView2.DataSource = null;
            frm.dataGridView3.DataSource = null;
            frm.dataGridView4.DataSource = null;
            frm.dataGridView5.DataSource = null;
            frm.PaymentDateFrom.Text = DateTime.Today.ToString();
            frm.PaymentDateTo.Text = DateTime.Today.ToString();
            frm.DateFrom.Text = DateTime.Today.ToString();
            frm.DateTo.Text = DateTime.Today.ToString();
            frm.dateTimePicker1.Text = DateTime.Today.ToString();
            frm.dateTimePicker2.Text = DateTime.Today.ToString();
            Branch.Enabled = false;
            frm.label13.Text = label23.Text;
            frm.label14.Text = label24.Text;
            frm.ShowDialog();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                FeeID.Text = dr.Cells[5].Value.ToString();
                Year.Text = dr.Cells[1].Value.ToString();
                Term.Text = dr.Cells[3].Value.ToString();
                FDCourse.Text = dr.Cells[2].Value.ToString();
                FDBranch.Text = dr.Cells[4].Value.ToString();
                UDFees.Text = dr.Cells[6].Value.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void Fine_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void TotalPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void TotalPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ScholarNo,FDCourse,FDBranch,Semester,DueFees,Year from OtherFeePayment where  FDCourse= '" + FDCourse.Text + "' and ScholarNo= '" + ScholarNo.Text + "' and Semester='" + Term.Text + "' and Year='" + Year.Text + "' and FeeName='"+FeeID.Text+"' order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label27.Text = rdr["DueFees"].ToString();
                    int val4 = 0;
                    int val5 = 0;
                    int val6 = 0;
                    int.TryParse(label27.Text, out val4);
                    int.TryParse(Fine.Text, out val5);
                    int.TryParse(TotalPaid.Text, out val6);
                    int I = ((val4 + val5) - val6);
                    DueFees.Text = I.ToString();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                else
                {
                    int val1 = 0;
                    int val2 = 0;
                    int val3 = 0;
                    int.TryParse(UDFees.Text, out val1);
                    int.TryParse(Fine.Text, out val2);
                    int.TryParse(TotalPaid.Text, out val3);
                    int I = ((val1 + val2) - val3);
                    DueFees.Text = I.ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TotalPaid_Validating(object sender, CancelEventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int.TryParse(UDFees.Text, out val1);
            int.TryParse(Fine.Text, out val2);
            int.TryParse(TotalPaid.Text, out val3);
            if (val3 > val1 + val2)
            {
                MessageBox.Show("Total Paid can not be more than Total Fees + Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UDFees.Text = "";
                UDFees.Focus();
            }
        }
        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void Year_TextChanged(object sender, EventArgs e)
        {
            //FeeID.Items.Clear();
           // AutocompleFeeID();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float x = 10;
                float y = 5;

                float width = 260.0F; // max width I found through trial and error
                float height = 0F;

                Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
                Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
                Font drawFontArial10italic = new Font("Arial", 10, FontStyle.Italic);
                Font drawFontArial10Bold = new Font("Arial", 10, FontStyle.Bold);
                Font drawFontArial6Regular = new Font("Arial", 6, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Set format of string.
                StringFormat drawFormatCenter = new StringFormat();
                drawFormatCenter.Alignment = StringAlignment.Center;
                StringFormat drawFormatLeft = new StringFormat();
                drawFormatLeft.Alignment = StringAlignment.Near;
                StringFormat drawFormatRight = new StringFormat();
                drawFormatRight.Alignment = StringAlignment.Far;

                // Draw string to screen.
                string text = "KIGUMBA TOWN COMMUNITY SECONDARY SCH";
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Poised to Excel ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "P.o Box 85, Kigumba, Kiryandongo";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "TEL:0782587448/0702042617";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "--------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;
                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Student: " + ScholarNo.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "Name: " + StudentName.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Payment ID: " + FeePaymentID.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Date: " + DateTime.Now.ToString();
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;
                text = "--------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                if (FeeID.Text == "Others")
                {
                    text = "Paid For: " + PaymentModeDetails.Text;
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                else
                {
                    text = "Paid For: " + FeeID.Text;
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
               
                text = "Paid To: " + label24.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Total Ammount: UGX." +string.Format("{0:n0}", Convert.ToInt32(UDFees.Text));
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Total Paid: UGX." + string.Format("{0:n0}", Convert.ToInt32(TotalPaid.Text));
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Due Payment: UGX." + string.Format("{0:n0}", Convert.ToInt32(DueFees.Text));
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "--------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "*****THANK YOU*****";
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Powered by: +256 787045644";
                e.Graphics.DrawString(text, drawFontArial6Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial6Regular).Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float x = 10;
                float y = 5;

                float width = 260.0F; // max width I found through trial and error
                float height = 0F;

                Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
                Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
                Font drawFontArial10italic = new Font("Arial", 10, FontStyle.Italic);
                Font drawFontArial10Bold = new Font("Arial", 10, FontStyle.Bold);
                Font drawFontArial6Regular = new Font("Arial", 6, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Set format of string.
                StringFormat drawFormatCenter = new StringFormat();
                drawFormatCenter.Alignment = StringAlignment.Center;
                StringFormat drawFormatLeft = new StringFormat();
                drawFormatLeft.Alignment = StringAlignment.Near;
                StringFormat drawFormatRight = new StringFormat();
                drawFormatRight.Alignment = StringAlignment.Far;

                // Draw string to screen.
                string text = "KIGUMBA TOWN COMMUNITY SECONDARY SCH";
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Poised to Excel ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "P.o Box 85, Kigumba, Kiryandongo";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "TEL:0782587448/0702042617";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "--------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Student No: " + ScholarNo.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                text = "Student Name: " + StudentName.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = "Date: " + DateTime.Now.ToString();
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "--------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM FeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "School Fees: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Registration Fee'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Registration Fee: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Development Fee'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Development Fee: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='UNSA Fee'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "UNSA Fee: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Sesemat Fee'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Sesemat Fee: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='UNEB Reg Fee'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "UNEB Registration Fee: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Ream'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Ream: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Sports Fee'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Sports Fee: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Uniform'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Uniform: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Identity Card & Photos'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Identity Card & Photos: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Tools'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Tools: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Hostel'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Hostel: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TotalPaid FROM OtherFeePayment WHERE ScholarNo = '" + ScholarNo.Text + "' and FeePaymentID='" + FeePaymentID.Text + "' and FeeName='Others'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    text = "Others: " + string.Format("{0:n0}", Convert.ToInt32(rdr.GetInt32(0)));
                    e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;
                }

                text = "--------------------------------------------";
                e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;
                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;
                text = "Paid To: " + label24.Text;
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;



                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "*****THANK YOU*****";
                e.Graphics.DrawString(text, drawFontArial10Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Bold).Height;

                text = " ";
                e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

                text = "Powered by: +256 787045644 Dither Technologies LTD";
                e.Graphics.DrawString(text, drawFontArial6Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, drawFontArial6Regular).Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PaymentDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ScholarNo_Click(object sender, EventArgs e)
        {
            frmClientDetails2 frm = new frmClientDetails2();
            frm.ShowDialog();
            ScholarNo.Text = frm.clientnames.Text;
        }

        private void ScholarNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Student_Name,Course,Branch FROM StudentRegistration WHERE Admission_no = '" + ScholarNo.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    StudentName.Text = rdr.GetString(0).Trim();
                    Course.Text = rdr.GetString(1).Trim();
                    Branch.Text = rdr.GetString(2).Trim();
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
    }
}

