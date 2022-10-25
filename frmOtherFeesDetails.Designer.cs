namespace College_Management_System
{
    partial class frmOtherFeesDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtherFeesDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.GetDetails = new System.Windows.Forms.Button();
            this.Update_record = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.Delete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.NewRecord = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.otherfeesname = new System.Windows.Forms.ComboBox();
            this.Category = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.FeeID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Semester = new System.Windows.Forms.ComboBox();
            this.Branch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Course = new System.Windows.Forms.ComboBox();
            this.TutionFees = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.GetDetails);
            this.panel1.Controls.Add(this.Update_record);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.NewRecord);
            this.panel1.Location = new System.Drawing.Point(558, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 219);
            this.panel1.TabIndex = 11;
            // 
            // GetDetails
            // 
            this.GetDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GetDetails.FlatAppearance.BorderSize = 0;
            this.GetDetails.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDetails.Location = new System.Drawing.Point(16, 171);
            this.GetDetails.Name = "GetDetails";
            this.GetDetails.Size = new System.Drawing.Size(95, 33);
            this.GetDetails.TabIndex = 4;
            this.GetDetails.Text = "&Get Data";
            this.GetDetails.UseVisualStyleBackColor = true;
            this.GetDetails.Click += new System.EventHandler(this.GetDetails_Click);
            // 
            // Update_record
            // 
            this.Update_record.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Update_record.Enabled = false;
            this.Update_record.FlatAppearance.BorderSize = 0;
            this.Update_record.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_record.Location = new System.Drawing.Point(16, 132);
            this.Update_record.Name = "Update_record";
            this.Update_record.Size = new System.Drawing.Size(95, 33);
            this.Update_record.TabIndex = 3;
            this.Update_record.Text = "&Update";
            this.Update_record.UseVisualStyleBackColor = true;
            this.Update_record.Click += new System.EventHandler(this.Update_record_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(36, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 22);
            this.label12.TabIndex = 13;
            this.label12.Text = "admin";
            this.label12.Visible = false;
            // 
            // Delete
            // 
            this.Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Delete.Enabled = false;
            this.Delete.FlatAppearance.BorderSize = 0;
            this.Delete.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(16, 93);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(95, 33);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "&Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(16, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // NewRecord
            // 
            this.NewRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewRecord.FlatAppearance.BorderSize = 0;
            this.NewRecord.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRecord.Location = new System.Drawing.Point(16, 14);
            this.NewRecord.Name = "NewRecord";
            this.NewRecord.Size = new System.Drawing.Size(95, 33);
            this.NewRecord.TabIndex = 0;
            this.NewRecord.Text = "&New";
            this.NewRecord.UseVisualStyleBackColor = true;
            this.NewRecord.Click += new System.EventHandler(this.NewRecord_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.otherfeesname);
            this.groupBox1.Controls.Add(this.Category);
            this.groupBox1.Controls.Add(this.year);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.FeeID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Semester);
            this.groupBox1.Controls.Add(this.Branch);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Course);
            this.groupBox1.Controls.Add(this.TutionFees);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 183);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fees Details";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(447, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 22);
            this.label13.TabIndex = 57;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // otherfeesname
            // 
            this.otherfeesname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.otherfeesname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.otherfeesname.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherfeesname.FormattingEnabled = true;
            this.otherfeesname.Items.AddRange(new object[] {
            "Identity Card",
            "Admission",
            "UAHEB",
            "Medical Insurance",
            "Hostel",
            "Guild",
            "Uniform",
            "Progressive Examination",
            "Library",
            "Document Verification",
            "Hospital Attachment",
            "Graduation",
            "Development",
            "Research",
            "Interview"});
            this.otherfeesname.Location = new System.Drawing.Point(84, 104);
            this.otherfeesname.Margin = new System.Windows.Forms.Padding(4);
            this.otherfeesname.Name = "otherfeesname";
            this.otherfeesname.Size = new System.Drawing.Size(232, 30);
            this.otherfeesname.TabIndex = 73;
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category.Location = new System.Drawing.Point(17, 109);
            this.Category.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(66, 22);
            this.Category.TabIndex = 74;
            this.Category.Text = "Fees For";
            // 
            // year
            // 
            this.year.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year.Location = new System.Drawing.Point(375, 104);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(112, 29);
            this.year.TabIndex = 72;
            this.year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(326, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 22);
            this.label15.TabIndex = 71;
            this.label15.Text = "Year";
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(493, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 29);
            this.button2.TabIndex = 68;
            this.button2.Text = "<";
            this.toolTip1.SetToolTip(this.button2, "View Records");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FeeID
            // 
            this.FeeID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeeID.Location = new System.Drawing.Point(280, 25);
            this.FeeID.Name = "FeeID";
            this.FeeID.ReadOnly = true;
            this.FeeID.Size = new System.Drawing.Size(207, 29);
            this.FeeID.TabIndex = 67;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(228, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 22);
            this.label10.TabIndex = 64;
            this.label10.Text = "Fee ID";
            // 
            // Semester
            // 
            this.Semester.Enabled = false;
            this.Semester.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Semester.FormattingEnabled = true;
            this.Semester.Location = new System.Drawing.Point(316, 64);
            this.Semester.Margin = new System.Windows.Forms.Padding(4);
            this.Semester.Name = "Semester";
            this.Semester.Size = new System.Drawing.Size(171, 30);
            this.Semester.TabIndex = 47;
            // 
            // Branch
            // 
            this.Branch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Branch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Branch.Enabled = false;
            this.Branch.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Branch.FormattingEnabled = true;
            this.Branch.Location = new System.Drawing.Point(84, 65);
            this.Branch.Margin = new System.Windows.Forms.Padding(4);
            this.Branch.Name = "Branch";
            this.Branch.Size = new System.Drawing.Size(137, 30);
            this.Branch.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(228, 67);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 22);
            this.label8.TabIndex = 61;
            this.label8.Text = "Semester";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 22);
            this.label7.TabIndex = 59;
            this.label7.Text = "Fee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 22);
            this.label2.TabIndex = 49;
            this.label2.Text = "Section";
            // 
            // Course
            // 
            this.Course.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Course.Location = new System.Drawing.Point(84, 28);
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(137, 30);
            this.Course.TabIndex = 66;
            this.Course.SelectedIndexChanged += new System.EventHandler(this.Course_SelectedIndexChanged);
            // 
            // TutionFees
            // 
            this.TutionFees.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TutionFees.Location = new System.Drawing.Point(84, 142);
            this.TutionFees.Name = "TutionFees";
            this.TutionFees.Size = new System.Drawing.Size(232, 29);
            this.TutionFees.TabIndex = 48;
            this.TutionFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TutionFees_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 22);
            this.label1.TabIndex = 44;
            this.label1.Text = "Course";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Information";
            // 
            // frmOtherFeesDetails
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::College_Management_System.Properties.Settings.Default.usercolor;
            this.BackgroundImage = global::College_Management_System.Properties.Resources._2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(691, 256);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::College_Management_System.Properties.Settings.Default, "usercolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmOtherFeesDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Fees Details";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FeesDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GetDetails;
        private System.Windows.Forms.Button NewRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox Semester;
        public System.Windows.Forms.ComboBox Branch;
        public System.Windows.Forms.ComboBox Course;
        public System.Windows.Forms.TextBox FeeID;
        public System.Windows.Forms.Button Update_record;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox year;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox otherfeesname;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox TutionFees;
    }
}