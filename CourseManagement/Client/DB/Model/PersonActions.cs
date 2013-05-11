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
            PersonQuery.insert(this);
        }

        public  static List<Person> getAll()
        {
            return PersonQuery.getAll();
        }

        public virtual void delete()
        {
            PersonQuery.delete(this);
        }

        public virtual void update()
        {
            PersonQuery.update(this);
        }

        public  static Person getById(int personId)
        {
            return PersonQuery.getById(personId);
        }



    }
}
