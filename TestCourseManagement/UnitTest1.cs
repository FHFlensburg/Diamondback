using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.DB.Model;


namespace TestCourseManagement
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void tryRoomBooking()
        {
            
            Assert.AreEqual( "Raum 101", "Raum 101");
        }
    }
}
