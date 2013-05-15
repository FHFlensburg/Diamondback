namespace CourseManagement.Client.BusinessLogic
{
    partial class Form1
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
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateCourse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.cbxStudentsMAX = new System.Windows.Forms.ComboBox();
            this.cbxStudentsMIN = new System.Windows.Forms.ComboBox();
            this.tbxValidity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxTutor = new System.Windows.Forms.ComboBox();
            this.cbxRoom = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveCourse = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.CourseNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountInEuro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidityInMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Appointments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCourses
            // 
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseNr,
            this.Titel,
            this.AmountInEuro,
            this.Description,
            this.MaxMember,
            this.MinMember,
            this.ValidityInMonth,
            this.Tutor,
            this.Room,
            this.StudentCount,
            this.Payments,
            this.Appointments});
            this.dgvCourses.Location = new System.Drawing.Point(12, 51);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.RowTemplate.Height = 24;
            this.dgvCourses.Size = new System.Drawing.Size(1097, 150);
            this.dgvCourses.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kurse";
            // 
            // btnCreateCourse
            // 
            this.btnCreateCourse.Location = new System.Drawing.Point(15, 208);
            this.btnCreateCourse.Name = "btnCreateCourse";
            this.btnCreateCourse.Size = new System.Drawing.Size(122, 23);
            this.btnCreateCourse.TabIndex = 2;
            this.btnCreateCourse.Text = "Kurs anlegen...";
            this.btnCreateCourse.UseVisualStyleBackColor = true;
            this.btnCreateCourse.Click += new System.EventHandler(this.btnCreateCourse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 507);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Datum";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(12, 263);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(139, 22);
            this.tbxTitle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Beitrag in €";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Beschreibung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Teilnehmer MAX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Teilnehmer MIN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(650, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Gültigkeit in Monaten";
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(160, 259);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(85, 22);
            this.tbxAmount.TabIndex = 10;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(254, 259);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(166, 22);
            this.tbxDescription.TabIndex = 11;
            // 
            // cbxStudentsMAX
            // 
            this.cbxStudentsMAX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStudentsMAX.FormattingEnabled = true;
            this.cbxStudentsMAX.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40"});
            this.cbxStudentsMAX.Location = new System.Drawing.Point(427, 259);
            this.cbxStudentsMAX.Name = "cbxStudentsMAX";
            this.cbxStudentsMAX.Size = new System.Drawing.Size(104, 24);
            this.cbxStudentsMAX.TabIndex = 12;
            // 
            // cbxStudentsMIN
            // 
            this.cbxStudentsMIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStudentsMIN.FormattingEnabled = true;
            this.cbxStudentsMIN.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40"});
            this.cbxStudentsMIN.Location = new System.Drawing.Point(540, 259);
            this.cbxStudentsMIN.Name = "cbxStudentsMIN";
            this.cbxStudentsMIN.Size = new System.Drawing.Size(104, 24);
            this.cbxStudentsMIN.TabIndex = 13;
            // 
            // tbxValidity
            // 
            this.tbxValidity.Location = new System.Drawing.Point(653, 259);
            this.tbxValidity.Name = "tbxValidity";
            this.tbxValidity.Size = new System.Drawing.Size(138, 22);
            this.tbxValidity.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(797, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tutor";
            // 
            // cbxTutor
            // 
            this.cbxTutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTutor.FormattingEnabled = true;
            this.cbxTutor.Location = new System.Drawing.Point(797, 259);
            this.cbxTutor.Name = "cbxTutor";
            this.cbxTutor.Size = new System.Drawing.Size(104, 24);
            this.cbxTutor.TabIndex = 16;
            // 
            // cbxRoom
            // 
            this.cbxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoom.FormattingEnabled = true;
            this.cbxRoom.Location = new System.Drawing.Point(907, 259);
            this.cbxRoom.Name = "cbxRoom";
            this.cbxRoom.Size = new System.Drawing.Size(202, 24);
            this.cbxRoom.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(904, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Raum (Nr, Gebäude, Kapazität)";
            // 
            // btnSaveCourse
            // 
            this.btnSaveCourse.Location = new System.Drawing.Point(15, 292);
            this.btnSaveCourse.Name = "btnSaveCourse";
            this.btnSaveCourse.Size = new System.Drawing.Size(122, 23);
            this.btnSaveCourse.TabIndex = 19;
            this.btnSaveCourse.Text = "SPEICHERN";
            this.btnSaveCourse.UseVisualStyleBackColor = true;
            this.btnSaveCourse.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 354);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1094, 150);
            this.dataGridView1.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Termine";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Kurs löschen...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 638);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Termin speichern";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(284, 507);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ende Datum";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 528);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(247, 22);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(287, 528);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(244, 22);
            this.dateTimePicker2.TabIndex = 26;
            // 
            // CourseNr
            // 
            this.CourseNr.DataPropertyName = "CourseNr";
            this.CourseNr.HeaderText = "Kurs Nr.";
            this.CourseNr.Name = "CourseNr";
            // 
            // Titel
            // 
            this.Titel.DataPropertyName = "Title";
            this.Titel.HeaderText = "Titel";
            this.Titel.Name = "Titel";
            // 
            // AmountInEuro
            // 
            this.AmountInEuro.DataPropertyName = "AmountInEuro";
            this.AmountInEuro.HeaderText = "Beitrag in €";
            this.AmountInEuro.Name = "AmountInEuro";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Beschreibung";
            this.Description.Name = "Description";
            // 
            // MaxMember
            // 
            this.MaxMember.DataPropertyName = "MAXMember";
            this.MaxMember.HeaderText = "Teilnehmer MAX";
            this.MaxMember.Name = "MaxMember";
            // 
            // MinMember
            // 
            this.MinMember.DataPropertyName = "MINMember";
            this.MinMember.HeaderText = "Teilnehmer MIN";
            this.MinMember.Name = "MinMember";
            // 
            // ValidityInMonth
            // 
            this.ValidityInMonth.DataPropertyName = "ValidityInMonth";
            this.ValidityInMonth.HeaderText = "Gültigkeit in Monaten";
            this.ValidityInMonth.Name = "ValidityInMonth";
            // 
            // Tutor
            // 
            this.Tutor.DataPropertyName = "Tutor";
            this.Tutor.HeaderText = "Dozent";
            this.Tutor.Name = "Tutor";
            // 
            // Room
            // 
            this.Room.DataPropertyName = "Room";
            this.Room.HeaderText = "Raum";
            this.Room.Name = "Room";
            this.Room.Visible = false;
            // 
            // StudentCount
            // 
            this.StudentCount.DataPropertyName = "StudentCount";
            this.StudentCount.HeaderText = "Anzahl Studenten";
            this.StudentCount.Name = "StudentCount";
            // 
            // Payments
            // 
            this.Payments.DataPropertyName = "Payments";
            this.Payments.HeaderText = "Anzahl Zahlungen";
            this.Payments.Name = "Payments";
            // 
            // Appointments
            // 
            this.Appointments.DataPropertyName = "Appointments";
            this.Appointments.HeaderText = "Anzahl Termine";
            this.Appointments.Name = "Appointments";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 673);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSaveCourse);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxRoom);
            this.Controls.Add(this.cbxTutor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxValidity);
            this.Controls.Add(this.cbxStudentsMIN);
            this.Controls.Add(this.cbxStudentsMAX);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreateCourse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCourses);
            this.Name = "Form1";
            this.Text = "WindowsFormForTesting";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateCourse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.ComboBox cbxStudentsMAX;
        private System.Windows.Forms.ComboBox cbxStudentsMIN;
        private System.Windows.Forms.TextBox tbxValidity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxTutor;
        private System.Windows.Forms.ComboBox cbxRoom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSaveCourse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountInEuro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidityInMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Appointments;
    }
}