using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Windows.Controls.Ribbon;
using System.Data;
using CourseManagement.Client.BusinessLogic;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Windows.Controls.Primitives;
using Xceed.Wpf.Toolkit;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndIndex.xaml
    /// </summary>
    public partial class WndIndex : RibbonWindow
    {
        DataRowView row;
        int choosenCourseNr;
        static string[] columnHeaderTitles = new string[]
            {
                "Kurs-Nr","Kurs Titel", "Betrag in €", "Beschreibung", "Max Teilnahmer", "Min Teilnahmer", "Tutor", "Gültigkeit in Monate", "Bezahlungen", "Buchungen"
            };
        
        static string[] personHeaderTitles = new string[]
        {

        };

        /// <summary>
        /// Default Constructor for the Index WPF Window
        /// </summary>
        public WndIndex()
        {
           InitializeComponent();
        }

        private void mainWindow_IsLoaded(object sender, System.EventArgs e)
        {
            refreshDataGrids(this);
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
            if (mainWindow.IsLoaded)
            {
                try
                {
                    switch (mainWindow.mainRibbon.SelectedIndex)
                    {
                        case 0:
                            mainWindow.dgCourse.DataContext = CourseLogic.getInstance().getAll();
                            changeColumnTitleCourse();
                            break;
                        case 1:
                            
                            mainWindow.dgCourse.DataContext = PersonLogic.getInstance().getAll();
                            mainWindow.dgCourse.Columns[0].Visibility = Visibility.Hidden;
                            mainWindow.dgCourse.Columns[1].Visibility = Visibility.Hidden;
                            mainWindow.dgCourse.Columns[2].Visibility = Visibility.Hidden;
                            mainWindow.dgCourse.Columns[3].Visibility = Visibility.Hidden;
                            mainWindow.dgCourse.Columns[4].Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            mainWindow.dgCourse.DataContext = RoomLogic.getInstance().getAll();
                            break;
                        case 3:
                            mainWindow.dgCourse.DataContext = PaymentLogic.getInstance().getAll();
                            break;
                        default:
                            mainWindow.dgCourse.DataContext = null;
                            break;
                    }

                    DataTable temp = null;
                    temp = AppointmentLogic.getInstance().getAll();
                    this.dgAppointments.DataContext = temp;
                    
                    dgAppointments.Columns[1].Header = "Startdatum";
                    dgAppointments.Columns[2].Header = "Enddatum";
                    dgAppointments.Columns[3].Header = "Kurs";
                    dgAppointments.Columns[4].Header = "Raum";
                }
                catch (System.Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString());
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
            WndParticipant2Course aNewAllocation = null;
            if (sender != null)
            {
                try
                {
                    if (dgCourse.SelectedItems.Count > 0)
                    {
                        aNewAllocation = new WndParticipant2Course(29);
                    }
                    else
                    {
                        aNewAllocation = new WndParticipant2Course(-1);
                    }
                    aNewAllocation.ShowDialog();
                }
                catch (System.Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString());
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
                System.Windows.MessageBox.Show(err.ToString());
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

                Xceed.Wpf.Toolkit.MessageBox.Show(err.ToString());
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
            if (dgCourse.SelectedItems.Count == 1)
            {
                try
                {
                    chosenCourseID = choosenCourseNr;
                }
                catch (Exception error)
                {

                    System.Windows.MessageBox.Show(error.ToString());
                }
               
            }
            else
            {
            }


            //getting begin of appointment from userselection
            if (this.dpBeginOfCourse.Text != null)
            {
                chosenStartDate = (DateTime)this.dpBeginOfCourse.Value.Value;
                lblBeginnDateNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblBeginnDateNotFilled.Visibility = Visibility.Visible;
            }


            //getting end of Appointment from userselection
            if (this.dpEndOfAppointCourse.Value.Value.ToUniversalTime() != null)
            {
                chosenEndDate = (DateTime)dpEndOfAppointCourse.Value.Value;
                lblEndDateNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblEndDateNotFilled.Visibility = Visibility.Visible;
            }

            //getting room number for appointment from userselection
            if (this.cbxAppointmentRoomNumber.SelectedItem != null)
            {
                //TODO: Array durch String ersetzen
                chosenRoomNr = Convert.ToInt32(cbxAppointmentRoomNumber.SelectedValue.ToString());
                lblRoomNrNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblRoomNrNotFilled.Visibility = Visibility.Visible;
            }


            if (dgCourse.SelectedItems.Count > 0
                && dpBeginOfCourse.Value.Value != null 
                && dpEndOfAppointCourse.Value.Value != null 
                && cbxAppointmentRoomNumber.SelectedItem != null
                && (DateTime)dpBeginOfCourse.Value.Value < (DateTime)dpEndOfAppointCourse.Value.Value)
            {
                if (AppointmentLogic.getInstance().isPossibleNewAppointment(chosenCourseID, chosenRoomNr, chosenStartDate, chosenEndDate))
                {
                    AppointmentLogic.getInstance().create(chosenCourseID, chosenRoomNr, chosenStartDate, chosenEndDate);
                }

                dgAppointments.DataContext = AppointmentLogic.getInstance().getByCourse(choosenCourseNr);

                //hiding the error labels again
                lblBeginnDateNotFilled.Visibility = Visibility.Hidden;
                lblEndDateNotFilled.Visibility = Visibility.Hidden;
                lblRoomNrNotFilled.Visibility = Visibility.Hidden;
            }
        }

        private void RibbonButtonEditCourse_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgCourse.SelectedIndex != -1)
            {
                DataTable temp = CourseLogic.getInstance().getAll();
                string selectedIndex = temp.Rows[dgCourse.SelectedIndex][0].ToString();
                int tmp = int.Parse(selectedIndex);
                try
                {
                    WndNewCourse editCourse = new WndNewCourse(CourseLogic.getInstance().getById(tmp));
                    editCourse.Show(); 
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString());
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearch_Changed(object sender, TextChangedEventArgs e)
        {            
            switch (mainRibbon.SelectedIndex)
            {
                case 0:
                    dgCourse.DataContext = CourseLogic.getInstance().search(tbSearch.Text);
                    break;
                case 1:
                    dgCourse.DataContext = StudentLogic.getInstance().search(tbSearch.Text);  
                    break;
                case 2:
                    dgCourse.DataContext = RoomLogic.getInstance().search(tbSearch.Text);
                    break;
                case 3:
                    dgCourse.DataContext = PaymentLogic.getInstance().search(tbSearch.Text);
                    break;
                default:
                    dgCourse.DataContext = null;
                    break;
            }
            changeColumnTitleCourse();
        }

        /// <summary>
        /// Creates a new Payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RibbonButtonNewPayment_Click(object sender, RoutedEventArgs e)
        {
            WndNewPayment aPaymentWindow = new WndNewPayment();
            aPaymentWindow.ShowDialog();
        }

        /// <summary>
        /// First check if the Course Tab is selected, then check if only one row in the Datagrid is selcted
        /// After it set the class variable choosenCourseNr by the selected course and fill the appointment table
        /// with all appointments from the selected course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void element_SelectCourse(object sender, SelectionChangedEventArgs e)
        {
            if (this.mainRibbon.SelectedIndex == 0)
            {
                if (dgCourse.SelectedItems.Count == 1)
                {
                    row = (DataRowView)dgCourse.SelectedItems[0];
                    choosenCourseNr = Convert.ToInt32(row[0].ToString());
                    dgAppointments.DataContext = AppointmentLogic.getInstance().getByCourse(choosenCourseNr);
                }
            }
        }

        /// <summary>
        /// Fills the Person DataGrid with the selected PersonGroup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RibbonGallery_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            switch (this.cbxPersons.Text)
            {
                case "Alle Personen":
                    this.dgCourse.DataContext = PersonLogic.getInstance().getAll();
                    break;
                case "Tutoren":
                    this.dgCourse.DataContext = TutorLogic.getInstance().getAll();
                    break;
                case "Studenten":
                    this.dgCourse.DataContext = StudentLogic.getInstance().getAll();
                    break;
                case "Benutzer":
                    this.dgCourse.DataContext = UserLogic.getInstance().getAll();
                    break;
            }
        }

        private void cbxAppointmentStartTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
