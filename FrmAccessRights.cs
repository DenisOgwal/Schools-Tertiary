using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace College_Management_System
{
    public partial class FrmAccessRights : Form
    {
        public FrmAccessRights()
        {
            InitializeComponent();
        }
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
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
            dataGridView1.DataSource = null;
            dynamic SelectQry = "select RTRIM(Username)[User Name],RTRIM(usertype)[UserType] from User_Registration order by Username ASC ";
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
        private void FrmAccessRights_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAccessRights frm = new FrmAccessRights();
            frm.ShowDialog();
        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                string clientnames = dr.Cells[0].Value.ToString();
                expandablePanel2.TitleText = clientnames;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserAccess where UserName='" + expandablePanel2.TitleText + "' ";
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
                   

                    if (masterentry == "Yes") { checkBoxItem1.Checked = true; } else { checkBoxItem1.Checked = false; }
                    if (accountcreation == "Yes") { checkBoxItem2.Checked = true; } else { checkBoxItem2.Checked = false; }
                    if (studentregistration == "Yes") { checkBoxItem3.Checked = true; } else { checkBoxItem3.Checked = false; }
                    if (attendance == "Yes") { checkBoxItem4.Checked = true; } else { checkBoxItem4.Checked = false; }
                    if (marksentry == "Yes") { checkBoxItem5.Checked = true; } else { checkBoxItem5.Checked = false; }
                    if (staffregistration == "Yes") { checkBoxItem6.Checked = true; } else { checkBoxItem6.Checked = false; }
                    if (salarypayment == "Yes") { checkBoxItem7.Checked = true; } else { checkBoxItem7.Checked = false; }
                    if (feespayment == "Yes") { checkBoxItem8.Checked = true; } else { checkBoxItem8.Checked = false; }
                    if (libraryaccess == "Yes") { checkBoxItem9.Checked = true; } else { checkBoxItem9.Checked = false; }
                    if (inventoryentry== "Yes") { checkBoxItem10.Checked = true; } else { checkBoxItem10.Checked = false; }
                    if (assignrights == "Yes") { checkBoxItem11.Checked = true; } else { checkBoxItem11.Checked = false; }
                    if (accesslogins == "Yes") { checkBoxItem12.Checked = true; } else { checkBoxItem12.Checked = false; }
                    if (registerhostlers == "Yes") { checkBoxItem13.Checked = true; } else { checkBoxItem13.Checked = false; }
                    if (registerbusholders == "Yes") { checkBoxItem14.Checked = true; } else { checkBoxItem14.Checked = false; }
                    if (accesssttudentcomplaints == "Yes") { checkBoxItem15.Checked = true; } else { checkBoxItem15.Checked = false; }
                    if (inventoryusage == "Yes") { checkBoxItem16.Checked = true; } else { checkBoxItem16.Checked = false; }
                    if ( inventorystockaccess== "Yes") { checkBoxItem17.Checked = true; } else { checkBoxItem17.Checked = false; }
                    if (busfeespayment == "Yes") { checkBoxItem18.Checked = true; } else { checkBoxItem18.Checked = false; }
                    if (staffsalarypayment == "Yes") { checkBoxItem19.Checked = true; } else { checkBoxItem19.Checked = false; }
                    if (hostelfeespayment == "Yes") { checkBoxItem20.Checked = true; } else { checkBoxItem20.Checked = false; }
                    if (scholarshipassignments == "Yes") { checkBoxItem21.Checked = true; } else { checkBoxItem21.Checked = false; }
                    if (vehiclehiretransactions == "Yes") { checkBoxItem22.Checked = true; } else { checkBoxItem22.Checked = false; }
                    if (othertransactions == "Yes") { checkBoxItem23.Checked = true; } else { checkBoxItem23.Checked = false; }
                    if (studentregistrationrecords == "Yes") { checkBoxItem24.Checked = true; } else { checkBoxItem24.Checked = false; }
                    if (hostelersrecords == "Yes") { checkBoxItem25.Checked = true; } else { checkBoxItem25.Checked = false; }
                    if (busholdersrecords == "Yes") { checkBoxItem26.Checked = true; } else { checkBoxItem26.Checked = false; }
                    if (studentattendancerecord == "Yes") { checkBoxItem27.Checked = true; } else { checkBoxItem27.Checked = false; }
                    if (staffrecords == "Yes") { checkBoxItem28.Checked = true; } else { checkBoxItem28.Checked = false; }
                    if (feespaymentrecords == "Yes") { checkBoxItem29.Checked = true; } else { checkBoxItem29.Checked = false; }
                    if (staffpaymentrecords == "Yes") { checkBoxItem30.Checked = true; } else { checkBoxItem30.Checked = false; }
                    if (hostelfeespaymentrecord == "Yes") { checkBoxItem31.Checked = true; } else { checkBoxItem31.Checked = false; }
                    if (busfeespaymentrecord == "Yes") { checkBoxItem32.Checked = true; } else { checkBoxItem32.Checked = false; }
                    if (scholarshiprecords == "Yes") { checkBoxItem33.Checked = true; } else { checkBoxItem33.Checked = false; }
                    if (otherfeestransactionrecord == "Yes") { checkBoxItem34.Checked = true; } else { checkBoxItem34.Checked = false; }
                    if (institutionfinancialsummary == "Yes") { checkBoxItem35.Checked = true; } else { checkBoxItem35.Checked = false; }
                    if (studentfinancialsummary == "Yes") { checkBoxItem36.Checked = true; } else { checkBoxItem36.Checked = false; }
                    if (studentresults == "Yes") { checkBoxItem37.Checked = true; } else { checkBoxItem37.Checked = false; }
                    if (studentregistrationreport == "Yes") { checkBoxItem38.Checked = true; } else { checkBoxItem38.Checked = false; }
                    if (paymentreceipts== "Yes") { checkBoxItem39.Checked = true; } else { checkBoxItem39.Checked = false; }
                    if (updates == "Yes") { checkBoxItem40.Checked = true; } else { checkBoxItem40.Checked = false; }
                    if (deletes == "Yes") { checkBoxItem41.Checked = true; } else { checkBoxItem41.Checked = false; }
                }
                else
                {
                    checkBoxItem1.Checked = false;
                    checkBoxItem2.Checked = false;
                    checkBoxItem3.Checked = false;
                    checkBoxItem4.Checked = false;
                    checkBoxItem5.Checked = false;
                    checkBoxItem6.Checked = false;
                    checkBoxItem7.Checked = false;
                    checkBoxItem8.Checked = false;
                    checkBoxItem9.Checked = false;
                    checkBoxItem10.Checked = false;
                    checkBoxItem11.Checked = false;
                    checkBoxItem12.Checked = false;
                    checkBoxItem15.Checked = false;
                    checkBoxItem13.Checked = false;
                    checkBoxItem14.Checked = false;
                    checkBoxItem16.Checked = false;
                    checkBoxItem17.Checked = false;
                    checkBoxItem18.Checked = false;
                    checkBoxItem19.Checked = false;
                    checkBoxItem20.Checked = false;
                    checkBoxItem21.Checked = false;
                    checkBoxItem22.Checked = false;
                    checkBoxItem23.Checked = false;
                    checkBoxItem24.Checked = false;
                    checkBoxItem25.Checked = false;
                    checkBoxItem26.Checked = false;
                    checkBoxItem27.Checked = false;
                    checkBoxItem28.Checked = false;
                    checkBoxItem29.Checked = false;
                    checkBoxItem30.Checked = false;
                    checkBoxItem31.Checked = false;
                    checkBoxItem32.Checked = false;
                    checkBoxItem33.Checked = false;
                    checkBoxItem34.Checked = false;
                    checkBoxItem35.Checked = false;
                    checkBoxItem36.Checked = false;
                    checkBoxItem37.Checked = false;
                    checkBoxItem38.Checked = false;
                    checkBoxItem39.Checked = false;
                    checkBoxItem40.Checked = false;
                    checkBoxItem41.Checked = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string masterentry, accountcreation, studentregistration, attendance, marksentry, staffregistration, salarypayment, feespayment, libraryaccess, inventoryentry = null;
        string assignrights, accesslogins, registerhostlers, registerbusholders, accesssttudentcomplaints, inventoryusage, inventorystockaccess, busfeespayment, staffsalarypayment = null;
        string hostelfeespayment, scholarshipassignments, vehiclehiretransactions, othertransactions, studentregistrationrecords, hostelersrecords, busholdersrecords, studentattendancerecord, staffrecords, feespaymentrecords = null;
        string staffpaymentrecords, hostelfeespaymentrecord, busfeespaymentrecord, scholarshiprecords, otherfeestransactionrecord, institutionfinancialsummary, studentfinancialsummary = null;
        string studentresults, studentregistrationreport, paymentreceipts, deletes, updates = null;
        public void Checkboxes()
        {
            if (checkBoxItem1.Checked == true) { masterentry = "Yes"; } else { masterentry = "No"; }
            if (checkBoxItem2.Checked == true) { accountcreation = "Yes"; } else { accountcreation = "No"; }
            if (checkBoxItem3.Checked == true) { studentregistration = "Yes"; } else { studentregistration = "No"; }
            if (checkBoxItem4.Checked == true) { attendance = "Yes"; } else { attendance = "No"; }
            if (checkBoxItem5.Checked == true) { marksentry = "Yes"; } else { marksentry = "No"; }
            if (checkBoxItem6.Checked == true) { staffregistration = "Yes"; } else { staffregistration = "No"; }
            if (checkBoxItem7.Checked == true) { salarypayment = "Yes"; } else { salarypayment = "No"; }
            if (checkBoxItem8.Checked == true) { feespayment = "Yes"; } else { feespayment = "No"; }
            if (checkBoxItem9.Checked == true) { libraryaccess = "Yes"; } else { libraryaccess = "No"; }
            if (checkBoxItem10.Checked == true) { inventoryentry = "Yes"; } else { inventoryentry = "No"; }
            if (checkBoxItem11.Checked == true) { assignrights = "Yes"; } else { assignrights = "No"; }
            if (checkBoxItem12.Checked == true) { accesslogins = "Yes"; } else { accesslogins = "No"; }
            if (checkBoxItem13.Checked == true) { registerhostlers = "Yes"; } else { registerhostlers = "No"; }
            if (checkBoxItem14.Checked == true) { registerbusholders = "Yes"; } else { registerbusholders = "No"; }
            if (checkBoxItem15.Checked == true) { accesssttudentcomplaints = "Yes"; } else { accesssttudentcomplaints = "No"; }
            if (checkBoxItem16.Checked == true) { inventoryusage = "Yes"; } else { inventoryusage = "No"; }
            if (checkBoxItem17.Checked == true) { inventorystockaccess = "Yes"; } else { inventorystockaccess = "No"; }
            if (checkBoxItem18.Checked == true) { busfeespayment = "Yes"; } else { busfeespayment = "No"; }
            if (checkBoxItem19.Checked == true) { staffsalarypayment = "Yes"; } else { staffsalarypayment = "No"; }
            if (checkBoxItem20.Checked == true) { hostelfeespayment = "Yes"; } else { hostelfeespayment = "No"; }
            if (checkBoxItem21.Checked == true) { scholarshipassignments = "Yes"; } else { scholarshipassignments = "No"; }
            if (checkBoxItem22.Checked == true) { vehiclehiretransactions = "Yes"; } else { vehiclehiretransactions = "No"; }
            if (checkBoxItem23.Checked == true) { othertransactions = "Yes"; } else { othertransactions = "No"; }
            if (checkBoxItem24.Checked == true) { studentregistrationrecords = "Yes"; } else { studentregistrationrecords = "No"; }
            if (checkBoxItem25.Checked == true) { hostelersrecords = "Yes"; } else { hostelersrecords = "No"; }
            if (checkBoxItem26.Checked == true) { busholdersrecords = "Yes"; } else { busholdersrecords = "No"; }
            if (checkBoxItem27.Checked == true) { studentattendancerecord = "Yes"; } else { studentattendancerecord = "No"; }
            if (checkBoxItem28.Checked == true) { staffrecords = "Yes"; } else { staffrecords = "No"; }
            if (checkBoxItem29.Checked == true) { feespaymentrecords = "Yes"; } else { feespaymentrecords = "No"; }
            if (checkBoxItem30.Checked == true) { staffpaymentrecords = "Yes"; } else { staffpaymentrecords = "No"; }
            if (checkBoxItem31.Checked == true) { hostelfeespaymentrecord = "Yes"; } else { hostelfeespaymentrecord = "No"; }
            if (checkBoxItem32.Checked == true) { busfeespaymentrecord = "Yes"; } else { busfeespaymentrecord = "No"; }
            if (checkBoxItem33.Checked == true) { scholarshiprecords = "Yes"; } else { scholarshiprecords = "No"; }
            if (checkBoxItem34.Checked == true) { otherfeestransactionrecord = "Yes"; } else { otherfeestransactionrecord = "No"; }
            if (checkBoxItem35.Checked == true) { institutionfinancialsummary = "Yes"; } else { institutionfinancialsummary = "No"; }
            if (checkBoxItem36.Checked == true) { studentfinancialsummary = "Yes"; } else { studentfinancialsummary = "No"; }
            if (checkBoxItem37.Checked == true) { studentresults = "Yes"; } else { studentresults = "No"; }
            if (checkBoxItem38.Checked == true) { studentregistrationreport = "Yes"; } else { studentregistrationreport = "No"; }
            if (checkBoxItem39.Checked == true) { paymentreceipts = "Yes"; } else { paymentreceipts = "No"; }
            if (checkBoxItem40.Checked == true) { updates = "Yes"; } else { updates = "No"; }
            if (checkBoxItem41.Checked == true) { deletes = "Yes"; } else { deletes = "No"; }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (expandablePanel2.TitleText == "Rights")
                {
                    MessageBox.Show("Please First Select User", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Checkboxes();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT UserName FROM UserAccess where UserName='" + expandablePanel2.TitleText + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update UserAccess set Deletes=@d42,Updates=@d41,PaymentReceipts=@d40,StudentRegistrationReport=@d39,StudentResults=@d38,StudentFiancialSummary=@d37,InstitutionFinancialSummary=@d36,OtherFeesTransactionsRecord=@d35,ScholarshipRecords=@d34,BusFeesPaymentRecord=@d33,HostelFeesPaymentRecords=@d32,StaffPaymentRecords=@d31,FeesPaymentRecords=@d30,StaffRecords=@d29,StudentAttendanceRecord=@d28,BusHoldersRecords=@d27,HostelersRecords=@d26,StudentRegistrationRecords=@d25,OtherTransactions=@d24,VehicleHireTransactions=@d23,ScholarshipAssignments=@d22,HostelFeesPayment=@d21,StaffSalaryPayment=@d20,BusFeesPayment=@d19,InventoryStockAccess=@d18,InventoryUsage=@d17,AccessStudentComplaints=@d16,RegisterBusHolders=@d15,RegisterHostelers=@d14,AccessLogins=@d13,AssignRights=@d12,InventoryAccess=@d11,LibraryAccess=@d10,FeesPayment=@d9,SalaryPayment=@d8,StaffRegistration=@d7,MarksEntry=@d6,Attendance=@d5,StudentRegistration=@d4,AccountCreation=@d3,MasterEntry=@d2 where UserName=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "MasterEntry"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "AccountCreation"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "StudentRegistration"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Attendance"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "MarksEntry"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "StaffRegistration"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "SalaryPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "FeesPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "LibraryAccess"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "InventoryAccess"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "AssignRights"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "AccessLogins"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "RegisterHostelers"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "RegisterBusHolders"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "AccessStudentComplaints"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "InventoryUsage"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 10, "InventoryStockAccess"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 10, "BusFeesPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 10, "StaffSalaryPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 10, "HostelFeesPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 10, "ScholarshipAssignments"));
                    cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 10, "VehicleHireTransactions"));
                    cmd.Parameters.Add(new SqlParameter("@d24", System.Data.SqlDbType.NChar, 10, "OtherTransactions"));
                    cmd.Parameters.Add(new SqlParameter("@d25", System.Data.SqlDbType.NChar, 10, "StudentRegistrationRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d26", System.Data.SqlDbType.NChar, 10, "HostelersRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d27", System.Data.SqlDbType.NChar, 10, "BusHoldersRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d28", System.Data.SqlDbType.NChar, 10, "StudentAttendanceRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d29", System.Data.SqlDbType.NChar, 10, "StaffRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d30", System.Data.SqlDbType.NChar, 10, "FeesPaymentRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d31", System.Data.SqlDbType.NChar, 10, "StaffPaymentRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d32", System.Data.SqlDbType.NChar, 10, "HostelFeesPaymentRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d33", System.Data.SqlDbType.NChar, 10, "BusFeesPaymentRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d34", System.Data.SqlDbType.NChar, 10, "ScholarshipRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d35", System.Data.SqlDbType.NChar, 10, "OtherFeesTransactionsRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d36", System.Data.SqlDbType.NChar, 10, "InstitutionFinancialSummary"));
                    cmd.Parameters.Add(new SqlParameter("@d37", System.Data.SqlDbType.NChar, 10, "StudentFiancialSummary"));
                    cmd.Parameters.Add(new SqlParameter("@d38", System.Data.SqlDbType.NChar, 10, "StudentResults"));
                    cmd.Parameters.Add(new SqlParameter("@d39", System.Data.SqlDbType.NChar, 10, "StudentRegistrationReport"));
                    cmd.Parameters.Add(new SqlParameter("@d40", System.Data.SqlDbType.NChar, 10, "PaymentReceipts"));
                    cmd.Parameters.Add(new SqlParameter("@d41", System.Data.SqlDbType.NChar, 10, "Updates"));
                    cmd.Parameters.Add(new SqlParameter("@d42", System.Data.SqlDbType.NChar, 10, "Deletes"));
                    cmd.Parameters["@d1"].Value = expandablePanel2.TitleText;
                    cmd.Parameters["@d2"].Value = masterentry;
                    cmd.Parameters["@d3"].Value = accountcreation;
                    cmd.Parameters["@d4"].Value = studentregistration;
                    cmd.Parameters["@d5"].Value = attendance;
                    cmd.Parameters["@d6"].Value = marksentry;
                    cmd.Parameters["@d7"].Value = staffregistration;
                    cmd.Parameters["@d8"].Value = salarypayment;
                    cmd.Parameters["@d9"].Value = feespayment;
                    cmd.Parameters["@d10"].Value = libraryaccess;
                    cmd.Parameters["@d11"].Value = inventoryentry;
                    cmd.Parameters["@d12"].Value = assignrights;
                    cmd.Parameters["@d13"].Value = accesslogins;
                    cmd.Parameters["@d14"].Value = registerhostlers;
                    cmd.Parameters["@d15"].Value = registerbusholders;
                    cmd.Parameters["@d16"].Value = accesssttudentcomplaints;
                    cmd.Parameters["@d17"].Value = inventoryusage;
                    cmd.Parameters["@d18"].Value = inventorystockaccess;
                    cmd.Parameters["@d19"].Value = busfeespayment;
                    cmd.Parameters["@d20"].Value = staffsalarypayment;
                    cmd.Parameters["@d21"].Value = hostelfeespayment;
                    cmd.Parameters["@d22"].Value = scholarshipassignments;
                    cmd.Parameters["@d23"].Value = vehiclehiretransactions;
                    cmd.Parameters["@d24"].Value = othertransactions;
                    cmd.Parameters["@d25"].Value = studentregistrationrecords;
                    cmd.Parameters["@d26"].Value = hostelersrecords;
                    cmd.Parameters["@d27"].Value = busholdersrecords;
                    cmd.Parameters["@d28"].Value = studentattendancerecord;
                    cmd.Parameters["@d29"].Value = staffrecords;
                    cmd.Parameters["@d30"].Value = feespaymentrecords;
                    cmd.Parameters["@d31"].Value = staffpaymentrecords;
                    cmd.Parameters["@d32"].Value = hostelfeespaymentrecord;
                    cmd.Parameters["@d33"].Value = busfeespaymentrecord;
                    cmd.Parameters["@d34"].Value = scholarshiprecords;
                    cmd.Parameters["@d35"].Value = otherfeestransactionrecord;
                    cmd.Parameters["@d36"].Value = institutionfinancialsummary;
                    cmd.Parameters["@d37"].Value = studentfinancialsummary;
                    cmd.Parameters["@d38"].Value = studentresults;
                    cmd.Parameters["@d39"].Value = studentregistrationreport;
                    cmd.Parameters["@d40"].Value = paymentreceipts;
                    cmd.Parameters["@d41"].Value = updates;
                    cmd.Parameters["@d42"].Value = deletes;
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully updated", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FrmAccessRights frm = new FrmAccessRights();
                    frm.ShowDialog();
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "Insert Into UserAccess (Username,MasterEntry,AccountCreation,StudentRegistration,Attendance,MarksEntry,StaffRegistration,SalaryPayment,FeesPayment,LibraryAccess,InventoryAccess,AssignRights,AccessLogins,RegisterHostelers,RegisterBusHolders,AccessStudentComplaints,InventoryUsage,InventoryStockAccess,BusFeesPayment,StaffSalaryPayment,HostelFeesPayment,ScholarshipAssignments,VehicleHireTransactions,OtherTransactions,StudentRegistrationRecords,HostelersRecords,BusHoldersRecords,StudentAttendanceRecord,StaffRecords,FeesPaymentRecords,StaffPaymentRecords,HostelFeesPaymentRecords,BusFeesPaymentRecord,ScholarshipRecords,OtherFeesTransactionsRecord,InstitutionFinancialSummary,StudentFiancialSummary,StudentResults,StudentRegistrationReport,PaymentReceipts,Updates,Deletes) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35,@d36,@d37,@d38,@d39,@d40,@d41,@d42)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 50, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 10, "MasterEntry"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 10, "AccountCreation"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 10, "StudentRegistration"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 10, "Attendance"));
                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.NChar, 10, "MarksEntry"));
                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.NChar, 10, "StaffRegistration"));
                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.NChar, 10, "SalaryPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.NChar, 10, "FeesPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.NChar, 10, "LibraryAccess"));
                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.NChar, 10, "InventoryAccess"));
                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.NChar, 10, "AssignRights"));
                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.NChar, 10, "AccessLogins"));
                    cmd.Parameters.Add(new SqlParameter("@d14", System.Data.SqlDbType.NChar, 10, "RegisterHostelers"));
                    cmd.Parameters.Add(new SqlParameter("@d15", System.Data.SqlDbType.NChar, 10, "RegisterBusHolders"));
                    cmd.Parameters.Add(new SqlParameter("@d16", System.Data.SqlDbType.NChar, 10, "AccessStudentComplaints"));
                    cmd.Parameters.Add(new SqlParameter("@d17", System.Data.SqlDbType.NChar, 10, "InventoryUsage"));
                    cmd.Parameters.Add(new SqlParameter("@d18", System.Data.SqlDbType.NChar, 10, "InventoryStockAccess"));
                    cmd.Parameters.Add(new SqlParameter("@d19", System.Data.SqlDbType.NChar, 10, "BusFeesPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d20", System.Data.SqlDbType.NChar, 10, "StaffSalaryPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d21", System.Data.SqlDbType.NChar, 10, "HostelFeesPayment"));
                    cmd.Parameters.Add(new SqlParameter("@d22", System.Data.SqlDbType.NChar, 10, "ScholarshipAssignments"));
                    cmd.Parameters.Add(new SqlParameter("@d23", System.Data.SqlDbType.NChar, 10, "VehicleHireTransactions"));
                    cmd.Parameters.Add(new SqlParameter("@d24", System.Data.SqlDbType.NChar, 10, "OtherTransactions"));
                    cmd.Parameters.Add(new SqlParameter("@d25", System.Data.SqlDbType.NChar, 10, "StudentRegistrationRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d26", System.Data.SqlDbType.NChar, 10, "HostelersRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d27", System.Data.SqlDbType.NChar, 10, "BusHoldersRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d28", System.Data.SqlDbType.NChar, 10, "StudentAttendanceRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d29", System.Data.SqlDbType.NChar, 10, "StaffRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d30", System.Data.SqlDbType.NChar, 10, "FeesPaymentRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d31", System.Data.SqlDbType.NChar, 10, "StaffPaymentRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d32", System.Data.SqlDbType.NChar, 10, "HostelFeesPaymentRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d33", System.Data.SqlDbType.NChar, 10, "BusFeesPaymentRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d34", System.Data.SqlDbType.NChar, 10, "ScholarshipRecords"));
                    cmd.Parameters.Add(new SqlParameter("@d35", System.Data.SqlDbType.NChar, 10, "OtherFeesTransactionsRecord"));
                    cmd.Parameters.Add(new SqlParameter("@d36", System.Data.SqlDbType.NChar, 10, "InstitutionFinancialSummary"));
                    cmd.Parameters.Add(new SqlParameter("@d37", System.Data.SqlDbType.NChar, 10, "StudentFiancialSummary"));
                    cmd.Parameters.Add(new SqlParameter("@d38", System.Data.SqlDbType.NChar, 10, "StudentResults"));
                    cmd.Parameters.Add(new SqlParameter("@d39", System.Data.SqlDbType.NChar, 10, "StudentRegistrationReport"));
                    cmd.Parameters.Add(new SqlParameter("@d40", System.Data.SqlDbType.NChar, 10, "PaymentReceipts"));
                    cmd.Parameters.Add(new SqlParameter("@d41", System.Data.SqlDbType.NChar, 10, "Updates"));
                    cmd.Parameters.Add(new SqlParameter("@d42", System.Data.SqlDbType.NChar, 10, "Deletes"));
                    cmd.Parameters["@d1"].Value = expandablePanel2.TitleText;
                    cmd.Parameters["@d2"].Value = masterentry;
                    cmd.Parameters["@d3"].Value = accountcreation;
                    cmd.Parameters["@d4"].Value = studentregistration;
                    cmd.Parameters["@d5"].Value = attendance;
                    cmd.Parameters["@d6"].Value = marksentry;
                    cmd.Parameters["@d7"].Value = staffregistration;
                    cmd.Parameters["@d8"].Value = salarypayment;
                    cmd.Parameters["@d9"].Value = feespayment;
                    cmd.Parameters["@d10"].Value = libraryaccess;
                    cmd.Parameters["@d11"].Value = inventoryentry;
                    cmd.Parameters["@d12"].Value = assignrights;
                    cmd.Parameters["@d13"].Value = accesslogins;
                    cmd.Parameters["@d14"].Value = registerhostlers;
                    cmd.Parameters["@d15"].Value = registerbusholders;
                    cmd.Parameters["@d16"].Value = accesssttudentcomplaints;
                    cmd.Parameters["@d17"].Value = inventoryusage;
                    cmd.Parameters["@d18"].Value = inventorystockaccess;
                    cmd.Parameters["@d19"].Value = busfeespayment;
                    cmd.Parameters["@d20"].Value = staffsalarypayment;
                    cmd.Parameters["@d21"].Value = hostelfeespayment;
                    cmd.Parameters["@d22"].Value = scholarshipassignments;
                    cmd.Parameters["@d23"].Value = vehiclehiretransactions;
                    cmd.Parameters["@d24"].Value = othertransactions;
                    cmd.Parameters["@d25"].Value = studentregistrationrecords;
                    cmd.Parameters["@d26"].Value = hostelersrecords;
                    cmd.Parameters["@d27"].Value = busholdersrecords;
                    cmd.Parameters["@d28"].Value = studentattendancerecord;
                    cmd.Parameters["@d29"].Value = staffrecords;
                    cmd.Parameters["@d30"].Value = feespaymentrecords;
                    cmd.Parameters["@d31"].Value = staffpaymentrecords;
                    cmd.Parameters["@d32"].Value = hostelfeespaymentrecord;
                    cmd.Parameters["@d33"].Value = busfeespaymentrecord;
                    cmd.Parameters["@d34"].Value = scholarshiprecords;
                    cmd.Parameters["@d35"].Value = otherfeestransactionrecord;
                    cmd.Parameters["@d36"].Value = institutionfinancialsummary;
                    cmd.Parameters["@d37"].Value = studentfinancialsummary;
                    cmd.Parameters["@d38"].Value = studentresults;
                    cmd.Parameters["@d39"].Value = studentregistrationreport;
                    cmd.Parameters["@d40"].Value = paymentreceipts;
                    cmd.Parameters["@d41"].Value = updates;
                    cmd.Parameters["@d42"].Value = deletes;
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully Saved", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FrmAccessRights frm = new FrmAccessRights();
                    frm.ShowDialog();
                }
                con.Close();
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
    }
}
