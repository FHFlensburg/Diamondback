using System;
using CourseManagement.Client.DB.Model;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Class to create Test Data
    /// </summary>
    public static class  TestData
    {
        /// <summary>
        /// Generates some Data for Testing
        /// </summary>
        public static void generateTestData()
        {
            
            for(int i = 0; i<10;i++)
            {
                bool unterschied =false;
                if(i%2==0) unterschied = true;
                new Student() {Forename = "VorStud"+i,
                    Surname="NachStud"+i,
                    City ="Stadt"+i}.addToDB();
                new User() {Forename = "VorUse"+i,
                    Surname="NachUse"+i,
                    City ="Stadt"+i,
                    Admin = unterschied}.addToDB();
                new Tutor() {Forename = "VorTut"+i,
                    Surname="NachTut"+i,
                    City ="Stadt"+i}.addToDB();                   
            }

            for(int i = 0; i<10;i++)
            {
                bool unterschied =false;
                if(i%2==0) unterschied = true;

                Appointment appointment = new Appointment();
                appointment.StartDate=DateTime.Now;
                appointment.EndDate=DateTime.UtcNow;
                appointment.Room = new Room() { Building = "Building" + i };

                Payment payment = new Payment();
                payment.IsPaid = unterschied;
                payment.Student = Student.getAll()[i];

                Course course = new Course();
                course.Tutor=Tutor.getAll()[i];
                course.MaxMember=i+10;
                course.MinMember=i+5;
                course.Title="Englisch für Anfänger"+i;
                course.ValidityInMonth=25;
                course.AmountInEuro = 14;
                course.Appointments.Add(appointment);
                course.Payments.Add(payment);
                course.addToDB();
                
                                                            
            }

            new User() { UserName = "admin", Password = "admin", Active = true, Admin = true }.addToDB();
            new User() { UserName = "user", Password = "user", Active = true, Admin = false }.addToDB();

        }
    }
}
