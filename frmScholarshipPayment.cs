using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmScholarshipPayment : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
       

        public frmScholarshipPayment()
        {
            InitializeComponent();
        }
        private void auto()
        {
            ScholarshipPaymentID.Text = "SSP-" + GetUniqueKey(6);
        }
        private void ScholarshipPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            frmMainMenu form2 = new frmMainMenu();
            form2.UserType.Text = label5.Text;
            form2.User.Text = label6.Text;
            form2.Show();*/
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

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();


        }
        private void Reset()
        {
            ScholarshipPaymentID.Text = "";
            ScholarshipID.Text = "";
            ScholarshipName.Text = "";
            Term.Text = "";
            Amount.Text = "";
            ScholarNo.Text = "";
            StudentName.Text = "";
            Course.Text = "";
            Branch.Text = "";
            PaymentDate.Text = DateTime.Today.ToString();
            Delete.Enabled = false;
            btnSave.Enabled = true;
            Year.Text = "";
        }

        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Student_Name,Course,Branch FROM student WHERE ScholarNo = '" + ScholarNo.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    StudentName.Text = rdr.GetString(0).Trim();
                    Course.Text = rdr.GetString(1).Trim();
                    Branch.Text = rdr.GetString(2).Trim();

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                PaymentDate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int percentage = 0;
        int ammounts = 0;
        double scholarship = 0;
        double payable = 0;
        private void ScholarshipID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Year.Text == "")
            {
                MessageBox.Show("Please Enter Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Year.Focus();
                return;
            }
            if (Term.Text == "")
            {
                MessageBox.Show("Please Enter Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Term.Focus();
                return;
            }
            try{
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("select TotalFees from FeesDetails where Course='" + Course.Text + "' and Semester='" + Term.Text + "' and Year='"+Year.Text+"' and Branch='"+Branch.Text+"'", con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Amount from Scholarship where ScholarshipID='" + ScholarshipID.Text + "'", con);
                percentage = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalFees from FeesDetails where Course='" + Course.Text + "' and Semester='" + Term.Text + "'and Year='" + Year.Text + "' and Branch='" + Branch.Text + "'", con);
                ammounts = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();
                if ((rdr != null))
                {
                    rdr.Close();
                }

            }
            else
            {
                MessageBox.Show("Fees not yet set for that course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScholarshipID.Text = "";
                return;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            double divs = percentage * 0.01;
            scholarship = divs * ammounts;
            payable = (ammounts - scholarship);
            Amount.Text = payable.ToString();
            scholardiscount.Text = scholarship.ToString();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Scholarship WHERE Scholarshipid = '" + ScholarshipID.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ScholarshipName.Text = (rdr.GetString(1).Trim());
                    //Amount.Text = payable.ToString(); //(rdr.GetString(3).Trim());
                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                ScholarNo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateScholarNo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ScholarNo) from student ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ScholarNo.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmScholarshipPayment_Load(object sender, EventArgs e)
        {
            PopulateScholarNo();
            PopulateScholarshipID();
            dataGridView1.DataSource = GetData();
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
            try
            {
                string prices = null;
                string pricess = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + label6.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    prices = rdr["Deletes"].ToString().Trim();
                    pricess = rdr["Updates"].ToString().Trim();
                    if (prices == "Yes") { Delete.Enabled = true; } else { Delete.Enabled = false; }
                   
                }
                if (label6.Text == "ADMIN")
                {
                    Delete.Enabled = true;
                  
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateScholarshipID()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM( ScholarshipID) from  Scholarship ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ScholarshipID.Items.Add(rdr[0]);
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
                if (ScholarshipID.Text == "")
                {
                    MessageBox.Show("Please select Scholarship ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScholarshipID.Focus();
                    return;
                }
                if (Term.Text == "")
                {
                    MessageBox.Show("Please Enter the Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Term.Focus();
                    return;
                }
                if (ScholarNo.Text == "")
                {
                    MessageBox.Show("Please select Scholar No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScholarNo.Focus();
                    return;
                }
                if (Year.Text == "")
                {
                    MessageBox.Show("Please Enter Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Year.Focus();
                    return;
                }

                auto();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq2 = "delete from FeePayment where ScholarNo=@DELETE1 and Year='" + Year.Text + "' and FDCourse='" + Course.Text + "' and Semester='" + Term.Text + "';";
                cmd = new SqlCommand(cq2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "ScholarNo"));
                cmd.Parameters["@DELETE1"].Value = ScholarNo.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into FeePayment(FeePaymentID,ScholarNo,FeeID,FDCourse,FDBranch,Semester,TutionFees,LibraryFees,UniversityDevelopmentFees,UniversityStudentWelfareFees,CautionMoney,OtherFees,TotalFees,DateOfPayment,ModeOfPayment,PaymentModeDetails,TotalPaid,Fine,DueFees,Year,TotalFees1,StudentNames) VALUES (@d1,@d2,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,'" + StudentName.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "FeeId"));
                cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 20, "FDCourse"));
                cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 30, "FDBranch"));
                cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "Semester"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.Int, 10, "TutionFees"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.Int, 10, "LibraryFees"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.Int, 10, "UniversityDevelopmentFees"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 15, "UniversityStudentWelfareFees"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.Int, 10, "CautionMoney"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.Int, 10, "OtherFees"));
                cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.Int, 10, "TotalFees"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 30, "DateOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 20, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.Int, 10, "Fine"));
                cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.Int, 10, "DueFees"));
                cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d24", System.Data.SqlDbType.Int, 10, "TotalFees1"));
                cmd.Parameters["@d1"].Value = ScholarshipPaymentID.Text.Trim();
                cmd.Parameters["@d2"].Value = ScholarNo.Text.Trim();
                cmd.Parameters["@d6"].Value = ScholarshipID.Text.Trim();
                cmd.Parameters["@d7"].Value = Course.Text.Trim();
                cmd.Parameters["@d8"].Value = Branch.Text.Trim();
                cmd.Parameters["@d9"].Value = Term.Text.Trim();
                cmd.Parameters["@d10"].Value = Convert.ToInt32(Amount.Text);
                cmd.Parameters["@d11"].Value = Convert.ToInt32(0);
                cmd.Parameters["@d12"].Value = Convert.ToInt32(0);
                cmd.Parameters["@d13"].Value = Convert.ToInt32(0);
                cmd.Parameters["@d23"].Value = Year.Text.Trim();
                cmd.Parameters["@d24"].Value = Convert.ToInt32(0);
                cmd.Parameters["@d14"].Value = 0;
                cmd.Parameters["@d15"].Value = Convert.ToInt32(0);
                cmd.Parameters["@d16"].Value = Convert.ToInt32(0);
                cmd.Parameters["@d17"].Value = (PaymentDate.Text);
                cmd.Parameters["@d18"].Value = (0);
                cmd.Parameters["@d19"].Value = (0);
                cmd.Parameters["@d20"].Value = Convert.ToInt32(0);
                cmd.Parameters["@d21"].Value = 0;
                cmd.Parameters["@d22"].Value = Convert.ToInt32(Amount.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb3 = "insert into ScholarshipPayment(ScholarshipPaymentID,Scholarshipid,amount,ScholarNo,PaymentDate,PaymentMode,PaymentModeDetails,TotalPaid,DuePayment,Term,Class,Year,Amount1,Section,StudentNames) VALUES (@d1,@d2,@d5,@d6,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,'"+Branch.Text+ "','" + StudentName.Text + "')";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "ScholarshipPaymentID"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.Int, 10, "ScholarshipID"));
                cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.Int, 10, "Amount"));
                cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 30, "PaymentDate"));
                cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 20, "PaymentMode"));
                cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.VarChar, 200, "PaymentModeDetails"));
                cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "Term"));
                cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 50, "Class"));
                cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.Int, 10, "DueFees"));
                cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "Year"));
                cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.Int, 10, "Amount1"));
                cmd.Parameters["@d1"].Value = ScholarshipPaymentID.Text.Trim();
                cmd.Parameters["@d2"].Value = ScholarshipID.Text;
                cmd.Parameters["@d5"].Value = scholardiscount.Text;
                cmd.Parameters["@d6"].Value = ScholarNo.Text.Trim();
                cmd.Parameters["@d10"].Value = (PaymentDate.Text);
                cmd.Parameters["@d11"].Value = "Cash";
                cmd.Parameters["@d12"].Value =ScholarshipName.Text;
                cmd.Parameters["@d13"].Value = Amount.Text;
                cmd.Parameters["@d15"].Value = (Term.Text);
                cmd.Parameters["@d16"].Value = (Course.Text);
                cmd.Parameters["@d14"].Value = Amount.Text;
                cmd.Parameters["@d17"].Value = (Year.Text);
                cmd.Parameters["@d18"].Value = Amount.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Scholarship Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void delete_records2()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from FeePayment where  ScholarNo='" + ScholarNo.Text + "' and FDCourse='" + Course.Text + "' and Semester='" + Term.Text + "' and Year='" + Year.Text + "'";
                cmd = new SqlCommand(cq, con);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {

                }
                else
                {

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
                string cq2 = "delete from FeePayment where  FeePaymentID=@DELETE1;";
                cmd = new SqlCommand(cq2);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "FeePaymentID"));
                cmd.Parameters["@DELETE1"].Value = ScholarshipPaymentID.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq3 = "delete from Student where  ScholarNo=@DELETE1 and Session='"+Year.Text+"' and Course='"+Course.Text+"' and Term='"+Term.Text+"';";
                cmd = new SqlCommand(cq3);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "ScholarNo"));
                cmd.Parameters["@DELETE1"].Value = ScholarNo.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from ScholarshipPayment where  ScholarshipPaymentID=@DELETE1;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 20, "ScholarshipPaymentID"));
                cmd.Parameters["@DELETE1"].Value = ScholarshipPaymentID.Text;
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
            dynamic SelectQry = "SELECT RTRIM(Scholarshipname)[Scholarship Name], RTRIM(ScholarshipID)[Scholarship ID], RTRIM(Amount)[Scholarship Percentage] from scholarship order by scholarshipname ";
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

        private void ViewRecord_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int percentage1 = 0;
            int ammounts1 = 0;
            double scholarship1 = 0;
            double payable1 = 0;
            if (Year.Text == "")
            {
                MessageBox.Show("Please Enter Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Year.Focus();
                return;
            }
            if (Term.Text == "")
            {
                MessageBox.Show("Please Enter Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Term.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select TotalFees from FeesDetails where Course='" + Course.Text + "' and Semester='" + Term.Text + "'and Year='" + Year.Text + "'", con);
                ammounts1 = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                ScholarshipName.Text = dr.Cells[0].Value.ToString();
                ScholarshipID.Text = dr.Cells[1].Value.ToString();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Amount from Scholarship WHERE ScholarshipID = '" + dr.Cells[1].Value.ToString() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    percentage1 = Convert.ToInt32(rdr.GetString(0));
                    double divs1 = percentage1 * 0.01;
                    scholarship1 = divs1 * ammounts1;
                    payable1 = (ammounts1 - scholarship1);
                    Amount.Text = payable1.ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmScholarshipPaymentRecord1 frm = new frmScholarshipPaymentRecord1();
            frm.label10.Text = label5.Text; ;
            frm.label11.Text = label6.Text;
            frm.ShowDialog();
        }
        private void Print_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                frmScholarshipPaymentReceipt frm = new frmScholarshipPaymentReceipt();

                rptScholarshipPaymentReceipt rpt = new rptScholarshipPaymentReceipt();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                CMS_DBDataSet myDS = new CMS_DBDataSet();
                //The DataSet you created.

                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from ScholarshipPayment,Student,Scholarship where Student.ScholarNo=ScholarshipPayment.ScholarNo and Scholarship.ScholarshipID=ScholarshipPayment.ScholarshipID and ScholarshipPaymentID = '" + ScholarshipPaymentID.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "ScholarshipPayment");
                myDA.Fill(myDS, "Student");
                myDA.Fill(myDS, "Scholarship");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Term.Text = "";
            SqlDataReader rdr = null;
            //Term.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Semester) from Batch where Course = '" + Course.Text + "' and Session='" + Year.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Term.Items.Add(rdr[0]);
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
