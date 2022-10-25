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
using System.IO;
namespace College_Management_System
{
    public partial class frmInternalMarksEntry : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string grade = null;
        int test1 = 0;
        int test2 = 0;
        int Exam = 0;
        int Average = 0;
        double Aggregate = 0;
        int test1outof20 = 0;
        int test2outof20 = 0;
        int examoutof60 = 0;
        double gradepoint = 0;
        int Cus = 0;
        int cu;
        string remark = null;
        public frmInternalMarksEntry()
        {
            InitializeComponent();
        }
        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCourse.Items.Clear();
            cmbCourse.Text = "";
            cmbCourse.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(course) from Student where session = '" + cmbSession.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCourse.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBranch.Items.Clear();
            cmbBranch.Text = "";
            cmbBranch.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(branch) from Student where course = '" + cmbCourse.Text + "' and session='" + cmbSession.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbBranch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSemester.Items.Clear();
            cmbSemester.Text = "";
            cmbSemester.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Semester) from batch where Course = '" + cmbCourse.Text + "' and session='" + cmbSession.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSemester.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSection.Items.Clear();
            cmbSection.Text = "";
            cmbSection.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Section) from Student,batch where Student.Session=Batch.session and Student.Course = '" + cmbCourse.Text + "' and Student.Branch= '" + cmbBranch.Text + "' and Semester='" + cmbSemester.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSection.Items.Add(rdr[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSubjectCode.Items.Clear();
                cmbSubjectCode.Text = "";
                cmbSubjectCode.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(SubjectCode) from SubjectInfo where CourseName = '" + cmbCourse.Text + "' and Branch= '" + cmbBranch.Text + "' and semester= '" + cmbSemester.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSubjectCode.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSubjectCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                string inquery3 = "SELECT Creditunits FROM SubjectInfo WHERE SubjectCode = '" + cmbSubjectCode.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                cus.Text = cmd.ExecuteScalar().ToString();
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
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT SubjectName FROM SubjectInfo WHERE SubjectCode = '" + cmbSubjectCode.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSubjectName.Text = rdr.GetString(0).Trim();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbCourse.Text == "")
            {
                MessageBox.Show("Please select course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCourse.Focus();
                return;
            }
            if (cmbBranch.Text == "")
            {
                MessageBox.Show("Please select branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBranch.Focus();
                return;
            }
            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please select semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }
            if (cmbSection.Text == "")
            {
                MessageBox.Show("Please select section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSection.Focus();
                return;
            }
            if (label5.Text == "Admin")
            {
                Delete.Enabled = true;
            }
            else
            {
                Delete.Enabled = false;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string sql = "select rtrim(ScholarNo),rtrim(Enrollment_no),rtrim(student_name) from Student,batch where Student.session=batch.session and Student.Course = '" + cmbCourse.Text + "' and Student.Branch= '" + cmbBranch.Text + "' and Batch.semester= '" + cmbSemester.Text + "' and Student.Session= '" + cmbSession.Text + "' and section='" + cmbSection.Text + "' order by student_name,ScholarNo";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AutocompleSession()
        {
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
                    cmbSession.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmInternalMarksEntry_Load(object sender, EventArgs e)
        {
            AutocompleSession();
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
                    if (pricess == "Yes") { Update_record.Enabled = true; } else { Update_record.Enabled = false; }
                }
                if (label6.Text == "ADMIN")
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
        private void Reset()
        {
            cmbBranch.Text = "";
            cmbCourse.Text = "";
            cmbSection.Text = "";
            cmbSession.Text = "";
            cmbSemester.Text = "";
            cmbSubjectCode.Text = "";
            txtSubjectName.Text = "";
            cmbExamName.Text = "";
            dtpExamDate.Text = System.DateTime.Today.ToString();
            cus.Text = "";
            cmbBranch.Enabled = false;
            cmbCourse.Enabled = false;
            cmbSemester.Enabled = false;
            cmbSubjectCode.Enabled = false;
            cmbSection.Enabled = false;
            dataGridView1.Rows.Clear();
            btnSave.Enabled = true;
            Delete.Enabled = false;
            Update_record.Enabled = false;
            cmbSession.Focus();
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            imagebrowse();
            try
            {
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (cmbCourse.Text == "")
                {
                    MessageBox.Show("Please select course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbCourse.Focus();
                    return;
                }
                if (cmbBranch.Text == "")
                {
                    MessageBox.Show("Please select branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbBranch.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please select semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }

                if (cmbSection.Text == "")
                {
                    MessageBox.Show("Please select section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSection.Focus();
                    return;
                }
                if (cmbSubjectCode.Text == "")
                {
                    MessageBox.Show("Please select subject code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSubjectCode.Focus();
                    return;
                }
                if (cmbExamName.Text == "")
                {
                    MessageBox.Show("Please select exam name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbExamName.Focus();
                    return;
                }
                if (cmbExamName.Text == "Coursework 1")
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select ScholarNo,SubjectCode from InternalMarksEntry where ScholarNo='" + row.Cells[0].Value + "' and SubjectCode='" + cmbSubjectCode.Text + "'";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                                return;
                            }
                        }
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into InternalMarksEntry(Session,Course,Branch,Semester,Section,SubjectCode,SubjectName,ExamDate,ScholarNo,CreditUnits,coursework1,enrollmentnumber,studentname,photo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d9,@d12,@d14,@d13,@d15,@d16,@d17)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    // Add Parameters to Command Parameters collection
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Session"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Course"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Branch"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Section"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "SubjectCode"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 250, "SubjectName"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "ExamDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "coursework1"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 15, "CreditUnits"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 20, "enrollmentnumber"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 40, "studentname"));
                    // Prepare command for repeated execution
                    cmd.Prepare();
                    // Data to be inserted
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@d1"].Value = cmbSession.Text;
                            cmd.Parameters["@d2"].Value = cmbCourse.Text;
                            cmd.Parameters["@d3"].Value = cmbBranch.Text;
                            cmd.Parameters["@d4"].Value = cmbSemester.Text;
                            cmd.Parameters["@d5"].Value = cmbSection.Text;
                            cmd.Parameters["@d6"].Value = cmbSubjectCode.Text;
                            cmd.Parameters["@d7"].Value = txtSubjectName.Text;
                            cmd.Parameters["@d9"].Value = dtpExamDate.Text;
                            cmd.Parameters["@d12"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d15"].Value = row.Cells[1].Value;
                            cmd.Parameters["@d16"].Value = row.Cells[2].Value;
                            cmd.Parameters["@d13"].Value = row.Cells[3].Value;
                            cmd.Parameters["@d14"].Value = cus.Text;
                            MemoryStream ms = new MemoryStream();
                            Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] data = ms.GetBuffer();
                            SqlParameter p = new SqlParameter("@d17", SqlDbType.Image);
                            p.Value = data;
                            cmd.Parameters.Add(p);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                    MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                }
                if (cmbExamName.Text == "Coursework 2")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update InternalMarksEntry set Session=@d1,Course=@d2,Branch=@d3,Semester=@d4,Section=@d5,SubjectName=@d7,ExamDate=@d9,coursework2=@d13 where ScholarNo=@d12 and SubjectCode=@d6 ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    // Add Parameters to Command Parameters collection
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Session"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Course"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Branch"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Section"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "SubjectCode"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 250, "SubjectName"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "ExamDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "coursework2"));
                    // Prepare command for repeated execution
                    cmd.Prepare();
                    // Data to be inserted
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@d1"].Value = cmbSession.Text;
                            cmd.Parameters["@d2"].Value = cmbCourse.Text;
                            cmd.Parameters["@d3"].Value = cmbBranch.Text;
                            cmd.Parameters["@d4"].Value = cmbSemester.Text;
                            cmd.Parameters["@d5"].Value = cmbSection.Text;
                            cmd.Parameters["@d6"].Value = cmbSubjectCode.Text;
                            cmd.Parameters["@d7"].Value = txtSubjectName.Text;
                            cmd.Parameters["@d9"].Value = dtpExamDate.Text;
                            cmd.Parameters["@d12"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d13"].Value = row.Cells[3].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                    MessageBox.Show("Successfully Saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update_record.Enabled = false;
                }
                if (cmbExamName.Text == "Exam")
                {
                    averageresults();
                    grading();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update InternalMarksEntry set Session=@d1,Course=@d2,Branch=@d3,MinMarks=@d10,Semester=@d4,Section=@d5,SubjectName=@d7,ExamDate=@d9,Exam=@d13,Totalmark=@d16, Grade=@d14,Aggregate=@d15,gp=@d17 where ScholarNo=@d12 and SubjectCode=@d6 ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    // Add Parameters to Command Parameters collection
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Session"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Course"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Branch"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Section"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "SubjectCode"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 250, "SubjectName"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "ExamDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "MinMarks"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "Exam"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "Grade"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.Int, 10, "Aggragate"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.Int, 10, "Totalmark"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.Int, 10, "gp"));
                    // Prepare command for repeated execution
                    cmd.Prepare();
                    // Data to be inserted
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@d1"].Value = cmbSession.Text;
                            cmd.Parameters["@d2"].Value = cmbCourse.Text;
                            cmd.Parameters["@d3"].Value = cmbBranch.Text;
                            cmd.Parameters["@d4"].Value = cmbSemester.Text;
                            cmd.Parameters["@d5"].Value = cmbSection.Text;
                            cmd.Parameters["@d6"].Value = cmbSubjectCode.Text;
                            cmd.Parameters["@d7"].Value = txtSubjectName.Text;
                            cmd.Parameters["@d9"].Value = dtpExamDate.Text;
                            cmd.Parameters["@d12"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d13"].Value = row.Cells[3].Value;
                            cmd.Parameters["@d10"].Value = remark;
                            cmd.Parameters["@d14"].Value = grade;
                            cmd.Parameters["@d15"].Value = Aggregate;
                            cmd.Parameters["@d17"].Value = gradepoint;
                            cmd.Parameters["@d16"].Value = Average;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                    MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update_record.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void imagebrowse()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Photo FROM Student WHERE ScholarNo =@d1";
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                cmd.Prepare();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        cmd.Parameters["@d1"].Value = row.Cells[0].Value;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            MemoryStream stream = new MemoryStream();
                            byte[] image = (byte[])rdr["Photo"];
                            stream.Write(image, 0, image.Length);
                            Bitmap bitmap = new Bitmap(stream);
                            pictureBox1.Image = bitmap;
                        }
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        cmd.ExecuteNonQuery();
                    }
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
        private int averageresults()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT Creditunits FROM SubjectInfo WHERE  CourseName = '" + cmbCourse.Text + "' and Semester = '" + cmbSemester.Text + "' and Branch = '" + cmbBranch.Text + "' and SubjectCode = '" + cmbSubjectCode.Text + "' and SubjectName = '" + txtSubjectName.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                label19.Text = cmd.ExecuteScalar().ToString();
                cu = int.Parse(label19.Text);
                Cus = Convert.ToInt32(cu);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT coursework1 FROM InternalMarksEntry WHERE  Session = '" + cmbSession.Text + "' and Course = '" + cmbCourse.Text + "' and Semester = '" + cmbSemester.Text + "' and Section = '" + cmbSection.Text + "' and Branch = '" + cmbBranch.Text + "' and SubjectCode = '" + cmbSubjectCode.Text + "' and SubjectName = '" + txtSubjectName.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                label10.Text = cmd.ExecuteScalar().ToString();
                test1 = int.Parse(label10.Text);
                test1outof20 = Convert.ToInt32(test1 * 0.2);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String inquery3 = "SELECT coursework2 FROM InternalMarksEntry WHERE  Session = '" + cmbSession.Text + "' and Course = '" + cmbCourse.Text + "' and Semester = '" + cmbSemester.Text + "' and Section = '" + cmbSection.Text + "' and Branch = '" + cmbBranch.Text + "' and SubjectCode = '" + cmbSubjectCode.Text + "' and SubjectName = '" + txtSubjectName.Text + "'";
                cmd = new SqlCommand(inquery3, con);
                label15.Text = cmd.ExecuteScalar().ToString();
                test2 = int.Parse(label15.Text);
                test2outof20 = Convert.ToInt32(test2 * 0.2);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (!row.IsNewRow)
                    {

                        Exam = Convert.ToInt32(row.Cells[3].Value.ToString());
                        examoutof60 = Convert.ToInt32(Exam * 0.6);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Average = (test1outof20 + test2outof20 + examoutof60);
            return Average;
        }
        private string grading()
        {
            if (Average >= 0 && Average <= 39)
            {
                grade = "F";
                Aggregate = 0;
                remark = "CRT";
            }
            else if (Average >= 40 && Average <= 44)
            {
                grade = "E-";
                Aggregate = 1;
                remark = "CRT";
            }
            else if (Average >= 45 && Average <= 49)
            {
                grade = "E";
                Aggregate = 1.5;
                remark = "CRT";
            }
            else if (Average >= 50 && Average <= 54)
            {
                grade = "D";
                Aggregate = 2;
                remark = "NP";
            }
            else if (Average >= 55 && Average <= 59)
            {
                grade = "D+";
                Aggregate = 2.5;
                remark = "NP";
            }
            else if (Average >= 60 && Average <= 64)
            {
                grade = "C";
                Aggregate = 3;
                remark = "NP";
            }
            else if (Average >= 65 && Average <= 69)
            {
                grade = "C+";
                Aggregate = 3.5;
                remark = "NP";
            }
            else if (Average >= 70 && Average <= 74)
            {
                grade = "B";
                Aggregate = 4;
                remark = "NP";
            }
            else if (Average >= 75 && Average <= 79)
            {
                grade = "B+";
                Aggregate = 4.5;
                remark = "NP";
            }
            else if (Average >= 80 && Average <= 90)
            {
                grade = "A";
                Aggregate = 5;
                remark = "NP";
            }
            else if (Average >= 90 && Average <= 100)
            {
                grade = "A+";
                Aggregate = 5;
                remark = "NP";
            }
            else
            {
                MessageBox.Show("marks can not be less than 0 or more than 100");
            }
            gradepoint = Aggregate * Cus;
            return grade;
        }
        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbExamName.Text == "Exam")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update InternalMarksEntry set Session=@d1,Course=@d2,Branch=@d3,Semester=@d4,Section=@d5,SubjectName=@d7,ExamDate=@d9,Exam=@d13 where ScholarNo=@d12 and SubjectCode=@d6 ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    // Add Parameters to Command Parameters collection
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Session"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Course"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Branch"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Section"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "SubjectCode"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 250, "SubjectName"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "ExamDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "Exam"));
                    // Prepare command for repeated execution
                    cmd.Prepare();
                    // Data to be inserted
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@d1"].Value = cmbSession.Text;
                            cmd.Parameters["@d2"].Value = cmbCourse.Text;
                            cmd.Parameters["@d3"].Value = cmbBranch.Text;
                            cmd.Parameters["@d4"].Value = cmbSemester.Text;
                            cmd.Parameters["@d5"].Value = cmbSection.Text;
                            cmd.Parameters["@d6"].Value = cmbSubjectCode.Text;
                            cmd.Parameters["@d7"].Value = txtSubjectName.Text;
                            cmd.Parameters["@d9"].Value = dtpExamDate.Text;
                            cmd.Parameters["@d12"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d13"].Value = row.Cells[3].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                    MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update_record.Enabled = false;
                }
                if (cmbExamName.Text == "Coursework 1")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update InternalMarksEntry set Session=@d1,Course=@d2,Branch=@d3,Semester=@d4,Section=@d5,SubjectName=@d7,ExamDate=@d9,coursework1=@d13 where ScholarNo=@d12 and SubjectCode=@d6 ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    // Add Parameters to Command Parameters collection
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Session"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Course"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Branch"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Section"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "SubjectCode"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 250, "SubjectName"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "ExamDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "coursework1"));
                    // Prepare command for repeated execution
                    cmd.Prepare();
                    // Data to be inserted
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@d1"].Value = cmbSession.Text;
                            cmd.Parameters["@d2"].Value = cmbCourse.Text;
                            cmd.Parameters["@d3"].Value = cmbBranch.Text;
                            cmd.Parameters["@d4"].Value = cmbSemester.Text;
                            cmd.Parameters["@d5"].Value = cmbSection.Text;
                            cmd.Parameters["@d6"].Value = cmbSubjectCode.Text;
                            cmd.Parameters["@d7"].Value = txtSubjectName.Text;
                            cmd.Parameters["@d9"].Value = dtpExamDate.Text;
                            cmd.Parameters["@d12"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d13"].Value = row.Cells[3].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                    MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update_record.Enabled = false;
                }
                if (cmbExamName.Text == "Coursework 1")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update InternalMarksEntry set Session=@d1,Course=@d2,Branch=@d3,Semester=@d4,Section=@d5,SubjectName=@d7,ExamDate=@d9,coursework2=@d13 where ScholarNo=@d12 and SubjectCode=@d6 ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    // Add Parameters to Command Parameters collection
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Session"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 30, "Course"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Branch"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "Semester"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Section"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 20, "SubjectCode"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 250, "SubjectName"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 30, "ExamDate"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 15, "ScholarNo"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.Int, 10, "coursework2"));
                    // Prepare command for repeated execution
                    cmd.Prepare();
                    // Data to be inserted
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@d1"].Value = cmbSession.Text;
                            cmd.Parameters["@d2"].Value = cmbCourse.Text;
                            cmd.Parameters["@d3"].Value = cmbBranch.Text;
                            cmd.Parameters["@d4"].Value = cmbSemester.Text;
                            cmd.Parameters["@d5"].Value = cmbSection.Text;
                            cmd.Parameters["@d6"].Value = cmbSubjectCode.Text;
                            cmd.Parameters["@d7"].Value = txtSubjectName.Text;
                            cmd.Parameters["@d9"].Value = dtpExamDate.Text;
                            cmd.Parameters["@d12"].Value = row.Cells[0].Value;
                            cmd.Parameters["@d13"].Value = row.Cells[3].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                    MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update_record.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInternalMarksEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* frmMainMenu frm = new frmMainMenu();
            this.Hide();
            frm.UserType.Text = label5.Text;
            frm.User.Text = label6.Text;
            frm.Show();*/
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete the records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
                string cq = "delete from InternalMarksEntry where Session='" + cmbSession.Text + "' and Course='" + cmbCourse.Text + "' and Branch='" + cmbBranch.Text + "' and Semester='" + cmbSemester.Text + "' and Section='" + cmbSection.Text + "'and SubjectCode='" + cmbSubjectCode.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbCourse.Text == "")
            {
                MessageBox.Show("Please select course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCourse.Focus();
                return;
            }
            if (cmbBranch.Text == "")
            {
                MessageBox.Show("Please select Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBranch.Focus();
                return;
            }
            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }

            if (cmbSection.Text == "")
            {
                MessageBox.Show("Please select Section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSection.Focus();
                return;
            }
            if (cmbSubjectCode.Text == "")
            {
                MessageBox.Show("Please select subject code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSubjectCode.Focus();
                return;
            }
            if (cmbExamName.Text == "")
            {
                MessageBox.Show("Please select exam name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbExamName.Focus();
                return;
            }

            if (cmbExamName.Text == "Coursework 1")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sql = "select RTrim(ScholarNo)[ScholarNo],Rtrim(enrollmentnumber)[Enrollment No.], RTRIM(studentname)[Student Name], RTRIM(coursework1)[Marks Obtained]from InternalMarksEntry where  InternalMarksEntry.Course= '" + cmbCourse.Text + "'and InternalMarksEntry.Branch='" + cmbBranch.Text + "'and InternalMarksEntry.Session='" + cmbSession.Text + "' and InternalMarksEntry.Semester= '" + cmbSemester.Text + "' and InternalMarksEntry.Section= '" + cmbSection.Text + "' and SubjectCode='" + cmbSubjectCode.Text + "' order by studentname";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                    }
                    con.Close();
                }
            if (cmbExamName.Text == "Coursework 2")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sql = "select RTrim(ScholarNo)[ScholarNo],Rtrim(enrollmentnumber)[Enrollment No.], RTRIM(studentname)[Student Name], RTRIM(coursework2)[Marks Obtained]from InternalMarksEntry where InternalMarksEntry.Course= '" + cmbCourse.Text + "'and InternalMarksEntry.Branch='" + cmbBranch.Text + "'and InternalMarksEntry.Session='" + cmbSession.Text + "' and InternalMarksEntry.Semester= '" + cmbSemester.Text + "' and InternalMarksEntry.Section= '" + cmbSection.Text + "' and SubjectCode='" + cmbSubjectCode.Text + "' order by studentname";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                    }
                    con.Close();
                }
                if (cmbExamName.Text == "Exam")
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sql = "select RTrim(ScholarNo)[ScholarNo],Rtrim(enrollmentnumber)[Enrollment No.], RTRIM(studentname)[Student Name], RTRIM(Exam)[Marks Obtained]from InternalMarksEntry where  InternalMarksEntry.Course= '" + cmbCourse.Text + "'and InternalMarksEntry.Branch='" + cmbBranch.Text + "'and InternalMarksEntry.Session='" + cmbSession.Text + "' and InternalMarksEntry.Semester= '" + cmbSemester.Text + "' and InternalMarksEntry.Section= '" + cmbSection.Text + "' and SubjectCode='" + cmbSubjectCode.Text + "' order by studentname";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                    }
                    con.Close();
                }
        }
    }
}
