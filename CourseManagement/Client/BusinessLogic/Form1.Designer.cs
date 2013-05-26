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
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxPayments = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Studenten = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.cbxStudents = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.dgvCourses.Location = new System.Drawing.Point(9, 41);
            this.dgvCourses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.RowTemplate.Height = 24;
            this.dgvCourses.Size = new System.Drawing.Size(823, 122);
            this.dgvCourses.TabIndex = 0;
            this.dgvCourses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellClick);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kurse";
            // 
            // btnCreateCourse
            // 
            this.btnCreateCourse.Location = new System.Drawing.Point(11, 169);
            this.btnCreateCourse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateCourse.Name = "btnCreateCourse";
            this.btnCreateCourse.Size = new System.Drawing.Size(92, 19);
            this.btnCreateCourse.TabIndex = 2;
            this.btnCreateCourse.Text = "Kurs anlegen...";
            this.btnCreateCourse.UseVisualStyleBackColor = true;
            this.btnCreateCourse.Click += new System.EventHandler(this.btnCreateCourse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 412);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Datum";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(11, 210);
            this.tbxTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(105, 20);
            this.tbxTitle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Beitrag in €";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Beschreibung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Teilnehmer MAX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Teilnehmer MIN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(488, 194);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Gültigkeit in Monaten";
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(120, 210);
            this.tbxAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(65, 20);
            this.tbxAmount.TabIndex = 10;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(190, 210);
            this.tbxDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(126, 20);
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
            this.cbxStudentsMAX.Location = new System.Drawing.Point(320, 210);
            this.cbxStudentsMAX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxStudentsMAX.Name = "cbxStudentsMAX";
            this.cbxStudentsMAX.Size = new System.Drawing.Size(79, 21);
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
            this.cbxStudentsMIN.Location = new System.Drawing.Point(405, 210);
            this.cbxStudentsMIN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxStudentsMIN.Name = "cbxStudentsMIN";
            this.cbxStudentsMIN.Size = new System.Drawing.Size(79, 21);
            this.cbxStudentsMIN.TabIndex = 13;
            // 
            // tbxValidity
            // 
            this.tbxValidity.Location = new System.Drawing.Point(490, 210);
            this.tbxValidity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxValidity.Name = "tbxValidity";
            this.tbxValidity.Size = new System.Drawing.Size(104, 20);
            this.tbxValidity.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(598, 194);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tutor";
            // 
            // cbxTutor
            // 
            this.cbxTutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTutor.FormattingEnabled = true;
            this.cbxTutor.Location = new System.Drawing.Point(598, 210);
            this.cbxTutor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxTutor.Name = "cbxTutor";
            this.cbxTutor.Size = new System.Drawing.Size(79, 21);
            this.cbxTutor.TabIndex = 16;
            // 
            // cbxRoom
            // 
            this.cbxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoom.FormattingEnabled = true;
            this.cbxRoom.Location = new System.Drawing.Point(680, 210);
            this.cbxRoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxRoom.Name = "cbxRoom";
            this.cbxRoom.Size = new System.Drawing.Size(152, 21);
            this.cbxRoom.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(678, 194);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Raum (Nr, Gebäude, Kapazität)";
            // 
            // btnSaveCourse
            // 
            this.btnSaveCourse.Location = new System.Drawing.Point(11, 237);
            this.btnSaveCourse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveCourse.Name = "btnSaveCourse";
            this.btnSaveCourse.Size = new System.Drawing.Size(92, 19);
            this.btnSaveCourse.TabIndex = 19;
            this.btnSaveCourse.Text = "SPEICHERN";
            this.btnSaveCourse.UseVisualStyleBackColor = true;
            this.btnSaveCourse.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Course,
            this.StartDate,
            this.EndDate,
            this.RoomNr});
            this.dgvAppointments.Location = new System.Drawing.Point(11, 288);
            this.dgvAppointments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.Size = new System.Drawing.Size(820, 122);
            this.dgvAppointments.TabIndex = 20;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // Course
            // 
            this.Course.DataPropertyName = "Course";
            this.Course.HeaderText = "Kurs Nr.";
            this.Course.Name = "Course";
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "Beginn";
            this.StartDate.Name = "StartDate";
            this.StartDate.Width = 200;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "Ende";
            this.EndDate.Name = "EndDate";
            this.EndDate.Width = 200;
            // 
            // RoomNr
            // 
            this.RoomNr.DataPropertyName = "Room";
            this.RoomNr.HeaderText = "Raum Nr.";
            this.RoomNr.Name = "RoomNr";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 271);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Termine";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 169);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 19);
            this.button1.TabIndex = 22;
            this.button1.Text = "Kurs löschen...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 518);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 19);
            this.button2.TabIndex = 23;
            this.button2.Text = "Termin speichern";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(213, 412);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ende Datum";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(11, 429);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(215, 429);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(184, 20);
            this.dateTimePicker2.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 194);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Titel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbxPayments);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.Studenten);
            this.groupBox1.Controls.Add(this.btnAddStudent);
            this.groupBox1.Controls.Add(this.cbxStudents);
            this.groupBox1.Location = new System.Drawing.Point(11, 452);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(820, 62);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zahlungen";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(526, 37);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 19);
            this.button3.TabIndex = 7;
            this.button3.Text = "Löschen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(334, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Zahlungen";
            // 
            // cbxPayments
            // 
            this.cbxPayments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPayments.FormattingEnabled = true;
            this.cbxPayments.Location = new System.Drawing.Point(333, 37);
            this.cbxPayments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxPayments.Name = "cbxPayments";
            this.cbxPayments.Size = new System.Drawing.Size(182, 21);
            this.cbxPayments.TabIndex = 5;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(270, 40);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(37, 13);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "0,00 €";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(270, 18);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Kontostand";
            // 
            // Studenten
            // 
            this.Studenten.AutoSize = true;
            this.Studenten.Location = new System.Drawing.Point(5, 18);
            this.Studenten.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Studenten.Name = "Studenten";
            this.Studenten.Size = new System.Drawing.Size(56, 13);
            this.Studenten.TabIndex = 2;
            this.Studenten.Text = "Studenten";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(192, 37);
            this.btnAddStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(74, 19);
            this.btnAddStudent.TabIndex = 1;
            this.btnAddStudent.Text = "Hinzufügen";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // cbxStudents
            // 
            this.cbxStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStudents.FormattingEnabled = true;
            this.cbxStudents.Location = new System.Drawing.Point(4, 37);
            this.cbxStudents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxStudents.Name = "cbxStudents";
            this.cbxStudents.Size = new System.Drawing.Size(182, 21);
            this.cbxStudents.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 547);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvAppointments);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "WindowsFormForTesting";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvAppointments;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label Studenten;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.ComboBox cbxStudents;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxPayments;
        private System.Windows.Forms.Button button3;
    }
}