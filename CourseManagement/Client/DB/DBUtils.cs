﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB
{
    /// <summary>
    /// Utilities for all Database Queries
    /// </summary>
    public static class DBUtils
    {
        /// <summary>
        /// Check's if the submitted string is an integer.
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        public static bool isNumber(string stringToCheck)
        {
             return ((new Regex(@"^\d+$").Match(stringToCheck).Success));
        }
    }
}
