using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;
using CourseManagement.Client.DB;

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
            /*foreach(Course course in CourseQuery.getAll())
            {
                allCourses.Rows.Add(course.CourseNr, course.StartDate, course.EndDate, null, null,
                    course.Rooms.RoomNr, course.Tutors.FirstOrDefault().Surname, null);
            }*/
            new Course().update(new Course());
            
            return allCourses;
        }
    }
}
