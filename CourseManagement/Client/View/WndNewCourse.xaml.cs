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
using CourseManagement.Client.DB.Model_EF;


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
        }
      

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach(Student strldk in Student.search("12"))
            {
                strldk.setForename(tbRoom.Text);
                tbCourseNumber.Text += strldk.Forename;
            }
        }

        private void btnAport_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tbCourseNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblCourseNumber.Content = "";
                foreach(Student student in Student.search(tbCourseNumber.Text))
                {
                    lblCourseNumber.Content += student.Id.ToString() + " | ";
                }
        }
    }
}
