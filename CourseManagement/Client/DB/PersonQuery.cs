using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;


namespace CourseManagement.Client.DB
{
    public static class PersonQuery
    {
        /// <summary>
        /// Get all Students from database.
        /// </summary>
        /// <returns>List of Students</returns>
        public static List<Person> getAll()
        {
            List<Person> qry = (from person in DBConfiguration.getContext().Persons
                                select person).ToList();

            return qry;
        }

        /// <summary>
        /// Add's the submitted Student to database.
        /// </summary>
        /// <param name="student"></param>
        public static void insert(Person person)
        {
            DBConfiguration.getContext().Persons.Add(person);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Deletes the submitted Student from the database.
        /// </summary>
        /// <param name="student"></param>
        public static void delete(Person person)
        {
            DBConfiguration.getContext().Persons.Remove(person);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Returns the Student who is bound to the given ID.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Student</returns>
        public static Person getById(int personId)
        {
            return (DBConfiguration.getContext().Persons.Find(personId));
        }

        /// <summary>
        /// Saves all changes made on the DataContext.
        /// Parameter is Placeholder for a new database-layer
        /// </summary>
        /// <param name="student"></param>
        public static void update(Person person)
        {
            DBConfiguration.getContext().SaveChanges();
        }
    }

}
