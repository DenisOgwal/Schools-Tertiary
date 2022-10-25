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
using System.Reflection;
namespace College_Management_System
{
    public partial class frmSetOrder7 : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmSetOrder7()
        {
            InitializeComponent();
        }
       
        string monthss = DateTime.Today.Month.ToString();
        string days = DateTime.Today.Day.ToString();
        string yearss = DateTime.Today.Year.ToString();
        private void auto()
        {
            string years = yearss.Substring(2, 2);
            purchaseid.Text = "AOID" + years + monthss + days + GetUniqueKey(5);
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
            dynamic SelectQry = "SELECT RTRIM(PriceID)[Price ID],RTRIM(PropertyName)[Hostel Name],RTRIM(quantity)[Quantity],RTRIM(units)[Unit],RTRIM(PriceDate)[Order Date],RTRIM(Price)[Price],RTRIM(description)[Description] FROM LodgeOrders order by ID DESC ";
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
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        private void FeesDetails_Load(object sender, EventArgs e)
        {
           
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(HostelName) FROM Hostel", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                propertys.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    propertys.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            dataGridView1.DataSource = GetData();
            try
            {
                string prices = null;
                string pricess = null;
                string pricesss = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label13.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["deletes"].ToString().Trim();
                    pricess = rdr["updates"].ToString().Trim();
                    pricesss = rdr["Records"].ToString().Trim();
                    if (prices == "Yes") { buttonX3.Enabled = true; }
                    if (pricess == "Yes") { buttonX4.Enabled = true; }
                  
                }
                if (label13.Text == "ADMIN")
                {
                    buttonX3.Enabled = true;
                    buttonX4.Enabled = true;
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }


        private void Reset()
        {
            this.Hide();
            frmSetOrder7 frm = new frmSetOrder7();
            frm.label13.Text = label13.Text;
            frm.ShowDialog();
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
           
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from LodgeOrders where PriceID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 15, "PriceID"));
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

        private void frmPurchaseDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmMainMenu frm = new frmMainMenu();
            this.Hide();
            //Reset();
            /*frm.UserType.Text = label13.Text;
            frm.User.Text = label21.Text;
            frm.Show();*/
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

       

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
            Reset();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {

              
                if (propertys.Text == "")
                {
                    MessageBox.Show("Please Select Property", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    propertys.Focus();
                    return;
                }
                if (Price.Text == "")
                {
                    MessageBox.Show("Please enter Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Price.Focus();
                    return;
                }
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(true))
                        {
                       
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select quantity,units,Pricedate,description from LodgeOrders where  units= '" + row.Cells[1].Value + "' and PropertyName='"+propertys.Text+"' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                
                            }
                            else
                            {
                                auto();
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct1 = "select PriceID from LodgeOrders where PriceID=@find";
                                cmd = new SqlCommand(ct1);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 15, "PriceID"));
                                cmd.Parameters["@find"].Value = purchaseid.Text;
                                rdr = cmd.ExecuteReader();
                                if (rdr.Read())
                                {
                                    //MessageBox.Show("Order ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    purchaseid.Text = "";
                                    if ((rdr != null))
                                    {
                                        rdr.Close();
                                    }
                                    //return;
                                    auto();
                                }
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string cb = "insert into LodgeOrders(PriceID,quantity,units,PriceDate,description,Price,PropertyName) VALUES (@d1,@d3,@d4,@d6,@d5,@d7,@d8)";
                                cmd = new SqlCommand(cb);
                                cmd.Connection = con;
                                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PriceID"));
                                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 10, "quantity"));
                                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "units"));
                                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 200, "description"));
                                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "PriceDate"));
                                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 30, "Price"));
                                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 50, "PropertyName"));
                                cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                                cmd.Parameters["@d3"].Value = 1;
                                cmd.Parameters["@d4"].Value = row.Cells[1].Value;
                                cmd.Parameters["@d5"].Value = description.Text;
                                cmd.Parameters["@d6"].Value = Purchasedate.Text.Trim();
                                cmd.Parameters["@d7"].Value = Price.Value;
                                cmd.Parameters["@d8"].Value = propertys.Text;
                                cmd.ExecuteNonQuery();
                                dataGridView1.DataSource = GetData();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
                dataGridView1.DataSource = GetData();
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (propertys.Text == "")
                {
                    MessageBox.Show("Please Select Property", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    propertys.Focus();
                    return;
                }
                if (Price.Text == "")
                {
                    MessageBox.Show("Please enter Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Price.Focus();
                    return;
                }
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(true))
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "update LodgeOrders set Price=@d7, quantity=@d3,units=@d4,description=@d5,PriceDate=@d6 where PriceID=@d1";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "PriceID"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.Int, 10, "quantity"));
                            cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "units"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 200, "description"));
                            cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "PriceDate"));
                            cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.Int, 30, "Price"));

                            cmd.Parameters["@d1"].Value = purchaseid.Text.Trim();
                            cmd.Parameters["@d3"].Value = 1;
                            cmd.Parameters["@d4"].Value = row.Cells[1].Value;
                            cmd.Parameters["@d5"].Value = description.Text;
                            cmd.Parameters["@d6"].Value = Purchasedate.Text.Trim();
                            cmd.Parameters["@d7"].Value = Price.Value;
                            cmd.ExecuteNonQuery();
                            dataGridView1.DataSource = GetData();
                        }
                    }
                  
                    MessageBox.Show("Successfully updated", "Order Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                purchaseid.Text = dr.Cells[0].Value.ToString();
                propertys.Text = dr.Cells[1].Value.ToString();
                Price.Text = dr.Cells[3].Value.ToString();
                description.Text = dr.Cells[7].Value.ToString();
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
                        if (prices == "Yes") { buttonX3.Enabled = true; } else { buttonX3.Enabled = false; }
                        if (pricess == "Yes") { buttonX4.Enabled = true; } else { buttonX4.Enabled = false; }
                    }
                    if (label13.Text == "ADMIN")
                    {
                        buttonX3.Enabled = true;
                        buttonX4.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void product_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void propertys_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(BedNumber)[Unit],RTRIM(PropertyName)[Hostel] from Beds where PropertyName='" + propertys.Text + "' order by BedID Asc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Beds");
                dataGridView2.DataSource = myDataSet.Tables["Beds"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void units_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}

