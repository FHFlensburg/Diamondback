using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.BusinessLogic;
using CourseManagement.Client.DB;
using CourseManagement.Client.DB.Model;

namespace TestCourseManagement
{
    [TestClass]
    public class TestAppointmentLogic
    {
        DateTime anfang = new DateTime(1998, 1, 1, 1, 1, 1);
        DateTime ende = new DateTime(1998, 2, 2, 2, 2, 2);

        [TestMethod]
        public void TestCreate()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            AppointmentLogic logic = AppointmentLogic.getInstance();

            int roomNr = Room.getAll()[0].RoomNr;
            int courseNr = Course.getAll()[0].CourseNr;
            int? test = logic.create(courseNr, roomNr, anfang, ende);
            Assert.IsNotNull(test);
            int? test2 = logic.create(courseNr, roomNr, anfang, ende);
            Assert.IsNull(test2);
            logic.delete(test.Value);

            ActiveUser.logout();

        }

    }
}
