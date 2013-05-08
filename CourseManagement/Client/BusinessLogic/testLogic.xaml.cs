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

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Interaktionslogik für testLogic.xaml
    /// </summary>
    public partial class testLogic : Window
    {
        public testLogic()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            dg_Test.DataContext = CourseLogic.getAllCourses();
        }


    }
}
