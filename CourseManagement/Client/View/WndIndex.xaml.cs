using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Windows.Controls.Ribbon;
using System.Data;
using CourseManagement.Client.BusinessLogic;
using System.Collections.Generic;
using System;


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

        private void mainWindow_IsLoaded(object sender, System.EventArgs e)
        {
            refreshDataGrids(this);
            fillComboBoxCourse();
            fillComboBoxRoomNumber();
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

        /// <summary>
        /// Manages which of the DataTables are shown in the datagrid of the view
        /// </summary>
        /// <param name="mainWindow"></param>
        private void refreshDataGrids(WndIndex mainWindow)
        {
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
                            changeColumnHeaderCourse();
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
                    dgAppointments.Columns[1].Header = "Kurs";
                    dgAppointments.Columns[2].Header = "Startdatum";
                    dgAppointments.Columns[3].Header = "Enddatum";
                    dgAppointments.Columns[4].Header = "Raum";
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void changeColumnHeaderCourse()
        {
            //ToDo ... opporunity to optimize? own method? 
            //changing column title from the ones the Databases delievers
            dgCourse.Columns[0].Header = "Kurs-Nr";
            dgCourse.Columns[1].Header = "Kurs Titel";
            dgCourse.Columns[2].Header = "Betrag in €";
            dgCourse.Columns[3].Header = "Beschreibung";
            dgCourse.Columns[4].Header = "Max Teilnahmer";
            dgCourse.Columns[5].Header = "Min Teilnahmer";
            dgCourse.Columns[6].Header = "Tutor";
            dgCourse.Columns[7].Header = "Gültigkeit in Monate";
            dgCourse.Columns[8].Header = "Bezahlungen";
            dgCourse.Columns[9].Header = "Buchungen";
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
                string selectedIndex = temp.Rows[dgCourse.SelectedIndex][0].ToString();
                int tmp = int.Parse(selectedIndex);
                try
                {
                    CourseLogic.getInstance().delete(tmp);
                }
                catch
                {

                }
                refreshDataGrids(this);
                fillComboBoxCourse();
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            //getting CourseNumber from Selection
            if (this.cbxAppointmentCourse.SelectedItem != null)
            {
                //Following does return an empty DataTable which then will cause a exception. 
                //ToDo Research why the search method does not work properly
                DataTable choosenCourse = AppointmentLogic.getInstance().search(cbxAppointmentCourse.SelectedItem.ToString());
                int courseNumber = Int32.Parse(choosenCourse.Rows[1]["courseNr"].ToString());
                lblCourseNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                this.lblCourseNotFilled.Visibility = Visibility.Visible;
            }


            //getting begin of appointment from selection
            if (this.dpBeginOfCourse.SelectedDate != null)
            {
                DateTime choosenStartDate = (DateTime)dpBeginOfCourse.SelectedDate;
                lblBeginnDateNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblBeginnDateNotFilled.Visibility = Visibility.Visible;
            }


            //getting end of Appointment from selection
            if (this.dpEndOfAppointCourse.SelectedDate != null)
            {
                DateTime choosenEndDate = (DateTime)dpEndOfAppointCourse.SelectedDate;
                lblEndDateNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblEndDateNotFilled.Visibility = Visibility.Visible;
            }

            //getting room number for appointment from selection
            if (this.cbxAppointmentRoomNumber.SelectedItem != null)
            {
                DataTable choosenRoom = AppointmentLogic.getInstance().search(cbxAppointmentRoomNumber.SelectedItem.ToString());
                int choosenRoomNr = Int32.Parse(choosenRoom.Rows[0]["roomNr"].ToString());
                lblRoomNrNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblRoomNrNotFilled.Visibility = Visibility.Visible;
            }


            if(dpBeginOfCourse.SelectedDate != null 
                && dpEndOfAppointCourse.SelectedDate != null 
                && cbxAppointmentCourse.SelectedItem != null 
                && cbxAppointmentRoomNumber.SelectedItem != null 
                && (DateTime)dpBeginOfCourse.SelectedDate < (DateTime)dpEndOfAppointCourse.SelectedDate)
            {
                //if(AppointmentLogic.getInstance().isPossibleNewAppointment(courseNumber,choosenStartDate, choosenEndDate,choosenRoomNr)
                //{
                //AppointmentLogic.getInstance().create(courseNumber, choosenStartDate, choosenEndDate, ChoosenRoomNr);
                //}

                refreshDataGrids(this);

                //hiding the error labels again
                this.lblCourseNotFilled.Visibility = Visibility.Hidden;
                lblBeginnDateNotFilled.Visibility = Visibility.Hidden;
                lblEndDateNotFilled.Visibility = Visibility.Hidden;
                lblRoomNrNotFilled.Visibility = Visibility.Hidden;
            }
        }
    }
}
