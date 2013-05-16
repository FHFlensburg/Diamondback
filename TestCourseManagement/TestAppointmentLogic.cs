using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.BusinessLogic;
using CourseManagement.Client.DB;

namespace TestCourseManagement
{
    [TestClass]
    public class TestAppointmentLogic
    {
        [TestMethod]
        public void TestCreate()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            AppointmentLogic logic = AppointmentLogic.getInstance();
            int? test = logic.create(3, 3, DateTime.Now, DateTime.Now.AddHours(1));
            Assert.IsNotNull(test);
            int? test2 = logic.create(3, 3, DateTime.Now, DateTime.Now.AddHours(1));
            Assert.IsNull(test2);
            logic.delete(test.Value);
            
        }
    }
}
