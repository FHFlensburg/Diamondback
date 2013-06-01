using CourseManagement.Client.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
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


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndNewCourse.xaml
    /// </summary>
    public partial class WndNewCourse : Window
    {
        private DataTable dataTable;


        public WndNewCourse()
        {
            InitializeComponent();
            setGuiValues();
        }


        public WndNewCourse(DataTable dataTable)
        {
            InitializeComponent();
            setGuiValues();
            this.dataTable = dataTable;
            tbCourseTitle.Text = dataTable.Rows[0]["Title"].ToString();
            tbCosts.Text = dataTable.Rows[0]["AmountInEuro"].ToString();
            tbDescription.Text = dataTable.Rows[0]["Description"].ToString();
            tbValidInMonth.Text = dataTable.Rows[0]["ValidityInMonth"].ToString();

            string temporaryMaxMember = dataTable.Rows[0]["MaxMember"].ToString();
            int tempMaxMember = Convert.ToInt32(temporaryMaxMember);
            cbMaxParticipants.SelectedValue = cbMaxParticipants.Items.IndexOf(temporaryMaxMember);
  
            cbMinParticipants.Items.Add(dataTable.Rows[0]["MinMember"].ToString());
            cbTutor.Items.Add(dataTable.Rows[0]["Tutor"].ToString());
            cbRoomNumber.Items.Add(dataTable.Rows[0]["CourseNr"].ToString());
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
                //TODO: Man sieht nur die ID, Zugehörigkeit ist schwer.
                temporaryTutor = string.Empty;
                temporaryTutor = tutors.Rows[i]["Id"].ToString();
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

            try
            {
            string titeL = tbCourseTitle.Text;
            string description = tbDescription.Text;
            string costs = tbCosts.Text;
            int validInMonths = Convert.ToInt16(tbValidInMonth.Text);
            int maxParticipants = Convert.ToInt16(cbMaxParticipants.Text);
            int minParticipants = Convert.ToInt16(cbMinParticipants.Text);
            int tutor = Convert.ToInt16(cbTutor.Text);
        //    int room = Convert.ToInt16(cbRoomNumber.Text);
            try
            {
             CourseLogic course = CourseLogic.getInstance();
                //GUI = ROOM, DB = VALIDITYinMONTHS
             course.create(titeL, null, description, maxParticipants, minParticipants, tutor, validInMonths);
            }
               catch (Exception err)
               {
                  MessageBox.Show("Fehler in der Datenbank. Wenden Sie sich bitte an den Administrator\n" +err.ToString());
               }

            }
            catch (OverflowException)
            {
                MessageBox.Show("Konvertierte Zahl ist außerhalb der Gültigkeit");
            }
            catch (FormatException)
            {
               
            }

        }     
    }
}
