using HealthCareApp.Exceptions;
using HealthCareApp.Models;
using HealthCareApp.Repositories;
using System;
using System.Collections.Generic;

namespace HealthCareApp.Services.Impl
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public void AddPatient(Patient patient)
        {
            _repository.AddPatient(patient);
        }

        public void DeletePatient(int id)
        {
            try
            {
                _repository.DeletePatient(id);
            }
            catch (Exception ex)
            {
                throw new PatientAppException(ex.Message);
            }
        }

        public List<Patient> GetAll()
        {
            return _repository.GetAll();
        }

        public Patient GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new PatientAppException(ex.Message);
            }
        }

        public void UpdatePatient(int id, Patient patient)
        {
            try
            {
                _repository.UpdatePatient(id, patient);
            }
            catch (Exception ex)
            {
                throw new PatientAppException(ex.Message);
            }
        }
    }
}