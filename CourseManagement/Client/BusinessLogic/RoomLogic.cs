using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.BusinessLogic
{
    class RoomLogic:AbstractLogic
    {
        private RoomLogic() { }

        /// <summary>
        /// Getting an instance of RoomLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static RoomLogic getInstance()
        {
            RoomLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new RoomLogic();
            return temp;
        }

        /// <summary>
        /// Creates a new room by the given parameters
        /// </summary>
        /// <param name="appointment"></param>
        /// <param name="building"></param>
        /// <param name="capacity"></param>
        /// <param name="city"></param>
        /// <param name="cityCode"></param>
        /// <param name="roomNr"></param>
        /// <param name="street"></param>
        public void createRoom(String building, int capacity, String city, String cityCode, int roomNr, String street)
        {
            Room room = new Room();
            room.Building = building;
            room.Capacity = capacity;
            room.City = city;
            room.CityCode = cityCode;
            room.RoomNr = roomNr;
            room.Street = street;

            room.addToDB();
        }

        /// <summary>
        /// Creates a new datatable containing all rooms and returns this datatable
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            DataTable allRooms = LogicUtils.getNewDataTable("RoomNr", "Building", "Capacity", "Street", "City", "CityCode");

            foreach(Room room in Room.getAll())
            {
                allRooms.Rows.Add(room.RoomNr, room.Building, room.Capacity, room.Street, room.City, room.CityCode);
            }

            return allRooms;
        }

        public override DataTable search(string search)
        {
            throw new NotImplementedException();
        }

        public override DataTable getById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
