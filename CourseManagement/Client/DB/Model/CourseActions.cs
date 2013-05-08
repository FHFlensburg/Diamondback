using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    public partial class Course
    {
        public List<Course> getAll()
        {
            return CourseQuery.getAll();
        }

        public void update(Course course)
        {
            CourseQuery.insert(this);
        }
    }
}
