using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace College_Management_System
{
    public partial class frmStudentsFeesPaymentSummaryReport : Form
    {
        public frmStudentsFeesPaymentSummaryReport()
        {
            InitializeComponent();
        }

        private void frmFeePaymentReceipt_Load(object sender, EventArgs e)
        {

        }

        private void frmStudentsFeesPaymentSummaryReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmStudentsFinancialSummary frm = new frmStudentsFinancialSummary();
            frm.label1.Text = label1.Text;
            frm.label2.Text = label2.Text;
            frm.Show();
        }
    }
}
