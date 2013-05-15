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
            try
            {
                StudentQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static new List<Student> getAll()
        {
            try
            {
                return StudentQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void delete()
        {
            try
            {
                StudentQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void update()
        {
            try
            {
                StudentQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static new Student getById(int studentId)
        {
            try
            {
                return StudentQuery.getById(studentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }    
    }
}
