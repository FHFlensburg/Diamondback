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
        private DataTable selectedCourse = null;


        public WndNewCourse()
        {
            InitializeComponent();
            setGuiValues();
        }


        public WndNewCourse(DataTable selectedCourse)
        {
            InitializeComponent();
            setGuiValues();

            this.selectedCourse = selectedCourse;
            lblCourse.Content = "Kurs bearbeiten";       

            // max member
            tbMaxParticipants.Text = selectedCourse.Rows[0]["MaxMember"].ToString();

            //min member
            int tempMinMember = Convert.ToInt32(selectedCourse.Rows[0]["MinMember"]);

            foreach (ComboBoxItem aComboBoxItem in cbMinParticipants.Items)
            {

                if(Convert.ToInt32(aComboBoxItem.Content) == Convert.ToInt32(selectedCourse.Rows[0]["MinMember"]))
                {
                    cbMinParticipants.SelectedItem = aComboBoxItem;
                }
            }

            tbCourseTitle.Text = selectedCourse.Rows[0]["Title"].ToString();
            tbCosts.Text = selectedCourse.Rows[0]["AmountInEuro"].ToString();
            tbDescription.Text = selectedCourse.Rows[0]["Description"].ToString();
            tbValidInMonth.Text = selectedCourse.Rows[0]["ValidityInMonth"].ToString();

        }

        private void setGuiValues()
        {

            lblCourse.Content = "Neuer Kurs";

           // Values for Tutor
            DataTable allTutors = TutorLogic.getInstance().getAll();
            foreach (DataRow aDataRow in allTutors.Rows)
            {
                ComboBoxItem aComboBoxItem = new ComboBoxItem();
                string name = aDataRow["Forename"].ToString() + " " + aDataRow["Surname"].ToString();
                aComboBoxItem.Content = name;
                aComboBoxItem.Tag = aDataRow["Id"];
                cbTutor.Items.Add(aComboBoxItem);
            }

            // Participants
            for (int i = 0; i < 51; i++)
            {
                ComboBoxItem minimalParticipants = new ComboBoxItem();
                minimalParticipants.Content = i;
                cbMinParticipants.Items.Add(minimalParticipants);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            insertNewCourseAndValidate();
            this.Close();
        }

        private void insertNewCourseAndValidate()
        {
            string titeL = "";
            string description = "";
            int validInMonths = 0;
            int maxParticipants = 0;
            int minParticipants = 0;
            int tutor = 0;
            decimal amountInEuro = 0;

            try
            {
                titeL = tbCourseTitle.Text;
                amountInEuro = Convert.ToDecimal(tbCosts.Text);
                description = tbDescription.Text;
                maxParticipants = Convert.ToInt32(tbMaxParticipants.Text);
                minParticipants = Convert.ToInt32(((ComboBoxItem)cbMinParticipants.SelectedItem).Tag);
                tutor = Convert.ToInt32(((ComboBoxItem)cbTutor.SelectedItem).Tag);
                validInMonths = Convert.ToInt32(tbValidInMonth.Text);
            }
            catch
            {
                MessageBox.Show("Eingaben haben nicht das richtige Format");
            }

            try
            {

            if(selectedCourse == null)
            {
            CourseLogic.getInstance().create(titeL, amountInEuro, description, maxParticipants, minParticipants, tutor, validInMonths);
            }
            else
            {
                int CourseNr = Convert.ToInt32(selectedCourse.Rows[0]["CourseNr"]);
                CourseLogic.getInstance().changeProperties(CourseNr, titeL, amountInEuro, description, maxParticipants, minParticipants, tutor, validInMonths);
            }
            }
               catch (Exception err)
               {
                  MessageBox.Show("Fehler in der Datenbank. Wenden Sie sich bitte an den Administrator\n" +err.ToString());
               }

        }

        private void btnAport_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }     
    }
}
