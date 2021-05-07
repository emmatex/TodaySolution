using System;

namespace Core.Entities
{
    public class Patient
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public string BloodGroup { get; set; }
        public string PhoneNumber { get; set; }
        public string TreatmentDetails { get; set; }
        public DateTime Date { get; set; }
        public int Age { get; set; }
        public string DoctorName { get; set; }
       // public decimal Charge { get; set; }
        public string Charge { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
