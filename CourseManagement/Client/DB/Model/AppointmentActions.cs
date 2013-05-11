using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    public partial class Appointment
    {
        public void addToDB()
        {
            AppointmentQuery.insert(this);
        }

        public static List<Appointment> getAll()
        {
            return AppointmentQuery.getAll();
        }

        public void delete()
        {
            AppointmentQuery.delete(this);
        }

        public void update()
        {
            AppointmentQuery.update(this);
        }

        public static Appointment getById(int appointmentId)
        {
            return AppointmentQuery.getById(appointmentId);
        }
    }
}
