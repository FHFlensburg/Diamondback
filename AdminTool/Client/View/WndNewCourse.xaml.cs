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
using AdminTool.Client.Model;


namespace AdminTool.Client.View
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
            foreach(Student strldk in Student.search("a"))
            {
                tbCourseNumber.Text += strldk.Surname;
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
