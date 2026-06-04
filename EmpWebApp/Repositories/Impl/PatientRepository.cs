using HealthCareApp.Database;
using HealthCareApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HealthCareApp.Repositories.Impl
{
    public class PatientRepository
        : IPatientRepository
    {
        private readonly DataStore _dataStore;

        public PatientRepository(
            DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Patient> GetAll()
        {
            return _dataStore.Patients;
        }

        public Patient GetById(int id)
        {
            return _dataStore.Patients
                .FirstOrDefault(
                    p => p.PatientId == id);
        }

        public void AddPatient(
            Patient patient)
        {
            _dataStore.Patients
                .Add(patient);
        }

        public void UpdatePatient(
            int id,
            Patient patient)
        {
            Patient existingPatient =
                _dataStore.Patients
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
        }

        public void DeletePatient(
            int id)
        {
            Patient patient =
                _dataStore.Patients
                .FirstOrDefault(
                    p => p.PatientId == id);

            if (patient != null)
            {
                _dataStore.Patients
                    .Remove(patient);
            }
        }
    }
}