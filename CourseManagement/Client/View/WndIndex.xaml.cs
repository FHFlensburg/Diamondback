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
using System.Windows.Media;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndIndex.xaml
    /// </summary>
    public partial class WndIndex : RibbonWindow
    {
        DataRowView row;
        int choosenCourseNr;

        /// <summary>
        /// Default Constructor for the Index WPF Window
        /// </summary>
        public WndIndex()
        {
           InitializeComponent();
        }

        private void mainWindow_IsLoaded(object sender, System.EventArgs e)
        {
            refreshDataGrids();
            fillComboBoxRoomNumber();
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshDataGrids();
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
        /// <param name=""></param>
        private void refreshDataGrids()
        {
            if (this.IsLoaded)
            {
                try
                {
                    switch (mainRibbon.SelectedIndex)
                    {
                        case 0:
                            this.dgCourse.DataContext = CourseLogic.getInstance().getAll();
                            changeColumnTitleCourse();
                            break;
                        case 1:
                            dgCourse.DataContext = PersonLogic.getInstance().getAll();
       

                             cbValues.Items.Clear();
                            cbValues.Items.Add(new RibbonGalleryItem() { Content = "Alle Personen", Foreground = Brushes.Blue });
                            cbValues.Items.Add(new RibbonGalleryItem() { Content = "Tutoren", Foreground = Brushes.Green });
                            cbValues.Items.Add(new RibbonGalleryItem() { Content = "Studenten", Foreground = Brushes.Red });
                            if (ActiveUser.userIsAdmin()) cbValues.Items.Add(new RibbonGalleryItem() 
                            { Content = "Benutzer", Foreground = Brushes.Orange });
                            break;
                        case 2:
                            dgCourse.DataContext = RoomLogic.getInstance().getAll();
                            break;
                        case 3:
                            dgCourse.DataContext = PaymentLogic.getInstance().getAll();
                            
                            break;
                        default:
                            dgCourse.DataContext = null;
                            break;
                    }
                    //sizingColumns();

                    DataTable temp = null;
                    temp = AppointmentLogic.getInstance().getAll();
                    dgAppointments.DataContext = temp;

                    dgAppointments.Columns[0].Header = "Termin-Nr";
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
        /// How the hell can I do it better? 
        ///
        /// New idea: Maybe possible with a Hash Map or something like that 
        /// </summary>
        private void changeColumnTitleCourse()
        {
            foreach (DataGridColumn aDGC in dgCourse.Columns)
            {
                switch (aDGC.Header.ToString())
                {
                    case "CourseNr":
                        aDGC.Header = "KursNr";
                        break;
                    case "Title":
                        aDGC.Header = "Titel";
                        break;
                    case "AmountInEuro":
                        aDGC.Header = "Betrag";
                        break;
                    case "Description":
                        aDGC.Header = "Beschreibung";
                        break;
                    case "MaxMember":
                        aDGC.Header = "Max Teilnehmer";
                        break;
                    case "MinMember":
                        aDGC.Header = "Min teilnehmer";
                        break;
                    case "ValidityInMonth":
                        aDGC.Header = "Gültigkeit in Monaten";
                        break;
                    case "Payments":
                        aDGC.Header = "Zahlungen";
                        break;
                    case "Appointments":
                        aDGC.Header = "Termine";
                        break;
                }
            }

            //if (dgCourse.Columns.Count == columnHeaderTitles.Length)
            //{
            //    for (int i = 0; i < columnHeaderTitles.Length; i++)
            //    {
            //        dgCourse.Columns[i].Header = columnHeaderTitles[i];
            //    }
            //}
        }


        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Only in Course tab there should appear the window to add a participant
            if (mainRibbon.SelectedIndex == 0)
            {
                OpenWindow2AddParticpant();
            }
        }

        private void OpenWindow2AddParticpant()
        {
            WndParticipant2Course aNewAllocation = null;
            try
            {
                if (dgCourse.SelectedItems.Count > 0)
                {
                    aNewAllocation = new WndParticipant2Course(choosenCourseNr);
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

        private void RibbonButtonAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow2AddParticpant();
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
                DataTable courseRoomNumber = RoomLogic.getInstance().getAll();
                int temporaryCountIndex = courseRoomNumber.Rows.Count;

                foreach (DataRow aDataRow in courseRoomNumber.Rows)
                {
                    ComboBoxItem aComboBoxItem = new ComboBoxItem();
                    aComboBoxItem.Content = aDataRow["RoomNr"];
                    cbxAppointmentRoomNumber.Items.Add(aComboBoxItem);
                }  
            }
            catch (System.Exception err)
            {

                Xceed.Wpf.Toolkit.MessageBox.Show(err.ToString());
            }
        }

        /// <summary>
        /// Method which Deletes a Course
        /// 
        /// Because we do data binding, the structure of the main index and the data tables are the same
        /// Only thing to do is to look which entry in all courses is the one which was selected to delete. 
        /// To do this there is the temporary Datatable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RibbonButtonDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            if (dgCourse.SelectedIndex != -1)
            {
                
                DataTable tempDataTable = CourseLogic.getInstance().getAll();
                try
                {
                    int selectedIndex = Convert.ToInt32(tempDataTable.Rows[dgCourse.SelectedIndex]["CourseNr"]);
                    CourseLogic.getInstance().delete(selectedIndex);
                }
                catch (Exception err)
                {
                throw new Exception(err.Message);
                }
                refreshDataGrids();
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
                lblCourseNotSelected.Visibility = Visibility.Visible;
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
            //if (this.dpEndOfAppointCourse.Value.Value.ToUniversalTime() != null)
            if(dpEndOfAppointCourse.Text != null)
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
                chosenRoomNr = Convert.ToInt32(((ComboBoxItem)cbxAppointmentRoomNumber.SelectedItem).Content);
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
                lblCourseNotSelected.Visibility = Visibility.Hidden;
            }
        }

        private void RibbonButtonEditCourse_Click(object sender, RoutedEventArgs e)
        {
            if (dgCourse.SelectedIndex != -1)
            {
                DataTable tempDataTable = CourseLogic.getInstance().getAll();
                try
                {
                    int selectedIndex = Convert.ToInt32(tempDataTable.Rows[dgCourse.SelectedIndex]["CourseNr"]);
                    DataTable selectedCourse = CourseLogic.getInstance().getById(selectedIndex);
                    WndNewCourse editCourse = new WndNewCourse(selectedCourse);
                    editCourse.ShowDialog(); 
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
                    choosenCourseNr = Convert.ToInt32(row["CourseNr"]);
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
            Mouse.Capture(cbxPersons);                                          //workaround for buggy combobox-selection in windows-ribbon.
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
            Mouse.Capture(null);                                                //workaround for buggy combobox-selection in windows-ribbon.
          
        }

        

        /// <summary>
        /// formatting the datagrids
        /// Each Grid has to have 25% of the Window, no matter how big or small it gets through user input
        /// As simple as it could be
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            dgCourse.Height = this.Height / 4;
            dgAppointments.Height = this.Height / 4;
            //if (this.IsLoaded)
            //{
            //    sizingColumns();
            //}
        }

        /// <summary>
        /// We needed a a solution that the width of the columns fill all the space of the datagrid and on the other hand
        /// are sized so that the content fits
        /// 
        /// </summary>
        private void sizingColumns()
        {
            //
            dgCourse.MinColumnWidth = 0;
            dgCourse.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Auto);
            double sumOfCoulumnsWidth = 0;
            foreach (DataGridColumn aDataGridColumn in dgCourse.Columns)
            {
                sumOfCoulumnsWidth += aDataGridColumn.ActualWidth;
                
            }
            if (sumOfCoulumnsWidth < this.ActualWidth)
            {
                dgCourse.MinColumnWidth = this.ActualWidth / dgCourse.Columns.Count;
            }
            
        }

        private void MainWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
