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

            
            WndLogin startWindow = new WndLogin();
            WndIndex mainWindow = new WndIndex();
            DataTable myDataTable = StudentLogic.getAllStudents();
            mainWindow.dgCourse.DataContext = myDataTable;
            if (startWindow.ShowDialog() == true)
            {
                mainWindow.Show();
            }
        }

        public static void foo(WndIndex a, SelectionChangedEventArgs e)
        {
            if (a.IsLoaded)
            {
                try
                {
                    if (a.mainRibbon.SelectedIndex == 0)
                    {

                        DataTable myDataTable = StudentLogic.getAllStudents();
                        a.dgCourse.DataContext = myDataTable;
                    }
                    else
                    {
                        DataTable myDataTable2 = StudentLogic.getAllStudents();
                        a.dgCourse.DataContext = myDataTable2;

                    }
                }
                catch
                {
                    MessageBox.Show("Test");
                }

            }
        }




        //WndNewCourse secondWindow = new WndNewCourse();
        //secondWindow.Show();

    }
}

