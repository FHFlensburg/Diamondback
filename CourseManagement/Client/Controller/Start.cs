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
            //ActiveUser.login("admin", "admin"); ///////////Without login there is no access to DB!!!!
           // testLogic testWindow = new testLogic();
            //testWindow.Show();
            
            
            WndLogin startWindow = new WndLogin();
            WndIndex mainWindow = new WndIndex();
            if (startWindow.ShowDialog() == true)
            {
                mainWindow.Show();
            }

            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        public static void viewChanged(WndIndex mainWindow, SelectionChangedEventArgs e)
        {
            /// <summary>
            /// Manages which of the DataTables are shown in the datagrid of the view
            /// just for test here, needs to be placed better^^
            /// </summary>
            /// <returns></returns>

            DataTable dt4Grid = null;
            if (mainWindow.IsLoaded)
            {
                try
                {
                    switch (mainWindow.mainRibbon.SelectedIndex)
                    {
                        case 0:
                            dt4Grid = CourseLogic.getInstance().getAll();
                            mainWindow.dgCourse.DataContext = dt4Grid;
                            break;
                        case 1:
                            dt4Grid = StudentLogic.getInstance().getAll();
                            mainWindow.dgCourse.DataContext = dt4Grid;
                            break;
                        case 2:
                            dt4Grid = RoomLogic.getInstance().getAll();
                            mainWindow.dgCourse.DataContext = dt4Grid;
                            break;
                        default:
                            mainWindow.dgCourse.DataContext = null;
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }

            }
        }
        




        //WndNewCourse secondWindow = new WndNewCourse();
        //secondWindow.Show();

    }
}

