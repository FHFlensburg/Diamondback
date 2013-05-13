using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            DataTable dtCourse = course.getAll();
            dgvCourses.DataSource = dtCourse;
        }
    }
}
