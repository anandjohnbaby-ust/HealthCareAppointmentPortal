using HealthCareApp.Models;
using System.Data.Entity;

namespace HealthCareApp.Data
{
    public class HealthCareDbContext : DbContext
    {
        public HealthCareDbContext()
            : base("HealthCareDbContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
    }
}