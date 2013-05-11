using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    public partial class Room
    {
        public void addToDB()
        {
            RoomQuery.insert(this);
        }

        public static List<Room> getAll()
        {
            return RoomQuery.getAll();
        }

        public void delete()
        {
            RoomQuery.delete(this);
        }

        public void update()
        {
            RoomQuery.update(this);
        }

        public static Room getById(int roomId)
        {
            return RoomQuery.getById(roomId);
        }
    }
}
