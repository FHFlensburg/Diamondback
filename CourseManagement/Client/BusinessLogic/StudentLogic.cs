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
            studentTable.Columns.Add("Test2");
            //studentTable.
           
            /*foreach (PropertyInfo pi in (new Student()).GetType().GetProperties())
            {
                studentTable.Columns.Add(pi.Name);
            }
            studentSet.Tables.Add(studentTable);*/
            return studentTable;
        }
        public static DataTable getDataTable2()
        {
            DataTable personTable = new DataTable();
            personTable.Columns.Add("Persons");
            personTable.Rows.Add("Person1");
            personTable.Rows.Add("Person2");
            return personTable;
        }

        public static DataTable getAllStudents()
        {
            return new DataTable();
        }
    }
}
