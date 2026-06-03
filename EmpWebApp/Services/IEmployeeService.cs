using EmpWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpWebApp.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(int id, Employee employee);
        void DeleteEmployee(int id);
    }
}
