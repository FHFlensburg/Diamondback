using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.BusinessLogic
{
    public class UserLogic : AbstractLogic
    {
        private UserLogic() { }

        /// <summary>
        /// Getting an instance of UserLogic is only possible if
        /// a user is an admin
        /// </summary>
        /// <returns></returns>
        public static UserLogic getInstance()
        {
            UserLogic temp = null;
            if (ActiveUser.userIsAdmin()) temp = new UserLogic();
            return temp;
        }

        /// <summary>
        /// Returns a DataTable containing all Users in DB
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allUsers = generatateUserTable();


                foreach (User user in User.getAll())
                {
                    allUsers.Rows.Add(
                    user.Id, user.Surname, user.Forename, user.City);
                }


                return allUsers;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Returns a DataTable containing all Users in DB
        /// with the search-Value in Forename, Surname or tutorNr
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override DataTable search(string search)
        {
            try
            {
                DataTable allUsers = generatateUserTable();

                foreach (User user in User.getAll())
                {
                    if (LogicUtils.notNullAndContains(user.Forename, search)
                        || LogicUtils.notNullAndContains(user.Surname, search)
                        || LogicUtils.notNullAndContains(user.Id, search))
                    {
                        allUsers.Rows.Add(
                        user.Id, user.Surname, user.Forename, user.City);
                    }
                }

                return allUsers;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        //depricated
        private DataTable generatateUserTable()
        {
            return LogicUtils.getNewDataTable(
                "TutorNr", "Surname", "Forename", "City");
        }


        /// <summary>
        /// Creates a new User in the database
        /// </summary>
        /// <param name="?"></param>
        public void createNewUser(string surname, string forename, string city)
        {
            try
            {
                User user = new User();
                user.Surname = surname;
                user.Forename = forename;
                user.City = city;

                user.addToDB();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Returns a DataTable containing one or zero User.
        /// </summary>
        /// <param name="tutorNr"></param>
        /// <returns></returns>
        public override DataTable getById(int userNr)
        {
            try
            {
                DataTable dtUser = generatateUserTable();
                Tutor user = Tutor.getById(userNr);
                if (user != null)
                {
                    dtUser.Rows.Add(
                        user.Id, user.Surname, user.Forename, user.City);
                }
                return dtUser;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  

        }

        /// <summary>
        /// Changing attributes of a User.
        /// The Tutor which is to be updated is specified by userNr.
        /// </summary>
        /// <param name="studentNr"></param>
        /// <param name="surname"></param>
        /// <param name="forename"></param>
        /// <param name="city"></param>
        public void changeTutorProperties(int userNr, string surname, string forename, string city)
        {
            try
            {
                User user = User.getById(userNr);
                user.Surname = surname;
                user.Forename = forename;
                user.City = city;
                user.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Get one user by id manage the remove from database of this user
        /// </summary>
        /// <param name="courseNr"></param>
        public override void delete(int userNr)
        {
            try
            {
                User.getById(userNr).delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

    }
}
