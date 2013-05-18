using CourseManagement.Client.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Person_Tutor Model
    /// </summary>
    public partial class Tutor : Person
    {
        public override void addToDB()
        {
            try
            {
                TutorQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static new List<Tutor> getAll()
        {
            try
            {
                return TutorQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void delete()
        {
            try
            {
                TutorQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void update()
        {
            try
            {
                TutorQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static new Tutor getById(int tutorId)
        {
            try
            {
                return TutorQuery.getById(tutorId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
