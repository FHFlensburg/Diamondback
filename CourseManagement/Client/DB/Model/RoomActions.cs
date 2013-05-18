using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Person Model
    /// </summary>
    public partial class Room
    {
        public void addToDB()
        {
            try
            {
                RoomQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Room> getAll()
        {
            try
            {
                return RoomQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void delete()
        {
            try
            {
                RoomQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void update()
        {
            try
            {
                RoomQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Room getById(int roomId)
        {
            try
            {
                return RoomQuery.getById(roomId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
