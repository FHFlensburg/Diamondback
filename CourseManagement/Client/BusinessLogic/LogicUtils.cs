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
    }
}
