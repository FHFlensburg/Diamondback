using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;
using System.Data;
using System.Reflection;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Contains all logical operations of a Person
    /// Implements some standard operations from the AbstractLogic
    /// </summary>
    public class PersonLogic:AbstractLogic
    {
        private PersonLogic() { }

        /// <summary>
        /// Getting an instance of PersonLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static PersonLogic getInstance()
        {
            PersonLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new PersonLogic();
            return temp;
        }

        /// <summary>
        /// Returns a DataTable containing all Person in DB
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            DataTable allPersons = getNewDataTable();


            foreach (Person person in Person.getAll())
            {
                allPersons.Rows.Add(getNewRow(allPersons,person));
            }

            return allPersons;
        }

        private DataTable getNewDataTable()
        {
            try
            {
                DataTable table = new DataTable();
                foreach (PropertyInfo pi in (new Student()).GetType().BaseType.GetProperties())
                {
                    table.Columns.Add(pi.Name);
                }
                return table;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private DataRow getNewRow(DataTable table, Person entity)
        {
            try
            {
                List<string> names = new List<string>();
                foreach (PropertyInfo pi in (new Student()).GetType().BaseType.GetProperties())
                {
                    names.Add(pi.Name);
                }
                DataRow row = table.NewRow();
                for (int i = 0; i < names.Count; i++)
                {
                    row[names[i]] = entity.GetType().GetProperty(names[i]).GetMethod.Invoke(entity, null);
                }
                return row;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Returns a DataTable containing all Person in DB
        /// with the search-Value in Forename, Surname or PersonNr
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override  DataTable search(string search)
        {
            DataTable allPersons = getNewDataTable();

            foreach (Person person in Person.getAll())
            {
                if (LogicUtils.notNullAndContains(person.Forename,search)
                    || LogicUtils.notNullAndContains(person.Surname, search)
                    || LogicUtils.notNullAndContains(person.Id, search))
                {
                    allPersons.Rows.Add(getNewRow(allPersons,person));
                }
            }

            return allPersons;
        }

        /// <summary>
        /// Returns a DataTable containing one or zero Person.
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public override  DataTable getById(int personNr)
        {
            DataTable dtPerson = getNewDataTable();
            Person person = Person.getById(personNr);
            if (person != null)
            {
                dtPerson.Rows.Add(getNewRow(dtPerson,person));
            }
            return dtPerson;

        }


        /// <summary>
        /// Updates the Personproperties.
        /// Tupel will be find by personNr
        /// </summary>
        /// <param name="personNr"></param>
        /// <param name="surname"></param>
        /// <param name="forename"></param>
        /// <param name="birthyear"></param>
        /// <param name="street"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="mail"></param>
        /// <param name="fax"></param>
        /// <param name="privatePhone"></param>
        /// <param name="gender"></param>
        /// <param name="isActive"></param>
        /// <param name="title"></param>
        /// <param name="city"></param>
        /// <param name="citycode"></param>
        public void changeProperties(int personNr, string surname, string forename, string birthyear, string street,
            string mobilePhone, string mail, string fax, string privatePhone, string gender,
            bool? isActive, string title, string city, string citycode)
        {
            try
            {
                Person person = Person.getById(personNr);
                person.Surname = surname;
                person.Forename = forename;
                person.Birthyear = birthyear;
                person.Street = street;
                person.MobilePhone = mobilePhone;
                person.Mail = mail;
                person.Fax = fax;
                person.PrivatePhone = privatePhone;
                person.Gender = gender;
                person.Active = isActive;
                person.Title = title;
                person.City = city;
                person.CityCode = citycode;

                person.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get one person by id manage the remove from database of this person
        /// </summary>
        /// <param name="courseNr"></param>
        public override void delete(int personNr)
        {
            try
            {
                Student.getById(personNr).delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
