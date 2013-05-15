using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;

namespace CourseManagement.Client.BusinessLogic
{
    public static class LogicUtils
    {
        public static DataTable getNewDataTable(params string[] columnNames)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < columnNames.Length;i++ )
            {
                table.Columns.Add(columnNames[i]);
            }
            return table;
        }

        public static DataTable getNewDataTable(object entity)
        {
            DataTable table = new DataTable();
            foreach(PropertyInfo pi in entity.GetType().GetProperties())
            {
                table.Columns.Add(pi.Name);
            }        
            return table;
        }

        public static List<string> getPropertyNames(object entity)
        {
            List<string> names = new List<string>();
            foreach (PropertyInfo pi in entity.GetType().GetProperties())
            {
                names.Add(pi.Name);
            }  
            return names;
        }

        

        /// <summary>
        /// Returns true if the given string is not null
        /// and contains the given string 
        /// </summary>
        public static bool notNullAndContains(string stringToCheck, string like)
        {
            bool result = false;
            if(stringToCheck != null && stringToCheck.ToUpper().Contains(like.ToUpper())) result = true;
            return result;
        }

        /// <summary>
        /// Returns true if the given int? is not null
        /// and cointains the given string
        /// </summary>
        /// <param name="intToCheck"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        public static bool notNullAndContains(int? intToCheck, string like)
        {
            bool result = false;
            if (intToCheck.HasValue) result = notNullAndContains(intToCheck.ToString(), like);
            return result;
        }



    }
}
