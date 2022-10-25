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
    public partial class frmFinancialSummary : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmFinancialSummary()
        {
            InitializeComponent();
        }

        private void frmFinancialSummary_FormClosing(object sender, FormClosingEventArgs e)
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
                year2.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    year.Items.Add(drow[0].ToString());
                    year2.Items.Add(drow[0].ToString());
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
        private void frmFinancialSummary_Load(object sender, EventArgs e)
        {
            Autocompleteyear();
            AutocompleteTerm();
        }

        int s1payablefeessa = 0;
        int s1payablefeess = 0;
        int totals1payablefeess = 0;
        int s1totalpaidd = 0;
        int totals1totalpaidd = 0;
        int s1duepaymentt = 0;
        int s1duepaymenttt = 0;
        int totals1duepayment = 0;
        int total = 0;
      
      /// ///hostel
        int hs1payablefeessa = 0;
        int hs1payablefeess = 0;
        int htotals1payablefeess = 0;
        int hs1totalpaidd = 0;
        int htotals1totalpaidd = 0;
        int hs1duepaymentt = 0;
        int hs1duepaymenttt = 0;
        int htotals1duepayment = 0;
        int htotal = 0;

        /// transport
       
        int ts1payablefeess = 0;
        int ttotals1payablefeess = 0;
        int ts1totalpaidd = 0;
        int ttotals1totalpaidd = 0;
        int ts1duepaymentt = 0;
        int ts1duepaymenttt = 0;
        int ttotals1duepayment = 0;
        // bus hire
        int hts1payablefeess = 0;
        int httotals1payablefeess = 0;
        int hts1totalpaidd = 0;
        int httotals1totalpaidd = 0;
        int hts1duepaymentt = 0;
        int hts1duepaymenttt = 0;
        int httotals1duepayment = 0;
        //scholarship fee
        int stotals1payablefeess = 0;
        int stotals1totalpaidd = 0;
      
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from FeePayment where Year='" + year.Text + "' and Semester='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  COUNT(DISTINCT ScholarNo) from FeePayment where Year='" + year.Text + "' and Semester='" + term.Text + "'", con);
                    s1payablefeessa = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("SELECT Totalfees FROM FeesDetails where Year='" + year.Text + "'and Semester='" + term.Text + "' ", con);
                    total = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    s1payablefeess = total * s1payablefeessa;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    s1payablefeess = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //end of payable for normal fees
            // begining of payable for scholarship
            totals1payablefeess = s1payablefeess;
            schoolfeespayablesummary.Text = totals1payablefeess.ToString();

            //end s.1 totalpayable


            //s.1 total paid
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from FeePayment where Year='" + year.Text + "' and Semester='" + term.Text + "' ", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from FeePayment where Year='" + year.Text + "' and Semester='" + term.Text + "'", con);
                    s1totalpaidd = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    s1totalpaidd = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            totals1totalpaidd = s1totalpaidd;
            shoolfeestotalpaidsummary.Text = totals1totalpaidd.ToString();
            //end s.1 totalpaid

            //start s.1 duepayment
            s1duepaymenttt = Convert.ToInt32(schoolfeespayablesummary.Text);
            s1duepaymentt = Convert.ToInt32(shoolfeestotalpaidsummary.Text);
            totals1duepayment = s1duepaymenttt - s1duepaymentt;
            duepaymentsummary.Text = totals1duepayment.ToString();
             //////////////////////////////////////// end fees payment

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from HostelFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  COUNT(DISTINCT ScholarNo) from Hostelers where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    hs1payablefeessa = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("SELECT HostelFees FROM Hostel ", con);
                    htotal = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    hs1payablefeess = htotal * hs1payablefeessa;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    hs1payablefeess = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            htotals1payablefeess = hs1payablefeess;
            hostelfeespayablesummary.Text = htotals1payablefeess.ToString();

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from HostelFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from HostelFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    hs1totalpaidd = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    hs1totalpaidd = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            htotals1totalpaidd = hs1totalpaidd;
            hosteltotalpaidsummary.Text = htotals1totalpaidd.ToString();
            //end s.1 totalpaid

            //start s.1 duepayment
            hs1duepaymenttt = Convert.ToInt32(hostelfeespayablesummary.Text);
            hs1duepaymentt = Convert.ToInt32(hosteltotalpaidsummary.Text);
            htotals1duepayment = hs1duepaymenttt - hs1duepaymentt;
            hostelduepaymentsummary.Text = htotals1duepayment.ToString();
