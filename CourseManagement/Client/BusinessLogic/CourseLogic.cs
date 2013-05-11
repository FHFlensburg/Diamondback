using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;


namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Contains all Methods for the interaction between Co
    /// </summary>
    public static class CourseLogic
    {
        

        public static DataTable getAllCourses()
        {
            DataTable allCourses = LogicUtils.getNewDataTable(
                "CourseNr", "StartDate", "EndDate", "StartTime", "DateCount", "Room", "Tutor", "StudentCount");

          
            foreach(Course course in Course.getAll())
            {
                allCourses.Rows.Add(course.CourseNr, course.StartDate, course.EndDate, null, null,
                    course.Room.RoomNr, course.Tutor.Surname, course.Payments.Count);
            }
            
            
            return allCourses;
        }
    }
}
