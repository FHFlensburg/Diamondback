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

            
            tbMaxParticipants.Text = selectedCourse.Rows[0]["MaxMember"].ToString();
           
            tbMinParticipants.Text = selectedCourse.Rows[0]["MinMember"].ToString();
            
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
                minParticipants = Convert.ToInt32(tbMinParticipants.Text);
                tutor = Convert.ToInt32(((ComboBoxItem)cbTutor.SelectedItem).Tag);
                validInMonths = Convert.ToInt32(tbValidInMonth.Text);

                if (selectedCourse == null)
                {
                    CourseLogic.getInstance().create(titeL, amountInEuro, description, maxParticipants, minParticipants, tutor, validInMonths);
                }
                else
                {
                    int CourseNr = Convert.ToInt32(selectedCourse.Rows[0]["CourseNr"]);
                    CourseLogic.getInstance().changeProperties(CourseNr, titeL, amountInEuro, description, maxParticipants, minParticipants, tutor, validInMonths);
                }
            }
            catch
            {
                MessageBox.Show("Eingaben haben nicht das richtige Format");
            }

        }

        private void btnAport_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }     
    }
}
