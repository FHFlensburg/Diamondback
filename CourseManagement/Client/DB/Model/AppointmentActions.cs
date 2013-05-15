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
            try
            {
                AppointmentQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Appointment> getAll()
        {
            try
            {
                return AppointmentQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void delete()
        {
            try
            {
                AppointmentQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void update()
        {
            try
            {
                AppointmentQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Appointment getById(int appointmentId)
        {
            try
            {
                return AppointmentQuery.getById(appointmentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
