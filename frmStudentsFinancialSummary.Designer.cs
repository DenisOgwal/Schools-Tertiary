namespace College_Management_System
{
    partial class frmStudentsFinancialSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentsFinancialSummary));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.studentno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.ComboBox();
            this.term = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.transportduepayment = new System.Windows.Forms.TextBox();
            this.transporttotalpaid = new System.Windows.Forms.TextBox();
            this.transportpayablefees = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hostelduepayment = new System.Windows.Forms.TextBox();
            this.hosteltotalpaid = new System.Windows.Forms.TextBox();
            this.hostelpayablefees = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.schoolduepayment = new System.Windows.Forms.TextBox();
            this.schooltotalpaid = new System.Windows.Forms.TextBox();
            this.schoolpayablefees = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.totalduepayment = new System.Windows.Forms.TextBox();
            this.totalfeespaid = new System.Windows.Forms.TextBox();
            this.totalpayablefees = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1087, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1087, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Controls.Add(this.button6);
            this.groupBox6.Location = new System.Drawing.Point(555, 17);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(432, 120);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(292, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Print Summary";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(24, 36);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(123, 55);
            this.button5.TabIndex = 0;
            this.button5.Text = "&View Summary";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(167, 36);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 55);
            this.button6.TabIndex = 1;
            this.button6.Text = "&Reset";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.studentno);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.year);
            this.groupBox5.Controls.Add(this.term);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(16, 17);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(531, 120);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            // 
            // studentno
            // 
            this.studentno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.studentno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.studentno.Enabled = false;
            this.studentno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentno.FormattingEnabled = true;
            this.studentno.Location = new System.Drawing.Point(352, 60);
            this.studentno.Margin = new System.Windows.Forms.Padding(4);
            this.studentno.Name = "studentno";
            this.studentno.Size = new System.Drawing.Size(159, 24);
            this.studentno.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(348, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Student No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Session";
            // 
            // year
            // 
            this.year.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.year.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year.FormattingEnabled = true;
            this.year.Location = new System.Drawing.Point(35, 58);
            this.year.Margin = new System.Windows.Forms.Padding(4);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(147, 24);
            this.year.TabIndex = 13;
            this.year.SelectedIndexChanged += new System.EventHandler(this.year_SelectedIndexChanged);
            // 
            // term
            // 
            this.term.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.term.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.term.Enabled = false;
            this.term.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.term.FormattingEnabled = true;
            this.term.Location = new System.Drawing.Point(207, 60);
            this.term.Margin = new System.Windows.Forms.Padding(4);
            this.term.Name = "term";
            this.term.Size = new System.Drawing.Size(113, 24);
            this.term.TabIndex = 12;
            this.term.SelectedIndexChanged += new System.EventHandler(this.term_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(203, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Semester";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.transportduepayment);
            this.groupBox10.Controls.Add(this.transporttotalpaid);
            this.groupBox10.Controls.Add(this.transportpayablefees);
            this.groupBox10.Controls.Add(this.label21);
            this.groupBox10.Controls.Add(this.label22);
            this.groupBox10.Controls.Add(this.label23);
            this.groupBox10.Location = new System.Drawing.Point(16, 364);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox10.Size = new System.Drawing.Size(529, 188);
            this.groupBox10.TabIndex = 29;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Transport Fees";
            // 
            // transportduepayment
            // 
            this.transportduepayment.Location = new System.Drawing.Point(228, 132);
            this.transportduepayment.Margin = new System.Windows.Forms.Padding(4);
            this.transportduepayment.Name = "transportduepayment";
            this.transportduepayment.Size = new System.Drawing.Size(256, 25);
            this.transportduepayment.TabIndex = 5;
            // 
            // transporttotalpaid
            // 
            this.transporttotalpaid.Location = new System.Drawing.Point(228, 88);
            this.transporttotalpaid.Margin = new System.Windows.Forms.Padding(4);
            this.transporttotalpaid.Name = "transporttotalpaid";
            this.transporttotalpaid.Size = new System.Drawing.Size(256, 25);
            this.transporttotalpaid.TabIndex = 4;
            // 
            // transportpayablefees
            // 
            this.transportpayablefees.Location = new System.Drawing.Point(228, 40);
            this.transportpayablefees.Margin = new System.Windows.Forms.Padding(4);
            this.transportpayablefees.Name = "transportpayablefees";
            this.transportpayablefees.Size = new System.Drawing.Size(256, 25);
            this.transportpayablefees.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(22, 136);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 18);
            this.label21.TabIndex = 2;
            this.label21.Text = "Due Payment";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(22, 92);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 18);
            this.label22.TabIndex = 1;
            this.label22.Text = "Total Fees Paid";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 45);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(122, 18);
            this.label23.TabIndex = 0;
            this.label23.Text = "Total Fees Payable";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.hostelduepayment);
            this.groupBox4.Controls.Add(this.hosteltotalpaid);
            this.groupBox4.Controls.Add(this.hostelpayablefees);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(576, 166);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(529, 177);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hostel Fees";
            // 
            // hostelduepayment
            // 
            this.hostelduepayment.Location = new System.Drawing.Point(227, 123);
            this.hostelduepayment.Margin = new System.Windows.Forms.Padding(4);
            this.hostelduepayment.Name = "hostelduepayment";
            this.hostelduepayment.Size = new System.Drawing.Size(256, 25);
            this.hostelduepayment.TabIndex = 5;
            // 
            // hosteltotalpaid
            // 
            this.hosteltotalpaid.Location = new System.Drawing.Point(227, 79);
            this.hosteltotalpaid.Margin = new System.Windows.Forms.Padding(4);
            this.hosteltotalpaid.Name = "hosteltotalpaid";
            this.hosteltotalpaid.Size = new System.Drawing.Size(256, 25);
            this.hosteltotalpaid.TabIndex = 4;
            // 
            // hostelpayablefees
            // 
            this.hostelpayablefees.Location = new System.Drawing.Point(227, 31);
            this.hostelpayablefees.Margin = new System.Windows.Forms.Padding(4);
            this.hostelpayablefees.Name = "hostelpayablefees";
            this.hostelpayablefees.Size = new System.Drawing.Size(256, 25);
            this.hostelpayablefees.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 127);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Due Payment";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 83);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "Total Fees Paid";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 36);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Total Fees Payable";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.schoolduepayment);
            this.groupBox3.Controls.Add(this.schooltotalpaid);
            this.groupBox3.Controls.Add(this.schoolpayablefees);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(18, 166);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(529, 177);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "School Fees";
            // 
            // schoolduepayment
            // 
            this.schoolduepayment.Location = new System.Drawing.Point(227, 125);
            this.schoolduepayment.Margin = new System.Windows.Forms.Padding(4);
            this.schoolduepayment.Name = "schoolduepayment";
            this.schoolduepayment.Size = new System.Drawing.Size(256, 25);
            this.schoolduepayment.TabIndex = 5;
            // 
            // schooltotalpaid
            // 
            this.schooltotalpaid.Location = new System.Drawing.Point(227, 81);
            this.schooltotalpaid.Margin = new System.Windows.Forms.Padding(4);
            this.schooltotalpaid.Name = "schooltotalpaid";
            this.schooltotalpaid.Size = new System.Drawing.Size(256, 25);
            this.schooltotalpaid.TabIndex = 4;
            // 
            // schoolpayablefees
            // 
            this.schoolpayablefees.Location = new System.Drawing.Point(227, 33);
            this.schoolpayablefees.Margin = new System.Windows.Forms.Padding(4);
            this.schoolpayablefees.Name = "schoolpayablefees";
            this.schoolpayablefees.Size = new System.Drawing.Size(256, 25);
            this.schoolpayablefees.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 129);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Due Payment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Fees Paid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total Fees Payable";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.totalduepayment);
            this.groupBox11.Controls.Add(this.totalfeespaid);
            this.groupBox11.Controls.Add(this.totalpayablefees);
            this.groupBox11.Controls.Add(this.label24);
            this.groupBox11.Controls.Add(this.label25);
            this.groupBox11.Controls.Add(this.label26);
            this.groupBox11.Location = new System.Drawing.Point(13, 570);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox11.Size = new System.Drawing.Size(1088, 90);
            this.groupBox11.TabIndex = 30;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Overall Summaries";
            // 
            // totalduepayment
            // 
            this.totalduepayment.Location = new System.Drawing.Point(820, 38);
            this.totalduepayment.Margin = new System.Windows.Forms.Padding(4);
            this.totalduepayment.Name = "totalduepayment";
            this.totalduepayment.Size = new System.Drawing.Size(201, 25);
            this.totalduepayment.TabIndex = 11;
            // 
            // totalfeespaid
            // 
            this.totalfeespaid.Location = new System.Drawing.Point(512, 40);
            this.totalfeespaid.Margin = new System.Windows.Forms.Padding(4);
            this.totalfeespaid.Name = "totalfeespaid";
            this.totalfeespaid.Size = new System.Drawing.Size(196, 25);
            this.totalfeespaid.TabIndex = 10;
            // 
            // totalpayablefees
            // 
            this.totalpayablefees.Location = new System.Drawing.Point(180, 38);
            this.totalpayablefees.Margin = new System.Windows.Forms.Padding(4);
            this.totalpayablefees.Name = "totalpayablefees";
            this.totalpayablefees.Size = new System.Drawing.Size(200, 25);
            this.totalpayablefees.TabIndex = 9;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(718, 43);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 18);
            this.label24.TabIndex = 8;
            this.label24.Text = "Due Payment";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(396, 44);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(101, 18);
            this.label25.TabIndex = 7;
            this.label25.Text = "Total Fees Paid";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(42, 43);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(122, 18);
            this.label26.TabIndex = 6;
            this.label26.Text = "Total Fees Payable";
            // 
            // frmStudentsFinancialSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1136, 677);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmStudentsFinancialSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Students Financial Summary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStudentsFinancialSummary_FormClosing);
            this.Load += new System.EventHandler(this.frmStudentsFinancialSummary_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button button6;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox year;
        public System.Windows.Forms.ComboBox term;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox transportduepayment;
        private System.Windows.Forms.TextBox transporttotalpaid;
        private System.Windows.Forms.TextBox transportpayablefees;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox hostelduepayment;
        private System.Windows.Forms.TextBox hosteltotalpaid;
        private System.Windows.Forms.TextBox hostelpayablefees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox schoolduepayment;
        private System.Windows.Forms.TextBox schooltotalpaid;
        private System.Windows.Forms.TextBox schoolpayablefees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox totalduepayment;
        private System.Windows.Forms.TextBox totalfeespaid;
        private System.Windows.Forms.TextBox totalpayablefees;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.ComboBox studentno;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}