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

        /*
         * http://dotnet-forum.de/blogs/larsschmitt/archive/2009/11/04/einfache-input-validation-mit-wpf.aspx
         */
        private string title, description = string.Empty;
        private int maxMember, minMember, tutorNr, validityInMonth = 0;
        private decimal amountInEuro = 0m;

        public WndNewCourse()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CourseLogic createCourse = CourseLogic.getInstance();
            insertNewCourseAndValidate();
            this.Close();
        }

        private void insertNewCourseAndValidate()
        {
            this.title = tbCourseTitle.Text.ToString();
        }     
    }
}
