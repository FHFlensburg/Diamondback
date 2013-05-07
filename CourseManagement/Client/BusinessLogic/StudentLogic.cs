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
        public static DataSet getDataSet()
        {
            DataSet studentSet = new DataSet();
            DataTable studentTable = new DataTable();
            studentTable.Columns.Add("Test");
            studentTable.Rows.Add("TestWert");
            studentTable.Rows.Add("Testwert2");
            studentSet.Tables.Add(studentTable);
            /*foreach (PropertyInfo pi in (new Student()).GetType().GetProperties())
            {
                studentTable.Columns.Add(pi.Name);
            }
            studentSet.Tables.Add(studentTable);*/
            return studentSet;
        }

        public static DataTable getDataTable()
        {
            
            DataTable studentTable = new DataTable();
            studentTable.Columns.Add("Test");
            studentTable.Rows.Add("TestWert");
            studentTable.Rows.Add("Testwert2");
           
            /*foreach (PropertyInfo pi in (new Student()).GetType().GetProperties())
            {
                studentTable.Columns.Add(pi.Name);
            }
            studentSet.Tables.Add(studentTable);*/
            return studentTable;
        }
    }
}
