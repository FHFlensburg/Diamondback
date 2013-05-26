using System.Windows;
using CourseManagement.Client.View;
using System.Data;
using CourseManagement.Client.BusinessLogic;
using System.Windows.Controls;

namespace CourseManagement.Client.Controller
{
    public partial class Start : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            //TestData.generateTestData();
            
            
            WndLogin startWindow = new WndLogin();
            WndIndex mainWindow = new WndIndex();
            if (startWindow.ShowDialog() == true)
            {
                mainWindow.Show();
            }

            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        
        




        //WndNewCourse secondWindow = new WndNewCourse();
        //secondWindow.Show();

    }
}

