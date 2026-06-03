using EmpWebApp.Exceptions;
using EmpWebApp.Models;
using EmpWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpWebApp.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository=repository;
        }
        public void AddEmployee(Employee employee)
        {
            _repository.AddEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                _repository.DeleteEmployee(id);
            }
            catch(Exception ex)
            {
                throw new EmployeeAppException(ex.Message);
            }
        }

        public List<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public Employee GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch(Exception ex)
            {
                throw new EmployeeAppException(ex.Message);
            }
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            try
            {
                _repository.UpdateEmployee(id, employee);
            }
            catch (Exception ex)
            {
                throw new EmployeeAppException(ex.Message);
            }
        }
    }
}