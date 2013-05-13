﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Responsible class for the logged in user
    /// </summary>
    public static class ActiveUser
    {
        private static User currentUser = null;

        /// <summary>
        /// Log in a User by checking userName and correct password.
        /// Log in a user is not possible while a user is logged in.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool login(string userName, string password)
        {
            bool loginSuccessful = false;
            User userToCheck = User.getByUserName(userName);
            if (!userIsLoggedIn() && userToCheck != null && 
                userToCheck.Active == true && userToCheck.Password == password)
            {
                loginSuccessful = true;
                currentUser = userToCheck;
            }

            return loginSuccessful;
        }

        /// <summary>
        /// Logout the current User.
        /// </summary>
        public static void logout()
        {
            currentUser = null;
        }

        /// <summary>
        /// change the password of the logged in user
        /// </summary>
        /// <param name="newPassword"></param>
        public static void changePassword(string newPassword)
        {
            if (userIsLoggedIn()&&possiblePassword(newPassword)) currentUser.Password = newPassword;
        }

        /// <summary>
        /// Return true if a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static bool userIsLoggedIn()
        {
            return currentUser != null;
        }

        /// <summary>
        /// Return true if the current user is an admin
        /// </summary>
        /// <returns></returns>
        public static bool userIsAdmin()
        {
            bool isAdmin = false;
            if (userIsLoggedIn()) isAdmin = currentUser.Admin.GetValueOrDefault(false);
            return isAdmin;
        }

        /// <summary>
        /// Check rules for a new password
        /// length>=6, 
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool possiblePassword(string newPassword)
        {
            return newPassword.Length >= 6;
        }

    }
}