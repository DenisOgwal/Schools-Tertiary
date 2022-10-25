using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmPurchaseDetails : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmPurchaseDetails()
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
        private void auto()
        {
            purchaseid.Text = "PR-" + GetUniqueKey(5);
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
                if (unitcost.Text == "")
                {
                    MessageBox.Show("Please enter unit costs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    unitcost.Focus();
                    return;
                }
                if (department.Text == "")
                {
                    MessageBox.Show("Please enter  department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    department.Focus();
                    return;
                }
                if (itemtype.Text == "")
                {
                    MessageBox.Show("Please Select Item Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    itemtype.Focus();
                    return;
                }
                if (product.Text == "")
                {
                    MessageBox.Show("Please enter product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (supplier.Text == "")
                {
                    MessageBox.Show("Please enter  supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    supplier.Focus();
                    return;
                }
                if (manufacturer.Text == "")
                {
                    MessageBox.Show("Please enter manufacturer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    manufacturer.Focus();
                    return;
                }
                if (standards.Text == "")
                {
                    MessageBox.Show("Please enter standards", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    standards.Focus();
                    return;
                }
                if (Noperunit.Text == "")
                {
                    MessageBox.Show("Please enter unit costs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Noperunit.Focus();
                    return;
                }
                if (Minorunits.Text == "")
                {
                    MessageBox.Show("Please enter  department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Minorunits.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select year,term,product,quantity,units,quality,department,supplier,purchasedate from Purchases where year= '" + year.Text + "' and term = '" + term.Text + "' and purchasedate= '" + Purchasedate.Text + "' and quality='" + Quality.Text + "' and quantity='"+Quantity.Text+"'";
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
                total.Text = (int.Parse(unitcost.Text) * int.Parse(Quantity.Text)).ToString();
                auto();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "select purchaseid from Purchases where purchaseid=@find";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "purchaseid"));
                cmd.Parameters["@find"].Value = purchaseid.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("purchase ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    purchaseid.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Purchases(purchaseid,year,term,employeeid,employeename,product,quantity,units,quality,unitcost,department,supplier,manufacturer,standards,totalcost,manufacturedate,purchasedate,expirydate,Noperunit,MinorUnits,ItemType) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,'"+itemtype.Text+"')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "purchaseidd"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "term"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 15, "employeeid"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "employeename"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "product"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "quantity"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "units"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30,  "quality"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 10, "unitcost"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "department"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 50, "supplier"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "manufacturer"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 20, "standards"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.Int, 30, "totalcost"));
                cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 30, "manufacturedate"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 30, "purchasedate"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 30, "expirydate"));
                cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.Int, 15, "Noperunit"));
                cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 15, "MinorUnits"));

                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = term.Text.Trim();
                cmd.Parameters["@d4"].Value = employeeid.Text.Trim();
                cmd.Parameters["@d5"].Value = employeename.Text.Trim();
                cmd.Parameters["@d6"].Value = product.Text.Trim();
                cmd.Parameters["@d7"].Value = (Quantity.Text);
                cmd.Parameters["@d8"].Value = units.Text.Trim();
                cmd.Parameters["@d9"].Value = Quality.Text.Trim();
                cmd.Parameters["@d10"].Value =(unitcost.Text);
                cmd.Parameters["@d11"].Value = department.Text.Trim();
                cmd.Parameters["@d12"].Value = supplier.Text.Trim();
                cmd.Parameters["@d13"].Value = manufacturer.Text.Trim();
                cmd.Parameters["@d14"].Value = standards.Text.Trim();
                cmd.Parameters["@d15"].Value = (total.Text);
                cmd.Parameters["@d16"].Value = manufacturedate.Text.Trim();
                cmd.Parameters["@d17"].Value = Purchasedate.Text.Trim();
                cmd.Parameters["@d18"].Value = expirydate.Text.Trim();
                cmd.Parameters["@d19"].Value = (Noperunit.Text);
                cmd.Parameters["@d20"].Value = Minorunits.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "insert into SupplierAccountTransactions(AccountNumber,TransactionID,Reason,Ammount,Date,Product,Quantity) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "AccountNumber"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "TransactionID"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 100, "Reason"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.Int, 10, "Ammount"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 20, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "Product"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "Quantity"));
                cmd.Parameters["@d1"].Value = supplier.Text;
                cmd.Parameters["@d2"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d3"].Value = product.Text + " Purchase on " + DateTime.Now;
                cmd.Parameters["@d4"].Value = total.Text;
                cmd.Parameters["@d5"].Value = Purchasedate.Text;
                cmd.Parameters["@d6"].Value = product.Text;
                cmd.Parameters["@d7"].Value = Quantity.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Purchases Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Noperunit.Text = "";
            Minorunits.Text = "";
            purchaseid.Text = "";
            product.Text = "";
            year.Text = "";
            term.Text = "";
            unitcost.Text = "";
            Quality.Text = "";
            department.Text = "";
            Quantity.Text = "";
            supplier.Text = "";
            units.Text = "";
            standards.Text = "";
            employeeid.Text = "";
            employeename.Text = "";
            manufacturer.Text = "";
            itemtype.Text = "";
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
                if (unitcost.Text == "")
                {
                    MessageBox.Show("Please enter unit costs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    unitcost.Focus();
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
                    MessageBox.Show("Please enter product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (supplier.Text == "")
                {
                    MessageBox.Show("Please enter  supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    supplier.Focus();
                    return;
                }
                if (manufacturer.Text == "")
                {
                    MessageBox.Show("Please enter manufacturer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    manufacturer.Focus();
                    return;
                }
                if (standards.Text == "")
                {
                    MessageBox.Show("Please enter standards", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    standards.Focus();
                    return;
                }
              
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Purchases set ItemType='"+itemtype.Text+"',year=@d2,term=@d3,employeeid=@d4,employeename=@d5,product=@d6,quantity=@d7,units=@d8,quality=@d9,unitcost=@d10,department=@d11, supplier=@d12,manufacturer=@d13,standards=@d14,totalcost=@d15, manufacturedate=@d16,purchasedate=@d16, expirydate=@d17 where Purchaseid=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "purchaseidd"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "year"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "term"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 15, "employeeid"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "employeename"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 50, "product"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 10, "quantity"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 20, "units"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "quality"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 10, "unitcost"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 50, "department"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 50, "supplier"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 50, "manufacturer"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 20, "standards"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.Int, 30, "totalcost"));
                cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 30, "manufacturedate"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 30, "purchasedate"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 30, "expirydate"));

                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                cmd.Parameters["@d2"].Value = year.Text.Trim();
                cmd.Parameters["@d3"].Value = term.Text.Trim();
                cmd.Parameters["@d4"].Value = employeeid.Text.Trim();
                cmd.Parameters["@d5"].Value = employeename.Text.Trim();
                cmd.Parameters["@d6"].Value = product.Text.Trim();
                cmd.Parameters["@d7"].Value = (Quantity.Text);
                cmd.Parameters["@d8"].Value = units.Text.Trim();
                cmd.Parameters["@d9"].Value = Quality.Text.Trim();
                cmd.Parameters["@d10"].Value = (unitcost.Text);
                cmd.Parameters["@d11"].Value = department.Text.Trim();
                cmd.Parameters["@d12"].Value = supplier.Text.Trim();
                cmd.Parameters["@d13"].Value = manufacturer.Text.Trim();
                cmd.Parameters["@d14"].Value = standards.Text.Trim();
                cmd.Parameters["@d15"].Value = (total.Text);
                cmd.Parameters["@d16"].Value = manufacturedate.Text.Trim();
                cmd.Parameters["@d17"].Value = Purchasedate.Text.Trim();
                cmd.Parameters["@d18"].Value = expirydate.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Purchases Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string ct = "select Purchaseid from Purchases where Purchaseid=@find";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "Purchaseid"));
                cmd.Parameters["@find"].Value = purchaseid.Text;
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
                string cq = "delete from Purchases where Purchaseid=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "purchaseid"));
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
            frmPurchasesDetailsRecord frm = new frmPurchasesDetailsRecord();
            this.Hide();
            Reset();
            frm.label13.Text = label13.Text;
            frm.label14.Text = label21.Text;
            frm.ShowDialog();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            frmPurchasesDetailsRecord frm = new frmPurchasesDetailsRecord();
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

        private void Quality_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void unitcost_KeyPress(object sender, KeyPressEventArgs e)
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


        private void frmPurchaseDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*frmMainMenu frm = new frmMainMenu();
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

        private void Quality_TextChanged(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmItemUsageBalance frm = new frmItemUsageBalance();
            frm.label13.Text = label13.Text;
            frm.label14.Text = label21.Text;
            frm.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void supplier_Click(object sender, EventArgs e)
        {
            frmSupplierDetails frm = new frmSupplierDetails();
            frm.ShowDialog();
            this.supplier.Text = frm.clientnames.Text;
            this.label25.Text = frm.clientcontact.Text;
            return;
        }
    }

}

