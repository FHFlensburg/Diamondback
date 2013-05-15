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
            try
            {
                UserQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static new List<User> getAll()
        {
            try
            {
                return UserQuery.getAll();
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
                UserQuery.delete(this);
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
                UserQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static new User getById(int userId)
        {
            try
            {
                return UserQuery.getById(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static User getByUserName(string userName)
        {
            try
            {
                return UserQuery.getByUserName(userName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }
        }
    }
}
