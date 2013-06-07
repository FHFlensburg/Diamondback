﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Windows.Controls.Ribbon;
using System.Data;
using CourseManagement.Client.BusinessLogic;
using System;
using System.Windows.Media;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndIndex.xaml
    /// </summary>
    public partial class WndIndex : RibbonWindow
    {
        private DataRowView row;
        private int choosenCourseNr;
        private double spAppointmentsHeight;
        private double dataGridHeight;
        private DataGrid lastfocusedDG;

        /// <summary>
        /// Default Constructor for the Index WPF Window
        /// </summary>
        public WndIndex()
        {
           InitializeComponent();
           spAppointmentsHeight = spAppointments.Height;
           dataGridHeight = dgAppointments.Height;

        }


        private void mainWindow_IsLoaded(object sender, System.EventArgs e)
        {
            if (!dgMainData.HasItems)
            {
                refreshCourses();
                refreshAppointments();
                fillComboBoxRoomNumber();
            }
            dgMainData.Columns[dgMainData.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            
        }

        private void mainWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region Office Ribbin Button pressed Eevents

        #region Office Ribbon tab Course
        /// <summary>
        /// First check if the Course Tab is selected, then check if only one row in the Datagrid is selcted
        /// After it set the class variable choosenCourseNr by the selected course and fill the appointment table
        /// with all appointments from the selected course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void element_SelectCourse(object sender, SelectionChangedEventArgs e)
        {

            if (dgMainData.SelectedItems.Count == 1)
            {
                try
                {
                    switch (mainRibbon.SelectedIndex)
                    {
                        case 0:
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            choosenCourseNr = Convert.ToInt32(row["CourseNr"]);
                            dgAppointments.DataContext = AppointmentLogic.getInstance().getByCourse(choosenCourseNr);
                            dgAppointments.Columns[0].Visibility = Visibility.Hidden;
                            string text = "Termin zu Kurs " + choosenCourseNr.ToString() + " buchen";
                            lblSettingAppointmentToCourse.Content = text;
                            text = "Buchungen zu Kurs " + choosenCourseNr.ToString();
                            lblAppointmentToCourse.Content = text;
                            break;
                        case 1:
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            choosenCourseNr = Convert.ToInt32(row["Id"]);
                            if (cbxPersons.Text == "Tutoren")
                            {
                                dgAppointments.DataContext = CourseLogic.getInstance().getByTutor(choosenCourseNr);
                            }
                            if (cbxPersons.Text == "Studenten")
                            {
                                dgAppointments.DataContext = CourseLogic.getInstance().getByStudent(choosenCourseNr);
                            }
                            if (cbxPersons.SelectionBoxItem.ToString() == "Alle Personen"
                                || cbxPersons.Text == "Benutzer")
                            {
                                dgAppointments.DataContext = CourseLogic.getInstance().getByPerson(choosenCourseNr);
                            }
                            break;
                        case 2:
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            choosenCourseNr = Convert.ToInt32(row["RoomNr"]);
                            dgAppointments.DataContext = AppointmentLogic.getInstance().getByRoom(choosenCourseNr);
                            break;
                        case 3:
                            if (cbxPaymentGroups.Text == "Studenten")
                            {
                                row = (DataRowView)dgMainData.SelectedItems[0];
                                choosenCourseNr = Convert.ToInt32(row["Id"]);
                                dgAppointments.DataContext = PaymentLogic.getInstance().getByStudent(choosenCourseNr);
                                lblStudentName.Content = "Saldo von " + row["Forename"] + " " + row["Surname"] + ":";
                                lblStudentHasToPay.Content = PaymentLogic.getInstance().getStudentBalance(choosenCourseNr).ToString();
                            }
                            if (cbxPaymentGroups.Text == "Kurse")
                            {
                                row = (DataRowView)dgMainData.SelectedItems[0];
                                choosenCourseNr = Convert.ToInt32(row["CourseNr"]);
                                dgAppointments.DataContext = StudentLogic.getInstance().getByCourse(choosenCourseNr);
                                lblStudentName.Content = "Forderungen: " + CourseLogic.getInstance().getOverAllAmount(choosenCourseNr).ToString();
                                lblStudentHasToPay.Content = "Noch zu zahlen: " + CourseLogic.getInstance().getBalance(choosenCourseNr).ToString();
                            }
                            break;
                        default:
                            dgMainData.DataContext = null;
                            break;

                    }
                    changeColumnTitles();
                }
                catch (System.Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString());
                }
            }
            else
            {
                lblSettingAppointmentToCourse.Content = "Termin buchen";
            }
        }

        private void ribbonButtonNewCourse_Click(object sender, RoutedEventArgs e)
        {
            WndNewCourse aNewCourse = new WndNewCourse();
            aNewCourse.ShowDialog();
        }


        private void ribbonButtonAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            openWindow2AddParticpant();
        }


        private void openWindow2AddParticpant()
        {
            WndParticipant2Course aNewAllocation = null;
            try
            {
                if (dgMainData.SelectedItems.Count > 0)
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


        private void ribbonButtonEditCourse_Click(object sender, RoutedEventArgs e)
        {
            if (dgMainData.SelectedIndex != -1)
            {
                DataTable tempDataTable = CourseLogic.getInstance().getAll();
                try
                {
                    int selectedIndex = Convert.ToInt32(tempDataTable.Rows[dgMainData.SelectedIndex]["CourseNr"]);
                    DataTable selectedCourse = CourseLogic.getInstance().getById(selectedIndex);
                    WndNewCourse editCourse = new WndNewCourse(selectedCourse);
                    editCourse.ShowDialog();
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString());
                }
                refreshCourses();
            }
        }

        /// <summary>
        /// ToDo Method from Christian is beetter, change 
        /// 
        /// Method which Deletes a Course
        /// 
        /// Because we do data binding, the structure of the main index and the data tables are the same
        /// Only thing to do is to look which entry in all courses is the one which was selected to delete. 
        /// To do this there is the temporary Datatable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            if (dgMainData.SelectedIndex != -1 && lastfocusedDG == dgMainData)
            {

                DataTable tempDataTable = CourseLogic.getInstance().getAll();
                try
                {
                    int selectedIndex = Convert.ToInt32(tempDataTable.Rows[dgMainData.SelectedIndex]["CourseNr"]);
                    CourseLogic.getInstance().delete(selectedIndex);
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
                refreshCourses();
            }
            else
            {
                if (dgAppointments.SelectedIndex != -1)
                {
                    deleteAppointment();

                }
            }
        }
        #endregion

        #region Office Ribbon Person Tab

        private void ribbonButtonNewPerson_Click(object sender, RoutedEventArgs e)
        {
            wndNewPerson aNewPerson = new wndNewPerson();
            aNewPerson.ShowDialog();
        }

        /// <summary>
        /// Fills the Person DataGrid with the selected PersonGroup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonGallery_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Mouse.Capture(cbxPersons);                                          //workaround for buggy combobox-selection in windows-ribbon.
            switch (this.cbxPersons.Text)
            {
                case "Alle Personen":
                    this.dgMainData.DataContext = PersonLogic.getInstance().getAll();
                    break;
                case "Tutoren":
                    this.dgMainData.DataContext = TutorLogic.getInstance().getAll();
                    break;
                case "Studenten":
                    this.dgMainData.DataContext = StudentLogic.getInstance().getAll();
                    dgMainData.Columns[18].Header = "Kurse";
                    break;
                case "Benutzer":
                    this.dgMainData.DataContext = UserLogic.getInstance().getAll();
                    break;
                    
            }
            changeColumnTitles();
            Mouse.Capture(null);                                                //workaround for buggy combobox-selection in windows-ribbon.
          
        }

        private void ribbonButtonDeletePerson_Click(object sender, RoutedEventArgs e)
        {

            if (dgAppointments.SelectedItems.Count == 1 && dgMainData.SelectedItems.Count == 1)
            {
                int courseNr = Convert.ToInt32(((DataRowView)dgAppointments.SelectedItem)["CourseNr"]);
                int studentNr = Convert.ToInt32(((DataRowView)dgMainData.SelectedItem)["Id"]);
                PaymentLogic.getInstance().delete(courseNr, studentNr);
                dgAppointments.DataContext = CourseLogic.getInstance().getByPerson(studentNr);
                changeColumnTitles();
            }

            else if (dgMainData.SelectedIndex != -1)
            {
                int id = Convert.ToInt32(((DataRowView)dgMainData.SelectedItem)["Id"]);
                PersonLogic.getInstance().delete(id);
                ribbonGallery_SelectionChanged(null, null);
            }


        }

        private void ribbonButtonEditPerson_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = -1;
            DataTable selectedPerson = null;
            int kindOfPerson = 0;

            if (dgMainData.SelectedIndex != -1)
            {
                try
                {
                    if (this.IsLoaded)
                    {
                        DataRowView selectedPersonRow = (DataRowView)dgMainData.SelectedItems[0];
                        selectedIndex = Convert.ToInt32(selectedPersonRow["Id"]);
                        switch (this.cbxPersons.Text)
                        {
                            case "Studenten":
                                selectedPerson = StudentLogic.getInstance().getById(selectedIndex);
                                kindOfPerson = 1;
                                break;
                            case "Benutzer":
                                selectedPerson = UserLogic.getInstance().getById(selectedIndex);
                                kindOfPerson = 2;
                                break;
                            case "Tutoren":
                                //selectedIndex = Convert.ToInt32(selectedPersonRow["Id"]);
                                selectedPerson = TutorLogic.getInstance().getById(selectedIndex);
                                kindOfPerson = 3;
                                break;
                            default:
                                selectedPerson = PersonLogic.getInstance().getById(selectedIndex);
                                kindOfPerson = 0;
                                break;
                        }

                        wndNewPerson editPerson = new wndNewPerson(selectedPerson, kindOfPerson);
                        editPerson.ShowDialog();
                    }
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString());
                }
            }
            refreshPersons();
        }

        #endregion

        #region Office Ribbon Room tab

        private void ribbonButtonNewRoom_Click(object sender, RoutedEventArgs e)
        {
            WndNewRoom aNewRoom = new WndNewRoom();
            aNewRoom.ShowDialog();
        }

        private void ribbonButtonDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            //ToDo: method stub for deleting room

            if (dgMainData.SelectedItems.Count == 1)
            {
                DataRowView selectedRoomRow = (DataRowView)dgMainData.SelectedItems[0];
                RoomLogic.getInstance().delete(Convert.ToInt32(selectedRoomRow["roomNr"]));
                refreshRooms();
            }
            if (dgAppointments.SelectedIndex != -1)
            {
                deleteAppointment();
            }
        }

        private void ribbonButtonEditRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dgMainData.SelectedIndex != -1)
            {
                try
                {
                    DataRowView selectedRoomRow = (DataRowView)dgMainData.SelectedItems[0];
                    int selectedIndex = Convert.ToInt32((selectedRoomRow["roomNr"]));
                    DataTable selectedRoom = RoomLogic.getInstance().getById(selectedIndex);
                    WndNewRoom editCourse = new WndNewRoom(selectedRoom);
                    editCourse.ShowDialog();
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString());
                }
            }
            refreshRooms();
        }

        #endregion

        #region Office Ribbon payment tab

        /// <summary>
        /// Creates a new Payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonNewPayment_Click(object sender, RoutedEventArgs e)
        {
            if (dgAppointments.SelectedItems.Count == 1)
            {
                DataRowView selectedRow = (DataRowView)dgAppointments.SelectedItems[0];
                PaymentLogic.getInstance().changeProperties(Convert.ToInt32(selectedRow["Id"]), true);

                if (dgMainData.SelectedItems.Count == 1)
                {
                    DataRowView selectedStudentRow = (DataRowView)dgMainData.SelectedItems[0];
                    dgAppointments.DataContext = PaymentLogic.getInstance().getByStudent(Convert.ToInt32(row["Id"]));
                    row = (DataRowView)dgMainData.SelectedItems[0];
                    choosenCourseNr = Convert.ToInt32(row["Id"]);
                    lblStudentName.Content = "Saldo von " + row["Forename"] + " " + row["Surname"] + ":";
                    lblStudentHasToPay.Content = PaymentLogic.getInstance().getStudentBalance(choosenCourseNr).ToString();
                }
            }
            changeColumnTitles();
        }


        private void rbnButtonUnbookPayment_Click(object sender, RoutedEventArgs e)
        {

            if (dgAppointments.SelectedItems.Count == 1)
            {
                DataRowView selectedRow = (DataRowView)dgAppointments.SelectedItems[0];
                PaymentLogic.getInstance().changeProperties(Convert.ToInt32(selectedRow["Id"]), false);

                if (dgMainData.SelectedItems.Count == 1)
                {
                    DataRowView selectedStudentRow = (DataRowView)dgMainData.SelectedItems[0];
                    dgAppointments.DataContext = PaymentLogic.getInstance().getByStudent(Convert.ToInt32(row["Id"]));
                    row = (DataRowView)dgMainData.SelectedItems[0];
                    choosenCourseNr = Convert.ToInt32(row["Id"]);
                    lblStudentName.Content = "Saldo von " + row["Forename"] + " " + row["Surname"] + ":";
                    lblStudentHasToPay.Content = PaymentLogic.getInstance().getStudentBalance(choosenCourseNr).ToString();
                }
            }
            changeColumnTitles();
        }

        #endregion

        private void ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (this.IsLoaded)
            {
                switch (mainRibbon.SelectedIndex)
                {
                    case 0:
                        this.lblStudentHasToPay.Content = "";
                        this.lblStudentName.Content = "";
                        refreshCourses();
                        refreshAppointments();
                        break;
                    case 1:
                        this.lblStudentHasToPay.Content = "";
                        this.lblStudentName.Content = "";
                        refreshPersons();
                        break;
                    case 2:
                        this.lblStudentHasToPay.Content = "";
                        this.lblStudentName.Content = "";
                        refreshRooms();
                        break;
                    case 3:
                        refreshPayments();
                        break;
                    default:
                        dgMainData.DataContext = null;
                        break;
                }
                dgMainData.Columns[dgMainData.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }


        #endregion

        #region refresh methods binding the data to the grids and setting the options for them

        private void refreshCourses()
        {
            this.dgMainData.DataContext = CourseLogic.getInstance().getAll();
            changeColumnTitles();
            dgMainData.Columns[8].Header = "Teilnehmer";
            //2write a better version
            lblHeadline.Content = "Kursübersicht";
            dgMainData.Columns[3].Visibility = Visibility.Hidden;
            spAppointments.Height = spAppointmentsHeight;
        
            lblAppointmentToCourse.Content = "Buchungen";
            dgMainData.Height = dgAppointments.Height = dataGridHeight;

        }


        private void refreshPersons()
        {
            dgMainData.DataContext = PersonLogic.getInstance().getAll();
            dgAppointments.DataContext = CourseLogic.getInstance().getAll();
            changeColumnTitles();
            lblHeadline.Content = "Personenübersicht";
            cbValues.Items.Clear();
            cbValues.Items.Add(new RibbonGalleryItem() { Content = "Alle Personen", Foreground = Brushes.Blue });
            cbValues.Items.Add(new RibbonGalleryItem() { Content = "Tutoren", Foreground = Brushes.Green });
            cbValues.Items.Add(new RibbonGalleryItem() { Content = "Studenten", Foreground = Brushes.Red });
            if (ActiveUser.userIsAdmin()) cbValues.Items.Add(new RibbonGalleryItem() { Content = "Benutzer", Foreground = Brushes.Orange });
            spAppointments.Height = 0;
           
            lblAppointmentToCourse.Content = "Gebuchte Kurse";

            dgMainData.Height = dgAppointments.Height = dataGridHeight + 55;
        }


        private void refreshRooms()
        {
            dgMainData.DataContext = RoomLogic.getInstance().getAll();
            changeColumnTitles();
            lblHeadline.Content = "Raumübersicht";
            spAppointments.Height = 0;
            dgMainData.Height = dgAppointments.Height = dataGridHeight + 55;
        }


        private void refreshPayments()
        {
            DataTable table = CourseLogic.getInstance().getAll();
            dgMainData.DataContext = table;
            dgAppointments.DataContext = PaymentLogic.getInstance().getAll();
            changeColumnTitles();
            lblHeadline.Content = "Zahlungsübersicht";
            spAppointments.Height = 0;
            cbPaymentGroupsValues.Items.Clear();
            cbPaymentGroupsValues.Items.Add(new RibbonGalleryItem() { Content = "Kurse", Foreground = Brushes.Blue });
            cbPaymentGroupsValues.Items.Add(new RibbonGalleryItem() { Content = "Studenten", Foreground = Brushes.Green });
            dgMainData.Height = dgAppointments.Height = dataGridHeight + 55;
        }


        private void refreshAppointments()
        {
            DataTable allAppointments = null;
            allAppointments = AppointmentLogic.getInstance().getAll();
            dgAppointments.DataContext = allAppointments;

            changeColumnTitles();

            //ID der Appointments ausgeblendet
            if (dgAppointments.Columns[0].Header.ToString() == "Id")
            {
                dgAppointments.Columns[0].Visibility = Visibility.Hidden;
            }
            else
            {
                dgAppointments.Columns[0].Visibility = Visibility.Visible;
            }
        }


        /// <summary>
        /// Runs every refreshDatagrid
        /// Should't be needed anymore
        /// </summary>
        /// <param name=""></param>
        private void refreshDataGrids()
        {
            if (this.IsLoaded)
            {
                refreshCourses();
            }
        }

        #endregion

        

        
        /// <summary>
        /// 
        ///  
        ///
        /// 
        /// </summary>
        private void changeColumnTitles()
        {
            string[,] englishGerman = new string[,] 
            {
                {"Id","Id"},{"IsPaid","Bezahlt"},{"Student","Student"},{"Course","Kurs-Nr."},{"CourseNr","Kurs-Nr."},{"Title","Titel"},
                {"AmountInEuro","Betrag in €"},{"Description","Beschreibung"},{"MaxMember","max. Teilnehmer"},{"MinMember","min. Teilnehmer"},
                {"ValidityInMonth","Gültigkeit (Monate)"},{"Tutor","Tutor"},{"Payments","Zahlungen"},{"Appointments","Termine"},
                {"RoomNr","RaumNr"},{"Capacity","Kapazität"},{"Building","Gebäude"},{"Street","Straße"},{"City","Stadt"},{"CityCode","PLZ"},
                {"StartDate","StartDatum"},{"EndDate","EndDatum"},{"Room","Raum"},{"Surname","Nachname"},{"Forename","Vorname"},
                {"Birthyear","Geburtsjahr"},{"MobilePhone","HandyNummer"},{"Mail","Mail"},{"Fax","Fax"},{"PrivatePhone","Telefon"},{"Gender","Geschlecht"},
                {"Active","Aktiv"},{"IBAN","IBAN"},{"BIC","BIC"},{"Depositor","Kontoinhaber"},{"NameOfBank","Bank"},{"UserName","Benutzername"},
                {"Password","Passwort"},{"LastLogin","LetztesLogin"},{"RegistrationDate","Registrierungsdatum"},  {"Admin","Admin"}, {"Courses","Kurse"},
                {"StudentName","StudentenName"}, {"CourseName","Kursbezeichnung"}
            };
           
            for(int i = 0; i<dgAppointments.Columns.Count;i++)
            {
                for (int j = 0; j < englishGerman.GetLength(0); j++)
                {
                    if (dgAppointments.Columns[i].Header.ToString() == englishGerman[j, 0]) dgAppointments.Columns[i].Header = englishGerman[j, 1];
                }
            }
            for (int i = 0; i < dgMainData.Columns.Count; i++)
            {
                for (int j = 0; j < englishGerman.GetLength(0); j++)
                {
                    if (dgMainData.Columns[i].Header.ToString() == englishGerman[j, 0]) dgMainData.Columns[i].Header = englishGerman[j, 1];
                }
            }
                
            }



        private void row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Only in Course tab there should appear the window to add a participant
            if (mainRibbon.SelectedIndex == 0)
            {
                openWindow2AddParticpant();
            }
        }


        #region help function
        private void ribbonButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            openHelp();
        }


        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                openHelp();
            }
        }

        private void ribbonHelpButton_Click(object sender, RoutedEventArgs e)
        {
            openHelp();
        }

        private void openHelp()
        {
            try
            {
                this.mainRibbon.SelectedIndex = 0;

                System.Diagnostics.Process.Start("..\\..\\Help_Kursverwaltung.chm");
            }
            catch (System.Exception err)
            {
                System.Windows.MessageBox.Show(err.ToString());
            }
        }

        #endregion



        #region methods and events of lower datagrid (Appointments)

        private void btnAllAppointments_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (mainRibbon.SelectedIndex)
                {
                    case 0:
                        dgAppointments.DataContext = AppointmentLogic.getInstance().getAll();
                        dgAppointments.Columns[0].Visibility = Visibility.Hidden;
                        lblSettingAppointmentToCourse.Content = "Termin buchen";
                        lblAppointmentToCourse.Content = "Buchungen";
                        //if not deselecting the top grid, there will be a course marked but all appointments are shown
                        dgMainData.SelectedIndex = -1;
                        break;
                    case 1:
                        dgAppointments.DataContext = CourseLogic.getInstance().getAll();
                        break;
                }
                changeColumnTitles();
            }
            catch
            {
                MessageBox.Show("Verbindungs- oder Datenbankfehler");
            }
        }

        private void deleteAppointment()
        {
            if (dgAppointments.SelectedItems.Count == 1&&lastfocusedDG==dgAppointments)
            {
            try
            {
                DataRowView selectedRow = (DataRowView)dgAppointments.SelectedItems[0];
                AppointmentLogic.getInstance().delete(Convert.ToInt32(selectedRow["Id"]));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            refreshAppointments();
            }
        }

        /// <summary>
        /// takes a startdate, enddate, roomNr from the booking controls and the course selected in the upper data grid.
        /// trys to book a appointment with it and shows error labels if needed data is missing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            int chosenCourseID = 0;
            DateTime chosenStartDate = DateTime.MinValue;
            DateTime chosenEndDate = DateTime.MinValue;
            int chosenRoomNr = 0;
            
            
            if (dgMainData.SelectedItems.Count == 1)
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
                lblInfo.Content = "Bitten oben erst einen Kurs auswählen";
                lblInfo.Visibility = Visibility.Visible;
            }

            
            if (this.dpBeginOfCourse.Text != null)
            {
                chosenStartDate = (DateTime)this.dpBeginOfCourse.Value.Value;
                lblBeginnDateNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblBeginnDateNotFilled.Visibility = Visibility.Visible;
            }


            
            if(dpEndOfAppointCourse.Text != null)
            {
                chosenEndDate = (DateTime)dpEndOfAppointCourse.Value.Value;
                lblEndDateNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblEndDateNotFilled.Visibility = Visibility.Visible;
            }

            
            if (this.cbxAppointmentRoomNumber.SelectedItem != null)
            {
                
                chosenRoomNr = Convert.ToInt32(((ComboBoxItem)cbxAppointmentRoomNumber.SelectedItem).Content);
                lblRoomNrNotFilled.Visibility = Visibility.Hidden;
            }
            else
            {
                lblRoomNrNotFilled.Visibility = Visibility.Visible;
            }

            if (dgMainData.SelectedItems.Count > 0
                && dpBeginOfCourse.Value.Value != null 
                && dpEndOfAppointCourse.Value.Value != null 
                && cbxAppointmentRoomNumber.SelectedItem != null
                && (DateTime)dpBeginOfCourse.Value.Value < (DateTime)dpEndOfAppointCourse.Value.Value)
            {
                if (AppointmentLogic.getInstance().isPossibleNewAppointment(chosenCourseID, chosenRoomNr, chosenStartDate, chosenEndDate))
                {
                    AppointmentLogic.getInstance().create(chosenCourseID, chosenRoomNr, chosenStartDate, chosenEndDate);
                    lblInfo.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblInfo.Visibility = Visibility.Visible;
                    lblInfo.Content = "Termin nicht möglich";  
                }

                dgAppointments.DataContext = AppointmentLogic.getInstance().getByCourse(choosenCourseNr);

                //hiding the error labels again
                lblBeginnDateNotFilled.Visibility = Visibility.Hidden;
                lblEndDateNotFilled.Visibility = Visibility.Hidden;
                lblRoomNrNotFilled.Visibility = Visibility.Hidden;
                refreshAppointments();
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

        #endregion


        #region search function and helper/formating clases


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSearch_Changed(object sender, TextChangedEventArgs e)
        {

            switch (mainRibbon.SelectedIndex)
            {
                case 0:
                    dgMainData.DataContext = CourseLogic.getInstance().search(tbSearch.Text);
                    break;
                case 1:
                    switch (this.cbxPersons.Text)
                    {
                        case "Alle Personen":
                            this.dgMainData.DataContext = PersonLogic.getInstance().search(tbSearch.Text);
                            break;
                        case "Tutoren":
                            this.dgMainData.DataContext = TutorLogic.getInstance().search(tbSearch.Text);
                            break;
                        case "Studenten":
                            this.dgMainData.DataContext = StudentLogic.getInstance().search(tbSearch.Text);
                            break;
                        case "Benutzer":
                            this.dgMainData.DataContext = UserLogic.getInstance().search(tbSearch.Text);
                            break;
                    }
                    break;
                case 2:
                    dgMainData.DataContext = RoomLogic.getInstance().search(tbSearch.Text);
                    break;
                case 3:
                    dgMainData.DataContext = StudentLogic.getInstance().search(tbSearch.Text);
                    break;
                default:
                    dgMainData.DataContext = null;
                    break;
            }
            changeColumnTitles(); 
        }

        
                    

        

        

        

        /// <summary>
        /// formatting the datagrids
        /// Each Grid has to have a certain % of height of the Window, no matter how big or small it gets through user input
        /// realised as simple as it could be
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            dgMainData.Height = this.Height / 4.5;
            dgAppointments.Height = this.Height / 4.5;
        }


        private void pgValue_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Mouse.Capture(cbxPaymentGroups);                                            //workaround for buggy combobox-selection in windows-ribbon.
            if (cbxPaymentGroups.Text == "Studenten")
            {
                this.rbnButtonNewPayment.IsEnabled = true;
                this.rbnButtonUnbookPayment.IsEnabled = true;
                dgMainData.DataContext = StudentLogic.getInstance().getAll();
            }
            if (cbxPaymentGroups.Text == "Kurse")
            {
                this.rbnButtonNewPayment.IsEnabled = false;
                this.rbnButtonUnbookPayment.IsEnabled = false;
                dgMainData.DataContext = CourseLogic.getInstance().getAll();
            }
            Mouse.Capture(null);                                                         //workaround for buggy combobox-selection in windows-ribbon.
        }

        /// <summary>
        /// buttons should allways have the same size, no matter how big/small the window gets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAppointment_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            btnAllAppointments.Width = btnAddAppointment.ActualWidth;
        }

      
        private void dg_Selected(object sender, RoutedEventArgs e)
        {
            lastfocusedDG = (DataGrid)sender;
        }

        #endregion

        

   

        

        

        

        

        

        

   
    }
}
