using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.BusinessLogic
{
    public class TutorLogic : AbstractLogic
    {
        private TutorLogic() { }

        /// <summary>
        /// Getting an instance of TutorLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static TutorLogic getInstance()
        {
            TutorLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new TutorLogic();
            return temp;
        }

        /// <summary>
        /// Returns a DataTable containing all Tutors in DB
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allTutors = generatateTutorTable();


                foreach (Tutor tutor in Tutor.getAll())
                {
                    allTutors.Rows.Add(
                    tutor.Id, tutor.Surname, tutor.Forename, tutor.City);
                }

                return allTutors;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Returns a DataTable containing all Tutors in DB
        /// with the search-Value in Forename, Surname or tutorNr
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override DataTable search(string search)
        {
            try
            {
                DataTable allTutors = generatateTutorTable();

                foreach (Tutor tutor in Tutor.getAll())
                {
                    if (LogicUtils.notNullAndContains(tutor.Forename, search)
                        || LogicUtils.notNullAndContains(tutor.Surname, search)
                        || LogicUtils.notNullAndContains(tutor.Id, search))
                    {
                        allTutors.Rows.Add(
                        tutor.Id, tutor.Surname, tutor.Forename, tutor.City);
                    }
                }

                return allTutors;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        //depricated
        private DataTable generatateTutorTable()
        {
            return LogicUtils.getNewDataTable(
                "TutorNr", "Surname", "Forename", "City");
        }


        /// <summary>
        /// Creates a new Tutor in the database
        /// </summary>
        /// <param name="?"></param>
        public void createNewTutor(string surname, string forename, string city)
        {
            try
            {
                Tutor tutor = new Tutor();
                tutor.Surname = surname;
                tutor.Forename = forename;
                tutor.City = city;

                tutor.addToDB();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Returns a DataTable containing one or zero Tutor.
        /// </summary>
        /// <param name="tutorNr"></param>
        /// <returns></returns>
        public override DataTable getById(int tutorNr)
        {
            try
            {
                DataTable dtTutor = generatateTutorTable();
                Tutor tutor = Tutor.getById(tutorNr);
                if (tutor != null)
                {
                    dtTutor.Rows.Add(
                        tutor.Id, tutor.Surname, tutor.Forename, tutor.City);
                }
                return dtTutor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  

        }

        /// <summary>
        /// Changing attributes of a Tutor.
        /// The Tutor which is to be updated is specified by tutorNr.
        /// </summary>
        /// <param name="studentNr"></param>
        /// <param name="surname"></param>
        /// <param name="forename"></param>
        /// <param name="city"></param>
        public void changeTutorProperties(int studentNr, string surname, string forename, string city)
        {
            try
            {
                Tutor tutor = Tutor.getById(studentNr);
                tutor.Surname = surname;
                tutor.Forename = forename;
                tutor.City = city;
                tutor.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Get one tutor by id manage the remove from database of this tutor
        /// </summary>
        /// <param name="courseNr"></param>
        public override void delete(int tutorNr)
        {
            try
            {
                Tutor.getById(tutorNr).delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }
    }
}
