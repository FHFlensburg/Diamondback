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
//            cboxitem = new ComboBoxItem();
//cboxitem.Content = "Created with C#";
//cbox.Items.Add(cboxitem);
            cbMaxParticipants.Background = Brushes.LightBlue;
            ComboBoxItem foo = new ComboBoxItem();
            foo.Content = 1;
            cbMaxParticipants.Items.Add(foo);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CourseLogic createCourse = CourseLogic.getInstance();
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
            MessageBox.Show(maxParticipants);
            
        }     
    }
}
