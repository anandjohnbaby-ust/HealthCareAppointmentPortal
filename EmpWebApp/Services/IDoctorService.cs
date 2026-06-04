using HealthCareApp.Enums;
using HealthCareApp.Models;
using System.Collections.Generic;

namespace HealthCareApp.Services
{
    public interface IDoctorService
    {
        List<Doctor> GetAll();

        Doctor GetById(int id);

        void AddDoctor(Doctor doctor);

        void UpdateDoctor(
            int id,
            Doctor doctor);

        void DeleteDoctor(int id);

        List<Doctor> GetDoctorsBySpecialisation(
    Specialisation specialisation);
    }
}