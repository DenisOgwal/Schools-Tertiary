namespace College_Management_System
{
    partial class frmStudentComplaints
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentComplaints));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.times = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.complaintdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.stdname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.description = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.staff = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.compsubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.times);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.complaintdate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.stdname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(11, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 123);
            this.panel1.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(465, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(566, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // times
            // 
            this.times.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.times.ForeColor = System.Drawing.SystemColors.Desktop;
            this.times.Items.AddRange(new object[] {
            "         1st",
            "         2nd",
            "         3rd",
            "         4th",
            "         5th",
            "         6th",
            "         7th",
            "         8th",
            "         9th",
            "         10th"});
            this.times.Location = new System.Drawing.Point(230, 66);
            this.times.MaxLength = 10;
            this.times.Name = "times";
            this.times.Size = new System.Drawing.Size(186, 26);
            this.times.TabIndex = 5;
            this.times.SelectedIndexChanged += new System.EventHandler(this.times_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Times Complained:";
            // 
            // complaintdate
            // 
            this.complaintdate.CustomFormat = "dd/ MM/ yyyy";
            this.complaintdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.complaintdate.Location = new System.Drawing.Point(508, 15);
            this.complaintdate.Name = "complaintdate";
            this.complaintdate.Size = new System.Drawing.Size(200, 25);
            this.complaintdate.TabIndex = 3;
            this.complaintdate.ValueChanged += new System.EventHandler(this.complaintdate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(432, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            // 
            // stdname
            // 
            this.stdname.Location = new System.Drawing.Point(230, 11);
            this.stdname.Name = "stdname";
            this.stdname.Size = new System.Drawing.Size(186, 25);
            this.stdname.TabIndex = 1;
            this.stdname.TextChanged += new System.EventHandler(this.stdname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = " Student Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.description);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.department);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.staff);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.compsubject);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(12, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(721, 267);
            this.panel2.TabIndex = 59;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(191, 162);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(490, 89);
            this.description.TabIndex = 7;
            this.description.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(31, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Complaint Description:";
            // 
            // department
            // 
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(191, 120);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(490, 26);
            this.department.TabIndex = 5;
            this.department.SelectedIndexChanged += new System.EventHandler(this.department_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(31, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Department:";
            // 
            // staff
            // 
            this.staff.FormattingEnabled = true;
            this.staff.Location = new System.Drawing.Point(191, 77);
            this.staff.Name = "staff";
            this.staff.Size = new System.Drawing.Size(490, 26);
            this.staff.TabIndex = 3;
            this.staff.SelectedIndexChanged += new System.EventHandler(this.staff_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(31, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Staff Concerned:";
            // 
            // compsubject
            // 
            this.compsubject.Location = new System.Drawing.Point(191, 31);
            this.compsubject.Name = "compsubject";
            this.compsubject.Size = new System.Drawing.Size(490, 25);
            this.compsubject.TabIndex = 1;
            this.compsubject.TextChanged += new System.EventHandler(this.compsubject_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Complaint Subject:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::College_Management_System.Properties.Resources.top_image;
            this.pictureBox1.Location = new System.Drawing.Point(0, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(747, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // frmStudentComplaints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::College_Management_System.Properties.Resources._2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(746, 517);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmStudentComplaints";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Complaints";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStudentComplaints_FormClosing);
            this.Load += new System.EventHandler(this.frmStudentComplaints_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker complaintdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stdname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox staff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox compsubject;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox times;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}