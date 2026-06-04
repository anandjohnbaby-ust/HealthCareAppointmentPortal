using HealthCareApp.Models;
using System.Collections.Generic;

namespace HealthCareApp.Services
{
    public interface IAppointmentService
    {
        List<Appointment> GetAll();

        Appointment GetById(int id);

        void AddAppointment(
            Appointment appointment);

        void UpdateAppointment(
            int id,
            Appointment appointment);

        void DeleteAppointment(int id);

        void ConfirmAppointment(int id);

        void CompleteAppointment(int id);

        void CancelAppointment(
            int id,
            string reason);
    }
}