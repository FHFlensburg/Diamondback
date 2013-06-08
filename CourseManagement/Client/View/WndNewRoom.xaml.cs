using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CourseManagement.Client.BusinessLogic;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für newRoom.xaml
    /// </summary>
    public partial class WndNewRoom : Window
    {

        private DataTable selectedRoom = null;
        private int capacity = 0;
        private string building = null;
        private string street = null;
        private string cityCode = null;
        private string city = null;
        private int roomNr = 0;

        /// <summary>
        /// default constructor for window newRoom
        /// </summary>
        public WndNewRoom()
        {
            InitializeComponent();
            lblNewRoom.Content = "Kurs bearbeiten";
        }

        /// <summary>
        /// Custom Constructor beeing called if user wants to change a room
        /// </summary>
        /// <param name="selectedRoom"></param>
        public WndNewRoom(DataTable selectedRoom)
        {
            InitializeComponent();

            this.selectedRoom = selectedRoom;

            setGuiElemntsToselectedCourseData(selectedRoom);
        }

        private void ButtonRoomAport_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveRoom_Click(object sender, RoutedEventArgs e)
        {
            insertRoom();
            this.Close();
        }

        private void insertRoom()
        {
            if (validateDataFields())
            {
                try
                {
                    if (selectedRoom != null && roomNr == 0)
                    {
                        RoomLogic.getInstance().create(building, capacity, city, cityCode, street);
                    }
                    else
                    {
                        RoomLogic.getInstance().changeProperties(roomNr, building, capacity, city, cityCode, street);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Datenbankfehler. \nException " + e.Message);
                }
                lblWrongUserInput.Visibility = Visibility.Hidden;
            }
            else
            {
                lblWrongUserInput.Visibility = Visibility.Visible;
            }
        }

        private void setGuiElemntsToselectedCourseData(DataTable selectedRoom)
        {
            lblNewRoom.Content = "Kurs bearbeiten";

            roomNr = Convert.ToInt32(selectedRoom.Rows[0]["roomNr"]);
            tbCapacity.Text = selectedRoom.Rows[0]["capacity"].ToString();


            tbStreet.Text = selectedRoom.Rows[0]["street"].ToString();
            tbCityCode.Text = selectedRoom.Rows[0]["citycode"].ToString();
            tbCity.Text = selectedRoom.Rows[0]["city"].ToString();
        }

        #region validate and fill variables with the data from the datafields

        /// <summary>
        /// Calls all validate methods and returns true if all user inputs were made correct
        /// </summary>
        /// <returns></returns>
        private bool validateDataFields()
        {
            bool validate = false;

            if (validateAndFillCapacity()
                
                & validateAndFillAdress())
            {
                validate = true;
            }

            return validate;
        }

        /// <summary>
        /// Checks if user has filled the capacity field 
        /// and if he did references the capacity variable with the provided text
        /// </summary>
        /// <returns></returns>
        private bool validateAndFillCapacity()
        {
            bool validate = false;
            try
            {
                capacity = Convert.ToInt32(tbCapacity.Text);
                lblCapacity.Foreground = Brushes.Black;
                validate = true;
            }
            catch
            {
                lblCapacity.Foreground = Brushes.Red;
                validate = false;
            }
            return validate;
        }

        /// <summary>
        /// Checks if user has chosen a Building for the course 
        /// and if he did it references the variable with selected entry
        /// </summary>
        /// <returns></returns>
        

        /// <summary>
        /// Street, Zip Code and City are fields which aren't neccessary to be filled out from the user
        /// no checks if data is provided by user, only referencing the variables
        /// </summary>
        /// <returns></returns>
        private bool validateAndFillAdress()
        {
            bool validate = false;
            try
            {
                street = tbStreet.Text.ToString();
                cityCode = tbCityCode.Text.ToString();
                city = tbCity.Text.ToString();
                validate = true;
            }
            catch
            {
                validate = false;
                MessageBox.Show("Adressfelder sind nicht richtig ausgefüllt");
            }
            return validate;
        }


        #endregion
    }
}
