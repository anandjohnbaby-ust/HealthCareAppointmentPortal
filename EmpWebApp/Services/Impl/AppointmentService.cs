using HealthCareApp.Models;
using HealthCareApp.Repositories;
using System.Collections.Generic;

namespace HealthCareApp.Services.Impl
{
    public class AppointmentService
        : IAppointmentService
    {
        private readonly
            IAppointmentRepository _repository;

        public AppointmentService(
            IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public List<Appointment> GetAll()
        {
            return _repository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddAppointment(
            Appointment appointment)
        {
            _repository.AddAppointment(
                appointment);
        }

        public void UpdateAppointment(
            int id,
            Appointment appointment)
        {
            _repository.UpdateAppointment(
                id,
                appointment);
        }

        public void DeleteAppointment(
            int id)
        {
            _repository.DeleteAppointment(id);
        }
    }
}