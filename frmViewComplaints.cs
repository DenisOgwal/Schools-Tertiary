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
    public partial class frmViewComplaints : Form
    {
        ConnectionString cs = new ConnectionString();
        public frmViewComplaints()
        {
            InitializeComponent();
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
            dynamic SelectQry = "SELECT RTRIM(studentname)[ Student Name],RTRIM(date)[date Complained],Rtrim(times)[Number of Times],RTRIM(compsubject)[ Subject],RTRIM(staff)[Staff Concerned],Rtrim(department)[Department],Rtrim(description)[Description] FROM Complaints ";
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
        public DataView GetData2()
        {
            dynamic SelectQry = "SELECT RTRIM(studentno)[Student NO.],RTRIM(year)[Session],Rtrim(class)[Course],RTRIM(term)[Semester],RTRIM(stream)[Section],Rtrim(level)[Branch],RTRIM(date)[Complaint Date],RTRIM(subjectname)[Subject Name],Rtrim(description)[Description] FROM Resultscomplaints ";
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
        private void frmViewComplaints_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
            dataGridView2.DataSource = GetData2();
        }

        private void frmViewComplaints_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.UserType.Text = label1.Text;
            frm.User.Text = label2.Text;
            frm.Show();*/
        }
    }
}
