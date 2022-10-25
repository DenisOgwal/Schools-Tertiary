namespace College_Management_System
{
    partial class frmStudentResults
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentResults));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stdno = new System.Windows.Forms.TextBox();
            this.level = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stream = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.term = new System.Windows.Forms.ComboBox();
            this.classes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Viewcomplaits = new System.Windows.Forms.Button();
            this.submitcomplaits = new System.Windows.Forms.Button();
            this.viewresults = new System.Windows.Forms.Button();
            this.complaintpanel = new System.Windows.Forms.Panel();
            this.description = new System.Windows.Forms.RichTextBox();
            this.complaintdate = new System.Windows.Forms.DateTimePicker();
            this.subject = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.complaintpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.stdno);
            this.groupBox1.Controls.Add(this.level);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.stream);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.year);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.term);
            this.groupBox1.Controls.Add(this.classes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1145, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // stdno
            // 
            this.stdno.Enabled = false;
            this.stdno.Location = new System.Drawing.Point(94, 31);
            this.stdno.Name = "stdno";
            this.stdno.Size = new System.Drawing.Size(150, 20);
            this.stdno.TabIndex = 76;
            this.stdno.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // level
            // 
            this.level.Enabled = false;
            this.level.FormattingEnabled = true;
            this.level.Location = new System.Drawing.Point(736, 33);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(106, 21);
            this.level.TabIndex = 75;
            this.level.SelectedIndexChanged += new System.EventHandler(this.level_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(676, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "Branch:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(449, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 72;
            this.label1.Text = "Course:";
            // 
            // stream
            // 
            this.stream.Enabled = false;
            this.stream.Location = new System.Drawing.Point(1074, 31);
            this.stream.Name = "stream";
            this.stream.Size = new System.Drawing.Size(65, 21);
            this.stream.TabIndex = 73;
            this.stream.SelectedIndexChanged += new System.EventHandler(this.stream_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(1002, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 18);
            this.label10.TabIndex = 68;
            this.label10.Text = "Section:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 18);
            this.label9.TabIndex = 67;
            this.label9.Text = "Student No:";
            // 
            // year
            // 
            this.year.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.year.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.year.Enabled = false;
            this.year.FormattingEnabled = true;
            this.year.Location = new System.Drawing.Point(311, 27);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(121, 21);
            this.year.TabIndex = 1;
            this.year.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(250, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Session:";
            // 
            // term
            // 
            this.term.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.term.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.term.Enabled = false;
            this.term.FormattingEnabled = true;
            this.term.Location = new System.Drawing.Point(926, 31);
            this.term.Name = "term";
            this.term.Size = new System.Drawing.Size(70, 21);
            this.term.TabIndex = 3;
            this.term.SelectedIndexChanged += new System.EventHandler(this.term_SelectedIndexChanged);
            // 
            // classes
            // 
            this.classes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.classes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.classes.Enabled = false;
            this.classes.FormattingEnabled = true;
            this.classes.Location = new System.Drawing.Point(506, 31);
            this.classes.Name = "classes";
            this.classes.Size = new System.Drawing.Size(145, 21);
            this.classes.TabIndex = 2;
            this.classes.SelectedIndexChanged += new System.EventHandler(this.classes_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(224, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 18);
            this.label4.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(852, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Semester:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Viewcomplaits);
            this.panel1.Controls.Add(this.submitcomplaits);
            this.panel1.Controls.Add(this.viewresults);
            this.panel1.Location = new System.Drawing.Point(918, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 151);
            this.panel1.TabIndex = 3;
            // 
            // Viewcomplaits
            // 
            this.Viewcomplaits.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Viewcomplaits.Location = new System.Drawing.Point(24, 64);
            this.Viewcomplaits.Name = "Viewcomplaits";
            this.Viewcomplaits.Size = new System.Drawing.Size(158, 39);
            this.Viewcomplaits.TabIndex = 2;
            this.Viewcomplaits.Text = "View Complaints Form";
            this.Viewcomplaits.UseVisualStyleBackColor = true;
            this.Viewcomplaits.Click += new System.EventHandler(this.Viewcomplaits_Click);
            // 
            // submitcomplaits
            // 
            this.submitcomplaits.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitcomplaits.Location = new System.Drawing.Point(24, 109);
            this.submitcomplaits.Name = "submitcomplaits";
            this.submitcomplaits.Size = new System.Drawing.Size(158, 35);
            this.submitcomplaits.TabIndex = 1;
            this.submitcomplaits.Text = "Submit Complaint";
            this.submitcomplaits.UseVisualStyleBackColor = true;
            this.submitcomplaits.Click += new System.EventHandler(this.submitcomplaits_Click);
            // 
            // viewresults
            // 
            this.viewresults.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewresults.Location = new System.Drawing.Point(24, 12);
            this.viewresults.Name = "viewresults";
            this.viewresults.Size = new System.Drawing.Size(158, 46);
            this.viewresults.TabIndex = 0;
            this.viewresults.Text = "View Results";
            this.viewresults.UseVisualStyleBackColor = true;
            this.viewresults.Click += new System.EventHandler(this.viewresults_Click);
            // 
            // complaintpanel
            // 
            this.complaintpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.complaintpanel.Controls.Add(this.description);
            this.complaintpanel.Controls.Add(this.complaintdate);
            this.complaintpanel.Controls.Add(this.subject);
            this.complaintpanel.Controls.Add(this.label11);
            this.complaintpanel.Controls.Add(this.label8);
            this.complaintpanel.Controls.Add(this.label7);
            this.complaintpanel.Controls.Add(this.label6);
            this.complaintpanel.Location = new System.Drawing.Point(888, 298);
            this.complaintpanel.Name = "complaintpanel";
            this.complaintpanel.Size = new System.Drawing.Size(260, 247);
            this.complaintpanel.TabIndex = 4;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(28, 130);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(208, 97);
            this.description.TabIndex = 6;
            this.description.Text = "";
            // 
            // complaintdate
            // 
            this.complaintdate.CustomFormat = "dd/ MM /yyyy";
            this.complaintdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.complaintdate.Location = new System.Drawing.Point(98, 79);
            this.complaintdate.Name = "complaintdate";
            this.complaintdate.Size = new System.Drawing.Size(121, 20);
            this.complaintdate.TabIndex = 5;
            // 
            // subject
            // 
            this.subject.FormattingEnabled = true;
            this.subject.Location = new System.Drawing.Point(98, 52);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(121, 21);
            this.subject.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(87, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 17);
            this.label11.TabIndex = 3;
            this.label11.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Subject";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Submit Your Complaints Here";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(12, 141);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Size = new System.Drawing.Size(856, 404);
            this.dataGridView1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::College_Management_System.Properties.Resources.top_image;
            this.pictureBox1.Location = new System.Drawing.Point(-8, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1181, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // frmStudentResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::College_Management_System.Properties.Resources._2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1169, 598);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.complaintpanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStudentResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Results";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStudentResults_FormClosing);
            this.Load += new System.EventHandler(this.frmStudentResults_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.complaintpanel.ResumeLayout(false);
            this.complaintpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox level;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox stream;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox term;
        private System.Windows.Forms.ComboBox classes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Viewcomplaits;
        private System.Windows.Forms.Button submitcomplaits;
        private System.Windows.Forms.Button viewresults;
        private System.Windows.Forms.Panel complaintpanel;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.DateTimePicker complaintdate;
        private System.Windows.Forms.ComboBox subject;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox stdno;
    }
}