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
            CourseQuery.insert(this);
        }

        public static List<Course> getAll()
        {
            return CourseQuery.getAll();
        }

        public  void delete()
        {
            CourseQuery.delete(this);
        }

        public  void update()
        {
            CourseQuery.update(this);
        }

        public static Course getById(int courseNr)
        {
            return CourseQuery.getById(courseNr);
        }

        public static List<Course> search(string like)
        {
            return CourseQuery.search(like);
        }

    }
}
