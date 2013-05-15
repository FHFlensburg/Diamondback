using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.BusinessLogic
{
    class AppointmentLogic:AbstractLogic
    {
        private AppointmentLogic() { }

        /// <summary>
        /// Getting an instance of AppointmentLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static AppointmentLogic getInstance()
        {
            AppointmentLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new AppointmentLogic();
            return temp;
        }
        

        /// <summary>
        /// Creates a new Appointment by the given parameters.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public int createAppointment(int courseNr, int roomNr, DateTime startDate, DateTime endDate)
        {
            try
            {
                Appointment appointment = new Appointment();
                appointment.Course = Course.getById(courseNr);
                appointment.Room = Room.getById(roomNr);
                appointment.StartDate = startDate;
                appointment.EndDate = endDate;

                appointment.addToDB();

                return appointment.Id;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override DataTable getAll()
        {
            //try/Catch!!!
            throw new NotImplementedException();
        }

        public override DataTable search(string search)
        { //try/Catch!!!
            throw new NotImplementedException();
        }

        public override DataTable getById(int id)
        { //try/Catch!!!
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get one appointment by id manage the remove from database of this appointment
        /// </summary>
        /// <param name="courseNr"></param>
        public override void delete(int appointmentNr)
        {
            try
            {
                Room.getById(appointmentNr).delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }
    }
}
