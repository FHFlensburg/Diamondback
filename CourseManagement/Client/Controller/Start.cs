using System.Windows;
using CourseManagement.Client.View;

namespace CourseManagement.Client.Controller
{
   public partial class Start : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            ///
            ///
            ///##
           // WndLogin startWindow = new WndLogin();
            //startWindow.Show();
            WndNewCourse secondWindow = new WndNewCourse();
            secondWindow.Show();
        }
    }
}
