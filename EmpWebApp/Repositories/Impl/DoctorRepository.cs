using HealthCareApp.Database;
using HealthCareApp.Enums;
using HealthCareApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HealthCareApp.Repositories.Impl
{
    public class DoctorRepository
        : IDoctorRepository
    {
        private readonly DataStore _dataStore;

        public DoctorRepository(
            DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Doctor> GetAll()
        {
            return _dataStore.Doctors;
        }

        public Doctor GetById(int id)
        {
            return _dataStore.Doctors
                .FirstOrDefault(
                    d => d.DoctorId == id);
        }

        public void AddDoctor(
            Doctor doctor)
        {
            _dataStore.Doctors
                .Add(doctor);
        }

        public void UpdateDoctor(
            int id,
            Doctor doctor)
        {
            Doctor existingDoctor =
                _dataStore.Doctors
                .FirstOrDefault(
                    d => d.DoctorId == id);

            if (existingDoctor == null)
            {
                return;
            }

            existingDoctor.FullName =
                doctor.FullName;

            existingDoctor.Specialisation =
                doctor.Specialisation;

            existingDoctor.YearsOfExperience =
                doctor.YearsOfExperience;

            existingDoctor.ConsultationFee =
                doctor.ConsultationFee;

            existingDoctor.IsActive =
                doctor.IsActive;
        }

        public void DeleteDoctor(
            int id)
        {
            Doctor doctor =
                _dataStore.Doctors
                .FirstOrDefault(
                    d => d.DoctorId == id);

            if (doctor != null)
            {
                _dataStore.Doctors
                    .Remove(doctor);
            }
        }
        public List<Doctor>
        GetDoctorsBySpecialisation(
            Specialisation specialisation)
            {
                return _dataStore.Doctors
                    .Where(d =>
                        d.Specialisation ==
                        specialisation)
                    .ToList();
            }
    }
}