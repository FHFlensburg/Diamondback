using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;

namespace CourseManagement.Client.DB
{
    public static class CourseQuery
    {
 
        /// <summary>
        /// Get all courses from database.
        /// </summary>
        /// <returns>List of courses</returns>
        public static List<Course> getAll()
        {
            List<Course> qry = (from course in DBConfiguration.getContext().Courses
                                 select course).ToList();

            return qry;
        }

        /// <summary>
        /// Add's the submitted course to database.
        /// </summary>
        /// <param name="student"></param>
        public static void insert(Course course)
        {
            //DBConfiguration.getContext().Courses.Add(course);
            //update(course);
            Room a = new Room();
            DBConfiguration.getContext().Rooms.Add(a);

            Tutor t = new Tutor();
            DBConfiguration.getContext().Persons.Add(t);
            DBConfiguration.getContext().SaveChanges();
            Course k = DBConfiguration.getContext().Courses.Create();
            k.Rooms = DBConfiguration.getContext().Rooms.Find(1);
            k.Tutors =(DBConfiguration.getContext().Persons.Find(1)as Tutor);
            DBConfiguration.getContext().Courses.Add(k);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Deletes the submitted course from the database.
        /// </summary>
        /// <param name="student"></param>
        public static void delete(Course course)
        {
            DBConfiguration.getContext().Courses.Remove(course);
            update(course);
        }

        /// <summary>
        /// Returns the course who is bound to the given ID.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Student</returns>
        public static Course getById(int courseId)
        {
            return (DBConfiguration.getContext().Courses.Find(courseId));
        }

        /// <summary>
        /// Saves all changes made on the DataContext.
        /// Parameter is Placeholder for a new database-layer
        /// </summary>
        /// <param name="student"></param>
        public static void update(Course course)
        {
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Searching for a tupel of course which contains the submitted string
        /// in property: Title, CourseNr
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<Course> search(string like)
        {
            List<Course> qry = new List<Course>();

            if (DBUtils.isNumber(like))
            {
                int wert = Convert.ToInt32(like);
                List<Course> listCourse = (from course in DBConfiguration.getContext().Courses
                                             select course).ToList();
                foreach (Course course in listCourse)
                {
                    if (course.CourseNr.ToString().Contains(like)) qry.Add(course);
                }
            }
            else
            {
                like = like.ToUpper();
                qry = (from course in DBConfiguration.getContext().Courses
                       where course.Title.ToUpper().Contains(like)
                       
                       select course).ToList();
            }
            return qry;
        }
    }
}