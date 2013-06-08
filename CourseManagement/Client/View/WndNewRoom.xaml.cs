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
        }

        private void insertRoom()
        {
            fillingNonMandatoryDataFields();
            try
            {
                if (selectedRoom == null & roomNr == 0)
                {
                    RoomLogic.getInstance().create(building, capacity, city, cityCode, street);
                    this.DialogResult = true;
                }
                else
                {
                    RoomLogic.getInstance().changeProperties(roomNr, building, capacity, city, cityCode, street);
                    this.DialogResult = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Datenbankfehler. \nException " + e.Message);
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



        /// <summary>
        /// references submitted data from user to variables. 
        /// No mandatory fields, so no check if user input was made
        /// </summary>
        /// <returns></returns>
        private void fillingNonMandatoryDataFields()
        {
            street = tbStreet.Text.ToString();
            city = tbCity.Text.ToString();
            cityCode = tbCityCode.Text.ToString();
            try
            {
                capacity = Convert.ToInt32(tbCapacity.Text);
            }
            catch
            {
                capacity = 0;
            }
        }
    }
}
