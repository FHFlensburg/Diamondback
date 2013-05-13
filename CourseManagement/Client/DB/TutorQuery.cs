using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;

namespace CourseManagement.Client.DB
{
    public static class TutorQuery
    {
 
        /// <summary>
        /// Get all Users from database.
        /// </summary>
        /// <returns>List of Tutors</returns>
        public static List<Tutor> getAll()
        {
            List<Tutor> qry = (from tutor in DBConfiguration.getContext().Persons.OfType<Tutor>()
                               select tutor).ToList();

            return qry;
        }

        /// <summary>
        /// Add's the submitted Tutor to database.
        /// </summary>
        /// <param name="student"></param>
        public static void insert(Tutor tutor)
        {
            DBConfiguration.getContext().Persons.Add(tutor);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Deletes the submitted Tutor from the database.
        /// </summary>
        /// <param name="student"></param>
        public static void delete(Tutor tutor)
        {
            DBConfiguration.getContext().Persons.Remove(tutor);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Returns the Tutor who is bound to the given ID.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Student</returns>
        public static Tutor getById(int tutorId)
        {
            return (DBConfiguration.getContext().Persons.Find(tutorId)) as Tutor;
        }

        /// <summary>
        /// Saves all changes made on the DataContext.
        /// Parameter is Placeholder for a new database-layer
        /// </summary>
        /// <param name="student"></param>
        public static void update(Tutor tutor)
        {
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Searching for a tupel of Tutor which contains the submitted string
        /// in property: Forename, Surname, Id
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<Tutor> search(String like)
        {
            List<Tutor> qry = new List<Tutor>();

            if (DBUtils.isNumber(like))
            {
                int wert = Convert.ToInt32(like);
                List<Tutor> listTutor = (from tutor in DBConfiguration.getContext().Persons.OfType<Tutor>()
                                             select tutor).ToList();
                foreach (Tutor tutor in listTutor)
                {
                    if (tutor.Id.ToString().Contains(like)) qry.Add(tutor);
                }
            }
            else
            {
                like = like.ToUpper();
                qry = (from tutor in DBConfiguration.getContext().Persons.OfType<Tutor>()
                       where tutor.Forename.ToUpper().Contains(like)
                       || tutor.Surname.ToUpper().Contains(like)
                       select tutor).ToList();
            }
            return qry;
        }
    }
}