using HealthCareApp.Enums;
using HealthCareApp.Models;
using HealthCareApp.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HealthCareApp.Controllers
{
    public class AppointmentController
        : Controller
    {
        private readonly
            IAppointmentService _appointmentService;

        private readonly
            IPatientService _patientService;

        private readonly
            IDoctorService _doctorService;

        public AppointmentController(
            IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService)
        {
            _appointmentService =
                appointmentService;

            _patientService =
                patientService;

            _doctorService =
                doctorService;
        }

        public ActionResult Index()
        {
            var appointments =
                _appointmentService.GetAll();

            foreach (var appointment
                in appointments)
            {
                appointment.Patient =
                    _patientService.GetById(
                        appointment.PatientId);

                appointment.Doctor =
                    _doctorService.GetById(
                        appointment.DoctorId);
            }

            return View(appointments);
        }

        public ActionResult Create()
        {
            LoadDropdowns();

            return View();
        }

        public ActionResult Edit(int id)
        {
            Appointment appointment =
                _appointmentService
                .GetById(id);

            LoadDropdowns();

            return View(appointment);
        }

        [HttpPost]
        public ActionResult Edit(
            Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();

                return View(appointment);
            }

            _appointmentService
                .UpdateAppointment(
                    appointment.AppointmentId,
                    appointment);

            return RedirectToAction(
                "Index");
        }

        public ActionResult Delete(int id)
        {
            Appointment appointment =
                _appointmentService
                .GetById(id);

            appointment.Patient =
                _patientService.GetById(
                    appointment.PatientId);

            appointment.Doctor =
                _doctorService.GetById(
                    appointment.DoctorId);

            return View(appointment);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(
            int id)
        {
            _appointmentService
                .DeleteAppointment(id);

            return RedirectToAction(
                "Index");
        }

        private void LoadDropdowns()
        {
            ViewBag.Patients =
                new SelectList(
                    _patientService.GetAll(),
                    "PatientId",
                    "FullName");

            ViewBag.Doctors =
                new SelectList(
                    _doctorService.GetAll(),
                    "DoctorId",
                    "FullName");

            ViewBag.Statuses =
                Enum.GetValues(
                    typeof(AppointmentStatus))
                .Cast<AppointmentStatus>();
        }

        [HttpPost]
        public ActionResult Create(
    Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();

                return View(appointment);
            }

            try
            {
                _appointmentService
                    .AddAppointment(
                        appointment);

                return RedirectToAction(
                    "Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    "",
                    ex.Message);

                LoadDropdowns();

                return View(appointment);
            }
        }
        public ActionResult Confirm(int id)
        {
            _appointmentService
                .ConfirmAppointment(id);

            return RedirectToAction("Index");
        }

        public ActionResult Complete(int id)
        {
            _appointmentService
                .CompleteAppointment(id);

            return RedirectToAction("Index");
        }

        //public ActionResult Cancel(int id)
        //{
        //    Appointment appointment =
        //        _appointmentService
        //        .GetById(id);

        //    return View(appointment);
        //}
        public ActionResult Cancel(int id)
        {
            _appointmentService
                .CancelAppointment(
                    id,
                    "Cancelled by user");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Cancel(
    int id,
    string reason)
        {
            _appointmentService
                .CancelAppointment(
                    id,
                    reason);

            return RedirectToAction(
                "Index");
        }
    }
}