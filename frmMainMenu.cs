using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmMainMenu : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string status = "UnAvailable";

        public frmMainMenu()
        {
            InitializeComponent();
        }


        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCourse frm = new frmCourse();
            frm.label1.Text = User.Text;
            frm.Show();

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox1 form2 = new frmAboutBox1();
            form2.Show();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContact form2 = new frmContact();

            form2.Show();
        }

        private void studentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent form2 = new frmStudent();
            form2.label11.Text = User.Text;
            form2.label30.Text = UserType.Text;
            form2.ShowDialog();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }




        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment frm = new frmDepartment();
            frm.label1.Text = User.Text;
            frm.ShowDialog();

        }

        private void employeeProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmEmployeeDetails form2 = new frmEmployeeDetails();
            form2.label21.Text = UserType.Text;
            form2.label23.Text = User.Text;
            form2.ShowDialog();
        }

        private void feesDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFeesDetails frm = new frmFeesDetails();
            frm.label13.Text = User.Text;
            frm.ShowDialog();
        }

        private void FeesMenu_Click(object sender, EventArgs e)
        {

        }

        private void feePaymentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFeePaymentRecord1 form2 = new frmFeePaymentRecord1();
            form2.label13.Text = UserType.Text;
            form2.label14.Text = User.Text;
            form2.Show();
        }

        private void studentRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStudentRecord form2 = new frmStudentRecord();
            form2.txtStudent.Text = "";
            form2.dataGridView1.DataSource = null;
            form2.dataGridView2.DataSource = null;
            form2.dataGridView3.DataSource = null;
            form2.cmbCourse.Text = "";
            form2.cmbBranch.Text = "";
            form2.cmbSession.Text = "";
            form2.cmbSemester.Text = "";
            form2.cmbSection.Text = "";
            form2.DateFrom.Text = DateTime.Today.ToString();
            form2.DateTo.Text = DateTime.Today.ToString();
            form2.StudentName.Text = "";
            form2.cmbBranch.Enabled = false;
            form2.cmbSession.Enabled = false;
            form2.cmbSemester.Enabled = false;
            form2.cmbSection.Enabled = false;
            form2.label10.Text = UserType.Text;
            form2.label11.Text = User.Text;
            form2.Show();
        }

        private void feePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmFeesPayment form2 = new frmFeesPayment();
            form2.label23.Text = UserType.Text;
            form2.label24.Text = User.Text;
            form2.ShowDialog();
        }



        private void scholarshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScholarship frm = new frmScholarship();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void othersTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmOtherTransaction frm = new frmOtherTransaction();
            frm.label4.Text = User.Text;
            frm.ShowDialog();
        }

        private void scholarshipPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmScholarshipPayment frm = new frmScholarshipPayment();
            frm.label5.Text = UserType.Text;
            frm.label6.Text = User.Text;
            frm.ShowDialog();
        }

        private void internalMarksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternalMarksEntry frm = new frmInternalMarksEntry();
            //this.Hide();
            frm.label5.Text = UserType.Text;
            frm.label6.Text = User.Text;
            frm.ShowDialog();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
            timer1.Start();
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
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = AssemblyCopyright;

            try
            {
                if (User.Text == "ADMIN")
                {
                    hostelFeePaymentReceiptToolStripMenuItem.Enabled = true;
                    busFeePaymentReceiptToolStripMenuItem.Enabled = true;
                    feeReceiptToolStripMenuItem.Enabled = true;
                    studentsRegistrationToolStripMenuItem.Enabled = true;
                    internalMarksToolStripMenuItem.Enabled = true;
                    studentsFinancialSummaryToolStripMenuItem.Enabled = true;
                    financialSummaryToolStripMenuItem.Enabled = true;
                    otherTransactionRecordToolStripMenuItem.Enabled = true;
                    scholarshipPaymentRecordToolStripMenuItem.Enabled = true;
                    busFeePaymentToolStripMenuItem1.Enabled = true;
                    hostelFeePaymentToolStripMenuItem1.Enabled = true;
                    employeePaymentRecordToolStripMenuItem.Enabled = true;
                    feePaymentRecordToolStripMenuItem.Enabled = true;
                    employeeRecordToolStripMenuItem.Enabled = true;
                    studentAttendanceRecordToolStripMenuItem.Enabled = true;
                    studentRegistrationRecordToolStripMenuItem.Enabled = true;
                    hostelersToolStripMenuItem1.Enabled = true;
                    busHoldersToolStripMenuItem1.Enabled = true;
                    othersTransactionToolStripMenuItem.Enabled = true;
                    vehicleHireToolStripMenuItem1.Enabled = true;
                    scholarshipPaymentToolStripMenuItem.Enabled = true;
                    hostelFeesPaymentToolStripMenuItem.Enabled = true;
                    employeeSalaryToolStripMenuItem.Enabled = true;
                    busFeePaymentToolStripMenuItem2.Enabled = true;
                    balanceToolStripMenuItem.Enabled = true;
                    usageToolStripMenuItem.Enabled = true;
                    complaintsToolStripMenuItem.Enabled = true;
                    busHoldersToolStripMenuItem.Enabled = true;
                    rightsToolStripMenuItem.Enabled = true;
                    loginDetailsToolStripMenuItem.Enabled = true;
                    hostelersToolStripMenuItem.Enabled = true;
                    invetoryToolStripMenuItem.Enabled = true;
                    itemPurchaseToolStripMenuItem.Enabled = true;
                    libraryToolStripMenuItem.Enabled = true;
                    feePaymentToolStripMenuItem.Enabled = true;
                    feePaymentToolStripMenuItem1.Enabled = true;
                    employeeSalaryToolStripMenuItem.Enabled = true;
                    salaryPaymentToolStripMenuItem.Enabled = true;
                    salaryPaymentToolStripMenuItem2.Enabled = true;
                    employeeToolStripMenuItem.Enabled = true;
                    employeeToolStripMenuItem1.Enabled = true;
                    internalMarksEntryToolStripMenuItem.Enabled = true;
                    internalMarksEntryToolStripMenuItem1.Enabled = true;
                    Master_entryMenu.Enabled = true;
                    registrationToolStripMenuItem.Enabled = true;
                    userRegistrationToolStripMenuItem.Enabled = true;
                    registrationToolStripMenuItem2.Enabled = true;
                    attendanceToolStripMenuItem.Enabled = true;
                    attendanceToolStripMenuItem1.Enabled = true;
                    studentToolStripMenuItem1.Enabled = true;
                }
                else
                {
                    string masterentry, accountcreation, studentregistration, attendance, marksentry, staffregistration, salarypayment, feespayment, libraryaccess, inventoryentry = null;
                    string assignrights, accesslogins, registerhostlers, registerbusholders, accesssttudentcomplaints, inventoryusage, inventorystockaccess, busfeespayment, staffsalarypayment = null;
                    string hostelfeespayment, scholarshipassignments, vehiclehiretransactions, othertransactions, studentregistrationrecords, hostelersrecords, busholdersrecords, studentattendancerecord, staffrecords, feespaymentrecords = null;
                    string staffpaymentrecords, hostelfeespaymentrecord, busfeespaymentrecord, scholarshiprecords, otherfeestransactionrecord, institutionfinancialsummary, studentfinancialsummary = null;
                    string studentresults, studentregistrationreport, paymentreceipts, deletes, updates = null;
                    SqlDataReader rdr = null;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + User.Text + "' ";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        masterentry = rdr["MasterEntry"].ToString().Trim();
                        accountcreation = rdr["AccountCreation"].ToString().Trim();
                        studentregistration = rdr["StudentRegistration"].ToString().Trim();
                        attendance = rdr["Attendance"].ToString().Trim();
                        marksentry = rdr["MarksEntry"].ToString().Trim();
                        staffregistration = rdr["StaffRegistration"].ToString().Trim();
                        salarypayment = rdr["SalaryPayment"].ToString().Trim();
                        feespayment = rdr["FeesPayment"].ToString().Trim();
                        libraryaccess = rdr["LibraryAccess"].ToString().Trim();
                        inventoryentry = rdr["InventoryAccess"].ToString().Trim();
                        assignrights = rdr["AssignRights"].ToString().Trim();
                        accesslogins = rdr["AccessLogins"].ToString().Trim();
                        registerhostlers = rdr["RegisterHostelers"].ToString().Trim();
                        registerbusholders = rdr["RegisterBusHolders"].ToString().Trim();
                        accesssttudentcomplaints = rdr["AccessStudentComplaints"].ToString().Trim();
                        inventoryusage = rdr["InventoryUsage"].ToString().Trim();
                        inventorystockaccess = rdr["InventoryStockAccess"].ToString().Trim();
                        busfeespayment = rdr["BusFeesPayment"].ToString().Trim();
                        staffsalarypayment = rdr["StaffSalaryPayment"].ToString().Trim();
                        hostelfeespayment = rdr["HostelFeesPayment"].ToString().Trim();
                        scholarshipassignments = rdr["ScholarshipAssignments"].ToString().Trim();
                        vehiclehiretransactions = rdr["VehicleHireTransactions"].ToString().Trim();
                        othertransactions = rdr["OtherTransactions"].ToString().Trim();
                        studentregistrationrecords = rdr["StudentRegistrationRecords"].ToString().Trim();
                        hostelersrecords = rdr["HostelersRecords"].ToString().Trim();
                        busholdersrecords = rdr["BusHoldersRecords"].ToString().Trim();
                        studentattendancerecord = rdr["StudentAttendanceRecord"].ToString().Trim();
                        staffrecords = rdr["StaffRecords"].ToString().Trim();
                        feespaymentrecords = rdr["FeesPaymentRecords"].ToString().Trim();
                        staffpaymentrecords = rdr["StaffPaymentRecords"].ToString().Trim();
                        hostelfeespaymentrecord = rdr["HostelFeesPaymentRecords"].ToString().Trim();
                        busfeespaymentrecord = rdr["BusFeesPaymentRecord"].ToString().Trim();
                        scholarshiprecords = rdr["ScholarshipRecords"].ToString().Trim();
                        otherfeestransactionrecord = rdr["OtherFeesTransactionsRecord"].ToString().Trim();
                        institutionfinancialsummary = rdr["InstitutionFinancialSummary"].ToString().Trim();
                        studentfinancialsummary = rdr["StudentFiancialSummary"].ToString().Trim();
                        studentresults = rdr["StudentResults"].ToString().Trim();
                        studentregistrationreport = rdr["StudentRegistrationReport"].ToString().Trim();
                        paymentreceipts = rdr["PaymentReceipts"].ToString().Trim();
                        updates = rdr["Updates"].ToString().Trim();
                        deletes = rdr["Deletes"].ToString().Trim();

                        if (masterentry == "Yes") { Master_entryMenu.Enabled = true; } else { Master_entryMenu.Enabled = false; }
                        if (accountcreation == "Yes") { userRegistrationToolStripMenuItem.Enabled = true; registrationToolStripMenuItem.Enabled = true; } else { userRegistrationToolStripMenuItem.Enabled = false; registrationToolStripMenuItem.Enabled = false; }
                        if (studentregistration == "Yes") { studentToolStripMenuItem1.Enabled = true; registrationToolStripMenuItem2.Enabled = true; } else { studentToolStripMenuItem1.Enabled = false; registrationToolStripMenuItem2.Enabled = false; }
                        if (attendance == "Yes") { attendanceToolStripMenuItem1.Enabled = true; attendanceToolStripMenuItem.Enabled = true; } else { attendanceToolStripMenuItem1.Enabled = false; attendanceToolStripMenuItem.Enabled = false; }
                        if (marksentry == "Yes") { internalMarksEntryToolStripMenuItem1.Enabled = true; internalMarksEntryToolStripMenuItem.Enabled = true; } else { internalMarksEntryToolStripMenuItem1.Enabled = false; internalMarksEntryToolStripMenuItem.Enabled = false; }
                        if (staffregistration == "Yes") { employeeToolStripMenuItem1.Enabled = true; employeeToolStripMenuItem.Enabled = true; } else { employeeToolStripMenuItem1.Enabled = false; employeeToolStripMenuItem.Enabled = false; }
                        if (salarypayment == "Yes") { salaryPaymentToolStripMenuItem.Enabled = true; employeeSalaryToolStripMenuItem.Enabled = true; salaryPaymentToolStripMenuItem2.Enabled = true; } else { salaryPaymentToolStripMenuItem.Enabled = false; employeeSalaryToolStripMenuItem.Enabled = false; salaryPaymentToolStripMenuItem2.Enabled = false; }
                        if (feespayment == "Yes") { feePaymentToolStripMenuItem1.Enabled = true; feePaymentToolStripMenuItem.Enabled = true; } else { feePaymentToolStripMenuItem1.Enabled = false; feePaymentToolStripMenuItem.Enabled = false; }
                        if (libraryaccess == "Yes") { libraryToolStripMenuItem.Enabled = true; } else { libraryToolStripMenuItem.Enabled = false; }
                        if (inventoryentry == "Yes") { invetoryToolStripMenuItem.Enabled = true; feePaymentToolStripMenuItem.Enabled = true; itemPurchaseToolStripMenuItem.Enabled = true; } else { invetoryToolStripMenuItem.Enabled = false; feePaymentToolStripMenuItem.Enabled = false; itemPurchaseToolStripMenuItem.Enabled = false; }
                        if (assignrights == "Yes") { rightsToolStripMenuItem.Enabled = true; } else { rightsToolStripMenuItem.Enabled = false; }
                        if (accesslogins == "Yes") { loginDetailsToolStripMenuItem.Enabled = true; } else { loginDetailsToolStripMenuItem.Enabled = false; }
                        if (registerhostlers == "Yes") { hostelersToolStripMenuItem.Enabled = true; } else { hostelersToolStripMenuItem.Enabled = false; }
                        if (registerbusholders == "Yes") { busHoldersToolStripMenuItem.Enabled = true; } else { busHoldersToolStripMenuItem.Enabled = false; }
                        if (accesssttudentcomplaints == "Yes") { complaintsToolStripMenuItem.Enabled = true; } else { complaintsToolStripMenuItem.Enabled = false; }
                        if (inventoryusage == "Yes") { usageToolStripMenuItem.Enabled = true; } else { usageToolStripMenuItem.Enabled = false; }
                        if (inventorystockaccess == "Yes") { balanceToolStripMenuItem.Enabled = true; } else { balanceToolStripMenuItem.Enabled = false; }
                        if (busfeespayment == "Yes") { busFeePaymentToolStripMenuItem2.Enabled = true; } else { busFeePaymentToolStripMenuItem2.Enabled = false; }
                        if (staffsalarypayment == "Yes") { employeeSalaryToolStripMenuItem.Enabled = true; } else { employeeSalaryToolStripMenuItem.Enabled = false; }
                        if (hostelfeespayment == "Yes") { hostelFeesPaymentToolStripMenuItem.Enabled = true; } else { hostelFeesPaymentToolStripMenuItem.Enabled = false; }
                        if (scholarshipassignments == "Yes") { scholarshipPaymentToolStripMenuItem.Enabled = true; } else { scholarshipPaymentToolStripMenuItem.Enabled = false; }
                        if (vehiclehiretransactions == "Yes") { vehicleHireToolStripMenuItem1.Enabled = true; } else { vehicleHireToolStripMenuItem1.Enabled = false; }
                        if (othertransactions == "Yes") { othersTransactionToolStripMenuItem.Enabled = true; } else { othersTransactionToolStripMenuItem.Enabled = false; }
                        if (studentregistrationrecords == "Yes") { studentRegistrationRecordToolStripMenuItem.Enabled = true; } else { studentRegistrationRecordToolStripMenuItem.Enabled = false; }
                        if (hostelersrecords == "Yes") { hostelersToolStripMenuItem1.Enabled = true; } else { hostelersToolStripMenuItem1.Enabled = false; }
                        if (busholdersrecords == "Yes") { busHoldersToolStripMenuItem1.Enabled = true; } else { busHoldersToolStripMenuItem1.Enabled = false; }
                        if (studentattendancerecord == "Yes") { studentAttendanceRecordToolStripMenuItem.Enabled = true; } else { studentAttendanceRecordToolStripMenuItem.Enabled = false; }
                        if (staffrecords == "Yes") { employeeRecordToolStripMenuItem.Enabled = true; } else { employeeRecordToolStripMenuItem.Enabled = false; }
                        if (feespaymentrecords == "Yes") { feePaymentRecordToolStripMenuItem.Enabled = true; } else { feePaymentRecordToolStripMenuItem.Enabled = false; }
                        if (staffpaymentrecords == "Yes") { employeePaymentRecordToolStripMenuItem.Enabled = true; } else { employeePaymentRecordToolStripMenuItem.Enabled = false; }
                        if (hostelfeespaymentrecord == "Yes") { hostelFeePaymentToolStripMenuItem1.Enabled = true; } else { hostelFeePaymentToolStripMenuItem1.Enabled = false; }
                        if (busfeespaymentrecord == "Yes") { busFeePaymentToolStripMenuItem1.Enabled = true; } else { busFeePaymentToolStripMenuItem1.Enabled = false; }
                        if (scholarshiprecords == "Yes") { scholarshipPaymentRecordToolStripMenuItem.Enabled = true; } else { scholarshipPaymentRecordToolStripMenuItem.Enabled = false; }
                        if (otherfeestransactionrecord == "Yes") { otherTransactionRecordToolStripMenuItem.Enabled = true; } else { otherTransactionRecordToolStripMenuItem.Enabled = false; }
                        if (institutionfinancialsummary == "Yes") { financialSummaryToolStripMenuItem.Enabled = true; } else { financialSummaryToolStripMenuItem.Enabled = false; }
                        if (studentfinancialsummary == "Yes") { studentsFinancialSummaryToolStripMenuItem.Enabled = true; } else { studentsFinancialSummaryToolStripMenuItem.Enabled = false; }
                        if (studentresults == "Yes") { internalMarksToolStripMenuItem.Enabled = true; } else { internalMarksToolStripMenuItem.Enabled = false; }
                        if (studentregistrationreport == "Yes") { studentsRegistrationToolStripMenuItem.Enabled = true; } else { studentsRegistrationToolStripMenuItem.Enabled = false; }
                        if (paymentreceipts == "Yes") { feeReceiptToolStripMenuItem.Enabled = true; busFeePaymentReceiptToolStripMenuItem.Enabled = true; hostelFeePaymentReceiptToolStripMenuItem.Enabled = true; } else { feeReceiptToolStripMenuItem.Enabled = false; busFeePaymentReceiptToolStripMenuItem.Enabled = false; hostelFeePaymentReceiptToolStripMenuItem.Enabled = false; }
                    }
                    else
                    {
                        hostelFeePaymentReceiptToolStripMenuItem.Enabled = false;
                        busFeePaymentReceiptToolStripMenuItem.Enabled = false;
                        feeReceiptToolStripMenuItem.Enabled = false;
                        studentsRegistrationToolStripMenuItem.Enabled = false;
                        internalMarksToolStripMenuItem.Enabled = false;
                        studentsFinancialSummaryToolStripMenuItem.Enabled = false;
                        financialSummaryToolStripMenuItem.Enabled = false;
                        otherTransactionRecordToolStripMenuItem.Enabled = false;
                        scholarshipPaymentRecordToolStripMenuItem.Enabled = false;
                        busFeePaymentToolStripMenuItem1.Enabled = false;
                        hostelFeePaymentToolStripMenuItem1.Enabled = false;
                        employeePaymentRecordToolStripMenuItem.Enabled = false;
                        feePaymentRecordToolStripMenuItem.Enabled = false;
                        employeeRecordToolStripMenuItem.Enabled = false;
                        studentAttendanceRecordToolStripMenuItem.Enabled = false;
                        studentRegistrationRecordToolStripMenuItem.Enabled = false;
                        hostelersToolStripMenuItem1.Enabled = false;
                        busHoldersToolStripMenuItem1.Enabled = false;
                        othersTransactionToolStripMenuItem.Enabled = false;
                        vehicleHireToolStripMenuItem1.Enabled = false;
                        scholarshipPaymentToolStripMenuItem.Enabled = false;
                        hostelFeesPaymentToolStripMenuItem.Enabled = false;
                        employeeSalaryToolStripMenuItem.Enabled = false;
                        busFeePaymentToolStripMenuItem2.Enabled = false;
                        balanceToolStripMenuItem.Enabled = false;
                        usageToolStripMenuItem.Enabled = false;
                        complaintsToolStripMenuItem.Enabled = false;
                        busHoldersToolStripMenuItem.Enabled = false;
                        rightsToolStripMenuItem.Enabled = false;
                        loginDetailsToolStripMenuItem.Enabled = false;
                        hostelersToolStripMenuItem.Enabled = false;
                        invetoryToolStripMenuItem.Enabled = false;
                        libraryToolStripMenuItem.Enabled = false;
                        feePaymentToolStripMenuItem.Enabled = false;
                        feePaymentToolStripMenuItem1.Enabled = false;
                        employeeSalaryToolStripMenuItem.Enabled = false;
                        salaryPaymentToolStripMenuItem.Enabled = false;
                        salaryPaymentToolStripMenuItem2.Enabled = false;
                        employeeToolStripMenuItem.Enabled = false;
                        employeeToolStripMenuItem1.Enabled = false;
                        internalMarksEntryToolStripMenuItem.Enabled = false;
                        internalMarksEntryToolStripMenuItem1.Enabled = false;
                        Master_entryMenu.Enabled = false;
                        registrationToolStripMenuItem.Enabled = false;
                        userRegistrationToolStripMenuItem.Enabled = false;
                        registrationToolStripMenuItem2.Enabled = false;
                        attendanceToolStripMenuItem.Enabled = false;
                        attendanceToolStripMenuItem1.Enabled = false;
                        studentToolStripMenuItem1.Enabled = false;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void subjectInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubjectInfo frm = new frmSubjectInfo();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistration frm = new frmUserRegistration();
            frm.label8.Text = UserType.Text;
            frm.label9.Text = User.Text;
            frm.ShowDialog();
            //this.Hide();
        }

        private void loginDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////frmLoginDetails frm = new frmLoginDetails();
            ///frm.Show();
            frmLogins frm = new frmLogins();
            frm.ShowDialog();
        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistration frm = new frmUserRegistration();
            frm.label8.Text = UserType.Text;
            frm.label9.Text = User.Text;
            frm.ShowDialog();
            //this.Hide();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmEmployeeDetails form2 = new frmEmployeeDetails();
            form2.label21.Text = UserType.Text;
            form2.label23.Text = User.Text;
            form2.ShowDialog();
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }




        private void employeePaymentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSalaryPaymentRecord frm = new frmSalaryPaymentRecord();
            frm.label1.Text = UserType.Text;
            frm.label3.Text = User.Text;
            frm.Show();
        }

        private void employeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmSalaryPayment frm = new frmSalaryPayment();
            frm.label6.Text = UserType.Text;
            frm.label7.Text = User.Text;
            frm.ShowDialog();
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStudentDetailsReport frm = new frmStudentDetailsReport();
            frm.Course.Text = "";
            frm.Branch.Text = "";
            frm.Session.Text = "";
            frm.crystalReportViewer1.ReportSource = null;
            frm.DateFrom.Text = DateTime.Today.ToString();
            frm.DateTo.Text = DateTime.Today.ToString();
            frm.crystalReportViewer2.ReportSource = null;
            frm.label4.Text = User.Text;
            frm.label5.Text = UserType.Text;
            frm.Show();
        }




        private void registrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistrationReport frm = new frmRegistrationReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                SqlDataReader rdr = null;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID from Logins WHERE UserName = '" + User.Text + "' order by ID DESC";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int Ids = Convert.ToInt32(rdr["ID"]);
                    string dts = DateTime.Now.ToLongTimeString();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "update Logins set LogOut=@d2 where UserName=@d1 and ID='" + Ids + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                    cmd.Parameters["@d1"].Value = User.Text.Trim();
                    cmd.Parameters["@d2"].Value = dts;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.User.Text = User.Text;
                frm.UserType.Text = UserType.Text;
                frm.Show();
            }
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttendance frm = new frmAttendance();
            frm.label11.Text = UserType.Text;
            frm.label12.Text = User.Text;
            frm.ShowDialog();
        }

        private void semesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSemester frm = new frmSemester();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSection frm = new frmSection();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void registrationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmStudentRegistration frm = new frmStudentRegistration();
            frm.label1.Text = UserType.Text;
            frm.label8.Text = User.Text;
            frm.ShowDialog();
        }

        private void registrationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistrationForm frm = new frmRegistrationForm();
            frm.ShowDialog();
        }

        private void studentRegistrationRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStudentRegistrationRecord frm = new frmStudentRegistrationRecord();
            frm.label5.Text = UserType.Text;
            frm.label8.Text = User.Text;
            frm.Show();
        }



        private void studentAttendanceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAttendanceRecord frm = new frmAttendanceRecord();
            frm.label24.Text = UserType.Text;
            frm.label25.Text = User.Text;
            frm.Show();
        }

        private void employeeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeRecord frm = new frmEmployeeRecord();
            frm.dataGridView1.DataSource = null;
            frm.cmbEmployeeName.Text = "";
            frm.txtEmployeeName.Text = "";
            frm.dataGridView2.DataSource = null;
            frm.label1.Text = UserType.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }

        private void feePaymentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFeesPaymentReport frm = new frmFeesPaymentReport();
            frm.label12.Text = User.Text;
            frm.label13.Text = UserType.Text;
            frm.Course.Text = "";
            frm.Branch.Text = "";
            frm.Date_from.Text = System.DateTime.Today.ToString();
            frm.Date_to.Text = System.DateTime.Today.ToString();
            frm.crystalReportViewer1.ReportSource = null;
            frm.ScholarNo.Text = "";
            frm.crystalReportViewer2.ReportSource = null;
            frm.PaymentDateFrom.Text = System.DateTime.Today.ToString();
            frm.PaymentDateTo.Text = System.DateTime.Today.ToString();
            frm.crystalReportViewer3.ReportSource = null;
            frm.DateFrom.Text = System.DateTime.Today.ToString();
            frm.DateTo.Text = System.DateTime.Today.ToString();
            frm.crystalReportViewer4.ReportSource = null;
            frm.dateTimePicker1.Text = System.DateTime.Today.ToString();
            frm.dateTimePicker2.Text = System.DateTime.Today.ToString();
            frm.crystalReportViewer5.ReportSource = null;
            frm.Show();
        }

        private void attendanceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAttendanceReport frm = new frmAttendanceReport();
            frm.label19.Text = User.Text;
            frm.label23.Text = UserType.Text;
            frm.cmbCourse.Text = "";
            frm.cmbBranch.Text = "";
            frm.cmbBranch.Enabled = false;
            frm.cmbSemester.Text = "";
            frm.cmbSemester.Enabled = false;
            frm.cmbSession.Text = "";
            frm.cmbSession.Enabled = false;
            frm.cmbSection.Text = "";
            frm.cmbSection.Enabled = false;
            frm.dateTimePicker1.Text = DateTime.Today.ToString();
            frm.dateTimePicker2.Text = DateTime.Today.ToString();
            frm.crystalReportViewer1.ReportSource = null;
            frm.cmbCourse1.Text = "";
            frm.cmbBranch1.Text = "";
            frm.cmbBranch1.Enabled = false;
            frm.cmbSemester1.Text = "";
            frm.cmbSemester1.Enabled = false;
            frm.cmbSession1.Text = "";
            frm.cmbSession1.Enabled = false;
            frm.cmbSection1.Text = "";
            frm.cmbSection1.Enabled = false;
            frm.cmbSubjectCode.Text = "";
            frm.cmbSubjectCode.Enabled = false;
            frm.txtSubjectName.Text = "";
            frm.txtSubjectName.ReadOnly = true;
            frm.dateTimePicker4.Text = DateTime.Today.ToString();
            frm.dateTimePicker3.Text = DateTime.Today.ToString();
            frm.crystalReportViewer2.ReportSource = null;
            frm.Show();
        }

        private void employeeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeReport frm = new frmEmployeeReport();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.Show();
        }

        private void otherTransactionRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTransactionRecord frm = new frmTransactionRecord();
            frm.label1.Text = UserType.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }

        private void othersTransactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTransactionReport frm = new frmTransactionReport();
            frm.label4.Text = User.Text;
            frm.label5.Text = UserType.Text;
            frm.DateFrom.Text = System.DateTime.Today.ToString();
            frm.DateTo.Text = System.DateTime.Today.ToString();
            frm.crystalReportViewer1.ReportSource = null;
            frm.dateTimePicker1.Text = System.DateTime.Today.ToString();
            frm.dateTimePicker2.Text = System.DateTime.Today.ToString(); ;
            frm.cmbTransactionType.Text = "";
            frm.crystalReportViewer2.ReportSource = null;
            frm.Show();
        }

        private void scholarshipPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmScholarshipPaymentReport frm = new frmScholarshipPaymentReport();
            frm.label10.Text = User.Text;
            frm.label11.Text = UserType.Text;
            frm.Course.Text = "";
            frm.Branch.Text = "";
            frm.Date_from.Text = System.DateTime.Today.ToString();
            frm.Date_to.Text = System.DateTime.Today.ToString();
            frm.crystalReportViewer1.ReportSource = null;
            frm.ScholarNo.Text = "";
            frm.crystalReportViewer2.ReportSource = null;
            frm.PaymentDateFrom.Text = System.DateTime.Today.ToString();
            frm.PaymentDateTo.Text = System.DateTime.Today.ToString();
            frm.crystalReportViewer3.ReportSource = null;
            frm.DateFrom.Text = System.DateTime.Today.ToString();
            frm.DateTo.Text = System.DateTime.Today.ToString();
            frm.crystalReportViewer4.ReportSource = null;
            frm.Show();
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStudent form2 = new frmStudent();
            form2.label11.Text = User.Text;
            form2.label30.Text = UserType.Text;
            form2.ShowDialog();
        }

        private void studentsRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStudentsRegistrationReport frm = new frmStudentsRegistrationReport();
            frm.label5.Text = UserType.Text;
            frm.label8.Text = User.Text;
            frm.Show();
        }

        private void salaryPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeePaymentReport frm = new frmEmployeePaymentReport();
            frm.label1.Text = UserType.Text;
            frm.label3.Text = User.Text;
            frm.crystalReportViewer1.ReportSource = null;

            frm.cmbStaffName.Text = "";
            frm.crystalReportViewer2.ReportSource = null;
            frm.DateFrom.Text = DateTime.Today.ToString();
            frm.DateTo.Text = DateTime.Today.ToString();
            frm.Show();
        }

        private void internalMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternalMarksReport frm = new frmInternalMarksReport();
            this.Hide();
            frm.label6.Text = UserType.Text;
            frm.label7.Text = User.Text;
            frm.cmbCourse.Text = "";
            frm.cmbBranch.Text = "";
            frm.cmbBranch.Enabled = false;
            frm.cmbSection.Text = "";
            frm.cmbSection.Enabled = false;
            frm.crystalReportViewer1.ReportSource = null;
            frm.Show();
        }

        private void internalMarksEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInternalMarksEntry frm = new frmInternalMarksEntry();
            //this.Hide();
            frm.label5.Text = UserType.Text;
            frm.label6.Text = User.Text;
            frm.ShowDialog();
        }

        private void scholarshipPaymentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmScholarshipPaymentRecord frm = new frmScholarshipPaymentRecord();
            frm.label10.Text = UserType.Text;
            frm.label11.Text = User.Text;
            frm.Show();
        }

        private void feePaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmFeesPayment form2 = new frmFeesPayment();
            form2.label23.Text = UserType.Text;
            form2.label24.Text = User.Text;
            form2.ShowDialog();
        }

        private void attendanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmAttendance frm = new frmAttendance();
            frm.label11.Text = UserType.Text;
            frm.label12.Text = User.Text;
            frm.ShowDialog();
        }

        private void salaryPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //this.Hide();
            frmSalaryPayment frm = new frmSalaryPayment();
            frm.label6.Text = UserType.Text;
            frm.label7.Text = User.Text;
            frm.ShowDialog();
        }


        private void hostelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostel frm = new frmHostel();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void hostelFeesPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmHostelFeePayment frm = new frmHostelFeePayment();
            frm.label3.Text = UserType.Text;
            frm.label4.Text = User.Text;
            frm.ShowDialog();
        }
        private void studentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentDetailsRpt frm = new frmStudentDetailsRpt();
            frm.Show();
        }

        private void feeReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourseFeePaymentReceipt frm = new frmCourseFeePaymentReceipt();
            frm.Show();
        }

        private void salarySlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalarySlipRpt frm = new frmSalarySlipRpt();
            frm.Show();
        }

        private void feesDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFeeDetailsReport frm = new frmFeeDetailsReport();
            frm.Show();
        }

        private void hostelersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelers frm = new frmHostelers();
            frm.label3.Text = User.Text;
            frm.ShowDialog();
        }

        private void hostelersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHostelersRecord1 frm = new frmHostelersRecord1();
            frm.label5.Text = UserType.Text;
            frm.label13.Text = User.Text;
            frm.Show();
        }

        private void hostlersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHostelersReport frm = new frmHostelersReport();
            frm.label5.Text = UserType.Text;
            frm.label13.Text = User.Text;
            frm.Show();
        }

        private void hostelFeePaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHostelFeePaymentRecord frm = new frmHostelFeePaymentRecord();
            frm.label13.Text = UserType.Text;
            frm.label14.Text = User.Text;
            frm.Show();
        }

        private void hostelFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHostelFeePaymentReport frm = new frmHostelFeePaymentReport();
            frm.label12.Text = UserType.Text;
            frm.label13.Text = User.Text;
            frm.Show();
        }

        private void scholarshipPaymentReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScholarshipPaymentReceiptRpt frm = new frmScholarshipPaymentReceiptRpt();
            frm.Show();
        }

        private void hostelFeePaymentReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelFeePaymentReceiptRpt frm = new frmHostelFeePaymentReceiptRpt();
            frm.Show();
        }



        private void transportationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransportation frm = new frmTransportation();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void transportationChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransportationReport frm = new frmTransportationReport();
            frm.Show();
        }

        private void busHoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusHolders frm = new frmBusHolders();
            frm.label3.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void busHoldersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBusHoldersRecord frm = new frmBusHoldersRecord();
            frm.label5.Text = UserType.Text;
            frm.label13.Text = User.Text;
            frm.Show();
        }

        private void busFeePaymentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmBusFeePayment frm = new frmBusFeePayment();
            frm.label3.Text = UserType.Text;
            frm.label4.Text = User.Text;
            frm.ShowDialog();
        }

        private void busFeePaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBusFeePaymentRecord frm = new frmBusFeePaymentRecord();
            frm.label13.Text = UserType.Text;
            frm.label14.Text = User.Text;
            frm.Show();
        }

        private void busHoldersToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBusHoldersReport frm = new frmBusHoldersReport();
            frm.label5.Text = UserType.Text;
            frm.label13.Text = User.Text;
            frm.Show();
        }

        private void busFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBusFeePaymentReport frm = new frmBusFeePaymentReport();
            frm.label12.Text = UserType.Text;
            frm.label13.Text = User.Text;
            frm.Show();
        }

        private void busFeePaymentReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusFeePaymentReceiptRpt frm = new frmBusFeePaymentReceiptRpt();
            frm.Show();
        }

        private void subjectInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSubjectInfoReport frm = new frmSubjectInfoReport();
            frm.Show();
        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEvent frm = new frmEvent();
            frm.label6.Text = User.Text;
            frm.ShowDialog();
        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatch frm = new frmBatch();
            frm.label6.Text = User.Text;
            frm.ShowDialog();

        }
        private void EventtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEventsReport frm = new frmEventsReport();
            frm.Show();
        }

        private void vehicleHireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransportationHire frm = new frmTransportationHire();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void academicDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frnLibraryDepartment frm = new frnLibraryDepartment();
            frm.label1.Text = UserType.Text;
            frm.label3.Text = User.Text;
            frm.ShowDialog();
        }

        private void librarySectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLibrarySections frm = new frmLibrarySections();
            frm.label1.Text = UserType.Text;
            frm.label3.Text = User.Text;
            frm.ShowDialog();
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChat frm = new frmChat();
            frm.label4.Text = UserType.Text;
            frm.label5.Text = User.Text;
            frm.ShowDialog();
        }

        private void complaintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmViewComplaints frm = new frmViewComplaints();
            frm.label1.Text = UserType.Text;
            frm.label2.Text = User.Text;
            frm.ShowDialog();
        }

        private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmItemUsageDetails frm = new frmItemUsageDetails();
            frm.label13.Text = UserType.Text;
            frm.label21.Text = User.Text;
            frm.ShowDialog();
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmItemUsageBalance frm = new frmItemUsageBalance();
            frm.label13.Text = UserType.Text;
            frm.label14.Text = User.Text;
            frm.ShowDialog();
        }

        private void vehicleHireToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmBusFeePaymentHire frm = new frmBusFeePaymentHire();
            frm.label3.Text = UserType.Text;
            frm.label4.Text = User.Text;
            frm.ShowDialog();
        }

        private void libraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLibraryRegistration frm = new frmLibraryRegistration();
            frm.label23.Text = User.Text;
            frm.label19.Text = User.Text;
            frm.ShowDialog();
        }

        private void invetoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmPurchaseDetails frm = new frmPurchaseDetails();
            frm.label13.Text = UserType.Text;
            frm.label21.Text = User.Text;
            frm.ShowDialog();
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                cmd.Parameters["@d1"].Value = User.Text.Trim();
                cmd.Parameters["@d2"].Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.Show();
            }
        }

        private void financialSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFinancialSummary frm = new frmFinancialSummary();
            frm.label1.Text = UserType.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }

        private void studentsFinancialSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStudentsFinancialSummary frm = new frmStudentsFinancialSummary();
            frm.label1.Text = UserType.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }

        private void rightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAccessRights frm = new FrmAccessRights();
            frm.ShowDialog();
        }

        private void userTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserTypes frm = new frmUserTypes();
            frm.ShowDialog();
        }

        private void hostelRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBedMade frm = new frmBedMade();
            frm.ShowDialog();
        }

        private void hostelRoomPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetOrder7 frm = new frmSetOrder7();
            frm.label13.Text = User.Text;
            frm.ShowDialog();
        }

        private void salaryPaymentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSalaryPayment frm = new frmSalaryPayment();
            frm.label6.Text = UserType.Text;
            frm.label7.Text = User.Text;
            frm.ShowDialog();
        }

        private void itemPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmPurchaseDetails frm = new frmPurchaseDetails();
            frm.label13.Text = UserType.Text;
            frm.label21.Text = User.Text;
            frm.ShowDialog();
        }

        private void supplierAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierAccounts frm = new frmSupplierAccounts();
            frm.label4.Text = User.Text;
            frm.ShowDialog();
        }

        private void supplierAccountBalancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierAccountBalance frm = new frmSupplierAccountBalance();
            frm.label12.Text = User.Text;
            frm.ShowDialog();
        }

        private void expenseTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpensesType frm = new frmExpensesType();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEXpenses frm = new frmEXpenses();
            frm.label1.Text = User.Text;
            frm.label2.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void institutionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigureCompanyDetails frm = new frmConfigureCompanyDetails();
            frm.ShowDialog();
        }

        private void libraryRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLibraryRecords frm = new frmLibraryRecords();
            frm.ShowDialog();
        }

        private void libraryRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLibraryRequests frm = new frmLibraryRequests();
            frm.ShowDialog();
        }

        private void libraryBookCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLibraryBookCategory frm = new frmLibraryBookCategory();
            frm.label1.Text = User.Text;
            frm.ShowDialog();
        }

        private void otherFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOtherFeesDetails frm = new frmOtherFeesDetails();
            frm.label13.Text = User.Text;
            frm.ShowDialog();
        }

        private void otherFeesPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOtherFeesPayment form2 = new frmOtherFeesPayment();
            form2.label23.Text = UserType.Text;
            form2.label24.Text = User.Text;
            form2.ShowDialog();
        }
    }

}

      

     

       
      

      

      

      

       

      


       

       
   

