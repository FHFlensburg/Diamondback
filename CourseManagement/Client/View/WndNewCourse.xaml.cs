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
            

            // max member
            string temporaryMaxMember = dataTable.Rows[0]["MaxMember"].ToString();
            int tempMaxMember = Convert.ToInt32(temporaryMaxMember);

            //min member
            string temporaryMinMember = dataTable.Rows[0]["MinMember"].ToString();
            int tempMinMember = Convert.ToInt32(temporaryMinMember);

            //tutor
           //string fOoObAr = dataTable.Rows[0]["Tutor"].ToString();
           // int temporaryTut = Convert.ToInt32(temporaryTutor);

            InitializeComponent();
            setGuiValues();
            this.dataTable = dataTable;
            tbCourseTitle.Text = dataTable.Rows[0]["Title"].ToString();
            tbCosts.Text = dataTable.Rows[0]["AmountInEuro"].ToString();
            tbDescription.Text = dataTable.Rows[0]["Description"].ToString();
            tbValidInMonth.Text = dataTable.Rows[0]["ValidityInMonth"].ToString();

            for (int i = 0; i < cbMinParticipants.Items.Count; i++)
            {
                if (i == tempMinMember)
                {
                    cbMinParticipants.Text = i.ToString();
                }
            }

            //for (int i = 0; i < 100; i++)
            //{
            //    if (Convert.ToString(i).Equals(temporaryTutor))
            //    {
            //        cbTutor.Text = i.ToString();
            //    }
            //}

        }

        private void setGuiValues()
        {
            // 0 Participants allowed in Comboboxes
            tbMaxParticipants.Text = "";
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
                tbMaxParticipants.Text = maximalParticipants.ToString();
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
            int validInMonths = Convert.ToInt32(tbValidInMonth.Text);
            int maxParticipants = Convert.ToInt32(tbMaxParticipants.Text);
            int minParticipants = Convert.ToInt32(cbMinParticipants.Text);
            int tutor = Convert.ToInt32(cbTutor.Text);
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

        private void btnAport_Click(object sender, RoutedEventArgs e)
        {
            //TODO: testen
            this.Close();
        }     
    }
}
