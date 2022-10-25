using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmOtherTransaction : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        public String str;
        SqlDataReader rdr = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmOtherTransaction()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtTransactionID.Text = "";
            txtdes.Text = "";
            txtamt.Text = "";
            dtp.Text = DateTime.Today.ToString();
            rbcredit.Checked = false;
            rbdebit.Checked = false;
            btnSave.Enabled = true;
            Delete.Enabled = false;
            Update_record.Enabled = false;
            Year.Text = "";
            term.Text = "";
            paidfor.Text = "";

        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void frmOtherTransaction_Load(object sender, EventArgs e)
        {
            rbcredit.Checked = false;
            rbdebit.Checked = false;
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtamt.Text == "")
            {
                MessageBox.Show("Please enter amount ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtamt.Focus();
                return;
            }
            if (Year.Text == "")
            {
                MessageBox.Show("Please enter Year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Year.Focus();
                return;
            }
            if (term.Text == "")
            {
                MessageBox.Show("Please enter term ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                term.Focus();
                return;
            }

            try
            {
                if (rbdebit.Checked)
                {
                    str = rbdebit.Text;
                }
                if (rbcredit.Checked)
                {
                    str = rbcredit.Text;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into OtherTransaction(TransactionType,Date,Amount,Description,Term,Year,Reason) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "TransactionType"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Amount"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.VarChar, 200, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.VarChar, 10, "Term"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.VarChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 100, "Reason"));
                cmd.Parameters["@d1"].Value = str;
                cmd.Parameters["@d2"].Value = dtp.Text;
                cmd.Parameters["@d3"].Value = txtamt.Text;
                cmd.Parameters["@d4"].Value = txtdes.Text;
                cmd.Parameters["@d5"].Value = term.Text;
                cmd.Parameters["@d6"].Value = Year.Text;
                cmd.Parameters["@d7"].Value = paidfor.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
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
                string cq = "delete from othertransaction where transactionid=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.Int, 10, "TransactionID"));
                cmd.Parameters["@DELETE1"].Value = Convert.ToInt32(txtTransactionID.Text);
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

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbdebit.Checked)
                {
                    str = rbdebit.Text;
                }
                if (rbcredit.Checked)
                {
                    str = rbcredit.Text;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update OtherTransaction set TransactionType=@d1,Date=@d2,Amount=@d3,Description=@d4,Term=@d5,Year=@d6 where TransactionType=@d1  and Date=@d2 and Year=@d6 and Term=@d5";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 10, "TransactionType"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Date"));
                cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "Amount"));
                cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.VarChar, 200, "Description"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.VarChar, 10, "Term"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.VarChar, 10, "Year"));
                cmd.Parameters["@d1"].Value = str;
                cmd.Parameters["@d2"].Value = dtp.Text;
                cmd.Parameters["@d3"].Value = txtamt.Text;
                cmd.Parameters["@d4"].Value = txtdes.Text;
                cmd.Parameters["@d5"].Value = term.Text;
                cmd.Parameters["@d6"].Value = Year.Text;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTransactionRecord1 frm = new frmTransactionRecord1();
            frm.label1.Text = label4.Text;
            frm.ShowDialog();
        }

        private void txtamt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rbcredit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ScholarNo_TextChanged(object sender, EventArgs e)
        {
            term.Text = "";
            SqlDataReader rdr = null;
            //Term.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Semester) from Batch where Session='" + Year.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
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
    }
    }

