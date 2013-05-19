﻿using CourseManagement.Client.DB.Model;
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
                DataTable allUsers = getNewDataTable();


                foreach (User user in User.getAll())
                {
                    allUsers.Rows.Add(getNewRow(allUsers,user));
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
                DataTable allUsers = getNewDataTable();

                foreach (User user in User.getAll())
                {
                    if (LogicUtils.notNullAndContains(user.Forename, search)
                        || LogicUtils.notNullAndContains(user.Surname, search)
                        || LogicUtils.notNullAndContains(user.UserName, search)
                        || LogicUtils.notNullAndContains(user.Id, search))
                    {
                        allUsers.Rows.Add(getNewRow(allUsers,user));
                    }
                }

                return allUsers;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Method for specific UserDataTable-changes to the default DataTable-Method in LogicUtils
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            return LogicUtils.getNewDataTable(new User());
        }

        /// <summary>
        /// Method for specific UserRow-changes to the default Row-Method in LogicUtils
        /// </summary>
        /// <param name="table"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private DataRow getNewRow(DataTable table, User user)
        {
            DataRow row = LogicUtils.getNewRow(table, user);
            row["Password"] = "***";
            return row;
        }


        /// <summary>
        /// Creates a new User in the database and return the userNr
        /// </summary>
        /// <param name="?"></param>
        public int create(string surname, string forename, string birthyear, string street,
            string mobilePhone, string mail, string fax, string privatePhone, string gender,
            bool? active, string title, string city, string citycode, string username, string password,
            bool? admin)
        {
            try
            {
                if (isPossibleNewUserName(username))
                {
                    User user = new User();
                    user.Surname = surname;
                    user.Forename = forename;
                    user.Birthyear = birthyear;
                    user.Street = street;
                    user.MobilePhone = mobilePhone;
                    user.Mail = mail;
                    user.Fax = fax;
                    user.PrivatePhone = privatePhone;
                    user.Gender = gender;
                    user.Active = active;
                    user.Title = title;
                    user.City = city;
                    user.CityCode = citycode;
                    user.UserName = username;
                    user.Password = password;
                    user.Admin = admin;

                    user.addToDB();
                    return user.Id;
                }
                else throw new Exception("Username nicht zulässig");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a new User in the database and return the userNr
        /// </summary>
        /// <param name="?"></param>
        public void changeProperties(int userNr,string surname, string forename, string birthyear, string street,
           string mobilePhone, string mail, string fax, string privatePhone, string gender,
           bool? active, string title, string city, string citycode, string username, string password,
           bool? admin)
        {
            try
            {
                User user = User.getById(userNr);
                user.Surname = surname;
                user.Forename = forename;
                user.Birthyear = birthyear;
                user.Street = street;
                user.MobilePhone = mobilePhone;
                user.Mail = mail;
                user.Fax = fax;
                user.PrivatePhone = privatePhone;
                user.Gender = gender;
                user.Active = active;
                user.Title = title;
                user.City = city;
                user.CityCode = citycode;
                if (user.UserName == username || isPossibleNewUserName(username))
                {
                    user.UserName = username;
                }
                else throw new Exception("Username nicht zulässig");
                user.Password = password;
                user.Admin = admin;

                user.update();
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
                DataTable dtUser = getNewDataTable();
                User user = User.getById(userNr);
                if (user != null)
                {
                    dtUser.Rows.Add(getNewRow(dtUser,user));
                }
                return dtUser;
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

        public bool isPossibleNewUserName(string userName)
        {
            try
            {
                User user = User.getByUserName(userName);
                return (user == null && userName != "" && userName != null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
