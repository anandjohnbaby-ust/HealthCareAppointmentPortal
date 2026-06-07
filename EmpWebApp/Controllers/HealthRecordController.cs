using HealthCareApp.Enums;
using HealthCareApp.Models;
using HealthCareApp.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HealthCareApp.Controllers
{
    public class HealthRecordController : Controller
    {
        private readonly IHealthRecordService _recordService;

        private readonly IAppointmentService _appointmentService;

        private readonly IPatientService _patientService;

        private readonly IDoctorService _doctorService;

        public HealthRecordController(
            IHealthRecordService recordService,
            IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService)
        {
            _recordService = recordService;

            _appointmentService = appointmentService;

            _patientService = patientService;

            _doctorService = doctorService;
        }

        public ActionResult Index()
        {
            var records =
                _recordService.GetAll();

            foreach (var record in records)
            {
                if (record.Patient == null ||
                    record.Doctor == null)
                {
                    var appointment =
                        _appointmentService
                        .GetById(
                            record.AppointmentId);

                    if (appointment != null)
                    {
                        record.Patient =
                            _patientService
                            .GetById(
                                appointment.PatientId);

                        record.Doctor =
                            _doctorService
                            .GetById(
                                appointment.DoctorId);
                    }
                }
            }

            return View(records);
        }

        // Show only completed appointments
        public ActionResult Create()
        {
            var completedAppointments =
                _appointmentService
                .GetCompletedAppointments()
                .Where(a =>
                    _recordService
                    .GetByAppointmentId(
                        a.AppointmentId) == null)
                .ToList();

            foreach (var appointment
                in completedAppointments)
            {
                appointment.Patient =
                    _patientService
                    .GetById(
                        appointment.PatientId);

                appointment.Doctor =
                    _doctorService
                    .GetById(
                        appointment.DoctorId);
            }

            return View(
                completedAppointments);
        }

        // Open health record form
        public ActionResult CreateFromAppointment(
            int appointmentId)
        {
            var appointment =
                _appointmentService
                .GetById(
                    appointmentId);

            if (appointment == null)
            {
                return HttpNotFound();
            }

            appointment.Patient =
                _patientService
                .GetById(
                    appointment.PatientId);

            appointment.Doctor =
                _doctorService
                .GetById(
                    appointment.DoctorId);

            var record =
                new HealthRecord
                {
                    AppointmentId =
                        appointment.AppointmentId,

                    VisitDate =
                        appointment.ScheduledDate,

                    Patient =
                        appointment.Patient,

                    Doctor =
                        appointment.Doctor,

                    Diagnosis = "",

                    Prescription = "",

                    Notes = ""
                };

            return View(record);
        }

        [HttpPost]
        public ActionResult CreateFromAppointment(
    HealthRecord record)
        {
            if (!ModelState.IsValid)
            {
                return View(record);
            }

            var appointment =
                _appointmentService
                .GetById(
                    record.AppointmentId);

            if (appointment == null)
            {
                return HttpNotFound();
            }

            record.PatientId =
                appointment.PatientId;

            record.DoctorId =
                appointment.DoctorId;

            record.VisitDate =
                appointment.ScheduledDate;

            record.Patient = null;

            record.Doctor = null;

            _recordService.AddRecord(
                record);

            return RedirectToAction(
                "Index");
        }

        public ActionResult Edit(int id)
        {
            var record =
                _recordService.GetById(id);

            if (record == null)
            {
                return HttpNotFound();
            }

            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(
            HealthRecord record)
        {
            if (!ModelState.IsValid)
            {
                return View(record);
            }

            _recordService.UpdateRecord(
                record.RecordId,
                record);

            return RedirectToAction(
                "Index");
        }

        public ActionResult Delete(int id)
        {
            var record =
                _recordService.GetById(id);

            if (record == null)
            {
                return HttpNotFound();
            }

            record.Patient =
                _patientService.GetById(
                    record.PatientId);

            record.Doctor =
                _doctorService.GetById(
                    record.DoctorId);

            return View(record);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(
            int id)
        {
            _recordService.DeleteRecord(id);

            return RedirectToAction(
                "Index");
        }
    }
}