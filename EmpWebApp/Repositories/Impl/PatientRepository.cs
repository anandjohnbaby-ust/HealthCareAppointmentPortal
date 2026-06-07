using HealthCareApp.Data;
using HealthCareApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HealthCareApp.Repositories.Impl
{
    public class PatientRepository
        : IPatientRepository
    {
        private readonly HealthCareDbContext _context;

        public PatientRepository(
            HealthCareDbContext context)
        {
            _context = context;
        }

        public List<Patient> GetAll()
        {
            return _context.Patients
                .ToList();
        }

        public Patient GetById(int id)
        {
            return _context.Patients
                .FirstOrDefault(
                    p => p.PatientId == id);
        }

        public void AddPatient(
            Patient patient)
        {
            _context.Patients
                .Add(patient);

            _context.SaveChanges();
        }

        public void UpdatePatient(
            int id,
            Patient patient)
        {
            Patient existingPatient =
                _context.Patients
                .FirstOrDefault(
                    p => p.PatientId == id);

            if (existingPatient == null)
            {
                return;
            }

            existingPatient.FullName =
                patient.FullName;

            existingPatient.DateOfBirth =
                patient.DateOfBirth;

            existingPatient.Gender =
                patient.Gender;

            existingPatient.PhoneNumber =
                patient.PhoneNumber;

            existingPatient.Email =
                patient.Email;

            existingPatient.InsuranceId =
                patient.InsuranceId;

            _context.SaveChanges();
        }

        public void DeletePatient(
            int id)
        {
            Patient patient =
                _context.Patients
                .FirstOrDefault(
                    p => p.PatientId == id);

            if (patient != null)
            {
                _context.Patients
                    .Remove(patient);

                _context.SaveChanges();
            }
        }
    }
}