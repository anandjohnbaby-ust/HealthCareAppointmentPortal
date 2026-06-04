using HealthCareApp.Enums;
using HealthCareApp.Models;
using HealthCareApp.Repositories;
using System.Collections.Generic;

namespace HealthCareApp.Services.Impl
{
    public class DoctorService
        : IDoctorService
    {
        private readonly
            IDoctorRepository _repository;

        public DoctorService(
            IDoctorRepository repository)
        {
            _repository = repository;
        }

        public List<Doctor> GetAll()
        {
            return _repository.GetAll();
        }

        public Doctor GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddDoctor(
            Doctor doctor)
        {
            _repository.AddDoctor(doctor);
        }

        public void UpdateDoctor(
            int id,
            Doctor doctor)
        {
            _repository.UpdateDoctor(
                id,
                doctor);
        }

        public void DeleteDoctor(
            int id)
        {
            _repository.DeleteDoctor(id);
        }

        public List<Doctor>
    GetDoctorsBySpecialisation(
        Specialisation specialisation)
        {
            return _repository
                .GetDoctorsBySpecialisation(
                    specialisation);
        }
    }
}