using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Windows.Controls.Ribbon;
using System.Data;
using CourseManagement.Client.BusinessLogic;
using System.Collections.Generic;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndIndex.xaml
    /// </summary>
    public partial class WndIndex : RibbonWindow
    {
        
        public WndIndex()
        {
            
            InitializeComponent();
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshDataGrids(this);
            //Noch zu überarbeiten und zu prüfen ob sauberer Stil
        }

        private void RibbonButtonNewCourse_Click(object sender, RoutedEventArgs e)
        {
            WndNewCourse aNewCourse = new WndNewCourse();
            aNewCourse.ShowDialog();
        }

        private void RibbonButtonNewPerson_Click(object sender, RoutedEventArgs e)
        {
            wndNewPerson aNewPerson = new wndNewPerson();
            aNewPerson.ShowDialog();
        }

        private void RibbonButtonNewRoom_Click(object sender, RoutedEventArgs e)
        {
            WndNewRoom aNewRoom = new WndNewRoom();
            aNewRoom.ShowDialog();
        }

        private void refreshDataGrids(WndIndex mainWindow)
        {
            /// <summary>
            /// Manages which of the DataTables are shown in the datagrid of the view
            /// 
            /// </summary>
            /// <returns></returns>
            /// 
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

                    DataTable temp = null;
                    temp = AppointmentLogic.getInstance().getAll();
                    this.dgAppointments.DataContext = temp;
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenWindow2AddParticpant(sender);
        }

        private void OpenWindow2AddParticpant(object sender)
        {
            if (sender != null)
            {
                try
                {
                    WndParticipant2Course aNewAllocation = new WndParticipant2Course();
                    aNewAllocation.dgParticipant.DataContext = (DataTable)this.dgCourse.DataContext;
                    aNewAllocation.ShowDialog();
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void RibbonButtonAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow2AddParticpant(sender);
        }

        private void OpenHelpFile(object sender, RoutedEventArgs e)
        {
            //opening a generated Help File
            //Made a Word File and converted it. Test chm file in the Image Folder
            //
            //ToDo Change so it works with relative paths

            try
            {
                System.Diagnostics.Process.Start(@"C:\path-to-chm-file.chm");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            
        }

        private void mainWindow_IsLoaded(object sender, System.EventArgs e)
        {
            refreshDataGrids(this);
            fillComboBoxCourse();
            fillComboBoxRoomNumber();
           
        }

        private void fillComboBoxRoomNumber()
        {
            if (this.cbxAppointmentRoomNumber.Items.Count >= 1)
            {
                this.cbxAppointmentRoomNumber.Items.Clear();
            }
            try
            {
                DataTable courseRoomNumber = null;
                courseRoomNumber = AppointmentLogic.getInstance().getAll();
                string temporaryItem = string.Empty;
                int temporaryCountIndex = courseRoomNumber.Rows.Count;

                for (int i = 0; i < temporaryCountIndex; i++)
                {
                    temporaryItem = string.Empty;
                    temporaryItem = courseRoomNumber.Rows[i]["Room"].ToString();
                    cbxAppointmentRoomNumber.Items.Add(temporaryItem);
                    //TODO: Duplizitäten. Wo erfolgt die Validierung?!
                }       
            }
            catch (System.Exception err)
            {

                MessageBox.Show(err.ToString());
            }
        }

        

        private void fillComboBoxCourse()
        {
            this.cbxAppointmentCourse.Items.Clear();
            try
            {
                DataTable CourseTitle = null;
                CourseTitle = CourseLogic.getInstance().getAll();
                string temporaryItem = string.Empty; 
                int temporaryCountIndex = CourseTitle.Rows.Count;
                for (int i = 0; i < temporaryCountIndex; i++)
                {
                    temporaryItem = string.Empty;
                    temporaryItem = CourseTitle.Rows[i]["Title"].ToString();
                    this.cbxAppointmentCourse.Items.Add(temporaryItem);
                }
            }
            catch (System.Exception err)
            {

                MessageBox.Show(err.ToString());
            }
        }

        private void RibbonButtonDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgCourse.SelectedIndex != -1)
            {
                
                DataTable temp = CourseLogic.getInstance().getAll();
                string i = temp.Rows[dgCourse.SelectedIndex][0].ToString();
                int bla = int.Parse(i);
                try
                {
                    CourseLogic.getInstance().delete(bla);
                }
                catch
                {

                }
                refreshDataGrids(this);
                fillComboBoxCourse();
                
            }
        }

        private void cbxAppointmentRoomNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: Jan, warum steht die Methode im XAML? Lösche Sie... Sie bringt nichts!
        }

        private void cbxAppointmentCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: Jan, warum steht die Methode im XAML? Lösche Sie... Sie bringt nichts!
        }

    }
}
