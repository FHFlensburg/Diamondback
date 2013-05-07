using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;
using System.Data;
using System.Reflection;

namespace CourseManagement.Client.BusinessLogic
{
    public static class StudentLogic
    {
        public static DataSet getAll()
        {
            DataSet studentSet = new DataSet();
            DataTable studentTable = new DataTable();
            foreach (PropertyInfo pi in (new Student()).GetType().GetProperties())
            {
                studentTable.Columns.Add(pi.Name);
            }
            studentSet.Tables.Add(studentTable);
            return studentSet;
        }
    }
}
