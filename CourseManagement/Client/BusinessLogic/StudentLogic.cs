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
 

        public static DataTable getAllStudents()
        {
            
            DataTable studentTable = new DataTable();
           
            foreach (PropertyInfo pi in (new Student()).GetType().GetProperties())
            {
                studentTable.Columns.Add(pi.Name);
            }

            foreach (Student student in Student.getAll())
            {
               
            }
            
            return studentTable;
        }

    }
}
