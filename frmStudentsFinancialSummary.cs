using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace College_Management_System
{
    public partial class frmStudentsFinancialSummary : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmStudentsFinancialSummary()
        {
            InitializeComponent();
        }

        private void frmStudentsFinancialSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.UserType.Text = label1.Text;
            frm.User.Text = label2.Text;
            frm.Show();
        }
        private void Autocompleteyear()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Session) FROM Batch", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                year.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    year.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompleteTerm()
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
                term.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    term.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompleteStudent()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(ScholarNo) FROM Student where Session='"+year.Text+"' and Term='"+term.Text+"'", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                studentno.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    studentno.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmStudentsFinancialSummary_Load(object sender, EventArgs e)
        {
            AutocompleteTerm();
            Autocompleteyear();
          
        }
      
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from FeePayment where Year='" + year.Text + "' and Semester='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  TotalFees from FeePayment where Year='" + year.Text + "' and Semester='" + term.Text + "' and ScholarNo='"+studentno.Text+"'", con);
                    schoolpayablefees.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    schoolpayablefees.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from FeePayment where Year='" + year.Text + "' and Semester='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from FeePayment where Year='" + year.Text + "' and Semester='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                    schooltotalpaid.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select TotalPaid from ScholarshipPayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select  Amount from ScholarshipPayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                            schoolpayablefees.Text = cmd.ExecuteScalar().ToString();
                            con.Close();
                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                        }
                        else
                        {
                            schoolpayablefees.Text = "0";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select TotalPaid from ScholarshipPayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select SUM(TotalPaid) from ScholarshipPayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                            schooltotalpaid.Text = cmd.ExecuteScalar().ToString();
                            con.Close();
                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                        }
                        else
                        {
                            schooltotalpaid.Text = "0";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    schoolduepayment.Text = ((Convert.ToInt32(schoolpayablefees.Text)) - (Convert.ToInt32(schooltotalpaid.Text))).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            schoolduepayment.Text = ((Convert.ToInt32(schoolpayablefees.Text)) - (Convert.ToInt32(schooltotalpaid.Text))).ToString();
            //////////////////////////////////////////////////
           
            ///////////////////////////////////////////
             try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from HostelFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  HostelFees from HostelFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='"+studentno.Text+"'", con);
                    hostelpayablefees.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    hostelpayablefees.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from HostelFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from HostelFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                    hosteltotalpaid.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    hosteltotalpaid.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hostelduepayment.Text = ((Convert.ToInt32(hostelpayablefees.Text)) - (Convert.ToInt32(hosteltotalpaid.Text))).ToString();
            ////////////////////////////////////////////////////

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from BusFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  BusCharges from BusFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                    transportpayablefees.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    transportpayablefees.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from BusFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from BusFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "' and ScholarNo='" + studentno.Text + "'", con);
                    transporttotalpaid.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    transporttotalpaid.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            transportduepayment.Text = ((Convert.ToInt32(transportpayablefees.Text)) - (Convert.ToInt32(transporttotalpaid.Text))).ToString();

            totalpayablefees.Text=((Convert.ToInt32(schoolpayablefees.Text))+(Convert.ToInt32(hostelpayablefees.Text))+(Convert.ToInt32(transportpayablefees.Text))).ToString();
            totalfeespaid.Text = ((Convert.ToInt32(schooltotalpaid.Text)) + (Convert.ToInt32(hosteltotalpaid.Text)) + (Convert.ToInt32(transporttotalpaid.Text))).ToString();
            totalduepayment.Text = ((Convert.ToInt32(totalpayablefees.Text)) - (Convert.ToInt32(totalfeespaid.Text))).ToString();
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            term.Enabled = true;
        }

        private void term_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentno.Enabled = true;
            AutocompleteStudent();
        }
        private void Reset()
        {
            year.Text = "";
            term.Text="";
            studentno.Text="";
            schoolduepayment.Text = "";
            schoolpayablefees.Text = "";
            schooltotalpaid.Text = "";
            hostelduepayment.Text = "";
            hosteltotalpaid.Text = "";
            hostelpayablefees.Text = "";
            transportduepayment.Text = "";
            transportpayablefees.Text = "";
            transporttotalpaid.Text = "";
            totalduepayment.Text = "";
            totalfeespaid.Text = "";
            totalpayablefees.Text = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                    this.Hide();
                    Cursor = Cursors.WaitCursor;
                    timer1.Enabled = true;
                    rptStudents_Financial_Summary rpt = new rptStudents_Financial_Summary(); //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    cms_purchases myDS = new cms_purchases(); //The DataSet you created.
                    frmStudentsFeesPaymentSummaryReport frm = new frmStudentsFeesPaymentSummaryReport();
                    frm.label1.Text = label1.Text;
                    frm.label2.Text = label2.Text;
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "select  * from Purchases";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "Purchases");
                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("year", year.Text.ToString());
                    rpt.SetParameterValue("term", term.Text.ToString());
                    rpt.SetParameterValue("studentno", studentno.Text.ToString());
                    rpt.SetParameterValue("feespayable", schoolpayablefees.Text.ToString());
                    rpt.SetParameterValue("feespaid", schooltotalpaid.Text.ToString());
                    rpt.SetParameterValue("feesdue", schoolduepayment.Text.ToString());
                    rpt.SetParameterValue("hostelpayable", hostelpayablefees.Text.ToString());
                    rpt.SetParameterValue("hostelpaid", hosteltotalpaid.Text.ToString());
                    rpt.SetParameterValue("hosteldue", hostelduepayment.Text.ToString());
                    rpt.SetParameterValue("transportpayable", transportpayablefees.Text.ToString());
                    rpt.SetParameterValue("transportpaid", transporttotalpaid.Text.ToString());
                    rpt.SetParameterValue("transportdue", transportduepayment.Text.ToString());
                    rpt.SetParameterValue("totalpayable", totalpayablefees.Text.ToString());
                    rpt.SetParameterValue("totalpaid", totalfeespaid.Text);
                    rpt.SetParameterValue("totaldue", totalduepayment.Text);
                    frm.crystalReportViewer1.ReportSource = rpt;
                    frm.Show();
                }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }
    }
}
