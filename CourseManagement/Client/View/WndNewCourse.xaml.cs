using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CourseManagement.Client.BusinessLogic;
using System.Data;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndNewCourse.xaml
    /// </summary>
    public partial class WndNewCourse : Window
    {

        public WndNewCourse()
        {
            InitializeComponent();
            setGuiValues();
        }

        private void setGuiValues()
        {
            // 0 Participants allowed in Comboboxes
            cbMaxParticipants.Items.Clear();
            cbMinParticipants.Items.Clear();

            // Values for Tutor
            DataTable tutors = null;
            tutors = TutorLogic.getInstance().getAll();
            string temporaryTutor = string.Empty;
            int countTutors = tutors.Rows.Count;

            // Values for RoomNumber
            DataTable roomNumber = null;
            roomNumber = RoomLogic.getInstance().getAll();
            string temporaryRoomNumber = string.Empty;
            int countRoomNumbers = roomNumber.Rows.Count;

            // Participants
            for (int i = 0; i < 51; i++)
            {
                ComboBoxItem maximalParticipants = new ComboBoxItem();
                ComboBoxItem minimalParticipants = new ComboBoxItem();
                maximalParticipants.Content = i;
                minimalParticipants.Content = i;
                cbMaxParticipants.Items.Add(maximalParticipants);
                cbMinParticipants.Items.Add(minimalParticipants);
            }

            // Tutors
            for (int i = 0; i < countTutors; i++)
            {
                temporaryTutor = string.Empty;
                temporaryTutor = tutors.Rows[i]["Surname"].ToString();
                cbTutor.Items.Add(temporaryTutor);
            }

            // RoomNumber
            for (int i = 0; i < countRoomNumbers; i++)
            {
                temporaryRoomNumber = string.Empty;
                temporaryRoomNumber = roomNumber.Rows[i]["RoomNr"].ToString();
                cbRoomNumber.Items.Add(temporaryRoomNumber);
            }
    
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            insertNewCourseAndValidate();
            this.Close();
        }

        private void insertNewCourseAndValidate()
        {
            string title = tbCourseTitle.Text;
            string description = tbDescription.Text;
            string costs = tbCosts.Text;
            string validInMonths = tbValidInMonth.Text;
            string maxParticipants = cbMaxParticipants.Text;
            string minParticipants = cbMinParticipants.Text;
            string tutor = cbTutor.Text;
            string room = cbRoomNumber.Text;
            CourseLogic course = CourseLogic.getInstance();
            //course.create();
            
        }     
    }
}
