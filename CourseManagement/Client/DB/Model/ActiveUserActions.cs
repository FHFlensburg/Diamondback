using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB;

namespace CourseManagement.Client.DB.Model
{
    public static class ActiveUserActions
    {
        /// <summary>
        /// Close the DB-Connection
        /// </summary>
        public static void closeContext()
        {
            try
            {
                DBConfiguration.closeContext();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
