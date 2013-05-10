using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.BusinessLogic;
using CourseManagement.Client.DB;
using CourseManagement.Client.DB.Model;
using System.Data;
using System.Data.EntityClient;
using System.IO;
using System.Reflection;


namespace TestCourseManagement
{
    [TestClass]
    public class UnitTest1
    {

        
        
        public void tryRoomBooking()
            {
            
                DBConfiguration.getContext(UnitHelper.getUnitConnectionString());

            StudentQuery.insert(new Student() { Forename = "Markus" });

            Assert.AreEqual(StudentQuery.search("MARKUS")[0].Forename, "Markus");
            
        }
 
    }
}
