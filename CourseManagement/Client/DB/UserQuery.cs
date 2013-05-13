using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB
{
    public static class UserQuery
    {
        /// <summary>
        /// Get all Users from database.
        /// </summary>
        /// <returns>List of Users</returns>
        public static List<User> getAll()
        {
            List<User> qry = (from user in DBConfiguration.getContext().Persons.OfType<User>()
                                 select user).ToList();

            return qry;
        }

        /// <summary>
        /// Add's the submitted User to database.
        /// </summary>
        /// <param name="student"></param>
        public static void insert(User user)
        {
            DBConfiguration.getContext().Persons.Add(user);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Deletes the submitted User from the database.
        /// </summary>
        /// <param name="student"></param>
        public static void delete(User user)
        {
            DBConfiguration.getContext().Persons.Remove(user);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Returns the User who is bound to the given ID.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Student</returns>
        public static User getById(int userId)
        {
            return (DBConfiguration.getContext().Persons.Find(userId)) as User;
        }

        /// <summary>
        /// Saves all changes made on the DataContext.
        /// Parameter is Placeholder for a new database-layer
        /// </summary>
        /// <param name="student"></param>
        public static void update(User user)
        {
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Searching for a tupel of User which contains the submitted string
        /// in property: Forename, Surname, Id
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<User> search(String like)
        {
            List<User> qry = new List<User>();

            if (DBUtils.isNumber(like))
            {
                int wert = Convert.ToInt32(like);
                List<User> listUser = (from user in DBConfiguration.getContext().Persons.OfType<User>()
                                             select user).ToList();
                foreach (User user in listUser)
                {
                    if (user.Id.ToString().Contains(like)) qry.Add(user);
                }
            }
            else
            {
                like = like.ToUpper();
                qry = (from user in DBConfiguration.getContext().Persons.OfType<User>()
                       where user.Forename.ToUpper().Contains(like)
                       || user.Surname.ToUpper().Contains(like)
                       select user).ToList();
            }
            return qry;
        }

        /// <summary>
        /// Return a user or null.
        /// Search for the username in DB
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static User getByUserName(string userName)
        {
            User qry = null;
            if (userName != "" && userName!=null)
            {
                qry = (from user in DBConfiguration.getContext().Persons.OfType<User>()
                            where user.UserName.Equals(userName)
                            select user).FirstOrDefault();
            }
            return qry;
        }
    }
}
