using CourseManagement.Client.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourseManagement.Client.DB.Model
{
    public partial class Tutor : Person
    {
        public void addToDB()
        {
            TutorQuery.insert(this);
        }

        public static List<Tutor> getAll()
        {
            return TutorQuery.getAll();
        }

        public static void delete(Tutor tutor)
        {
            TutorQuery.delete(tutor);
        }

        public static void update(Tutor tutor)
        {
            TutorQuery.update(tutor);
        }

        public static Tutor getById(int tutorId)
        {
            return TutorQuery.getById(tutorId);
        }

        public static List<Tutor> search(string like)
        {
            return TutorQuery.search(like);
        }


    }
}
