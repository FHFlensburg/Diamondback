using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    public partial class Course
    {

        public void addToDB()
        {
            try
            {
                CourseQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Course> getAll()
        {
            try
            {
                return CourseQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public  void delete()
        {
            try
            {
                CourseQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public  void update()
        {
            try
            {
                CourseQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Course getById(int courseNr)
        {
            try
            {
                return CourseQuery.getById(courseNr);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Course> search(string like)
        {
            try
            {
                return CourseQuery.search(like);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
