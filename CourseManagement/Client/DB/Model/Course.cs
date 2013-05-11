//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseManagement.Client.DB.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public Course()
        {
            this.Payments = new HashSet<Payment>();
            this.Appointment = new HashSet<Appointment>();
        }
    
        public int CourseNr { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> AmountInEuro { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> MaxMember { get; set; }
        public Nullable<decimal> MinMember { get; set; }
        public Nullable<decimal> ValidityInMonth { get; set; }
    
        public virtual Tutor Tutor { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
