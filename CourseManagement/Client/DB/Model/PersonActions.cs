using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    public abstract partial class Person
    {
        public virtual void addToDB()
        {
            try
            {
                PersonQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public  static List<Person> getAll()
        {
            try
            {
                return PersonQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual void delete()
        {
            try
            {
                PersonQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual void update()
        {
            try
            {
                PersonQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public  static Person getById(int personId)
        {
            try
            {
                return PersonQuery.getById(personId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
