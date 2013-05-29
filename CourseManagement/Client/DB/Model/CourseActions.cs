using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Course Model
    /// </summary>
    public partial class Course
    {
        /// <summary>
        /// Calls the Database Query witch adds a Course to the Database
        /// </summary>
        public void addToDB()
        {
            try
            {
                CourseQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query witch gets a List of all Courses
        /// </summary>
        /// <returns>Courses</returns>
        public static List<Course> getAll()
        {
            try
            {
                return CourseQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query witch deletes the selected Course
        /// </summary>
        public  void delete()
        {
            try
            {
                CourseQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query witch updates the selected Course
        /// </summary>
        public  void update()
        {
            try
            {
                CourseQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query witch calls a Course by Id
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns>Course</returns>
        public static Course getById(int courseNr)
        {
            try
            {
                return CourseQuery.getById(courseNr);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query witch search a resultset of Courses by a search-string
        /// </summary>
        /// <param name="like"></param>
        /// <returns>Courses</returns>
        public static List<Course> search(string like)
        {
            try
            {
                return CourseQuery.search(like);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
