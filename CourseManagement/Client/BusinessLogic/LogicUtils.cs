using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
