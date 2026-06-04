using HealthCareApp.Models;
using System.Collections.Generic;

namespace HealthCareApp.Repositories
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();

        Appointment GetById(int id);

        void AddAppointment(
            Appointment appointment);

        void UpdateAppointment(
            int id,
            Appointment appointment);

        void DeleteAppointment(int id);
    }
}