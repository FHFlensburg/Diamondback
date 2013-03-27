using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdminTool.Client.Model;


namespace TestAdminTool
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void tryRoomBooking()
        {
            Room room = new Room();
            Assert.AreEqual(room.RoomName = "Raum 101", "Raum 101");
        }
    }
}
