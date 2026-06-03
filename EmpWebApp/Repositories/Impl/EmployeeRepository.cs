using EmpWebApp.Database;
using EmpWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpWebApp.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void AddEmployee(Employee employee)
        {
            EmployeeDb.Employees.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            var employee = EmployeeDb.Employees.First(x => x.Id == id);
            EmployeeDb.Employees.Remove(employee);
              

        }

        public List<Employee> GetAll()
        {
            return EmployeeDb.Employees;
        }

        public Employee GetById(int id)
        {
            return EmployeeDb.Employees.Single(x => x.Id == id);
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = EmployeeDb.Employees.First(x => x.Id == id);
            existingEmployee.Name = employee.Name;
            existingEmployee.Gender = employee.Gender;
            existingEmployee.Age = employee.Age;
            existingEmployee.Salary = employee.Salary;
        }
    }
}