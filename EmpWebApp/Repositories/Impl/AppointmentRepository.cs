using HealthCareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using HealthCareApp.Data;
using System.Data.Entity;

namespace HealthCareApp.Repositories.Impl
{
    public class AppointmentRepository
        : IAppointmentRepository
    {
        private readonly
            HealthCareDbContext _context;

        public AppointmentRepository(
            HealthCareDbContext context)
        {
            _context = context;
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments
                .FirstOrDefault(
                    a => a.AppointmentId == id);
        }

        public void AddAppointment(
            Appointment appointment)
        {
            _context.Appointments
                .Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(
            int id,
            Appointment appointment)
        {
            Appointment existingAppointment =
                _context.Appointments
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

            _context.SaveChanges();
        }

        public void DeleteAppointment(
            int id)
        {
            Appointment appointment =
                _context.Appointments
                .FirstOrDefault(
                    a => a.AppointmentId == id);

            if (appointment != null)
            {
                _context.Appointments
                    .Remove(appointment);
                _context.SaveChanges();
            }
        }

        public Appointment
            GetConflictingAppointment(
                int doctorId,
                DateTime date,
                string timeSlot)
        {
            return _context.Appointments
                .FirstOrDefault(a =>
                    a.DoctorId == doctorId
                    &&
                    DbFunctions.TruncateTime(
                        a.ScheduledDate)
                    ==
                    DbFunctions.TruncateTime(
                        date)
                    &&
                    a.TimeSlot ==
                    timeSlot);
        }
    }
}