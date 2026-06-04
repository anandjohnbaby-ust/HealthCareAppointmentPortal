using HealthCareApp.Models;
using System.Collections.Generic;

namespace HealthCareApp.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();

        Patient GetById(int id);

        void AddPatient(Patient patient);

        void UpdatePatient(int id, Patient patient);

        void DeletePatient(int id);
    }
}