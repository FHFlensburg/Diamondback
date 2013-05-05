using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminTool.Client.Model;
using System.Text.RegularExpressions;

namespace AdminTool.Client.DB
{
    /// <summary>
    /// All database activities for Students.
    /// </summary>
    public static class StudentQuery
    {
        /// <summary>
        /// Get all Students from database.
        /// </summary>
        /// <returns>List of Students</returns>
        public static List<Student> getAll()
        {
            List<Student> qry = (from student in DBConfiguration.getContext().Persons.OfType<Student>()
                                 select student).ToList();

            return qry;
        }

        /// <summary>
        /// Add's the submitted Student to database.
        /// </summary>
        /// <param name="student"></param>
        public static void insert(Student student)
        {
            DBConfiguration.getContext().Persons.Add(student);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Deletes the submitted Student from the database.
        /// </summary>
        /// <param name="student"></param>
        public static void delete(Student student)
        {
            DBConfiguration.getContext().Persons.Remove(student);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Returns the Student who is bound to the given ID.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Student</returns>
        public static Student getById(int studentId)
        {
            return (DBConfiguration.getContext().Persons.Find(studentId)) as Student;
        }

        /// <summary>
        /// Saves all changes made on the DataContext.
        /// Parameter is Placeholder for a new database-layer
        /// </summary>
        /// <param name="student"></param>
        public static void update(Student student)
        {
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Searching for a tupel which contains the submitted string
        /// in property: Forename, Surname, Id
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<Student> search(string like)
        {
            List<Student> qry = new List<Student>();
            Regex isNumber = new Regex(@"^\d+$");
            if (isNumber.Match(like).Success)
            {
                int wert = Convert.ToInt32(like);
                List<Student> listStudent = (from student in DBConfiguration.getContext().Persons.OfType<Student>()
                                             select student).ToList();
                foreach (Student student in listStudent)
                {
                    if (student.Id.ToString().Contains(like)) qry.Add(student);
                }
            }
            else
            {
                like = like.ToUpper();
                qry = (from student in DBConfiguration.getContext().Persons.OfType<Student>()
                       where student.Forename.ToUpper().Contains(like)
                       || student.Surname.ToUpper().Contains(like)
                       select student).ToList();               
            }
            return qry;
        }
    }
}
