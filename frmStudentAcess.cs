using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace College_Management_System
{
    public partial class frmStudentAcess : Form
    {
      
        public frmStudentAcess()
        {
            InitializeComponent();
        }

        private void frmStudentAcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmStudentAcess frm = new frmStudentAcess();
                frm.Show();
            }
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentResults frm = new frmStudentResults();
            frm.stdno.Text = password.Text;
            frm.ShowDialog();
        }

     
        private void issuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentComplaints frm = new frmStudentComplaints();
           // frm.stdno.Text = password.Text;
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Hide();
            frm.txtUserName.Text = "";
            frm.txtPassword.Text = "";
            frm.Show();
        }

        private void viewFeesDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmStudentFeesDetails frm = new frmStudentFeesDetails();
            frm.stdno.Text = password.Text;
            frm.ShowDialog();
        }

        private void libraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentLibrary frm = new frmStudentLibrary();
            frm.stdno.Text = password.Text;
            frm.ShowDialog();
        }

        private void frmStudentAcess_Load(object sender, EventArgs e)
        {

        }

               }
    }

