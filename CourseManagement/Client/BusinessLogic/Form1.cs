using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagement.Client.BusinessLogic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Fill the tutor combobox with surnames of all tutors
            TutorLogic tutor = TutorLogic.getInstance();
            DataTable dtTutor = tutor.getAll();
            cbxTutor.DataSource = dtTutor;
            cbxTutor.DisplayMember = "Surname";
            cbxTutor.BindingContext = this.BindingContext;

            // Fill the room combobox with the Building, RoomNumber and Capicity of all rooms
            RoomLogic room = RoomLogic.getInstance();
            DataTable dtRoom = room.getAll();
            cbxRoom.DataSource = dtRoom;
            cbxRoom.DisplayMember = "RoomNr";
            cbxRoom.BindingContext = this.BindingContext;

            //Collect all courses from the DB and put them in the courses Datatable
            CourseLogic course = CourseLogic.getInstance();
            DataTable dtCourse = course.search("Englisch");
            //DataTable dtCourse = course.getById(1);
            dgvCourses.DataSource = dtCourse;

            //Fill the student combobox with the surnames of all students
            StudentLogic student = StudentLogic.getInstance();
            DataTable dtStudent = student.getAll();
            cbxStudents.DataSource = dtStudent;
            cbxStudents.DisplayMember = "Surname";
            cbxStudents.BindingContext = this.BindingContext;

            //Fill the payment combobox with id´s of all payments
            PaymentLogic payment = PaymentLogic.getInstance();
            DataTable dtPayment = payment.getAll();
            cbxPayments.DataSource = dtPayment;
            cbxPayments.DisplayMember = "Id";
            cbxPayments.BindingContext = this.BindingContext;

            cbxStudentsMAX.SelectedIndex = 0;
            cbxStudentsMIN.SelectedIndex = 0;

            tbxAmount.Enabled = false;
            tbxDescription.Enabled = false;
            tbxTitle.Enabled = false;
            tbxValidity.Enabled = false;
            cbxRoom.Enabled = false;
            cbxStudentsMAX.Enabled = false;
            cbxStudentsMIN.Enabled = false;
            cbxTutor.Enabled = false;
            btnSaveCourse.Visible = false;
        }

        private void btnCreateCourse_Click(object sender, EventArgs e)
        {
            tbxAmount.Enabled = true;
            tbxDescription.Enabled = true;
            tbxTitle.Enabled = true;
            tbxValidity.Enabled = true;
            cbxRoom.Enabled = true;
            cbxStudentsMAX.Enabled = true;
            cbxStudentsMIN.Enabled = true;
            cbxTutor.Enabled = true;
            btnCreateCourse.Enabled = false;
            btnSaveCourse.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CourseLogic course = CourseLogic.getInstance();
            DataTable tutor = (DataTable)cbxTutor.DataSource;
            DataTable room = (DataTable)cbxRoom.DataSource;

            int id = course.create(tbxTitle.Text,Convert.ToDecimal(tbxAmount.Text),tbxDescription.Text,Convert.ToInt32(cbxStudentsMAX.SelectedItem),
                                    Convert.ToInt32(cbxStudentsMIN.SelectedItem),Convert.ToInt32(tutor.Rows[cbxTutor.SelectedIndex]["TutorNr"]),Convert.ToInt32(tbxValidity.Text));
            AppointmentLogic.getInstance().create(id, Convert.ToInt32(room.Rows[cbxRoom.SelectedIndex]["RoomNr"]),DateTime.Now,DateTime.Now);

            tbxTitle.Clear();
            tbxDescription.Clear();
            tbxAmount.Clear();
            tbxValidity.Clear();
            cbxRoom.SelectedIndex = 0;
            cbxStudentsMAX.SelectedIndex = 0;
            cbxStudentsMIN.SelectedIndex = 0;
            cbxTutor.SelectedIndex = 0;
            tbxAmount.Enabled = false;
            tbxDescription.Enabled = false;
            tbxTitle.Enabled = false;
            tbxValidity.Enabled = false;
            cbxRoom.Enabled = false;
            cbxStudentsMAX.Enabled = false;
            cbxStudentsMIN.Enabled = false;
            cbxTutor.Enabled = false;
            btnCreateCourse.Enabled = true;
            btnSaveCourse.Visible = false;

            

            //Collect all courses from the DB and put them in the courses Datatable
            DataTable dtCourse = course.getAll();
            dgvCourses.DataSource = dtCourse;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvCourses.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvCourses.Rows[selectedrowindex];

                string courseNr = Convert.ToString(selectedRow.Cells["CourseNr"].Value);

                CourseLogic course = CourseLogic.getInstance();
                course.delete(Convert.ToInt32(selectedRow.Cells["CourseNr"].Value));

                MessageBox.Show("Kurs Nr. " + courseNr + " wurde gelöscht!");

            }

            //Collect all courses from the DB and put them in the courses Datatable
            CourseLogic newCourse = CourseLogic.getInstance();
            DataTable dtCourse = newCourse.getAll();
            dgvCourses.DataSource = dtCourse;
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get all Appointments of the selected Course and put the result into a DataGridView
            AppointmentLogic appointment = AppointmentLogic.getInstance();
            if (new Regex(@"^\d+$").Match(dgvCourses.SelectedCells[0].Value.ToString()).Success)
            {
                int courseId = Convert.ToInt32(dgvCourses.SelectedCells[0].Value);
                DataTable dtAppointment = appointment.getByCourse(courseId);
                dgvAppointments.DataSource = dtAppointment;
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt32(dgvCourses.SelectedCells[0].Value);
            DataTable dtStudent = (DataTable)cbxStudents.DataSource;
            int studentId = Convert.ToInt32(dtStudent.Rows[cbxStudents.SelectedIndex]["Id"]);
            //int studentId = 7;
            PaymentLogic payment = PaymentLogic.getInstance();
            payment.create(courseId, studentId);

            //Collect all courses from the DB and put them in the courses Datatable
            CourseLogic course = CourseLogic.getInstance();
            DataTable dtCourse = course.getAll();
            dgvCourses.DataSource = dtCourse;

            //Fill the payment combobox with id´s of all payments
            DataTable dtPayment = (DataTable)cbxPayments.DataSource;
            dtPayment = payment.getAll();
            cbxPayments.DataSource = dtPayment;
            cbxPayments.DisplayMember = "Id";
            cbxPayments.BindingContext = this.BindingContext;

            lblAmount.Text = payment.getStudentBalance(Convert.ToInt32(dtStudent.Rows[cbxStudents.SelectedIndex]["Id"]));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dtPayment = (DataTable)cbxPayments.DataSource;
            int paymentId = Convert.ToInt32(dtPayment.Rows[cbxPayments.SelectedIndex]["Id"]);
            PaymentLogic payment = PaymentLogic.getInstance();
            payment.delete(paymentId);

            //Fill the payment combobox with id´s of all payments
            dtPayment = payment.getAll();
            cbxPayments.DataSource = dtPayment;
            cbxPayments.DisplayMember = "Id";
            cbxPayments.BindingContext = this.BindingContext;

            //Collect all courses from the DB and put them in the courses Datatable
            CourseLogic course = CourseLogic.getInstance();
            DataTable dtCourse = course.getAll();
            dgvCourses.DataSource = dtCourse;

            DataTable dtStudent = (DataTable)cbxStudents.DataSource;
            lblAmount.Text = payment.getStudentBalance(Convert.ToInt32(dtStudent.Rows[cbxStudents.SelectedIndex]["Id"]));
        }
    }
}
