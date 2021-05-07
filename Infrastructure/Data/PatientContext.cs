using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Patient>().Property(a => a.Id).IsRequired().HasMaxLength(128);
            builder.Entity<Patient>().Property(a => a.PatientName).IsRequired().HasMaxLength(256);
            builder.Entity<Patient>().Property(a => a.Date).IsRequired();
            builder.Entity<Patient>().Property(a => a.Age).IsRequired();
            builder.Entity<Patient>().Property(a => a.DateOfBirth).IsRequired();
            builder.Entity<Patient>().Property(a => a.PhoneNumber).IsRequired().HasMaxLength(100);
            builder.Entity<Patient>().Property(a => a.DoctorName).IsRequired().HasMaxLength(256);
            builder.Entity<Patient>().Property(a => a.Charge).IsRequired().HasConversion<decimal>();
            builder.Entity<Patient>().Property(a => a.TreatmentDetails).IsRequired().HasMaxLength(500);
            builder.Entity<Patient>().Property(a => a.BloodGroup).IsRequired().HasMaxLength(100); 
        }
    }
}
