using HealthCareApp.Data;
using HealthCareApp.Enums;
using HealthCareApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HealthCareApp.Repositories.Impl
{
    public class DoctorRepository
        : IDoctorRepository
    {
        private readonly HealthCareDbContext _context;

        public DoctorRepository(
            HealthCareDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            return _context.Doctors
                .FirstOrDefault(
                    d => d.DoctorId == id);
        }

        public void AddDoctor(
            Doctor doctor)
        {
            _context.Doctors
                .Add(doctor);

            _context.SaveChanges();
        }

        public void UpdateDoctor(
            int id,
            Doctor doctor)
        {
            Doctor existingDoctor =
                _context.Doctors
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

            _context.SaveChanges();
        }

        public void DeleteDoctor(
            int id)
        {
            Doctor doctor =
                _context.Doctors
                .FirstOrDefault(
                    d => d.DoctorId == id);

            if (doctor != null)
            {
                _context.Doctors
                    .Remove(doctor);

                _context.SaveChanges();
            }
        }

        public List<Doctor>
        GetDoctorsBySpecialisation(
            Specialisation specialisation)
        {
            return _context.Doctors
                .Where(d =>
                    d.Specialisation ==
                    specialisation)
                .ToList();
        }
    }
}