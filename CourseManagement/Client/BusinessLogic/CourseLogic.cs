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
    public class CourseLogic:AbstractLogic
    {
        private CourseLogic() { }

        /// <summary>
        /// Getting an instance of CourseLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static CourseLogic getInstance()
        {
            CourseLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new CourseLogic();
            return temp;
        }
        

        public override DataTable getAll()
        {
            DataTable allCourses = LogicUtils.getNewDataTable(
                "CourseNr", "StartDate", "EndDate", "StartTime", "DateCount", "Room", "Tutor", "StudentCount");

          
            foreach(Course course in Course.getAll())
            {
                allCourses.Rows.Add(course.CourseNr, null, null,
                    course.Tutor.Surname, course.Payments.Count);
            }
            
            
            return allCourses;
        }

        /// <summary>
        /// Creates a new Course by the given parameters
        /// </summary>
        /// <param name="title"></param>
        /// <param name="amountinEuro"></param>
        /// <param name="description"></param>
        /// <param name="maxMember"></param>
        /// <param name="minMember"></param>
        /// <param name="validityInMonth"></param>
        public void createCourse(String title, decimal amountInEuro, String description, int maxMember, int minMember, int validityInMonth)
        {
            Course course = new Course();
            course.Title = title;
            course.AmountInEuro = amountInEuro;
            course.Description = description;
            course.MaxMember = maxMember;
            course.MinMember = minMember;
            course.ValidityInMonth = validityInMonth;

            course.addToDB();
        }

        public override DataTable getById(int courseNr)
        {
            throw new NotImplementedException();
        }

        public override DataTable search(string search)
        {
            throw new NotImplementedException();
        }
    }
}
