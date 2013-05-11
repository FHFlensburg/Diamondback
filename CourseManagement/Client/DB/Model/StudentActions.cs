using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB;


namespace CourseManagement.Client.DB.Model
{
    public partial class Student : Person
    {
        public override void addToDB()
        {
            StudentQuery.insert(this);
        }

        public static new List<Student> getAll()
        {
            return StudentQuery.getAll();
        }

        public override void delete()
        {
            StudentQuery.delete(this);
        }

        public override void update()
        {
            StudentQuery.update(this);
        }

        public static new Student getById(int studentId)
        {
            return StudentQuery.getById(studentId);
        }



    
    }
}
