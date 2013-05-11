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
    public static class StudentLogic
    {

        /// <summary>
        /// Returns a DataTable containing all Students in DB
        /// </summary>
        /// <returns></returns>
        public static DataTable getAllStudents()
        {
            DataTable allStudents = generatateStudentTable();


            foreach (Student student in Student.getAll())
            {
                allStudents.Rows.Add(
                student.Id, student.Surname, student.Forename, student.City);
            }

            return allStudents;
        }

        public static DataTable searchStudents(string search)
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
        private static DataTable generatateStudentTable()
        {
            return LogicUtils.getNewDataTable(
                "StudentNr", "Surname", "Forename", "City");
        }


        /// <summary>
        /// Creates a new Student in the database
        /// </summary>
        /// <param name="?"></param>
        public static void createNewStudent(string surname, string forename, string city)
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
        public static DataTable getStudent(int studentNr)
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

        public static void changeStudentProperties(int studentNr, string surname, string forename, string city)
        {
            Student student = Student.getById(studentNr);
            student.Surname = surname;
            student.Forename = forename;
            student.City = city;
            student.update();
        }


        
    }
}
