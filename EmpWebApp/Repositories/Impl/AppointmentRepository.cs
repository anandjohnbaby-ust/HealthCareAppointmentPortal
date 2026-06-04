using HealthCareApp.Database;
using HealthCareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthCareApp.Repositories.Impl
{
    public class AppointmentRepository
        : IAppointmentRepository
    {
        private readonly
            DataStore _dataStore;

        public AppointmentRepository(
            DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Appointment> GetAll()
        {
            return _dataStore.Appointments;
        }

        public Appointment GetById(int id)
        {
            return _dataStore.Appointments
                .FirstOrDefault(
                    a => a.AppointmentId == id);
        }

        public void AddAppointment(
            Appointment appointment)
        {
            _dataStore.Appointments
                .Add(appointment);
        }

        public void UpdateAppointment(
            int id,
            Appointment appointment)
        {
            Appointment existingAppointment =
                _dataStore.Appointments
                .FirstOrDefault(
                    a => a.AppointmentId == id);

            if (existingAppointment == null)
            {
                return;
            }

            existingAppointment.PatientId =
                appointment.PatientId;

            existingAppointment.DoctorId =
                appointment.DoctorId;

            existingAppointment.ScheduledDate =
                appointment.ScheduledDate;

            existingAppointment.TimeSlot =
                appointment.TimeSlot;

            existingAppointment.Status =
                appointment.Status;

            existingAppointment.CancellationReason =
                appointment.CancellationReason;
        }

        public void DeleteAppointment(
            int id)
        {
            Appointment appointment =
                _dataStore.Appointments
                .FirstOrDefault(
                    a => a.AppointmentId == id);

            if (appointment != null)
            {
                _dataStore.Appointments
                    .Remove(appointment);
            }
        }

        public Appointment
            GetConflictingAppointment(
                int doctorId,
                DateTime date,
                string timeSlot)
        {
            return _dataStore.Appointments
                .FirstOrDefault(a =>
                    a.DoctorId == doctorId
                    &&
                    a.ScheduledDate.Date ==
                    date.Date
                    &&
                    a.TimeSlot ==
                    timeSlot);
        }
    }
}