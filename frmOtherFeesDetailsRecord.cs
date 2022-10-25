using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmOtherFeesDetailsRecord : Form
    {
        ConnectionString cs = new ConnectionString();
        public frmOtherFeesDetailsRecord()
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
            dynamic SelectQry = "SELECT RTRIM(FeeID)[Fee ID],(Year)[Year],RTRIM(Course)[Class], RTRIM(Branch)[Level], RTRIM(Semester)[Term], RTRIM(RealFeesName)[Fee], RTRIM(RealFees)[Fee Ammount] from OtherFeesDetails order by Course,Semester ";
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
        private void FeesDetailsRecord_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmOtherFeesDetails frm = new frmOtherFeesDetails();
                frm.label13.Text = label1.Text;
              
                frm.FeeID.Text = dr.Cells[0].Value.ToString();
                frm.year.Text = dr.Cells[1].Value.ToString();
                frm.Course.Text = dr.Cells[2].Value.ToString();
                frm.Branch.Text = dr.Cells[3].Value.ToString();
                frm.Semester.Text = dr.Cells[4].Value.ToString();
                frm.TutionFees.Text = dr.Cells[6].Value.ToString();
                frm.otherfeesname.Text = dr.Cells[5].Value.ToString();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFeesDetailsRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmOtherFeesDetails frm = new frmOtherFeesDetails();
            frm.Show();*/
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
      
    
    }
}
