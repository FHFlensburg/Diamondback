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
        public override void addToDB()
        {
            TutorQuery.insert(this);
        }

        public  static new List<Tutor> getAll()
        {
            return TutorQuery.getAll();
        }

        public override void delete()
        {
            TutorQuery.delete(this);
        }

        public override void update()
        {
            TutorQuery.update(this);
        }

        public static new Tutor getById(int tutorId)
        {
            return TutorQuery.getById(tutorId);
        }




    }
}
