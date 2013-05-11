using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.BusinessLogic
{
    class AppointmentLogic
    {
        /// <summary>
        /// Creates a new Appointment by the given parameters.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void createAppointment(DateTime startDate, DateTime endDate)
        {
            Appointment appointment = new Appointment();
            appointment.StartDate = startDate;
            appointment.EndDate = endDate;

            appointment.addToDB();
        }
    }
}
