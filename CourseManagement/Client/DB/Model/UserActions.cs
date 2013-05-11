using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    public partial class User : Person
    {
        public override void addToDB()
        {
            UserQuery.insert(this);
        }

        public static new List<User> getAll()
        {
            return UserQuery.getAll();
        }

        public override void delete()
        {
            UserQuery.delete(this);
        }

        public override void update()
        {
            UserQuery.update(this);
        }

        public static new User getById(int userId)
        {
            return UserQuery.getById(userId);
        }
    }
}
