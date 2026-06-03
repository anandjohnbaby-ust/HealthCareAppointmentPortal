using EmpWebApp.Models;
using EmpWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController()
        {
             
        }
        public EmployeeController(IEmployeeService service)
        {
            _service=service;
        }
        // GET: Employee
        public ActionResult Index()
        {

            var employees = _service.GetAll();
            return View(employees);
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            _service.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var employee=_service.GetById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
          _service.UpdateEmployee(employee.Id, employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var employee= _service.GetById(id);
            return View(employee);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            _service.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}