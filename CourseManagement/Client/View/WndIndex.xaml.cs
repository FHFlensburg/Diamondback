﻿using CourseManagement.Client.BusinessLogic;
using Microsoft.Win32;
using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndIndex.xaml
    /// </summary>
    public partial class WndIndex : RibbonWindow
    {
        private DataRowView row;
        private int chosenCourseNr;
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
           dataGridHeight = dgSecondary.Height;
        }

        /// <summary>
        /// Event is triggered if window is loaded
        /// Fills datagrids and person combobox with data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_IsLoaded(object sender, System.EventArgs e)
        {
            try
            {
                if (!dgMainData.HasItems)
                {
                    refreshCourses();
                    refreshAppointments();
                    fillComboBoxRoomNumber();

                    cbValues.Items.Clear();
                    cbValues.Items.Add(new RibbonGalleryItem() { Content = "Studenten", Foreground = Brushes.Red });
                    cbValues.Items.Add(new RibbonGalleryItem() { Content = "Tutoren", Foreground = Brushes.Green });
                    if (ActiveUser.userIsAdmin()) cbValues.Items.Add(new RibbonGalleryItem() { Content = "Benutzer", Foreground = Brushes.Orange });
                    cbValues.Items.Add(new RibbonGalleryItem() { Content = "Alle Personen", Foreground = Brushes.Blue });
   
                }
                dgMainData.Columns[dgMainData.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            catch (Exception err)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// Closes main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region Office Ribbon Button pressed Eevents

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
                            if (cbCourse.Text == "Termine")
                            {
                           
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            chosenCourseNr = Convert.ToInt32(row["CourseNr"]);
                            SpecificTables.changeDgAppointment(dgSecondary, AppointmentLogic.getInstance().getByCourse(chosenCourseNr));
                            string text = "Termin zu Kurs " + chosenCourseNr.ToString() + " buchen";
                            lblSettingAppointmentToCourse.Content = text;
                            text = "Buchungen zu Kurs " + chosenCourseNr.ToString();
                            lblAppointmentToCourse.Content = text;
                            }
                            else if (cbCourse.Text == "Teilnehmer")
                            {
                                int auswahl = Convert.ToInt16(((DataRowView)dgMainData.SelectedItems[0])["CourseNr"]);
                                SpecificTables.changeDgStudent(dgSecondary, StudentLogic.getInstance().getByCourse(auswahl));
                                lblAppointmentToCourse.Content = "Teilnehmer zu Kurs " + auswahl ;
                            }

                            break;
                        case 1:
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            chosenCourseNr = Convert.ToInt32(row["Id"]);
                            if (cbxPersons.Text == "Tutoren")
                            {
                                SpecificTables.changeDgCourse(dgSecondary,CourseLogic.getInstance().getByTutor(chosenCourseNr));
                  
                            }
                            if (cbxPersons.Text == "Studenten")
                            {
                                SpecificTables.changeDgCourse(dgSecondary, CourseLogic.getInstance().getByStudent(chosenCourseNr));

                            }
                            if (cbxPersons.SelectionBoxItem.ToString() == "Alle Personen"
                                || cbxPersons.Text == "Benutzer")
                            {
                                SpecificTables.changeDgCourse(dgSecondary, CourseLogic.getInstance().getByPerson(chosenCourseNr));

                            }
                            break;
                        case 2:
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            chosenCourseNr = Convert.ToInt32(row["RoomNr"]);
                            SpecificTables.changeDgAppointment(dgSecondary, AppointmentLogic.getInstance().getByRoom(chosenCourseNr));
                            break;
                        case 3:
                            if (cbxPaymentGroups.Text == "Studenten")
                            {
                                this.lblHeadline.Content = "Studenten";
                                row = (DataRowView)dgMainData.SelectedItems[0];
                                chosenCourseNr = Convert.ToInt32(row["Id"]);
                                SpecificTables.changeDgPayment(dgSecondary, PaymentLogic.getInstance().getByStudent(chosenCourseNr));
                                getStudentBalance(row);
                            }
                            if (cbxPaymentGroups.Text == "Kurse")
                            {
                                this.lblHeadline.Content = "Kurse";
                                row = (DataRowView)dgMainData.SelectedItems[0];
                                chosenCourseNr = Convert.ToInt32(row["CourseNr"]);
                                SpecificTables.changeDgPayment(dgSecondary, PaymentLogic.getInstance().getByCourse(chosenCourseNr));
                                getCourseBalance(row);
                            }
                            break;
                        default:
                            dgMainData.DataContext = null;
                            break;

                    }
                    
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
                }
            }
            else
            {
                lblSettingAppointmentToCourse.Content = "Termin buchen";
            }
        }

        /// <summary>
        /// Opens window to creat a new course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonNewCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WndCourse aNewCourse = new WndCourse();
                aNewCourse.ShowDialog();
                refreshCourses();
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// Opens window to add a participant to a course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            openWindow2AddParticpant();
        }

        /// <summary>
        /// Initialize the window to add a person to course
        /// </summary>
        private void openWindow2AddParticpant()
        {
            WndParticipant2Course aNewAllocation = null;

                if (dgMainData.SelectedItems.Count > 0)
                {
                    aNewAllocation = new WndParticipant2Course(chosenCourseNr);
                }
                else
                {
                    aNewAllocation = new WndParticipant2Course();
                }
                aNewAllocation.ShowDialog();
        }

        /// <summary>
        /// Event that opens window to add participant to course when there is a double click in the course tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Only in Course tab there should appear the window to add a participant
            if (mainRibbon.SelectedIndex == 0)
            {
                openWindow2AddParticpant();
            }
        }

        /// <summary>
        /// Opens window to change selected course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonEditCourse_Click(object sender, RoutedEventArgs e)
        {
            if (dgMainData.SelectedIndex != -1)
            {

                try
                {
                    DataRowView selectedCourseRow = (DataRowView)dgMainData.SelectedItems[0];
                    int selectedIndex = Convert.ToInt32((selectedCourseRow["CourseNr"]));
                    DataTable selectedCourse = CourseLogic.getInstance().getById(selectedIndex);
                    WndCourse editCourse = new WndCourse(selectedCourse);
                    editCourse.ShowDialog();
                    refreshCourses();
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
                }
            }
        }

        /// <summary>
        /// Deletes selected course or appointment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgMainData.SelectedIndex != -1 && lastfocusedDG == dgMainData)
                {

                    DataRowView selectedCourseRow = (DataRowView)dgMainData.SelectedItems[0];
                    int selectedIndex = Convert.ToInt32((selectedCourseRow["CourseNr"]));
                    CourseLogic.getInstance().delete(selectedIndex);
                    refreshCourses();
                }
                else
                {
                    if (dgSecondary.SelectedIndex != -1 && cbCourse.Text == "Termine")
                    {
                        deleteAppointment();
                    }
                    else if (dgSecondary.SelectedIndex != -1 && dgMainData.SelectedIndex != -1 && cbCourse.Text == "Teilnehmer")
                    {
                        int index = dgMainData.SelectedIndex;
                        int person = Convert.ToInt16(((DataRowView)dgSecondary.SelectedItem)["Id"]);
                        int course = Convert.ToInt16(((DataRowView)dgMainData.SelectedItem)["CourseNr"]);
                        PaymentLogic.getInstance().delete(course, person);
                        SpecificTables.changeDgCourse(dgMainData, CourseLogic.getInstance().getAll());
                        dgMainData.SelectedIndex = index;
                        SpecificTables.changeDgStudent(dgSecondary, StudentLogic.getInstance().getByCourse(course));
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }
        #endregion

        #region Office Ribbon Person Tab

        /// <summary>
        /// Pens window to create a new person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonNewPerson_Click(object sender, RoutedEventArgs e)
        {
            wndPerson aNewPerson = new wndPerson();
            aNewPerson.ShowDialog();
        }

        /// <summary>
        /// Fills the Person DataGrid with the selected PersonGroup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonGallery_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                Mouse.Capture(cbxPersons);                                          //workaround for buggy combobox-selection in windows-ribbon.
                switch (this.cbxPersons.Text)
                {
                    case "Alle Personen":
                        SpecificTables.changeDgPerson(dgMainData, PersonLogic.getInstance().getAll());
                        break;
                    case "Tutoren":
                        SpecificTables.changeDgTutor(dgMainData, TutorLogic.getInstance().getAll());
                        break;
                    case "Studenten":
                        SpecificTables.changeDgStudent(dgMainData, StudentLogic.getInstance().getAll());
                        break;
                    case "Benutzer":
                        SpecificTables.changeDgUser(dgMainData, UserLogic.getInstance().getAll());
                        break;

                }
                Mouse.Capture(null);                                                //workaround for buggy combobox-selection in windows-ribbon.
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// Deletes selected Person or Course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSecondary.SelectedItems.Count == 1 && dgMainData.SelectedItems.Count == 1 && lastfocusedDG == dgSecondary)
                {
                    int courseNr = Convert.ToInt32(((DataRowView)dgSecondary.SelectedItem)["CourseNr"]);
                    int studentNr = Convert.ToInt32(((DataRowView)dgMainData.SelectedItem)["Id"]);
                    PaymentLogic.getInstance().delete(courseNr, studentNr);
                    SpecificTables.changeDgCourse(dgSecondary, CourseLogic.getInstance().getByPerson(studentNr));
                }

                else if (dgMainData.SelectedIndex != -1 && lastfocusedDG == dgMainData)
                {
                    int id = Convert.ToInt32(((DataRowView)dgMainData.SelectedItem)["Id"]);
                    PersonLogic.getInstance().delete(id);
                    ribbonGallery_SelectionChanged(null, null);
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }

        }

        /// <summary>
        /// Opens window to edit a person
        /// It differs which kind of person is selected. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonEditPerson_Click(object sender, RoutedEventArgs e)
        {
            int personID = -1;
            DataTable selectedPerson = null;
            int kindOfPerson = 0;
            try
            {
                if (dgMainData.SelectedIndex != -1)
                {

                    if (this.IsLoaded)
                    {
                        DataRowView selectedPersonRow = (DataRowView)dgMainData.SelectedItems[0];
                        personID = Convert.ToInt32(selectedPersonRow["Id"]);

                        if (PersonLogic.getInstance().isStudent(personID))
                        {
                            selectedPerson = StudentLogic.getInstance().getById(personID);
                            kindOfPerson = 1;
                        }
                        else
                        {
                            if (PersonLogic.getInstance().isUser(personID))
                            {
                                selectedPerson = UserLogic.getInstance().getById(personID);
                                kindOfPerson = 2;
                            }
                            else
                            {
                                if (PersonLogic.getInstance().isTutor(personID))
                                {
                                    selectedPerson = TutorLogic.getInstance().getById(personID);
                                    kindOfPerson = 3;
                                }
                                else { MessageBox.Show("Error: Keine gültige Person"); }
                            }
                        }
                        wndPerson editPerson = new wndPerson(selectedPerson, kindOfPerson);
                        editPerson.ShowDialog();
                        refreshPersons();
                        SpecificTables.changeDgCourse(dgSecondary, CourseLogic.getInstance().getByPerson(personID));
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        #endregion

        #region Office Ribbon Room tab

        /// <summary>
        /// Opens window to create a new room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonNewRoom_Click(object sender, RoutedEventArgs e)
        {
            WndRoom aNewRoom = new WndRoom();
            aNewRoom.lblNewRoom.Content = "Neuer Raum";
            aNewRoom.ShowDialog();
        }

        /// <summary>
        /// Deletes selected room or appointment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgMainData.SelectedItems.Count == 1)
                {
                    DataRowView selectedRoomRow = (DataRowView)dgMainData.SelectedItems[0];
                    RoomLogic.getInstance().delete(Convert.ToInt32(selectedRoomRow["roomNr"]));
                    refreshRooms();
                }
                if (dgSecondary.SelectedIndex != -1)
                {
                    deleteAppointment();
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// Opens window to edit selected room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonEditRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgMainData.SelectedIndex != -1)
                {
                    DataRowView selectedRoomRow = (DataRowView)dgMainData.SelectedItems[0];
                    int selectedIndex = Convert.ToInt32((selectedRoomRow["roomNr"]));
                    DataTable selectedRoom = RoomLogic.getInstance().getById(selectedIndex);
                    WndRoom editCourse = new WndRoom(selectedRoom);
                    editCourse.ShowDialog();
                }
                refreshRooms();
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        #endregion

        #region Office Ribbon payment tab

        /// <summary>
        /// Writes the Student Name and the Balance to a label in the payment view
        /// </summary>
        /// <param name="row"></param>
        public void getStudentBalance(DataRowView row)
        {
            lblStudentName.Content = "Saldo von " + row["Forename"] + " " + row["Surname"] + ":";
            lblStudentHasToPay.Content = PaymentLogic.getInstance().getStudentBalance(chosenCourseNr).ToString();
        }

        /// <summary>
        /// Writes the Course Balance to a label in the payment view
        /// </summary>
        /// <param name="row"></param>
        public void getCourseBalance(DataRowView row)
        {
            lblStudentName.Content = "Forderungen: " + CourseLogic.getInstance().getOverAllAmount(chosenCourseNr).ToString();
            lblStudentHasToPay.Content = "Noch zu zahlen: " + CourseLogic.getInstance().getBalance(chosenCourseNr).ToString();
        }

        /// <summary>
        /// Creates a new Payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonNewPayment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.lblHeadline.Content = "Kurse";
                this.lblAppointmentToCourse.Content = "Zahlungen";
                if (dgSecondary.SelectedItems.Count == 1)
                {
                    DataRowView selectedRow = (DataRowView)dgSecondary.SelectedItems[0];
                    PaymentLogic.getInstance().changeProperties(Convert.ToInt32(selectedRow["Id"]), true);

                    if (dgMainData.SelectedItems.Count == 1)
                    {
                        if (cbxPaymentGroups.Text == "Studenten")
                        {
                            DataRowView selectedStudentRow = (DataRowView)dgMainData.SelectedItems[0];
                            SpecificTables.changeDgPayment(dgSecondary, PaymentLogic.getInstance().getByStudent(Convert.ToInt32(row["Id"])));
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            chosenCourseNr = Convert.ToInt32(row["Id"]);
                            getStudentBalance(row);
                        }
                        else
                        {
                            DataRowView selectedStudentRow = (DataRowView)dgMainData.SelectedItems[0];
                            SpecificTables.changeDgPayment(dgSecondary, PaymentLogic.getInstance().getByCourse(Convert.ToInt32(row["CourseNr"])));
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            chosenCourseNr = Convert.ToInt32(row["CourseNr"]);
                            getCourseBalance(row);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// Deletes payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnButtonUnbookPayment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSecondary.SelectedItems.Count == 1)
                {
                    DataRowView selectedRow = (DataRowView)dgSecondary.SelectedItems[0];
                    PaymentLogic.getInstance().changeProperties(Convert.ToInt32(selectedRow["Id"]), false);

                    if (dgMainData.SelectedItems.Count == 1)
                    {
                        if (cbxPaymentGroups.Text == "Studenten")
                        {
                            DataRowView selectedStudentRow = (DataRowView)dgMainData.SelectedItems[0];
                            SpecificTables.changeDgPayment(dgSecondary, PaymentLogic.getInstance().getByStudent(Convert.ToInt32(row["Id"])));
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            chosenCourseNr = Convert.ToInt32(row["Id"]);
                            getStudentBalance(row);
                        }
                        else
                        {
                            DataRowView selectedStudentRow = (DataRowView)dgMainData.SelectedItems[0];
                            SpecificTables.changeDgPayment(dgSecondary, PaymentLogic.getInstance().getByCourse(Convert.ToInt32(row["CourseNr"])));
                            row = (DataRowView)dgMainData.SelectedItems[0];
                            chosenCourseNr = Convert.ToInt32(row["CourseNr"]);
                            getCourseBalance(row);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        #endregion

        /// <summary>
        /// Event that is triggered when tab on the top are changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.IsLoaded)
                {
                    switch (mainRibbon.SelectedIndex)
                    {
                        case 0:
                            this.lblStudentHasToPay.Content = "";
                            this.lblStudentName.Content = "";
                            rgCourse.SelectedValue = "Termine";
                            refreshCourses();
                            refreshAppointments();
                            
                            break;
                        case 1:
                            this.lblStudentHasToPay.Content = "";
                            this.lblStudentName.Content = "";
                            rgValue.SelectedValue = "Studenten";
                            refreshPersons();
                            
                            break;
                        case 2:
                            this.lblStudentHasToPay.Content = "";
                            this.lblStudentName.Content = "";
                            refreshRooms();
                            break;
                        case 3:
                            pgValue.SelectedValue = "Kurse";
                            refreshPayments();
                            
                            break;
                        default:
                            dgMainData.DataContext = null;
                            break;
                    } 
                }
            }

            catch (Exception err)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }


        #endregion

        #region refresh methods binding the data to the grids and setting the options for them

        /// <summary>
        /// Fills top datagrid with courses and sets the headlines
        /// </summary>
        private void refreshCourses()
        {
            try
            {
                SpecificTables.changeDgCourse(dgMainData, CourseLogic.getInstance().getAll());
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

            lblHeadline.Content = "Kursübersicht";
            spAppointments.Height = spAppointmentsHeight;
        
            lblAppointmentToCourse.Content = "Termine";
            dgMainData.Height = dgSecondary.Height = dataGridHeight;

        }

        /// <summary>
        /// Fills top datagrid with selected type of persons and sets the headlines
        /// </summary>
        private void refreshPersons()
        {
            try
            {
                switch (rgValue.SelectedValue.ToString())
                {
                    case "Studenten":
                        SpecificTables.changeDgStudent(dgMainData, StudentLogic.getInstance().getAll());
                        break;
                    case "Benutzer":
                        SpecificTables.changeDgUser(dgMainData, UserLogic.getInstance().getAll());
                        break;
                    case "Tutoren":
                        SpecificTables.changeDgTutor(dgMainData, TutorLogic.getInstance().getAll());
                        break;
                    case "Alle Personen":
                        SpecificTables.changeDgPerson(dgMainData, PersonLogic.getInstance().getAll());
                        break;
                }

                SpecificTables.changeDgCourse(dgSecondary, CourseLogic.getInstance().getAll());
                lblHeadline.Content = "Personenübersicht";

                spAppointments.Height = 0;

                lblAppointmentToCourse.Content = "Gebuchte Kurse";

                dgMainData.Height = dgSecondary.Height = dataGridHeight + 55;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// Fills top datagrid with rooms and sets the headlines
        /// </summary>
        private void refreshRooms()
        {
            try
            {
                SpecificTables.changeDgRoom(dgMainData, RoomLogic.getInstance().getAll());
                lblHeadline.Content = "Raumübersicht";
                spAppointments.Height = 0;
                dgMainData.Height = dgSecondary.Height = dataGridHeight + 55;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// Fills top datagrid with payments and sets the headlines
        /// </summary>
        private void refreshPayments()
        {
            try
            {
                if (cbxPaymentGroups.Text == "Kurse")
                {
                    this.lblHeadline.Content = "Kursübersicht";
                }
                else
                    this.lblHeadline.Content = "Studentenübersicht";
                this.lblAppointmentToCourse.Content = "Zahlungen";
                SpecificTables.changeDgCourse(dgMainData, CourseLogic.getInstance().getAll());
                SpecificTables.changeDgPayment(dgSecondary, PaymentLogic.getInstance().getAll());
                spAppointments.Height = 0;
                
                dgMainData.Height = dgSecondary.Height = dataGridHeight + 55;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// Fills the second datagrid with appointments
        /// </summary>
        private void refreshAppointments()
        {
            try
            {
                SpecificTables.changeDgAppointment(dgSecondary, AppointmentLogic.getInstance().getAll());
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        #endregion

        


        #region help function

        /// <summary>
        /// Runs method that opens help file when button in the application menu is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            openHelp();
        }

        /// <summary>
        /// If user presses f1 button the help will open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                openHelp();
            }
        }

        /// <summary>
        /// Opens when help button in the upper right corner is pressed
        /// Runs method which opens the help file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonHelpButton_Click(object sender, RoutedEventArgs e)
        {
            openHelp();
        }

        /// <summary>
        /// Opens the help file which is located on the pc. 
        /// </summary>
        /// <comment>
        /// Reads registry entry so this is only available if software is installed with setup. Trying to open help file
        /// from visual studio will crash software
        /// </comment>
        private void openHelp()
        {
            try
            {
                this.mainRibbon.SelectedIndex = 0;
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\App Paths\CourseManagement");
                object objRegisteredValue = key.GetValue("Path");
                Process openHelpFile = new Process();
                openHelpFile.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                openHelpFile.StartInfo.FileName = "hh.exe";
                openHelpFile.StartInfo.Arguments = "ms-its:" + objRegisteredValue.ToString() + @"\Help_Kursverwaltung.chm::/Kurse.htm";
                openHelpFile.Start();
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        #endregion



        #region methods and events of lower datagrid (Appointments)

        /// <summary>
        /// resets the filter of appointments so that all are shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllAppointments_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (mainRibbon.SelectedIndex)
                {
                    case 0:
                        if (cbCourse.Text == "Termine")
                        {
                            SpecificTables.changeDgAppointment(dgSecondary, AppointmentLogic.getInstance().getAll());
                            lblAppointmentToCourse.Content = "Termine";
                        }
                        else if (cbCourse.Text == "Teilnehmer")
                        {
                            SpecificTables.changeDgStudent(dgSecondary, StudentLogic.getInstance().getAll());
                            lblAppointmentToCourse.Content="Teilnehmer";
                        }
                        
                        //if not deselecting the top grid, there will be a course marked but all appointments are shown
                        dgMainData.SelectedIndex = -1;
                        break;
                    case 1:
                        SpecificTables.changeDgCourse(dgSecondary, CourseLogic.getInstance().getAll());
                        break;
                    case 2:
                        SpecificTables.changeDgAppointment(dgSecondary, AppointmentLogic.getInstance().getAll());
                        break;
                    case 3:
                        SpecificTables.changeDgPayment(dgSecondary, PaymentLogic.getInstance().getAll());
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// deletes selected appointment
        /// </summary>
        private void deleteAppointment()
        {
            if (dgSecondary.SelectedItems.Count == 1&&lastfocusedDG==dgSecondary)
            {
            try
            {
                DataRowView selectedRow = (DataRowView)dgSecondary.SelectedItems[0];
                AppointmentLogic.getInstance().delete(Convert.ToInt32(selectedRow["Id"]));
                refreshAppointments();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            
            }
        }

        /// <summary>
        /// takes a startdate, enddate, roomNr from the booking controls and the selected course in the upper maindatagrid.
        /// trys to book a appointment with it and shows error labels if needed data is missing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int chosenCourseID = 0;
                DateTime chosenStartDate = DateTime.MinValue;
                DateTime chosenEndDate = DateTime.MinValue;
                int chosenRoomNr = 0;

                if (dgMainData.SelectedItems.Count == 1)
                {
                    chosenCourseID = chosenCourseNr;
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

                if (dpEndOfAppointCourse.Text != null)
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
                    SpecificTables.changeDgAppointment(dgSecondary, AppointmentLogic.getInstance().getByCourse(chosenCourseNr));
                    //hiding the error labels again
                    lblBeginnDateNotFilled.Visibility = Visibility.Hidden;
                    lblEndDateNotFilled.Visibility = Visibility.Hidden;
                    lblRoomNrNotFilled.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// Fills the combobox where a room has to be selected before a appointment can be created
        /// </summary>
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
            catch (Exception err)
            {
               throw new Exception(err.Message);
            }
        }

        #endregion


        #region search function and helper/formating clases


        /// <summary>
        /// Search function. Looks if submitted text fits data in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSearch_Changed(object sender, TextChangedEventArgs e)
        {
            try
            {
                switch (mainRibbon.SelectedIndex)
                {
                    case 0:
                        SpecificTables.changeDgCourse(dgMainData, CourseLogic.getInstance().search(tbSearch.Text));
                        break;
                    case 1:
                        switch (this.cbxPersons.Text)
                        {
                            case "Alle Personen":
                                SpecificTables.changeDgPerson(dgMainData, PersonLogic.getInstance().search(tbSearch.Text));
                                break;
                            case "Tutoren":
                                SpecificTables.changeDgTutor(dgMainData, TutorLogic.getInstance().search(tbSearch.Text));
                                break;
                            case "Studenten":
                                SpecificTables.changeDgStudent(dgMainData, StudentLogic.getInstance().search(tbSearch.Text));
                                break;
                            case "Benutzer":
                                SpecificTables.changeDgUser(dgMainData, UserLogic.getInstance().search(tbSearch.Text));
                                break;
                        }
                        break;
                    case 2:
                        SpecificTables.changeDgRoom(dgMainData, RoomLogic.getInstance().search(tbSearch.Text));
                        break;
                    case 3:
                        switch(cbxPaymentGroups.Text)
                        {
                            case "Kurse":
                                SpecificTables.changeDgCourse(dgMainData, CourseLogic.getInstance().search(tbSearch.Text));
                                break;
                            case "Studenten":
                                SpecificTables.changeDgStudent(dgMainData, StudentLogic.getInstance().search(tbSearch.Text));
                                break;
                        }
                        break;
                    default:
                        dgMainData.DataContext = null;
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// formatting the datagrids
        /// Each Grid should have a certain hight of of the height of the mainWindow, no matter how big or small it gets through user input
        /// realised as simple as it could be
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            dgMainData.Height = this.Height / 4.5;
            dgSecondary.Height = this.Height / 4.5;
        }

        /// <summary>
        /// Shows selected type of person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pgValue_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                Mouse.Capture(cbxPaymentGroups);                                            //workaround for buggy combobox-selection in windows-ribbon.
                if (cbxPaymentGroups.Text == "Studenten")
                {
                    this.lblHeadline.Content = "Studentenübersicht";
                    SpecificTables.changeDgStudent(dgMainData, StudentLogic.getInstance().getAll());
                }
                if (cbxPaymentGroups.Text == "Kurse")
                {
                    this.lblHeadline.Content = "Kursübersicht";
                    SpecificTables.changeDgCourse(dgMainData, CourseLogic.getInstance().getAll());
                }
                Mouse.Capture(null);                                                         //workaround for buggy combobox-selection in windows-ribbon.
            }
            catch (Exception err)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// Two buttons should have the same size. The add appointment button is sized through
        /// a stretch function so the other button has get the same size if size changed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAppointment_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            btnAllAppointments.Width = btnAddAppointment.ActualWidth;
        }

        /// <summary>
        /// saves last selected datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg_Selected(object sender, RoutedEventArgs e)
        {
            lastfocusedDG = (DataGrid)sender;
        }

        #endregion

        /// <summary>
        /// Changes wether appointments or participants are shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCourse_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                Mouse.Capture(cbCourse);
                if (cbCourse.Text == "Termine")
                {
                    dgMainData.Height = dgSecondary.Height = dataGridHeight;
                    spAppointments.Height = spAppointmentsHeight;
                    if (dgMainData.SelectedItems.Count == 1)
                    {
                        int auswahl = Convert.ToInt16(((DataRowView)dgMainData.SelectedItems[0])["CourseNr"]);
                        SpecificTables.changeDgAppointment(dgSecondary, AppointmentLogic.getInstance().getByCourse(auswahl));
                        lblAppointmentToCourse.Content = "Teilnehmer zu Kurs " + auswahl;
                    }
                    else
                    {
                        SpecificTables.changeDgAppointment(dgSecondary, AppointmentLogic.getInstance().getAll());
                        lblAppointmentToCourse.Content = "Termine";
                    }

                }
                else if (cbCourse.Text == "Teilnehmer")
                {
                    dgMainData.Height = dgSecondary.Height = dataGridHeight + 55;
                    spAppointments.Height = 0;
                    if (dgMainData.SelectedItems.Count == 1)
                    {
                        int auswahl = Convert.ToInt16(((DataRowView)dgMainData.SelectedItems[0])["CourseNr"]);
                        SpecificTables.changeDgStudent(dgSecondary, StudentLogic.getInstance().getByCourse(auswahl));
                        lblAppointmentToCourse.Content = "Teilnehmer zu Kurs " + auswahl;
                    }
                    else
                    {
                        //empty Grid
                        SpecificTables.changeDgStudent(dgSecondary, StudentLogic.getInstance().getAll());
                        lblAppointmentToCourse.Content = "Teilnehmer";
                    }
                }
                Mouse.Capture(null);
            }
            catch (Exception err)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
            }
        }

        /// <summary>
        /// Shows window to change password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changePsw_Click(object sender, RoutedEventArgs e)
        {
            new WndChangePsw().ShowDialog();
        }

        /// <summary>
        /// Shows Information of the creators of this software
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Software Projekt 2013\n\nGruppe Diamondback\n\nMitglieder:\n\tChristoph Süßens\n\tJan Greve\n\tChristian Hapke\n\tJanne Tjark Krüger\n\tAndre Schiemann\n\tSebastian Gorr\n\tStefan Siemsen");
        }
    }
}
