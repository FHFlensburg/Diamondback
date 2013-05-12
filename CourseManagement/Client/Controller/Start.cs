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
            //nur zum testen
            ActiveUser.login("admin", "admin"); ///////////Without login there is no access to DB!!!!
            testLogic testWindow = new testLogic();
            testWindow.Show();
            
            
            WndLogin startWindow = new WndLogin();
            WndIndex mainWindow = new WndIndex();
            DataTable myDataTable = StudentLogic.getInstance().getAll();
            mainWindow.dgCourse.DataContext = myDataTable;
            if (startWindow.ShowDialog() == true)
            {
                mainWindow.Show();
                
                
            }

            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        public static void foo(WndIndex a, SelectionChangedEventArgs e)
        {
            if (a.IsLoaded)
            {
                try
                {
                    if (a.mainRibbon.SelectedIndex == 0)
                    {

                        DataTable myDataTable = StudentLogic.getInstance().getAll();
                        a.dgCourse.DataContext = myDataTable;
                    }
                    else
                    {
                        DataTable myDataTable2 = StudentLogic.getInstance().getAll();
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

