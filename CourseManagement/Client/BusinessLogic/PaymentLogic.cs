﻿using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.BusinessLogic
{
    public class PaymentLogic:AbstractLogic
    {
        /// <summary>
        /// Getting an instance of PaymentLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static PaymentLogic getInstance()
        {
            PaymentLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new PaymentLogic();
            return temp;
        }

        /// <summary>
        /// Method for specific PaymentDataTable-changes to the default DataTable-Method in LogicUtils
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            try
            {
                return LogicUtils.getNewDataTable(new Payment());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Creates a new datatable containing all Payments and returns this datatable
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allPayments = getNewDataTable();

                foreach (Payment payment in Payment.getAll())
                {
                    allPayments.Rows.Add(getNewRow(allPayments, payment));
                }

                return allPayments;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override System.Data.DataTable search(string search)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a datatable and get one Payment by id and fills the datatable with all property names and
        /// the data from the Payment
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public override DataTable getById(int paymentId)
        {
            try
            {
                Payment payment = Payment.getById(paymentId);
                DataTable aPayment = LogicUtils.getNewDataTable(payment);

                aPayment.Rows.Add(getNewRow(aPayment, payment));

                return aPayment;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for specific PaymentRow-changes to the default Row-Method in LogicUtils
        /// </summary>
        /// <param name="table"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DataRow getNewRow(DataTable table, object entity)
        {
            return LogicUtils.getNewRow(table, entity);
        }

        /// <summary>
        /// Get one Payment by id and manages the remove from database of this Payment
        /// </summary>
        /// <param name="paymentId"></param>
        public override void delete(int paymentId)
        {
            try
            {
                Payment.getById(paymentId).delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a new Payment and connect it to the selected Course and Student
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        public void createPayment(int courseId, int studentId)
        {
            try
            {
                Payment payment = new Payment();
                payment.IsPaid = false;
                payment.Student = Student.getById(studentId);
                payment.addToDB();

                Course course = Course.getById(courseId);
                course.Payments.Add(payment);
                course.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return a DataTable containing all Payments of the submitted Student
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public DataTable getByStudent(int studentNr)
        {
            try
            {
                DataTable allOfStudent = getNewDataTable();
                foreach (Payment payment in Student.getById(studentNr).Payments)
                {
                    allOfStudent.Rows.Add(getNewRow(allOfStudent, payment));
                }
                return allOfStudent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calculates the balance of the selected Student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public String getStudentBalance(int studentId)
        {
            decimal sum = 0.00M;
            foreach (Payment aPayment in Payment.getAll())
            {
                if (aPayment.IsPaid == false)
                {
                    Course course = aPayment.Course;
                    sum -= (decimal)course.AmountInEuro;
                }
                else
                {
                    Course course = aPayment.Course;
                    sum += (decimal)course.AmountInEuro;
                }
            } 
            return sum + " €";
        }

        /// <summary>
        /// Return a DataTable containing all Payments of the submitted Course
        /// </summary>
        /// <param name="roomNr"></param>
        /// <returns></returns>
        public DataTable getByCourse(int courseNr)
        {
            try
            {
                DataTable allOfCourse = getNewDataTable();
                foreach (Payment payment in Course.getById(courseNr).Payments)
                {
                    allOfCourse.Rows.Add(getNewRow(allOfCourse, payment));
                }
                return allOfCourse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
