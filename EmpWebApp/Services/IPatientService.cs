using HealthCareApp.Models;
using System.Collections.Generic;

namespace HealthCareApp.Services
{
    public interface IPatientService
    {
        List<Patient> GetAll();

        Patient GetById(int id);

        void AddPatient(Patient patient);

        void UpdatePatient(int id, Patient patient);

        void DeletePatient(int id);
    }
}