using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;

namespace College_Management_System
{
    public partial class frmEXpenses :Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlCommand cmd2 = null;
        SqlDataReader rdr2 = null;
        ConnectionString cs = new ConnectionString();
        SqlDataAdapter adp;
        string companyname = null;
        string companyemail = null;
        string companyaddress = null;
        string companycontact = null;
        string companyslogan = null;
        public frmEXpenses()
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
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            expenseid.Text = "EX-" + years + monthss + days + GetUniqueKey(5);
        }
        public void dataload() {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Comment)[Comment], RTRIM(ExpenseID)[Expense ID], RTRIM(CashierID)[Cashier Name],RTRIM(Year)[Year], RTRIM(Months)[Months], RTRIM(Date)[Date],RTRIM(Expense)[Paid For],RTRIM(Cost)[Cost],RTRIM(TotalPaid)[Total Paid], RTRIM(Duepayment)[Due Payment],RTRIM(Description)[Description], RTRIM(Payee)[Names of Payee],RTRIM(Telephone)[Telephone No. ], RTRIM(Expenses.Email)[Email Address], RTRIM(Expenses.Address)[ Address], RTRIM(Paid)[Payment], RTRIM(ExpenseType)[Expense Type], RTRIM(ModeOfPayment)[Mode Of Payment] from Expenses where LoanID ='N/A'  order by Expenses.ID DESC", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Expenses");
                dataGridViewX1.DataSource = myDataSet.Tables["Expenses"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }
        private void AutocompleteStaffName()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Expense) FROM ExpensesType", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                expensetype.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    expensetype.Items.Add(drow[0].ToString());
                }
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmEXpenses_Load(object sender, EventArgs e)
        {
            /*Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;*/
            dataload();
            AutocompleteStaffName();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label1.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                }
                if (label1.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
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
            expenseid.Text = "";
            year.Text = DateTime.Today.ToString();
            months.Text = DateTime.Today.ToString();
            expensedate.Text = DateTime.Today.ToString();
            description.Text = "";
            cost.Text = null;
            names.Text = "";
            address.Text = "";
            tel.Text = null;
            email.Text = "";
            service.Text = "";
            expensetype.Text = "";
            buttonX5.Enabled = true;
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEXpenses frm = new frmEXpenses();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

        private void email_Validating(object sender, CancelEventArgs e)
        {
            if (email.Text == "" || email.Text == "N/A" || email.Text == "n/a")
            {
            }else{
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (email.Text.Length > 0)
            {
                if (!rEMail.IsMatch(email.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    email.SelectAll();
                    e.Cancel = true;
                }
            }
            }
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
                    companyaddress = rdr.GetString(7).Trim();
                    companyslogan = rdr.GetString(2).Trim();
                    companycontact = rdr.GetString(4).Trim();
                    companyemail = rdr.GetString(3).Trim();
                }
                else
                {
                
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (expensetype.Text == "")
            {
                MessageBox.Show("Please enter Expense Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expensetype.Focus();
                return;
            }
           
            if (cost.Text == "")
            {
                MessageBox.Show("Please enter Cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cost.Focus();
                return;
            }
            if (year.Text == "")
            {
                MessageBox.Show("Please enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                year.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Duepayment from Expenses where ExpenseID='"+expenseid.Text+"'order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (expenseid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expenseid.Focus();
                        return;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "update Expenses set Duepayment=@d9 where ExpenseID=@d1";
                    cmd = new SqlCommand(cb3);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = label1.Text.Trim();
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = Convert.ToInt32(0);
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(tel.Text);
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Expenses(ExpenseID,CashierID,Year,Months,Date,Expense,Cost,TotalPaid,Duepayment,Description,Payee,Telephone,Email,Address,Comment,Paid,ExpenseType,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,'"+cmbModeOfPayment.Text+"')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 30, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Paid"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 50, "ExpenseType"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = label1.Text;
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(0);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = 0;
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = tel.Text;
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.Parameters["@d15"].Value = "Pending Approval";
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d17"].Value = expensetype.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    auto();
                    if (expenseid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expenseid.Focus();
                        return;
                    }
                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Expenses(ExpenseID,CashierID,Year,Months,Date,Expense,Cost,TotalPaid,Duepayment,Description,Payee,Telephone,Email,Address,Comment,Paid,ExpenseType,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,'"+cmbModeOfPayment.Text+"')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 30, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Paid"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 50, "ExpenseType"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = label1.Text;
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = 0;
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = tel.Text;
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.Parameters["@d15"].Value = "Pending Approval";
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d17"].Value = expensetype.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                buttonX5.Enabled = false;
                dataload();
                dataGridViewX1.Refresh();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmEXpenses frm2 = new frmEXpenses();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
        }

        private void managername_TextChanged(object sender, EventArgs e)
        {
            //comment.Enabled = true;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            try
            {
                int RowsAffected = 0;
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete  from  Expenses where ExpenseID=@DELETE1 and Comment !='Approved'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                cmd.Parameters["@DELETE1"].Value = expenseid.Text;
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ExpenseID from Expenses where ExpenseID=@find and Comment='Approved'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                cmd.Parameters["@find"].Value = expenseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to Update..Once Approved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Expenses set Year=@d3,Months=@d4,Date=@d5,Expense=@d6,Cost=@d7,TotalPaid=@d8,Duepayment=@d9,Description=@d10,Payee=@d11,Telephone=@d12,Email=@d13,Address=@d14 where ExpenseID=@d1 and Comment!='Approved'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "CashierID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                cmd.Parameters["@d2"].Value =label1.Text.Trim();
                cmd.Parameters["@d3"].Value = year.Text.Trim();
                cmd.Parameters["@d4"].Value = months.Text.Trim();
                cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                cmd.Parameters["@d6"].Value = service.Text.Trim();
                cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Value);
                cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                cmd.Parameters["@d9"].Value = 0;
                cmd.Parameters["@d10"].Value = description.Text;
                cmd.Parameters["@d11"].Value = names.Text.Trim();
                cmd.Parameters["@d12"].Value = Convert.ToInt32(tel.Text);
                cmd.Parameters["@d13"].Value = email.Text;
                cmd.Parameters["@d14"].Value = address.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (expenseid.Text == "")
            {
                MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expenseid.Focus();
                return;
            }
           
           
        }

        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridViewX1.SelectedRows[0];
                //comment.Text = dr.Cells[0].Value.ToString();
                expenseid.Text = dr.Cells[1].Value.ToString();
              
                expensedate.Text = dr.Cells[5].Value.ToString();
                service.Text = dr.Cells[6].Value.ToString();
                cost.Text = dr.Cells[7].Value.ToString();
                description.Text = dr.Cells[10].Value.ToString();
                names.Text = dr.Cells[11].Value.ToString();
                tel.Text = dr.Cells[12].Value.ToString();
                email.Text = dr.Cells[13].Value.ToString();
                address.Text = dr.Cells[14].Value.ToString();
                expensetype.Text = dr.Cells[16].Value.ToString();
                cmbModeOfPayment.Text = dr.Cells[17].Value.ToString();
               // label3.Text= dr.Cells[0].Value.ToString();
                cost.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        string result = null;
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
       
        private void frmEXpenses_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.User.Text = label1.Text;
            frm.UserType.Text = label2.Text;
            frm.Show();*/
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmExpensesRecord frm = new frmExpensesRecord();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.ShowDialog();
        }

      
        //string printoptionss = Properties.Settings.Default.PrintOptions;
        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (expensetype.Text == "")
            {
                MessageBox.Show("Please enter Expense Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expensetype.Focus();
                return;
            }

           
            if (cost.Text == "")
            {
                MessageBox.Show("Please enter Cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cost.Focus();
                return;
            }
            if (year.Text == "")
            {
                MessageBox.Show("Please enter Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                year.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Duepayment from Expenses where ExpenseID='" + expenseid.Text + "'order by ID Desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (expenseid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expenseid.Focus();
                        return;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb3 = "update Expenses set Duepayment=@d9 where ExpenseID=@d1";
                    cmd = new SqlCommand(cb3);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = label1.Text.Trim();
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = Convert.ToInt32(0);
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = Convert.ToInt32(tel.Text);
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.ExecuteNonQuery();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Expenses(ExpenseID,CashierID,Year,Months,Date,Expense,Cost,TotalPaid,Duepayment,Description,Payee,Telephone,Email,Address,Comment,Paid,ExpenseType,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,'" + cmbModeOfPayment.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 30, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Paid"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 50, "ExpenseType"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = label1.Text;
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(0);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = 0;
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = tel.Text;
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.Parameters["@d15"].Value = "Pending Approval";
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d17"].Value = expensetype.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    auto();
                    if (expenseid.Text == "")
                    {
                        MessageBox.Show("Please enter Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        expenseid.Focus();
                        return;
                    }

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Expenses(ExpenseID,CashierID,Year,Months,Date,Expense,Cost,TotalPaid,Duepayment,Description,Payee,Telephone,Email,Address,Comment,Paid,ExpenseType,ModeOfPayment) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,'" + cmbModeOfPayment.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ExpenseID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "CashierID"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Year"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Months"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 40, "Expense"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 15, "Cost"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.Int, 15, "TotalPaid"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.Int, 15, "Duepayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 200, "Description"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 60, "Payee"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "Telephone"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "Email"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 60, "Address"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 30, "Comment"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "Paid"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 50, "ExpenseType"));
                    cmd.Parameters["@d1"].Value = expenseid.Text.Trim();
                    cmd.Parameters["@d2"].Value = label1.Text;
                    cmd.Parameters["@d3"].Value = year.Text.Trim();
                    cmd.Parameters["@d4"].Value = months.Text.Trim();
                    cmd.Parameters["@d5"].Value = expensedate.Text.Trim();
                    cmd.Parameters["@d6"].Value = service.Text.Trim();
                    cmd.Parameters["@d7"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d8"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d9"].Value = 0;
                    cmd.Parameters["@d10"].Value = description.Text;
                    cmd.Parameters["@d11"].Value = names.Text.Trim();
                    cmd.Parameters["@d12"].Value = tel.Text;
                    cmd.Parameters["@d13"].Value = email.Text;
                    cmd.Parameters["@d14"].Value = address.Text;
                    cmd.Parameters["@d15"].Value = "Pending Approval";
                    cmd.Parameters["@d16"].Value = Convert.ToInt32(cost.Value);
                    cmd.Parameters["@d17"].Value = expensetype.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully saved", "Expense Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();
                company();
                /*try
                {
                    //this.Hide();
                    Cursor = Cursors.WaitCursor;
                    timer1.Enabled = true;
                    rptReceiptExpenses rpt = new rptReceiptExpenses(); //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSet myDS = new DataSet(); //The DataSet you created.
                    Receipt frm = new Receipt();
                    myConnection = new SqlConnection(cs.DBConn);
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select * from Expenses";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Expenses");
                    //myDA.Fill(myDS, "Rights");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("paymentid", expenseid.Text);
                    rpt.SetParameterValue("paidto", names.Text);
                    rpt.SetParameterValue("paidfor", service.Text);
                    rpt.SetParameterValue("ammount", cost.Value);
                    rpt.SetParameterValue("totalpaid", Convert.ToInt32(cost.Value));
                    rpt.SetParameterValue("duepayment", 0);
                    rpt.SetParameterValue("issuedby", cashiername.Text);
                    rpt.SetParameterValue("comanyname", companyname);
                    rpt.SetParameterValue("companyemail", companyemail);
                    rpt.SetParameterValue("companycontact", companycontact);
                    rpt.SetParameterValue("companyslogan", companyslogan);
                    rpt.SetParameterValue("companyaddress", companyaddress);
                    rpt.SetParameterValue("picpath", "logo.jpg");
                    frm.crystalReportViewer1.ReportSource = rpt;
                    myConnection.Close();
                    if (printoptionss == "autoprint")
                    {
                        string BarPrinter = Properties.Settings.Default.frontendprinter;
                        rpt.PrintOptions.PrinterName = BarPrinter;
                        rpt.PrintToPrinter(1, true, 1, 1);
                    }
                    else
                    {
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
                buttonX5.Enabled = false;
                dataload();
                dataGridViewX1.Refresh();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            frmEXpenses frm2 = new frmEXpenses();
            frm2.label1.Text = label1.Text;
            frm2.label2.Text = label2.Text;
            frm2.ShowDialog();
           
        }

    }
}
