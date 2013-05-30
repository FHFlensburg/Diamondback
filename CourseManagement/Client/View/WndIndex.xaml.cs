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

        static string[] columnHeaderTitles = new string[]
            {
                "Kurs-Nr","Kurs Titel", "Betrag in €", "Beschreibung", "Max Teilnahmer", "Min Teilnahmer", "Tutor", "Gültigkeit in Monate", "Bezahlungen", "Buchungen"
            };
        
        static string[] personHeaderTitles = new string[]
        {

        };

        
        public WndIndex()
        {
            dgCourse.ColumnFromDisplayIndex(5);
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
                            changeColumnTitleCourse();
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

        
        /// <summary>
        /// Like this for every Header 
        ///ToDo How to change oder of columns 
        ///
        /// </summary>
        private void changeColumnTitleCourse()
        {
            if(dgCourse.Columns.Count == columnHeaderTitles.Length)
            {
                for(int i = 0; i < columnHeaderTitles.Length; i++)
                {
                dgCourse.Columns[i].Header = columnHeaderTitles[i];
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

      

        private void fillComboBoxRoomNumber()
        {
            if (this.cbxAppointmentRoomNumber.Items.Count >= 1)
            {
                this.cbxAppointmentRoomNumber.Items.Clear();
            }
            try
            {
                DataTable courseRoomNumber = null;
                courseRoomNumber = RoomLogic.getInstance().getAll();
                string temporaryItem = string.Empty;
                int temporaryCountIndex = courseRoomNumber.Rows.Count;

                for (int i = 0; i < temporaryCountIndex; i++)
                {
                    temporaryItem = string.Empty;
                    temporaryItem = courseRoomNumber.Rows[i]["RoomNr"].ToString();
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
            int chosenCourseID = 0;
            DateTime chosenStartDate = DateTime.MinValue;
            DateTime chosenEndDate = DateTime.MinValue;
            int chosenRoomNr = 0;

            //getting CourseNumber from UserSelection (ComboBox)
            if (this.cbxAppointmentCourse.SelectedItem != null)
            {
                DataTable chosenCourse = CourseLogic.getInstance().search(cbxAppointmentCourse.SelectedItem.ToString());
                chosenCourseID = Int32.Parse(chosenCourse.Rows[0][0].ToString());
                lblCourseNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                this.lblCourseNotFilled.Visibility = Visibility.Visible;
            }


            //getting begin of appointment from userselection
            if (this.dpBeginOfCourse.SelectedDate != null)
            {
                chosenStartDate = (DateTime)dpBeginOfCourse.SelectedDate;
                lblBeginnDateNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblBeginnDateNotFilled.Visibility = Visibility.Visible;
            }


            //getting end of Appointment from userselection
            if (this.dpEndOfAppointCourse.SelectedDate != null)
            {
                chosenEndDate = (DateTime)dpEndOfAppointCourse.SelectedDate;
                lblEndDateNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblEndDateNotFilled.Visibility = Visibility.Visible;
            }

            //getting room number for appointment from userselection
            if (this.cbxAppointmentRoomNumber.SelectedItem != null)
            {
                DataTable chosenRoom = RoomLogic.getInstance().search(cbxAppointmentRoomNumber.SelectedItem.ToString());
                chosenRoomNr = Int32.Parse(chosenRoom.Rows[0][0].ToString());
                lblRoomNrNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblRoomNrNotFilled.Visibility = Visibility.Visible;
            }


            if(cbxAppointmentCourse.SelectedItem != null 
                && dpBeginOfCourse.SelectedDate != null 
                && dpEndOfAppointCourse.SelectedDate != null 
                && cbxAppointmentRoomNumber.SelectedItem != null 
                && (DateTime)dpBeginOfCourse.SelectedDate < (DateTime)dpEndOfAppointCourse.SelectedDate)
            {
                if (AppointmentLogic.getInstance().isPossibleNewAppointment(chosenCourseID, chosenRoomNr, chosenStartDate, chosenEndDate))
                {
                    AppointmentLogic.getInstance().create(chosenCourseID, chosenRoomNr, chosenStartDate, chosenEndDate);
                }

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
