using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;

namespace CourseManagement.Client.DB
{
    class AppointmentQuery
    {
 
        /// <summary>
        /// Get all Appointments from database.
        /// </summary>
        /// <returns>List of Appointments</returns>
        public static List<Appointment> getAll()
        {
            List<Appointment> qry = (from appointment in DBConfiguration.getContext().Appointments.OfType<Appointment>()
                                     select appointment).ToList();

            return qry;
        }

        /// <summary>
        /// Add's the submitted Appointment to database.
        /// </summary>
        /// <param name="appointment"></param>
        public static void insert(Appointment appointment)
        {
            DBConfiguration.getContext().Appointments.Add(appointment);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Deletes the submitted Appointment from the database.
        /// </summary>
        /// <param name="appointment"></param>
        public static void delete(Appointment appointment)
        {
            DBConfiguration.getContext().Appointments.Remove(appointment);
            DBConfiguration.getContext().SaveChanges();
        }

        /// <summary>
        /// Returns the Appointment who is bound to the given ID.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>Student</returns>
        public static Appointment getById(int appointmentId)
        {
            return (DBConfiguration.getContext().Appointments.Find(appointmentId)) as Appointment;
        }

        /// <summary>
        /// Saves all changes made on the DataContext.
        /// Parameter is Placeholder for a new database-layer
        /// </summary>
        /// <param name="appointment"></param>
        public static void update(Appointment appointment)
        {
            DBConfiguration.getContext().SaveChanges();
        }
               
    }
}