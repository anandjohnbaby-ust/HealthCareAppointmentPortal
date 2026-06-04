using HealthCareApp.Models;
using HealthCareApp.Services;
using System.Web.Mvc;

namespace HealthCareApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;

        public PatientController()
        {

        }

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var patients = _service.GetAll();
            return View(patients);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            _service.AddPatient(patient);

            return RedirectToAction("Index");
        }

        // GET: Patient/Edit/1
        public ActionResult Edit(int id)
        {
            var patient = _service.GetById(id);

            if (patient == null)
            {
                return HttpNotFound();
            }

            return View(patient);
        }

        // POST: Patient/Edit
        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            _service.UpdatePatient(
                patient.PatientId,
                patient);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var patient = _service.GetById(id);
            return View(patient);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            _service.DeletePatient(id);
            return RedirectToAction("Index");
        }
    }
}