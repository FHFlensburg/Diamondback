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
        private string postCode = null;
        private string city = null;

        /// <summary>
        /// default constructor for window newRoom
        /// </summary>
        public WndNewRoom()
        {
            InitializeComponent();
            lblNewRoom.Content = "Kurs bearbeiten";
        }

        public WndNewRoom(DataTable selectedRoom)
        {
            InitializeComponent();

            this.selectedRoom = selectedRoom;

            lblNewRoom.Content = "Kurs bearbeiten";

            tbCapacity.Text = selectedRoom.Rows[0]["capacity"].ToString();
        }


        private void btnSaveRoom_Click(object sender, RoutedEventArgs e)
        {
            insertNewRoom();
            this.Close();
        }

        private void ButtonRoomAport_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void insertNewRoom()
        {
            if (validateDataFields())
            {
                try
                {
                    RoomLogic.getInstance().create(building, capacity, city, postCode, street);
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

        #region validate and fill variables with the data from the datafields

        /// <summary>
        /// Calls all validate methods and returns true if all user inputs were made correct
        /// </summary>
        /// <returns></returns>
        public bool validateDataFields()
        {
            bool validate = false;

            if (validateAndFillCapacity()
                & validateAndFillBuilding()
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
        private bool validateAndFillBuilding()
        {
            bool validate = false;
            if(cbBuilding.SelectedIndex != -1)
            {
                building = ((ComboBoxItem)cbBuilding.SelectedItem).Content.ToString();
                lblBuilding.Foreground = Brushes.Black;
                validate = true;
            }
            else
            {
                lblBuilding.Foreground = Brushes.Red;
                validate = false;
            }
            return validate;
        }

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
                postCode = tbPostCode.Text.ToString();
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
