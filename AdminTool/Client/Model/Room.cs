using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTool.Client.Model
{
    public class Room
    {
        #region Room Contrcutor

        // TODO: Example #1
        // Custom contructor
        
        public Room()
        {

        }
        #endregion
        /// <summary>
        /// TODO: Example #2
        /// This is the model for the department's rooms.
        /// </summary>
        private string roomName = "";

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
    }
}
