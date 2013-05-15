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
            try
            {
                DataTable allStudents = generatateStudentTable();


                foreach (Student student in Student.getAll())
                {
                    allStudents.Rows.Add(
                    student.Id, student.Surname, student.Forename, student.City);
                }

                return allStudents;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        public override DataTable search(string search)
        {
            try
            {
                DataTable allStudents = generatateStudentTable();

                foreach (Student student in Student.getAll())
                {
                    if (LogicUtils.notNullAndContains(student.Forename, search)
                        || LogicUtils.notNullAndContains(student.Surname, search)
                        || student.Id.ToString().Contains(search))//---to correct!
                    {
                        allStudents.Rows.Add(
                        student.Id, student.Surname, student.Forename, student.City);
                    }
                }

                return allStudents;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        //depricated
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
            try
            {
                Student student = new Student();
                student.Surname = surname;
                student.Forename = forename;
                student.City = city;

                student.addToDB();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Returns a DataTable containing one or zero Student.
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public override DataTable getById(int studentNr)
        {
            try
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        public void changeStudentProperties(int studentNr, string surname, string forename, string city)
        {
            try
            {
                Student student = Student.getById(studentNr);
                student.Surname = surname;
                student.Forename = forename;
                student.City = city;
                student.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Get one student by id manage the remove from database of this student
        /// </summary>
        /// <param name="courseNr"></param>
        public override void delete(int studentNr)
        {
            try
            {
                Student.getById(studentNr).delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }
        
    }
}
