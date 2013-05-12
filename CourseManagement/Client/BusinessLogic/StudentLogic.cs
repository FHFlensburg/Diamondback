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

    public class StudentLogic:AbstractLogic
    {
        private StudentLogic() { }

        /// <summary>
        /// Getting an instance of StudentLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static StudentLogic getInstance()
        {
            StudentLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new StudentLogic();
            return temp;
        }

        /// <summary>
        /// Returns a DataTable containing all Students in DB
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            DataTable allStudents = generatateStudentTable();


            foreach (Student student in Student.getAll())
            {
                allStudents.Rows.Add(
                student.Id, student.Surname, student.Forename, student.City);
            }

            return allStudents;
        }

        public override DataTable search(string search)
        {
            search = search.ToUpper();
            DataTable allStudents = generatateStudentTable();

            foreach (Student student in Student.getAll())
            {
                if (LogicUtils.notNullAndContains(student.Forename, search)
                    || LogicUtils.notNullAndContains(student.Surname, search)
                    || student.Id.ToString().Contains(search))
                {
                    allStudents.Rows.Add(
                    student.Id, student.Surname, student.Forename, student.City);
                }
            }

            return allStudents;
        }

        /// <summary>
        /// Generates the standard Student DataTable for this class.
        /// </summary>
        /// <returns></returns>
        private DataTable generatateStudentTable()
        {
            return LogicUtils.getNewDataTable(
                "StudentNr", "Surname", "Forename", "City");
        }


        /// <summary>
        /// Creates a new Student in the database
        /// </summary>
        /// <param name="?"></param>
        public void createNewStudent(string surname, string forename, string city)
        {
            Student student = new Student();
            student.Surname = surname;
            student.Forename = forename;
            student.City = city;

            student.addToDB();
        }

        /// <summary>
        /// Returns a DataTable containing one or zero Student.
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public override DataTable getById(int studentNr)
        {
            DataTable dtStudent = generatateStudentTable();
            Student student = Student.getById(studentNr);
            if (student != null)
            {
                dtStudent.Rows.Add(
                    student.Id, student.Surname, student.Forename, student.City);
            }
            return dtStudent;

        }

        public void changeStudentProperties(int studentNr, string surname, string forename, string city)
        {
            Student student = Student.getById(studentNr);
            student.Surname = surname;
            student.Forename = forename;
            student.City = city;
            student.update();
        }


        
    }
}
