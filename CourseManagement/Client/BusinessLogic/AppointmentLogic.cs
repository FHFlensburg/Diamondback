using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
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
        public static void createAppointment(DateTime startDate, DateTime endDate)
        {
            Appointment appointment = new Appointment();
            appointment.StartDate = startDate;
            appointment.EndDate = endDate;

            appointment.addToDB();
        }

        public override System.Data.DataTable getAll()
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataTable search(string search)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataTable getById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
