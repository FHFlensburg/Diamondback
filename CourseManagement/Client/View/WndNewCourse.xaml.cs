using CourseManagement.Client.BusinessLogic;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndNewCourse.xaml
    /// </summary>
    public partial class WndNewCourse : Window
    {
        private DataTable selectedCourse = null;
        private string titeL = "";
        private string description = "";
        private int validInMonths = 0;
        private int maxParticipants = 0;
        private int minParticipants = 0;
        private int tutor = 0;
        private decimal amountInEuro = 0;

        /// <summary>
        /// standard constructor for window newCourse
        /// </summary>
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


            fillingDataFieldsWithProvidedData();
        }

        private void fillingDataFieldsWithProvidedData()
        {
            tbMaxParticipants.Text = selectedCourse.Rows[0]["MaxMember"].ToString();

            tbMinParticipants.Text = selectedCourse.Rows[0]["MinMember"].ToString();

            tbCourseTitle.Text = selectedCourse.Rows[0]["Title"].ToString();

            tbCosts.Text = selectedCourse.Rows[0]["AmountInEuro"].ToString();

            tbDescription.Text = selectedCourse.Rows[0]["Description"].ToString();

            tbValidInMonth.Text = selectedCourse.Rows[0]["ValidityInMonth"].ToString();

            foreach (ComboBoxItem cbItem in cbTutor.Items)
            {
                if (selectedCourse.Rows[0]["Tutor"].ToString() == cbItem.Content.ToString())
                {
                    cbTutor.SelectedItem = cbItem;
                }
            }
        }

        private void setGuiValues()
        {

            lblCourse.Content = "Neuer Kurs";

            // Values for Tutor
            DataTable allTutors = TutorLogic.getInstance().getAll();
            foreach (DataRow aDataRow in allTutors.Rows)
            {
                ComboBoxItem aComboBoxItem = new ComboBoxItem();
                string name = aDataRow["Surname"].ToString() + ", " + aDataRow["Forename"].ToString();
                aComboBoxItem.Content = name;
                aComboBoxItem.Tag = aDataRow["Id"];
                cbTutor.Items.Add(aComboBoxItem);
            }
        }



        private void insertCourse()
        {
            fillingNonMandatoryDataFields();
            if(cbTutor.SelectedItem != null)
            {
                tutor = Convert.ToInt32(((ComboBoxItem)cbTutor.SelectedItem).Tag);
            try
            {
                if (selectedCourse == null)
                {
                    CourseLogic.getInstance().create(titeL, amountInEuro, description, maxParticipants, minParticipants, tutor, validInMonths);
                    this.DialogResult = true;
                }
                else
                {
                    int CourseNr = Convert.ToInt32(selectedCourse.Rows[0]["CourseNr"]);
                    CourseLogic.getInstance().changeProperties(CourseNr, titeL, amountInEuro, description, maxParticipants, minParticipants, tutor, validInMonths);
                    this.DialogResult = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler \nException:" + e.Message);
            }   
            }
            else { MessageBox.Show("Bitte Tutor auswählen"); }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            insertCourse();
        }

        private void btnAport_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void fillingNonMandatoryDataFields()
        {
            titeL = tbCourseTitle.Text;
            try { amountInEuro = Convert.ToDecimal(tbCosts.Text); }
            catch { amountInEuro = 0; }
            description = tbDescription.Text;
            try { maxParticipants = Convert.ToInt32(tbMaxParticipants.Text); }
            catch { amountInEuro = 0; }
            try { minParticipants = Convert.ToInt32(tbMinParticipants.Text); }
            catch { minParticipants = 0; }
            
            try { validInMonths = Convert.ToInt32(tbValidInMonth.Text); }
            catch { validInMonths = 0; }
        }
    }
}
