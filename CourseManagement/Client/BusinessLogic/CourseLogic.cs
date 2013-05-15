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
        
        /// <summary>
        /// Creates a datatable and fills it with the property names and all the data
        /// from the entity Courses
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            DataTable allCourses = LogicUtils.getNewDataTable(new Course());          
            List<string> names = LogicUtils.getPropertyNames(new Course());
            foreach(Course course in Course.getAll())
            {
               allCourses.Rows.Add(getNewRow(allCourses, course));

                //allCourses.Rows.Add(course.CourseNr, course.Title, course.AmountInEuro, course.Description, course.MaxMember,
                  //  course.MinMember, course.ValidityInMonth, null, course.Tutor.Surname, course.Payments.Count);
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
        public int createNewCourse(String title, decimal amountInEuro, String description, int maxMember, int minMember, int tutor,
                                        int appointment, int validityInMonth)
        {
            Course course = new Course();
            course.Title = title;
            course.AmountInEuro = amountInEuro;
            course.Description = description;
            course.MaxMember = maxMember;
            course.MinMember = minMember;
            course.Tutor = Tutor.getById(tutor); 

            
            course.ValidityInMonth = validityInMonth;

            course.addToDB();
            return course.CourseNr;
        }

        /// <summary>
        /// Creates a datatable and get one Course by id and fills the datatable with all property names and
        /// the data from the Course
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns></returns>
        public override DataTable getById(int courseNr)
        {
            Course course = Course.getById(courseNr);
            DataTable aCourse = LogicUtils.getNewDataTable(course);

            
            aCourse.Rows.Add(getNewRow(aCourse, course));

            return aCourse;
        }

        /// <summary>
        /// Create the default DataRow for Course-DataTables and
        /// Change the fields which references other entities. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="course"></param>
        private DataRow getNewRow(DataTable table, Course course)
        {
            DataRow row = table.NewRow();
            List<string> names = LogicUtils.getPropertyNames(course);
            for (int i = 0; i < names.Count; i++)
            {
                row[names[i]] = course.GetType().GetProperty(names[i]).GetMethod.Invoke(course, null);
            }
            row["Tutor"] = course.Tutor.Surname;
            row["Payments"] = course.Payments.Count;
            row["Appointments"] = course.Appointments.Count;

            return row;
        }

        /// <summary>
        /// Search all courses by the parameter in the columns CourseNr, Title and Description
        /// A datatable with the resultset will be returned
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override DataTable search(string search)
        {
            DataTable allCourses = LogicUtils.getNewDataTable(new Course());

            foreach (Course course in Course.getAll())
            {
                if (LogicUtils.notNullAndContains(course.CourseNr, search)
                    || LogicUtils.notNullAndContains(course.Title, search)
                    || LogicUtils.notNullAndContains(course.Description, search))
                {
                    allCourses.Rows.Add(getNewRow(allCourses,course));
                }
            }

            return allCourses;
        }

        /// <summary>
        /// Get one course by id manage the remove from database of this course
        /// </summary>
        /// <param name="courseNr"></param>
        public override void delete(int courseNr)
        {
            Course.getById(courseNr).delete();
        }
    }
}
