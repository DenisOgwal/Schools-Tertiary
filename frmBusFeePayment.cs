using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmBusFeePayment : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmBusFeePayment()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            Year.Text = "";
            FeePaymentID.Text = "";
            ScholarNo.Text = "";
            StudentName.Text = "";
            Course.Text = "";
            Branch.Text = "";
            Term.Text = "";
            txtBusCharges.Text = "";
            txtSourceLocation.Text = "";
            ModeOfPayment.Text = "";
            PaymentDate.Text = DateTime.Today.ToString();
            PaymentModeDetails.Text = "";
            Fine.Text = "";
            TotalPaid.Text = "";
            DueFees.Text = "";
            btnSave.Enabled = true;
            Delete.Enabled = false;
            Update_record.Enabled = false;
            Print.Enabled = false;
            ScholarNo.Focus();
        }
        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void delete_records2()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ScholarNo,Year,Term,Class from BusFeePayment where ScholarNo= '" + ScholarNo.Text + "' and Term='" + Term.Text + "' and Class='" + Course.Text + "'and Year='" + Year.Text + "' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int RowsAffected = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "delete from BusFeePayment where ScholarNo='" + ScholarNo.Text + "' and Year='" + Year.Text + "' and Term='" + Term.Text + "'";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                    cmd.Parameters["@DELETE1"].Value = FeePaymentID.Text;
                    RowsAffected = cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DueFees.Text != "0")
            {
                MessageBox.Show("Please payment for transport must be cleared to zero and not less", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TotalPaid.Focus();
                return;
            }
            try
            {
                if (ScholarNo.Text == "")
                {
                    MessageBox.Show("Please select Scholar No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScholarNo.Focus();
                    return;
                }
                if (Year.Text == "")
                {
                    MessageBox.Show("Please Enter Year.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Year.Focus();
                    return;
                }
                if (Term.Text == "")
                {
                    MessageBox.Show("Please Enter Tern", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Term.Focus();
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
                //delete_records2();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ScholarNo,Year,Term,Class from BusFeePayment where ScholarNo= '" + ScholarNo.Text + "' and Term='" + Term.Text + "' and Class='" + Course.Text + "'and Year='" + Year.Text + "' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    auto();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update BusFeePayment set Section='" + Branch.Text + "',StudentNames='" + StudentName.Text + "',BusCharges=@d3,DateOfPayment=@d4,ModeOfPayment=@d5,PaymentModeDetails=@d6,TotalPaid=@d7,Fine=@d8,DueFees=@d9,FeePaymentID=@d1  where Year=@d12 and ScholarNo=@d2 and Class=@d11 and Term=@d10 ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 10, "BusCharges"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Fine"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "DueFees"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 15, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Term"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "Class"));
                    cmd.Parameters["@d1"].Value = FeePaymentID.Text.Trim();
                    cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(txtBusCharges.Text);
                    cmd.Parameters["@d4"].Value = (PaymentDate.Text);
                    cmd.Parameters["@d5"].Value = (ModeOfPayment.Text);
                    cmd.Parameters["@d6"].Value = (PaymentModeDetails.Text);
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(txtBusCharges.Text) - Convert.ToInt32(DueFees.Text);
                    cmd.Parameters["@d12"].Value = Year.Text.Trim();
                    if (Fine.Text == "")
                    {
                        cmd.Parameters["@d8"].Value = 0;
                    }
                    else
                    {
                        cmd.Parameters["@d8"].Value = Convert.ToInt32(Fine.Text);
                    }
                    cmd.Parameters["@d9"].Value = Convert.ToInt32(DueFees.Text);
                    cmd.Parameters["@d10"].Value = (Term.Text);
                    cmd.Parameters["@d11"].Value = (Course.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    Print.Enabled = true;
                }
                else
                {
                    auto();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into BusFeePayment(FeePaymentID,ScholarNo,BusCharges,DateOfPayment,ModeOfPayment,PaymentModeDetails,TotalPaid,Fine,DueFees,Term,Class,Year,StudentNames,Section,SourceLocations) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'" + StudentName.Text + "','" + Branch.Text + "','" + txtSourceLocation.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 10, "BusCharges"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Fine"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "DueFees"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Term"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "Class"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 15, "Year"));
                    cmd.Parameters["@d1"].Value = FeePaymentID.Text.Trim();
                    cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                    cmd.Parameters["@d3"].Value = Convert.ToInt32(txtBusCharges.Text);
                    cmd.Parameters["@d4"].Value = (PaymentDate.Text);
                    cmd.Parameters["@d5"].Value = (ModeOfPayment.Text);
                    cmd.Parameters["@d6"].Value = (PaymentModeDetails.Text);
                    cmd.Parameters["@d10"].Value = (Term.Text);
                    cmd.Parameters["@d11"].Value = (Course.Text);
                    cmd.Parameters["@d12"].Value = Year.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(TotalPaid.Text);
                    if (Fine.Text == "")
                    {
                        cmd.Parameters["@d8"].Value = 0;
                    }
                    else
                    {
                        cmd.Parameters["@d8"].Value = Convert.ToInt32(Fine.Text);
                    }
                    cmd.Parameters["@d9"].Value = Convert.ToInt32(DueFees.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FeePaymentID.Text = "F-" + GetUniqueKey(7);
        }
        private void frmTransportationFeePayemt_Load(object sender, EventArgs e)
        {
            AutocompleScholaNo();
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update BusFeePayment set Section='"+Branch.Text+"',StudentNames='"+StudentName.Text+"',ScholarNo=@d2,BusCharges=@d3,DateOfPayment=@d4,ModeOfPayment=@d5,PaymentModeDetails=@d6,TotalPaid=@d7,Fine=@d8,DueFees=@d9, Year=@d12 where FeePaymentID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 10, "BusCharges"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Fine"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "DueFees"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Year"));
                cmd.Parameters["@d1"].Value = FeePaymentID.Text.Trim();
                cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                cmd.Parameters["@d3"].Value = Convert.ToInt32(txtBusCharges.Text);
                cmd.Parameters["@d4"].Value = (PaymentDate.Text);
                cmd.Parameters["@d5"].Value = (ModeOfPayment.Text);
                cmd.Parameters["@d6"].Value = (PaymentModeDetails.Text);
                cmd.Parameters["@d7"].Value = Convert.ToInt32(TotalPaid.Text);
                cmd.Parameters["@d12"].Value = Year.Text.Trim();
                if (Fine.Text == "")
                {
                    cmd.Parameters["@d8"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(Fine.Text);
                }
                cmd.Parameters["@d9"].Value = Convert.ToInt32(DueFees.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string cq = "delete from BusFeePayment where FeePaymentID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
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
        private void AutocompleScholaNo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ScholarNo) from BusHolders ";
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

        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Student_Name,Course,Branch,BusHolders.SourceLocation,BusCharges FROM student,BusHolders,Transportation WHERE Student.ScholarNo=BusHolders.ScholarNo and BusHolders.SourceLocation=Transportation.SourceLocation and Student.ScholarNo = '" + ScholarNo.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    StudentName.Text = rdr.GetString(0).Trim();
                    Course.Text = rdr.GetString(1).Trim();
                    Branch.Text = rdr.GetString(2).Trim();
                    txtSourceLocation.Text = rdr.GetString(3).Trim();
                    txtBusCharges.Text = rdr.GetInt32(4).ToString();
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

        private void TotalPaid_TextChanged(object sender, EventArgs e)
        {
             try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ScholarNo,DueFees,Term,Class,Year from BusFeePayment where ScholarNo= '" + ScholarNo.Text + "' and Term='" + Term.Text + "' and Class='" + Course.Text + "'and Year='" + Year.Text + "' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label5.Text =rdr["DueFees"].ToString();
                    int val4 = 0;
                    int val5 = 0;
                    int val6 = 0;
                    int.TryParse(label5.Text, out val4);
                    int.TryParse(Fine.Text, out val5);
                    int.TryParse(TotalPaid.Text, out val6);
                    if (val4 != 0)
                    {
                        int I = ((val4 + val5) - val6);
                        DueFees.Text = I.ToString();
                    }
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
                    int.TryParse(txtBusCharges.Text, out val1);
                    int.TryParse(Fine.Text, out val2);
                    int.TryParse(TotalPaid.Text, out val3);
                    int I = ((val1 + val2) - val3);
                    DueFees.Text = I.ToString();
                }
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
            int.TryParse(txtBusCharges.Text, out val1);
            int.TryParse(Fine.Text, out val2);
            int.TryParse(TotalPaid.Text, out val3);
            if (val3 > val1 + val2)
            {
                MessageBox.Show("Total Paid can not be more than Transportation Fees + Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TotalPaid.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBusFeePaymentRecord1 frm = new frmBusFeePaymentRecord1();
            frm.label13.Text = label3.Text;
            frm.label14.Text = label4.Text;
            frm.ShowDialog();
        }

        private void Print_Click(object sender, EventArgs e)
        {
           try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                frmBusFeePaymentReceipt frm = new frmBusFeePaymentReceipt();
                rptBusFeePaymentReceipt rpt = new rptBusFeePaymentReceipt();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                TransportationFacility_DBDataSet myDS = new TransportationFacility_DBDataSet();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select *  from BusFeePayment,Student,Transportation,BusHolders where Student.scholarNo=BusHolders.ScholarNo and BusFeePayment.ScholarNo=Student.ScholarNo and Transportation.SourceLocation=BusHolders.SourceLocation and FeePaymentID= '" + FeePaymentID.Text + "'" ;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "BusFeePayment");
                myDA.Fill(myDS, "Transportation");
                myDA.Fill(myDS, "BusHolders");
                myDA.Fill(myDS, "Student");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();          
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

       

        private void frmBusFeePayment_Load(object sender, EventArgs e)
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
            AutocompleScholaNo();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label4.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { Delete.Enabled = true; } else { Delete.Enabled = false; }
                    if (pricess == "Yes") { Update_record.Enabled = true; } else { Update_record.Enabled = false; }
                }
                if (label4.Text == "ADMIN")
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

        private void frmBusFeePayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*frmMainMenu frm = new frmMainMenu();
            this.Hide();
            frm.UserType.Text = label3.Text;
            frm.User.Text = label4.Text;
            frm.Show();*/
        }

        private void Course_TextChanged(object sender, EventArgs e)
        {
            Term.Text = "";
            SqlDataReader rdr = null;
            //Term.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Semester) from Batch where Course = '" + Course.Text + "' and Session='" + Year.Text + "'";
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

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}