/////////////////////////////////////////////////end of total hostel fees

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from BusFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  SUM(BusCharges) from BusFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    ts1payablefeess = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    ts1payablefeess = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            ttotals1payablefeess = ts1payablefeess;
            buspayablesummary.Text = ttotals1payablefeess.ToString();

          
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from BusFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from BusFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    ts1totalpaidd = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    ts1totalpaidd = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ttotals1totalpaidd = ts1totalpaidd;
            buspaidsummary.Text = ttotals1totalpaidd.ToString();
            //end s.1 totalpaid

            //start s.1 duepayment
            ts1duepaymenttt = Convert.ToInt32(buspayablesummary.Text);
            ts1duepaymentt = Convert.ToInt32(buspaidsummary.Text);
            ttotals1duepayment = ts1duepaymenttt - ts1duepaymentt;
            busduepaymentsummary.Text = ttotals1duepayment.ToString();

            ////////////////////////////////////////////////// end student bus payment

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select HireTotalPaid from BusHireFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(HireTotalPaid) from BusHireFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    hts1totalpaidd = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    hts1totalpaidd = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             httotals1totalpaidd = hts1totalpaidd;
             bushirepaidsummary.Text = httotals1totalpaidd.ToString();

             try
             {
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 cmd = new SqlCommand("select HireTotalPaid from BusHireFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     cmd = new SqlCommand("select  SUM(HireBusCharges) from BusHireFeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                     hts1payablefeess = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                     con.Close();

                     if ((rdr != null))
                     {
                         rdr.Close();
                     }
                 }
                 else
                 {
                     hts1payablefeess = 0;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

             httotals1payablefeess = hts1payablefeess;
             bushirepayablesummary.Text = httotals1payablefeess.ToString();

             hts1duepaymenttt = Convert.ToInt32(bushirepayablesummary.Text);
             hts1duepaymentt = Convert.ToInt32(bushirepaidsummary.Text);
             httotals1duepayment = hts1duepaymenttt - hts1duepaymentt;
             bushireduepayment.Text = httotals1duepayment.ToString();

            /////////////////////////////////////end of bus hire

             try
             {
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 cmd = new SqlCommand("select TotalPaid from ScholarshipPayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     cmd = new SqlCommand("select SUM(Amount) from ScholarshipPayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                     hs1payablefeess = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                     con.Close();
                     if ((rdr != null))
                     {
                         rdr.Close();
                     }
                 }
                 else
                 {
                     hs1payablefeess = 0;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             htotals1payablefeess = hs1payablefeess;
             scholarshippayablesummary.Text = htotals1payablefeess.ToString();

             //end s.1 totalpayable


             //s.1 total paid
             try
             {
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 cmd = new SqlCommand("select TotalPaid from ScholarshipPayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     cmd = new SqlCommand("select SUM(TotalPaid) from ScholarshipPayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                     hs1totalpaidd = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                     con.Close();
                 }
                 else
                 {
                     hs1totalpaidd = 0;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             htotals1totalpaidd = hs1totalpaidd;
             scholarshippaidsummary.Text = htotals1totalpaidd.ToString();

             hs1duepaymenttt = Convert.ToInt32(scholarshippayablesummary.Text);
             hs1duepaymentt = Convert.ToInt32(scholarshippaidsummary.Text);
             htotals1duepayment = hs1duepaymenttt - hs1duepaymentt;
             scholarshipduepaymentsummary.Text = htotals1duepayment.ToString();

             totalincomespaid.Text = (totals1totalpaidd + htotals1totalpaidd + ttotals1totalpaidd + httotals1totalpaidd + stotals1totalpaidd).ToString();
            totalincomespayable.Text=(totals1payablefeess+htotals1payablefeess+ttotals1payablefeess+httotals1payablefeess+stotals1payablefeess).ToString();
            totalincomesdue.Text = ((Convert.ToInt32(totalincomespayable.Text))-(Convert.ToInt32(totalincomespaid.Text))).ToString();

            ///////////////////////////////////expenditures
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Amount from OtherTransaction where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Amount) from OtherTransaction where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    totalexpenses.Text =cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    totalexpenses.Text = "0";
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
                cmd = new SqlCommand("select totalcost from Purchases where Year='" + year.Text + "' and term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(totalcost) from Purchases where Year='" + year.Text + "' and term='" + term.Text + "'", con);
                    purchasespaidsummary.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    purchasespaidsummary.Text = "0";
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
                cmd = new SqlCommand("select TotalPaid from EmployeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from EmployeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    salarypaidsummary.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    salarypaidsummary.Text = "0";
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
                cmd = new SqlCommand("select BasicSalary from EmployeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(BasicSalary) from EmployeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    salarypayablesummary.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    salarypayablesummary.Text = "0";
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
                cmd = new SqlCommand("select Duefees from EmployeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(DueFees) from EmployeePayment where Year='" + year.Text + "' and Term='" + term.Text + "'", con);
                    salaryduepaymentsummary.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    salaryduepaymentsummary.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            totalpayableexpenditures.Text = (Convert.ToInt32(totalexpenses.Text) + Convert.ToInt32(purchasespaidsummary.Text)+Convert.ToInt32(salarypayablesummary.Text)).ToString();
            totalpaidexpenditures.Text = (Convert.ToInt32(salarypaidsummary.Text) + Convert.ToInt32(totalexpenses.Text) + Convert.ToInt32(purchasespaidsummary.Text)).ToString();
            totalexpendituredues.Text = (Convert.ToInt32(totalpayableexpenditures.Text) - Convert.ToInt32(totalpaidexpenditures.Text)).ToString();

            Profitmargin.Text = ((Convert.ToInt32(totalincomespaid.Text)) - (Convert.ToInt32(totalpaidexpenditures.Text))).ToString();
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            term.Enabled = true;
        }
        private void Reset()
        {
            year.Text = "";
            term.Text = "";
            schoolfeespayablesummary.Text = "";
            shoolfeestotalpaidsummary.Text = "";
            duepaymentsummary.Text = "";
            hostelduepaymentsummary.Text = "";
            hosteltotalpaidsummary.Text = "";
            hostelfeespayablesummary.Text = "";
            busduepaymentsummary.Text = "";
            buspaidsummary.Text = "";
            buspayablesummary.Text = "";
            bushireduepayment.Text = "";
            bushirepaidsummary.Text = "";
            bushirepayablesummary.Text = "";
            scholarshipduepaymentsummary.Text = "";
            scholarshippaidsummary.Text = "";
            scholarshippayablesummary.Text = "";
            totalincomesdue.Text = "";
            totalincomespaid.Text = "";
            totalincomespayable.Text = "";
            totalexpenses.Text = "";
            purchasespaidsummary.Text = "";
            salaryduepaymentsummary.Text = "";
            salarypaidsummary.Text = "";
            salarypayablesummary.Text = "";
            totalpaidexpenditures.Text = "";
            totalpayableexpenditures.Text = "";
            totalexpendituredues.Text = "";
            Profitmargin.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reset();
        }
        int s1payablefeessa1 = 0;
        int s1payablefeess1 = 0;
        int totals1payablefeess1 = 0;
        int s1totalpaidd1 = 0;
        int totals1totalpaidd1 = 0;
        int s1duepaymentt1 = 0;
        int s1duepaymenttt1 = 0;
        int totals1duepayment1 = 0;
        int total1 = 0;

        /// ///hostel
        int hs1payablefeessa1 = 0;
        int hs1payablefeess1 = 0;
        int htotals1payablefeess1 = 0;
        int hs1totalpaidd1 = 0;
        int htotals1totalpaidd1 = 0;
        int hs1duepaymentt1 = 0;
        int hs1duepaymenttt1 = 0;
        int htotals1duepayment1 = 0;
        int htotal1 = 0;

        /// transport

        int ts1payablefeess1 = 0;
        int ttotals1payablefeess1 = 0;
        int ts1totalpaidd1 = 0;
        int ttotals1totalpaidd1 = 0;
        int ts1duepaymentt1 = 0;
        int ts1duepaymenttt1 = 0;
        int ttotals1duepayment1 = 0;
        // bus hire
        int hts1payablefeess1 = 0;
        int httotals1payablefeess1 = 0;
        int hts1totalpaidd1 = 0;
        int httotals1totalpaidd1 = 0;
        int hts1duepaymentt1 = 0;
        int hts1duepaymenttt1 = 0;
        int httotals1duepayment1 = 0;
        //scholarship fee
        int stotals1payablefeess1 = 0;
        int stotals1totalpaidd1 = 0;
        private void button3_Click(object sender, EventArgs e)
        {
try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from FeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  COUNT(DISTINCT ScholarNo) from FeePayment where Year='" + year2.Text + "'", con);
                    s1payablefeessa1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("SELECT Totalfees FROM FeesDetails where Year='" + year2.Text + "'", con);
                    total1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    s1payablefeess1 = total1 * s1payablefeessa1;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    s1payablefeess1 = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
            //end of payable for normal fees
            // begining of payable for scholarship
            totals1payablefeess1 = s1payablefeess1;
            schoolfeespayablesummary1.Text = totals1payablefeess1.ToString();

            //end s.1 totalpayable


            //s.1 total paid
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from FeePayment where Year='" + year2.Text + "' ", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from FeePayment where Year='" + year2.Text + "'", con);
                    s1totalpaidd1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    s1totalpaidd1 = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            totals1totalpaidd1 = s1totalpaidd1;
            shoolfeestotalpaidsummary1.Text = totals1totalpaidd1.ToString();
            //end s.1 totalpaid

            //start s.1 duepayment
            s1duepaymenttt1 = Convert.ToInt32(schoolfeespayablesummary1.Text);
            s1duepaymentt1 = Convert.ToInt32(shoolfeestotalpaidsummary1.Text);
            totals1duepayment1 = s1duepaymenttt1 - s1duepaymentt1;
            duepaymentsummary1.Text = totals1duepayment1.ToString();
             //////////////////////////////////////// end fees payment

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from HostelFeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  COUNT(DISTINCT ScholarNo) from Hostelers where Year='" + year2.Text + "'", con);
                    hs1payablefeessa1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("SELECT HostelFees FROM Hostel ", con);
                    htotal1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    hs1payablefeess1 = htotal1 * hs1payablefeessa1;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    hs1payablefeess1 = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            htotals1payablefeess1 = hs1payablefeess1;
            hostelfeespayablesummary1.Text = htotals1payablefeess1.ToString();

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from HostelFeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from HostelFeePayment where Year='" + year2.Text + "'", con);
                    hs1totalpaidd1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    hs1totalpaidd1 = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            htotals1totalpaidd1 = hs1totalpaidd1;
            hosteltotalpaidsummary1.Text = htotals1totalpaidd1.ToString();
            //end s.1 totalpaid

            //start s.1 duepayment
            hs1duepaymenttt1 = Convert.ToInt32(hostelfeespayablesummary1.Text);
            hs1duepaymentt1 = Convert.ToInt32(hosteltotalpaidsummary1.Text);
            htotals1duepayment1 = hs1duepaymenttt1 - hs1duepaymentt1;
            hostelduepaymentsummary1.Text = htotals1duepayment1.ToString();
/////////////////////////////////////////////////end of total hostel fees

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from BusFeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  SUM(BusCharges) from BusFeePayment where Year='" + year2.Text + "'", con);
                    ts1payablefeess1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    ts1payablefeess1 = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            ttotals1payablefeess1 = ts1payablefeess1;
            buspayablesummary1.Text = ttotals1payablefeess1.ToString();

          
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalPaid from BusFeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from BusFeePayment where Year='" + year2.Text + "'", con);
                    ts1totalpaidd1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    ts1totalpaidd1 = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ttotals1totalpaidd1 = ts1totalpaidd1;
            buspaidsummary1.Text = ttotals1totalpaidd1.ToString();
            //end s.1 totalpaid

            //start s.1 duepayment
            ts1duepaymenttt1 = Convert.ToInt32(buspayablesummary1.Text);
            ts1duepaymentt1 = Convert.ToInt32(buspaidsummary1.Text);
            ttotals1duepayment1 = ts1duepaymenttt1 - ts1duepaymentt1;
            busduepaymentsummary1.Text = ttotals1duepayment1.ToString();

            ////////////////////////////////////////////////// end student bus payment

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select HireTotalPaid from BusHireFeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(HireTotalPaid) from BusHireFeePayment where Year='" + year2.Text + "' ", con);
                    hts1totalpaidd1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    con.Close();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                }
                else
                {
                    hts1totalpaidd1 = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             httotals1totalpaidd1 = hts1totalpaidd1;
             bushirepaidsummary1.Text = httotals1totalpaidd1.ToString();

             try
             {
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 cmd = new SqlCommand("select HireTotalPaid from BusHireFeePayment where Year='" + year2.Text + "'", con);
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     cmd = new SqlCommand("select  SUM(HireBusCharges) from BusHireFeePayment where Year='" + year2.Text + "'", con);
                     hts1payablefeess1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                     con.Close();

                     if ((rdr != null))
                     {
                         rdr.Close();
                     }
                 }
                 else
                 {
                     hts1payablefeess1 = 0;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

             httotals1payablefeess1 = hts1payablefeess1;
             bushirepayablesummary1.Text = httotals1payablefeess1.ToString();

             hts1duepaymenttt1 = Convert.ToInt32(bushirepayablesummary1.Text);
             hts1duepaymentt1 = Convert.ToInt32(bushirepaidsummary1.Text);
             httotals1duepayment1 = hts1duepaymenttt1 - hts1duepaymentt1;
             bushireduepayment1.Text = httotals1duepayment1.ToString();

            /////////////////////////////////////end of bus hire

             try
             {
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 cmd = new SqlCommand("select TotalPaid from ScholarshipPayment where Year='" + year2.Text + "'", con);
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     cmd = new SqlCommand("select SUM(Amount) from ScholarshipPayment where Year='" + year2.Text + "'", con);
                     hs1payablefeess1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                     con.Close();
                     if ((rdr != null))
                     {
                         rdr.Close();
                     }
                 }
                 else
                 {
                     hs1payablefeess1 = 0;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             htotals1payablefeess1 = hs1payablefeess1;
             scholarshippayablesummary1.Text = htotals1payablefeess1.ToString();

             //end s.1 totalpayable


             //s.1 total paid
             try
             {
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 cmd = new SqlCommand("select TotalPaid from ScholarshipPayment where Year='" + year2.Text + "' ", con);
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     con = new SqlConnection(cs.DBConn);
                     con.Open();
                     cmd = new SqlCommand("select SUM(TotalPaid) from ScholarshipPayment where Year='" + year2.Text + "'", con);
                     hs1totalpaidd1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                     con.Close();
                 }
                 else
                 {
                     hs1totalpaidd1 = 0;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             htotals1totalpaidd1 = hs1totalpaidd1;
             scholarshippaidsummary1.Text = htotals1totalpaidd1.ToString();

             hs1duepaymenttt1 = Convert.ToInt32(scholarshippayablesummary1.Text);
             hs1duepaymentt1 = Convert.ToInt32(scholarshippaidsummary1.Text);
             htotals1duepayment1 = hs1duepaymenttt1 - hs1duepaymentt1;
             scholarshipduepaymentsummary1.Text = htotals1duepayment1.ToString();

             totalincomespaid1.Text = (totals1totalpaidd1 + htotals1totalpaidd1 + ttotals1totalpaidd1 + httotals1totalpaidd1 + stotals1totalpaidd1).ToString();
            totalincomespayable1.Text=(totals1payablefeess1+htotals1payablefeess1+ttotals1payablefeess1+httotals1payablefeess1+stotals1payablefeess1).ToString();
            totalincomesdue1.Text = ((Convert.ToInt32(totalincomespayable1.Text))-(Convert.ToInt32(totalincomespaid1.Text))).ToString();

            ///////////////////////////////////expenditures
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Amount from OtherTransaction where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(Amount) from OtherTransaction where Year='" + year2.Text + "'", con);
                    totalexpenses1.Text =cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    totalexpenses1.Text = "0";
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
                cmd = new SqlCommand("select totalcost from Purchases where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(totalcost) from Purchases where Year='" + year2.Text + "' ", con);
                    purchasespaidsummary1.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    purchasespaidsummary1.Text = "0";
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
                cmd = new SqlCommand("select TotalPaid from EmployeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(TotalPaid) from EmployeePayment where Year='" + year2.Text + "'", con);
                    salarypaidsummary1.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    salarypaidsummary1.Text = "0";
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
                cmd = new SqlCommand("select BasicSalary from EmployeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(BasicSalary) from EmployeePayment where Year='" + year2.Text + "'", con);
                    salarypayablesummary1.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    salarypayablesummary1.Text = "0";
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
                cmd = new SqlCommand("select Duefees from EmployeePayment where Year='" + year2.Text + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select SUM(DueFees) from EmployeePayment where Year='" + year2.Text + "'", con);
                    salaryduepaymentsummary1.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                else
                {
                    salaryduepaymentsummary1.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            totalpayableexpenditures1.Text = (Convert.ToInt32(totalexpenses1.Text) + Convert.ToInt32(purchasespaidsummary1.Text)+Convert.ToInt32(salarypayablesummary1.Text)).ToString();
            totalpaidexpenditures1.Text = (Convert.ToInt32(salarypaidsummary1.Text) + Convert.ToInt32(totalexpenses1.Text) + Convert.ToInt32(purchasespaidsummary1.Text)).ToString();
            totalexpendituredues1.Text = (Convert.ToInt32(totalpayableexpenditures1.Text) - Convert.ToInt32(totalpaidexpenditures1.Text)).ToString();

            Profitmargin1.Text = ((Convert.ToInt32(totalincomespaid1.Text)) - (Convert.ToInt32(totalpaidexpenditures1.Text))).ToString();
        }
        private void Reset2()
        {
            year2.Text = "";
            schoolfeespayablesummary1.Text = "";
            shoolfeestotalpaidsummary1.Text = "";
            duepaymentsummary1.Text = "";
            hostelduepaymentsummary1.Text = "";
            hosteltotalpaidsummary1.Text = "";
            hostelfeespayablesummary1.Text = "";
            busduepaymentsummary1.Text = "";
            buspaidsummary1.Text = "";
            buspayablesummary1.Text = "";
            bushireduepayment1.Text = "";
            bushirepaidsummary1.Text = "";
            bushirepayablesummary1.Text = "";
            scholarshipduepaymentsummary1.Text = "";
            scholarshippaidsummary1.Text = "";
            scholarshippayablesummary1.Text = "";
            totalincomesdue1.Text = "";
            totalincomespaid1.Text = "";
            totalincomespayable1.Text = "";
            totalexpenses1.Text = "";
            purchasespaidsummary1.Text = "";
            salaryduepaymentsummary1.Text = "";
            salarypaidsummary1.Text = "";
            salarypayablesummary1.Text = "";
            totalpaidexpenditures1.Text = "";
            totalpayableexpenditures1.Text = "";
            totalexpendituredues1.Text = "";
            Profitmargin1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptfinancialsummary rpt = new rptfinancialsummary(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                cms_purchases myDS = new cms_purchases(); //The DataSet you created.
                frmFinancialSummaryReport frm = new frmFinancialSummaryReport();
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
                rpt.SetParameterValue("feespayable", schoolfeespayablesummary.Text.ToString());
                rpt.SetParameterValue("feespaid", shoolfeestotalpaidsummary.Text.ToString());
                rpt.SetParameterValue("feesduepayment", duepaymentsummary.Text.ToString());
                rpt.SetParameterValue("hostelpayable", hostelfeespayablesummary.Text.ToString());
                rpt.SetParameterValue("hostelpaid", hosteltotalpaidsummary.Text.ToString());
                rpt.SetParameterValue("hostelduepayment", hostelduepaymentsummary.Text.ToString());
                rpt.SetParameterValue("buspayable", buspayablesummary.Text.ToString());
                rpt.SetParameterValue("buspaid", buspaidsummary.Text.ToString());
                rpt.SetParameterValue("busduepayment", busduepaymentsummary.Text.ToString());
                rpt.SetParameterValue("hirepayable", bushirepayablesummary.Text.ToString());
                rpt.SetParameterValue("hirepaid", bushirepaidsummary.Text.ToString());
                rpt.SetParameterValue("hireduepayment", bushireduepayment.Text);
                rpt.SetParameterValue("scholarshippayable", scholarshippayablesummary.Text.ToString());
                rpt.SetParameterValue("scholarshippaid", scholarshippaidsummary.Text.ToString());
                rpt.SetParameterValue("scholarshipduepayment", scholarshipduepaymentsummary.Text);
                rpt.SetParameterValue("payableincomes", totalincomespayable.Text.ToString());
                rpt.SetParameterValue("paidincomes", totalincomespaid.Text.ToString());
                rpt.SetParameterValue("incomesdue", totalincomesdue.Text);
                rpt.SetParameterValue("salarypayable", salarypayablesummary.Text.ToString());
                rpt.SetParameterValue("salarypaid", salarypaidsummary.Text.ToString());
                rpt.SetParameterValue("salaryduepayment", salaryduepaymentsummary.Text);
                rpt.SetParameterValue("expensesammount", totalexpenses.Text);
                rpt.SetParameterValue("purchasesammount", purchasespaidsummary.Text.ToString());
                rpt.SetParameterValue("expenditurespayable", totalpayableexpenditures.Text.ToString());
                rpt.SetParameterValue("expenditurespaid", totalpaidexpenditures.Text);
                rpt.SetParameterValue("expendituresdue", totalexpendituredues.Text);
                rpt.SetParameterValue("profit", Profitmargin.Text);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptfinancialsummary2 rpt = new rptfinancialsummary2(); //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                cms_purchases myDS = new cms_purchases(); //The DataSet you created.
                frmFinancialSummaryReport frm = new frmFinancialSummaryReport();
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
                rpt.SetParameterValue("year", year2.Text.ToString());
                rpt.SetParameterValue("feespayable", schoolfeespayablesummary1.Text.ToString());
                rpt.SetParameterValue("feespaid", shoolfeestotalpaidsummary1.Text.ToString());
                rpt.SetParameterValue("feesduepayment", duepaymentsummary1.Text.ToString());
                rpt.SetParameterValue("hostelpayable", hostelfeespayablesummary1.Text.ToString());
                rpt.SetParameterValue("hostelpaid", hosteltotalpaidsummary1.Text.ToString());
                rpt.SetParameterValue("hostelduepayment", hostelduepaymentsummary1.Text.ToString());
                rpt.SetParameterValue("buspayable", buspayablesummary1.Text.ToString());
                rpt.SetParameterValue("buspaid", buspaidsummary1.Text.ToString());
                rpt.SetParameterValue("busduepayment", busduepaymentsummary1.Text.ToString());
                rpt.SetParameterValue("hirepayable", bushirepayablesummary1.Text.ToString());
                rpt.SetParameterValue("hirepaid", bushirepaidsummary1.Text.ToString());
                rpt.SetParameterValue("hireduepayment", bushireduepayment1.Text);
               rpt.SetParameterValue("scholarshippayable", scholarshippayablesummary1.Text.ToString());
                rpt.SetParameterValue("scholarshippaid", scholarshippaidsummary1.Text.ToString());
                rpt.SetParameterValue("scholarshipduepayment", scholarshipduepaymentsummary1.Text);
                rpt.SetParameterValue("payableincomes", totalincomespayable1.Text.ToString());
                rpt.SetParameterValue("paidincomes", totalincomespaid1.Text.ToString());
                rpt.SetParameterValue("incomesdue", totalincomesdue1.Text);
                rpt.SetParameterValue("salarypayable", salarypayablesummary1.Text.ToString());
                rpt.SetParameterValue("salarypaid", salarypaidsummary1.Text.ToString());
                rpt.SetParameterValue("salaryduepayment", salaryduepaymentsummary1.Text);
                rpt.SetParameterValue("expensesammount", totalexpenses1.Text);
                rpt.SetParameterValue("purchasesammount", purchasespaidsummary1.Text.ToString());
                rpt.SetParameterValue("expenditurespayable", totalpayableexpenditures1.Text.ToString());
                rpt.SetParameterValue("expenditurespaid", totalpaidexpenditures1.Text);
                rpt.SetParameterValue("expendituresdue", totalexpendituredues1.Text);
                rpt.SetParameterValue("profit", Profitmargin1.Text);
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
