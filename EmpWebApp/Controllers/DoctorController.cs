using HealthCareApp.Enums;
using HealthCareApp.Models;
using HealthCareApp.Services;
using System;
using System.Web.Mvc;

namespace HealthCareApp.Controllers
{
    public class DoctorController
        : Controller
    {
        private readonly
            IDoctorService _service;

        public DoctorController(
            IDoctorService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var doctors =
                _service.GetAll();

            return View(doctors);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            _service.AddDoctor(doctor);

            return RedirectToAction(
                "Index");
        }

        public ActionResult Edit(int id)
        {
            var doctor =
                _service.GetById(id);

            return View(doctor);
        }

        [HttpPost]
        public ActionResult Edit(
            Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            _service.UpdateDoctor(
                doctor.DoctorId,
                doctor);

            return RedirectToAction(
                "Index");
        }

        public ActionResult Delete(int id)
        {
            var doctor =
                _service.GetById(id);

            return View(doctor);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(
            int id)
        {
            _service.DeleteDoctor(id);

            return RedirectToAction(
                "Index");
        }

        public ActionResult Search()
        {
            ViewBag.Specialisations =
                Enum.GetValues(
                    typeof(Specialisation));

            return View();
        }

        [HttpPost]
        public ActionResult Search(
    Specialisation specialisation)
        {
            var doctors =
                _service
                .GetDoctorsBySpecialisation(
                    specialisation);

            ViewBag.Specialisations =
                Enum.GetValues(
                    typeof(Specialisation));

            return View(doctors);
        }
    }
}