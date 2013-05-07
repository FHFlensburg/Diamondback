using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.DB.Model;
using System.Data;
using CourseManagement.Client.BusinessLogic;


namespace TestCourseManagement
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für testStudentLogics
    /// </summary>
    [TestClass]
    public class testStudentLogics
    {
        public testStudentLogics()
        {
            //
            // TODO: Konstruktorlogik hier hinzufügen
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Textkontext mit Informationen über
        ///den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        //
        // Sie können beim Schreiben der Tests folgende zusätzliche Attribute verwenden:
        //
        // Verwenden Sie ClassInitialize, um vor Ausführung des ersten Tests in der Klasse Code auszuführen.
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Verwenden Sie ClassCleanup, um nach Ausführung aller Tests in einer Klasse Code auszuführen.
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen. 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testgetAllStudents()
        {
             Student testStud = new Student() { Forename = "Peter", Birthyear = "1234" };
             DataTable dt = new DataTable();
             dt.Columns.Add("Forename");
             dt.Columns.Add("Birthyear");
             DataRow dr = StudentLogic.getAllStudents().Rows.Find(1) ;
            Assert.Equals(dr.ToString(),dr.ToString());

            
        
        
        
        }
    }
}
