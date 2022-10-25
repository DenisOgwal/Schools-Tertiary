using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmSalaryPayment : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

      
        public frmSalaryPayment()
        {
            InitializeComponent();
        }
        private void Reset()
        {

            txtPaymentID.Text = "";
            cmbStaffID.Text = "";
            cmbModeOfPayment.Text = "";
            dtpPaymentDate.Text = DateTime.Today.ToString();
            months.Text = DateTime.Today.ToString();
            session.Text = DateTime.Today.ToString();
            txtBasicSalary.Text = "";
            txtDeduction.Text = "";
            txtPaymentModeDetails.Text = "";
            txtStaffName.Text = "";
            txtTotalPaid.Text = "";
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            btnSave.Enabled = true;
            btnPrint.Enabled = false;
            term.Text = "";
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
            txtPaymentID.Text = "SP-" + GetUniqueKey(8);
        }
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStaffID.Text == "")
            {
                MessageBox.Show("Please select staff id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStaffID.Focus();
                return;
            }
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please select mode of payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Months,Year from EmployeePayment WHERE StaffID = '" + cmbStaffID.Text + "' and Months='" + months.Text + "' and Year='" + Year.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "UPDATE  EmployeePayment SET basicsalary=@d4,PaymentDate=@d5,ModeOfPayment=@d6,PaymentModeDetails=@d7,Deduction=@d8,TotalPaid=@d9,DueFees=@d12 WHERE Months='" + months.Text + "' and Year='" + Year.Text + "' and StaffID='" + cmbStaffID.Text + "'";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "BasicSalary"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "PaymentDate"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Deduction"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "DueFees"));
                    cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                    cmd.Parameters["@d2"].Value = cmbStaffID.Text;
                    cmd.Parameters["@d4"].Value = Convert.ToInt32(txtBasicSalary.Text);
                    cmd.Parameters["@d5"].Value = dtpPaymentDate.Text;
                    cmd.Parameters["@d6"].Value = cmbModeOfPayment.Text;
                    cmd.Parameters["@d7"].Value = txtPaymentModeDetails.Text;
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(txtDeduction.Text);
                    cmd.Parameters["@d9"].Value = (Convert.ToInt32(txtBasicSalary.Text) - Convert.ToInt32(Duepayment.Text));
                    cmd.Parameters["@d10"].Value = months.Text;
                    cmd.Parameters["@d11"].Value = Year.Text;
                    cmd.Parameters["@d12"].Value = Duepayment.Text;
                    if (txtDeduction.Text == "")
                    {
                        txtDeduction.Text = "0";
                    }
                    cmd.ExecuteReader();
                    con.Close();
                  
                }
                else
                {

                    auto();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into EmployeePayment(PaymentId,StaffId,basicsalary,PaymentDate,ModeOfPayment,PaymentModeDetails,Deduction,TotalPaid,Months,Year,DueFees,StaffName,Term,Session) VALUES (@d1,@d2,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,'"+term.Text+ "','" + session.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "BasicSalary"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "PaymentDate"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Deduction"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "DueFees"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "StaffName"));
                    cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                    cmd.Parameters["@d2"].Value = cmbStaffID.Text;
                    cmd.Parameters["@d4"].Value = Convert.ToInt32(txtBasicSalary.Text);
                    cmd.Parameters["@d5"].Value = dtpPaymentDate.Text;
                    cmd.Parameters["@d6"].Value = cmbModeOfPayment.Text;
                    cmd.Parameters["@d7"].Value = txtPaymentModeDetails.Text;
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(txtDeduction.Text);
                    cmd.Parameters["@d9"].Value = Convert.ToInt32(txtTotalPaid.Text);
                    cmd.Parameters["@d10"].Value = months.Text;
                    cmd.Parameters["@d11"].Value = Year.Text;
                    cmd.Parameters["@d12"].Value = Duepayment.Text;
                    cmd.Parameters["@d14"].Value = txtStaffName.Text;
                    cmd.ExecuteReader();
                    con.Close();
                }
                con.Close();
               
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPrint.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void PopulateStaffID()
        {

            try
            {

                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(StaffID) FROM Employee", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbStaffID.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbStaffID.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmSalaryPayment_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
            PopulateStaffID();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label7.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { btnDelete.Enabled = true; } else { btnDelete.Enabled = false; }
                    if (pricess == "Yes") { btnUpdate_record.Enabled = true; } else { btnUpdate_record.Enabled = false; }
                }
                if (label7.Text == "ADMIN")
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
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Session),ID from Student order by ID Desc ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    session.Text = rdr[0].ToString();
                    session.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from EmployeePayment where  PaymentID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters["@DELETE1"].Value = txtPaymentID.Text;
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

        private void frmSalaryPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.UserType.Text = label6.Text;
            frm.User.Text = label7.Text;
            frm.Show();*/
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptSalarySlip rpt = new rptSalarySlip(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                CMS_DBDataSet myDS = new CMS_DBDataSet(); //The DataSet you created.
                FrmSalarySlip frm = new FrmSalarySlip();
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from EmployeePayment,Employee where Employee.StaffID=EmployeePayment.StaffID and PaymentID='" + txtPaymentID.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "EmployeePayment");
                myDA.Fill(myDS, "Employee");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbStaffID_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Staffname,basicsalary from Employee WHERE StaffID = '" + cmbStaffID.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtStaffName.Text = (rdr.GetString(0).Trim());
                    txtBasicSalary.Text = rdr.GetInt32(1).ToString();
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
            dynamic SelectQry = "SELECT RTRIM(StaffID)[Staff ID], RTRIM(StaffName)[Staff Name], RTRIM(BasicSalary)[Basic Salary] from Employee where Active='Yes' order by Staffname ";
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                cmbStaffID.Text = dr.Cells[0].Value.ToString();
                txtStaffName.Text = dr.Cells[1].Value.ToString();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT basicsalary from Employee WHERE StaffID = '" + dr.Cells[0].Value.ToString() + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtBasicSalary.Text = rdr.GetInt32(0).ToString();

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

        private void txtDeduction_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (int.Parse(txtDeduction.Text) > int.Parse(txtBasicSalary.Text))
                {
                    MessageBox.Show("Deduction can not be more than Basic Salary", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDeduction.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSalaryPaymentRecord1 frm = new frmSalaryPaymentRecord1();
            frm.label1.Text = label6.Text;
            frm.label3.Text = label7.Text;
            frm.ShowDialog();
        }

        private void txtPaymentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void txtDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtDeduction_TextChanged(object sender, EventArgs e)
        {

            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtBasicSalary.Text, out val1);
            int.TryParse(txtDeduction.Text, out val2);
            int I = (val1 - val2);
            txtTotalPaid.Text = I.ToString();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update EmployeePayment set StaffId=@d2,DueFees=@d12,basicsalary=@d4,Months=@d10,Year=@d11,PaymentDate=@d5,ModeOfPayment=@d6,PaymentModeDetails=@d7,Deduction=@d8,TotalPaid=@d9,Term=@d13 where PaymentID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "BasicSalary"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "PaymentDate"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Deduction"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "DueFees"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "term"));
                cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                cmd.Parameters["@d2"].Value = cmbStaffID.Text;
                cmd.Parameters["@d4"].Value = Convert.ToInt32(txtBasicSalary.Text);
                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text;
                cmd.Parameters["@d6"].Value = cmbModeOfPayment.Text;
                cmd.Parameters["@d7"].Value = txtPaymentModeDetails.Text;
                cmd.Parameters["@d8"].Value = Convert.ToInt32(txtDeduction.Text);
                cmd.Parameters["@d9"].Value = Convert.ToInt32(txtTotalPaid.Text);
                cmd.Parameters["@d10"].Value = months.Text;
                cmd.Parameters["@d11"].Value = session.Text;
                cmd.Parameters["@d12"].Value = Duepayment.Text;
                cmd.Parameters["@d13"].Value = term.Text;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select StaffID,Months,Year,DueFees from EmployeePayment where StaffID= '" + cmbStaffID.Text + "' and Months='" + months.Text + "' and Year='" + Year.Text + "' order by ID DESC";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label11.Text = rdr["DueFees"].ToString();
                    int val4 = 0;
                    int val5 = 0;
                    int val6 = 0;
                    int.TryParse(label11.Text, out val4);
                    int.TryParse(txtDeduction.Text, out val5);
                    int.TryParse(txtTotalPaid.Text, out val6);
                    if (val4 != 0)
                    {
                        int I = (val4 - (val6 + val5));
                        Duepayment.Text = I.ToString();
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
                    int.TryParse(txtBasicSalary.Text, out val1);
                    int.TryParse(txtDeduction.Text, out val2);
                    int.TryParse(txtTotalPaid.Text, out val3);
                    int I = (val1 - (val2 + val3));
                    Duepayment.Text = I.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSalaryPayment_Shown(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {


                        int yearintconvert1 = 0;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select Months,Year from EmployeePayment where StaffID= '" + row.Cells[0].Value.ToString() + "' order by ID DESC";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            string monthss = rdr["Months"].ToString().Trim();
                            string years = rdr["Year"].ToString().Trim();
                            yearintconvert1 = Convert.ToInt32(years);
                            int monthsintconvert = 0;
                            int monthsintconvert1 = 0;
                            string monthstoinsert = null;
                            string insertyear = null;
                            int yearintconvert = Convert.ToInt32(Year.Text);
                            if (monthss == "Jan") { monthsintconvert = 1; }
                            if (monthss == "Feb") { monthsintconvert = 2; }
                            if (monthss == "Mar") { monthsintconvert = 3; }
                            if (monthss == "Apr") { monthsintconvert = 4; }
                            if (monthss == "May") { monthsintconvert = 5; }
                            if (monthss == "Jun") { monthsintconvert = 6; }
                            if (monthss == "Jul") { monthsintconvert = 7; }
                            if (monthss == "Aug") { monthsintconvert = 8; }
                            if (monthss == "Sep") { monthsintconvert = 9; }
                            if (monthss == "Oct") { monthsintconvert = 10; }
                            if (monthss == "Nov") { monthsintconvert = 11; }
                            if (monthss == "Dec") { monthsintconvert = 12; }
                            if (months.Text == "Jan") { monthsintconvert1 = 1; }
                            if (months.Text == "Feb") { monthsintconvert1 = 2; }
                            if (months.Text == "Mar") { monthsintconvert1 = 3; }
                            if (months.Text == "Apr") { monthsintconvert1 = 4; }
                            if (months.Text == "May") { monthsintconvert1 = 5; }
                            if (months.Text == "Jun") { monthsintconvert1 = 6; }
                            if (months.Text == "Jul") { monthsintconvert1 = 7; }
                            if (months.Text == "Aug") { monthsintconvert1 = 8; }
                            if (months.Text == "Sep") { monthsintconvert1 = 9; }
                            if (months.Text == "Oct") { monthsintconvert1 = 10; }
                            if (months.Text == "Nov") { monthsintconvert1 = 11; }
                            if (months.Text == "Dec") { monthsintconvert1 = 12; }
                            if (months.Text == monthss && Year.Text == years)
                            {

                            }
                            else if (yearintconvert == yearintconvert1 && monthsintconvert1 >= monthsintconvert)
                            {
                                auto();
                                if (monthss == "Jan") { monthstoinsert = "Feb"; }
                                else if (monthss == "Feb") { monthstoinsert = "Mar"; insertyear = Year.Text; }
                                else if (monthss == "Mar") { monthstoinsert = "Apr"; insertyear = Year.Text; }
                                else if (monthss == "Apr") { monthstoinsert = "May"; insertyear = Year.Text; }
                                else if (monthss == "May") { monthstoinsert = "Jun"; insertyear = Year.Text; }
                                else if (monthss == "Jun") { monthstoinsert = "Jul"; insertyear = Year.Text; }
                                else if (monthss == "Jul") { monthstoinsert = "Aug"; insertyear = Year.Text; }
                                else if (monthss == "Aug") { monthstoinsert = "Sep"; insertyear = Year.Text; }
                                else if (monthss == "Sep") { monthstoinsert = "Oct"; insertyear = Year.Text; }
                                else if (monthss == "Oct") { monthstoinsert = "Nov"; insertyear = Year.Text; }
                                else if (monthss == "Nov") { monthstoinsert = "Dec"; insertyear = Year.Text; }
                                else if (monthss == "Dec") { monthstoinsert = "Jan"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb = "insert into EmployeePayment(PaymentId,StaffId,basicsalary,PaymentDate,ModeOfPayment,PaymentModeDetails,Deduction,TotalPaid,Months,Year,DueFees,StaffName,Term,Session,BasicSalary1) VALUES (@d1,@d2,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,'"+term.Text+ "','" + session.Text + "',@d4)";
                                cmd = new SqlCommand(cb);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "BasicSalary"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "PaymentDate"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Deduction"));
                                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Months"));
                                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Year"));
                                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "DueFees"));
                                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "StaffName"));
                                cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                                cmd.Parameters["@d2"].Value = row.Cells[0].Value;
                                cmd.Parameters["@d4"].Value = row.Cells[2].Value;
                                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text;
                                cmd.Parameters["@d6"].Value = "Cash";
                                cmd.Parameters["@d7"].Value = "Auto generated Salary Due paymwents at the End of the months";
                                cmd.Parameters["@d8"].Value = 0;
                                cmd.Parameters["@d9"].Value = 0;
                                cmd.Parameters["@d10"].Value = monthstoinsert;
                                cmd.Parameters["@d11"].Value = insertyear;
                                cmd.Parameters["@d12"].Value = row.Cells[2].Value;
                                cmd.Parameters["@d14"].Value = row.Cells[1].Value;
                                cmd.ExecuteReader();
                                con.Close();
                            }
                            else if (yearintconvert1 < yearintconvert)
                            {
                                auto();
                                if (monthss == "Jan") { monthstoinsert = "Feb"; }
                                else if (monthss == "Feb") { monthstoinsert = "Mar"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Mar") { monthstoinsert = "Apr"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Apr") { monthstoinsert = "May"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "May") { monthstoinsert = "Jun"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Jun") { monthstoinsert = "Jul"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Jul") { monthstoinsert = "Aug"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Aug") { monthstoinsert = "Sep"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Sep") { monthstoinsert = "Oct"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Oct") { monthstoinsert = "Nov"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Nov") { monthstoinsert = "Dec"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                else if (monthss == "Dec") { monthstoinsert = "Jan"; insertyear = (Convert.ToInt32(Year.Text) + 1).ToString(); }
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb = "insert into EmployeePayment(PaymentId,StaffId,basicsalary,PaymentDate,ModeOfPayment,PaymentModeDetails,Deduction,TotalPaid,Months,Year,DueFees,StaffName) VALUES (@d1,@d2,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,'" + term.Text + "','" + session.Text + "',@d4)";
                                cmd = new SqlCommand(cb);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PaymentID"));
                                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "StaffID"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "BasicSalary"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 30, "PaymentDate"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 10, "Deduction"));
                                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "Months"));
                                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "Year"));
                                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "DueFees"));
                                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 50, "StaffName"));
                                cmd.Parameters["@d1"].Value = txtPaymentID.Text;
                                cmd.Parameters["@d2"].Value = row.Cells[0].Value;
                                cmd.Parameters["@d4"].Value = row.Cells[2].Value;
                                cmd.Parameters["@d5"].Value = dtpPaymentDate.Text;
                                cmd.Parameters["@d6"].Value = "Cash";
                                cmd.Parameters["@d7"].Value = "Auto generated Salary Due paymwents at the End of the months";
                                cmd.Parameters["@d8"].Value = 0;
                                cmd.Parameters["@d9"].Value = 0;
                                cmd.Parameters["@d10"].Value = monthstoinsert;
                                cmd.Parameters["@d11"].Value = insertyear;
                                cmd.Parameters["@d12"].Value = row.Cells[2].Value;
                                cmd.Parameters["@d14"].Value = row.Cells[1].Value;
                                cmd.ExecuteReader();
                                con.Close();
                            }

                        }
                    }
                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void Year_TextChanged(object sender, EventArgs e)
        {
            term.Items.Clear();
            term.Text = "";
            SqlDataReader rdr = null;
            //Term.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Semester) from Batch where Session='" + session.Text + "' order by BatchID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    term.Text = rdr[0].ToString();
                    term.Items.Add(rdr[0]);
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

        private void Years_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
