using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminTool.Client.DB;

namespace AdminTool.Client.Model
{
    public partial class Student : Person
    {
        public void addToDB()
        {
            StudentQuery.insert(this);
        }

        public static List<Student> getAll()
        {
            return StudentQuery.getAll();
        }

        public static void delete(Student student)
        {
            StudentQuery.delete(student);
        }

        public static void update(Student student)
        {
            StudentQuery.update(student);
        }

        public static Student getById(int studentId)
        {
            return StudentQuery.getById(studentId);
        }

        public static List<Student> search(string like)
        {
            return StudentQuery.search(like);
        }
    }
}
