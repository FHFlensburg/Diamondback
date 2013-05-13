/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;
using System.Data;

namespace CourseManagement.Client.BusinessLogic
{
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
            DataTable allPersons = generatatePersonTable();


            foreach (Person person in Person.getAll())
            {
                allPersons.Rows.Add(
                person.Id, person.Surname, person.Forename, person.City);
            }

            return allPersons;
        }


        /// <summary>
        /// Returns a DataTable containing all Person in DB
        /// with the search-Value in Forename, Surname or PersonNr
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override  DataTable search(string search)
        {
            DataTable allPersons = generatatePersonTable();

            foreach (Person person in Person.getAll())
            {
                if (LogicUtils.notNullAndContains(person.Forename,search)
                    || LogicUtils.notNullAndContains(person.Surname, search)
                    || LogicUtils.notNullAndContains(person.Id, search))
                {
                    allPersons.Rows.Add(
                    person.Id, person.Surname, person.Forename, person.City);
                }
            }

            return allPersons;
        }

        /// <summary>
        /// Generates the standard Person DataTable for this class.
        /// </summary>
        /// <returns></returns>
        private  DataTable generatatePersonTable()
        {
            return LogicUtils.getNewDataTable(
                "StudentNr", "Surname", "Forename", "City");
        }


        /// <summary>
        /// Creates a new Person in the database
        /// </summary>
        /// <param name="?"></param>
        public  void createNewPerson(string surname, string forename, string city, bool isTutor)
        {
            Person person;
            if (isTutor)
            {
                person = new Tutor();
            }
            else
            {
                person = new Student();
            }
            person.Surname = surname;
            person.Forename = forename;
            person.City = city;

            person.addToDB();
        }

        /// <summary>
        /// Returns a DataTable containing one or zero Person.
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public override  DataTable getById(int personNr)
        {
            DataTable dtPerson = generatatePersonTable();
            Person person = Person.getById(personNr);
            if (person != null)
            {
                dtPerson.Rows.Add(
                    person.Id, person.Surname, person.Forename, person.City);
            }
            return dtPerson;

        }


        /// <summary>
        /// Updates the Personproperties.
        /// Tupel will be find by personNr
        /// </summary>
        /// <param name="studentNr"></param>
        /// <param name="surname"></param>
        /// <param name="forename"></param>
        /// <param name="city"></param>
        public void changePersonProperties(int personNr, string surname, string forename, string city, bool isTutor)
        {
            Person person = Person.getById(personNr);
            person.Surname = surname;
            person.Forename = forename;
            person.City = city;
            person.update();
        }



    }
}
*/