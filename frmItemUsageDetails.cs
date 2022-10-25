using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmItemUsageDetails : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmItemUsageDetails()
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
        private void AutocompleCourse2()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(product) from Purchases ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    product.Items.Add(rdr[0]);
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
            purchaseid.Text = "IU-" + GetUniqueKey(5);
        }

        private void FeesDetails_Load(object sender, EventArgs e)
        {
            AutocompleCourse();
            AutocompleCourse2();
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label21.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { Delete.Enabled = true; } else { Delete.Enabled = false; }
                    if (pricess == "Yes") { Update_record.Enabled = true; } else { Update_record.Enabled = false; }
                }
                if (label21.Text == "ADMIN")
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
                if (year.Text == "")
                {
                    MessageBox.Show("Please select year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    year.Focus();
                    return;
                }
                if (term.Text == "")
                {
                    MessageBox.Show("Please select term", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    term.Focus();
                    return;
                }
                if (employeeid.Text == "")
                {
                    MessageBox.Show("Please Enter Enployee id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    employeeid.Focus();
                    return;
                }
                if (department.Text == "")
                {
                    MessageBox.Show("Please enter  department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    department.Focus();
                    return;
                }
                if (product.Text == "")
                {
                    MessageBox.Show("Please select product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    product.Focus();
                    return;
                }
                if (Quality.Text == "")
                {
                    MessageBox.Show("Please enter Product Quality", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Quality.Focus();
                    return;
                }
                if (units.Text == "")
                {
                    MessageBox.Show("Please Select units", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    units.Focus();
                    return;
                }
                if (description.Text == "")
                {
                    MessageBox.Show("Please enter  Usage Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    description.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select year,term,product,quantity,units,quality,department,usagedate,description from ItemUsage where year= '" + year.Text + "' and term = '" + term.Text + "' and usagedate= '" + Purchasedate.Text + "' and description= '" + description.Text + "' and quality='" + Quality.Text + "' ";
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
                string ct1 = "select UsageID from ItemUsage where UsageID=@find";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "UsageID"));
                cmd.Parameters["@find"].Value = purchaseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Usage ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    purchaseid.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into ItemUsage(UsageID,year,term,employeeid,employeename,product,quantity,units,quality,department,description,balance,usagedate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "UsageID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "term"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 15, "employeeid"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "employeename"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "product"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "quantity"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "units"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "quality"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 50, "department"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 200, "description"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 30, "balance"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 30, "usagedate"));

                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = term.Text.Trim();
                cmd.Parameters["@d4"].Value = employeeid.Text.Trim();
                cmd.Parameters["@d5"].Value = employeename.Text.Trim();
                cmd.Parameters["@d6"].Value = product.Text.Trim();
                cmd.Parameters["@d7"].Value = (Quantity.Text);
                cmd.Parameters["@d8"].Value = units.Text.Trim();
                cmd.Parameters["@d9"].Value = Quality.Text.Trim();
                cmd.Parameters["@d10"].Value = department.Text.Trim();
                cmd.Parameters["@d11"].Value = description.Text;
                cmd.Parameters["@d12"].Value = (balance.Text);
                cmd.Parameters["@d13"].Value = Purchasedate.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Usage Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
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
            purchaseid.Text = "";
            product.Text = "";
            year.Text = "";
            term.Text = "";
            Quality.Text = "";
            department.Text = "";
            Quantity.Text = "";
            balance.Text = "";
            units.Text = "";
            description.Text = "";
            employeeid.Text = "";
            employeename.Text = "";
            term.Enabled = false;
            employeeid.Enabled = false;
            employeename.Enabled = false;
            Delete.Enabled = false;
            Update_record.Enabled = false;
            btnSave.Enabled = true;
            year.Focus();
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (year.Text == "")
                {
                    MessageBox.Show("Please select year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    year.Focus();
                    return;
                }
                if (term.Text == "")
                {
                    MessageBox.Show("Please select term", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    term.Focus();
                    return;
                }
                if (employeeid.Text == "")
                {
                    MessageBox.Show("Please Enter Enployee id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    employeeid.Focus();
                    return;
                }
                if (department.Text == "")
                {
                    MessageBox.Show("Please enter  department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    department.Focus();
                    return;
                }
                if (product.Text == "")
                {
                    MessageBox.Show("Please select product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    product.Focus();
                    return;
                }
                if (Quality.Text == "")
                {
                    MessageBox.Show("Please enter Product Quality", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Quality.Focus();
                    return;
                }
                if (units.Text == "")
                {
                    MessageBox.Show("Please Select units", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    units.Focus();
                    return;
                }
                if (description.Text == "")
                {
                    MessageBox.Show("Please enter  product description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    description.Focus();
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update ItemUsage set year=@d2,term=@d3,employeeid=@d4,employeename=@d5,product=@d6,quantity=@d7,units=@d8,quality=@d9,department=@d10, description=@d11,balance=@d12,usagedate=@d13 where UsageID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "UsageID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "term"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 15, "employeeid"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "employeename"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "product"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "quantity"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "units"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "quality"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 50, "department"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 200, "description"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 30, "balance"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 30, "usagedate"));

                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = term.Text.Trim();
                cmd.Parameters["@d4"].Value = employeeid.Text.Trim();
                cmd.Parameters["@d5"].Value = employeename.Text.Trim();
                cmd.Parameters["@d6"].Value = product.Text.Trim();
                cmd.Parameters["@d7"].Value = (Quantity.Text);
                cmd.Parameters["@d8"].Value = units.Text.Trim();
                cmd.Parameters["@d9"].Value = Quality.Text.Trim();
                cmd.Parameters["@d10"].Value = department.Text.Trim();
                cmd.Parameters["@d11"].Value = description.Text;
                cmd.Parameters["@d12"].Value = (balance.Text);
                cmd.Parameters["@d13"].Value = Purchasedate.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Usage Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string cq = "delete from ItemUsage where UsageID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "UsageID"));
                cmd.Parameters["@DELETE1"].Value = purchaseid.Text;
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
            frmItemUsageDetailsRecord frm = new frmItemUsageDetailsRecord();
            this.Hide();
            Reset();
            frm.label13.Text = label13.Text;
            frm.label14.Text = label21.Text;
            frm.ShowDialog();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            frmItemUsageDetailsRecord frm = new frmItemUsageDetailsRecord();
            this.Hide();
            Reset();
            frm.label13.Text = label13.Text;
            frm.label14.Text = label21.Text;
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

        private void year_SelectedIndexChanged(object sender, EventArgs e)
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


        private void frmPurchaseDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* frmMainMenu frm = new frmMainMenu();
            this.Hide();
            Reset();
            frm.UserType.Text = label13.Text;
            frm.User.Text = label21.Text;
            frm.Show();*/
        }

        private void term_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeid.Clear();
            employeeid.Text = "";
            employeeid.Enabled = true;
        }

        private void employeeid_TextChanged(object sender, EventArgs e)
        {

            employeename.Clear();
            employeename.Text = "";
            employeename.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(StaffName) from Employee where StaffID = '" + employeeid.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employeename.Text = rdr.GetString(0).Trim();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void product_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(MinorUnits) from Purchases where product='" + product.Text + "' and year='" + year.Text + "' and term='" + term.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    units.Items.Add(rdr[0]);
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
                string ct = "select distinct RTRIM(quality) from Purchases where product='" + product.Text + "' and year='" + year.Text + "' and term='" + term.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Quality.Text = rdr.GetString(0).Trim();
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
                string ct = "select distinct RTRIM(department) from Purchases where product='" + product.Text + "' and year='" + year.Text + "' and term='" + term.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    department.Text = rdr.GetString(0).Trim();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void units_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                unit.Text = units.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int itembalance = 0;
        private void Quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                balanceexist2();
                balanceexist();
                itembalance = (balanceexists2 *balanceexists2)- balanceexists1;
                int val1 = 0;
                int.TryParse(Quantity.Text, out val1);
                int I = (itembalance - val1);
                balance.Text = I.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int balanceexists1 = 0;
        private int balanceexist()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT SUM(quantity) FROM ItemUsage  WHERE product='" + product.Text + "' and quality='"+Quality.Text+"'";
                cmd = new SqlCommand(inquery3, con);
                label4.Text = cmd.ExecuteScalar().ToString();
                int.TryParse(label4.Text, out balanceexists1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return balanceexists1;
        }
        int balanceexists2 = 0;
        private int balanceexist2()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT SUM(quantity) FROM Purchases  WHERE product='" + product.Text + "' and quality='" + Quality.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                label9.Text = cmd.ExecuteScalar().ToString();
                int.TryParse(label9.Text, out balanceexists2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return balanceexists2;
        }
        int  balanceexists3;
        private int balanceexist3()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT (Noperunit) FROM Purchases  WHERE product='" + product.Text + "' and quality='" + Quality.Text + "' ORDER BY ID DESC";
                cmd = new SqlCommand(inquery3, con);
                label9.Text = cmd.ExecuteScalar().ToString();
                int.TryParse(label11.Text, out balanceexists3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return balanceexists3;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmItemUsageBalance frm = new frmItemUsageBalance();
            frm.label13.Text = label13.Text;
            frm.label14.Text = label21.Text;
            frm.ShowDialog();
        }
    }
}

