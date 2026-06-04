using HealthCareApp.Enums;
using HealthCareApp.Exceptions;
using HealthCareApp.Models;
using HealthCareApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
            DateTime today =
                DateTime.Today;

            if (appointment.ScheduledDate.Date
                < today)
            {
                throw new
                    PastDateException();
            }

            DateTime maxDate =
                today.AddMonths(6);

            if (appointment.ScheduledDate.Date
                > maxDate)
            {
                throw new
                    AdvanceBookingLimitException();
            }

            Appointment conflict =
                _repository
                .GetConflictingAppointment(
                    appointment.DoctorId,
                    appointment.ScheduledDate,
                    appointment.TimeSlot);

            if (conflict != null)
            {
                throw new
                    AppointmentConflictException();
            }

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

        public void ConfirmAppointment(int id)
        {
            Appointment appointment =
                _repository.GetById(id);

            if (appointment == null)
            {
                throw new Exception(
                    "Appointment not found.");
            }

            if (appointment.Status !=
                AppointmentStatus.Pending)
            {
                throw new Exception(
                    "Only Pending appointments can be confirmed.");
            }

            appointment.Status =
                AppointmentStatus.Confirmed;

            _repository.UpdateAppointment(
                id,
                appointment);
        }

        public void CompleteAppointment(int id)
        {
            Appointment appointment =
                _repository.GetById(id);

            if (appointment == null)
            {
                throw new Exception(
                    "Appointment not found.");
            }

            if (appointment.Status !=
                AppointmentStatus.Confirmed)
            {
                throw new Exception(
                    "Only Confirmed appointments can be completed.");
            }

            appointment.Status =
                AppointmentStatus.Completed;

            _repository.UpdateAppointment(
                id,
                appointment);
        }

        public void CancelAppointment(
    int id,
    string reason)
        {
            Appointment appointment =
                _repository.GetById(id);

            if (appointment == null)
            {
                throw new Exception(
                    "Appointment not found.");
            }

            if (appointment.Status ==
                AppointmentStatus.Completed)
            {
                throw new Exception(
                    "Completed appointments cannot be cancelled.");
            }

            appointment.Status =
                AppointmentStatus.Cancelled;

            appointment.CancellationReason =
                reason;

            _repository.UpdateAppointment(
                id,
                appointment);
        }

        public List<Appointment> GetCompletedAppointments()
        {
            return _repository
                .GetAll()
                .Where(a =>
                    a.Status ==
                    AppointmentStatus.Completed)
                .ToList();
        }
    }
}