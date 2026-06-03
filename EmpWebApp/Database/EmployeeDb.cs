using EmpWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpWebApp.Database
{
    public static class EmployeeDb
    {
        public static List<Employee>  Employees { get; set; }

        static EmployeeDb()
        {
            Employees = new List<Employee>
            {
                new Employee{Id=1,Name="John",Gender="Male",Age=27,Salary=78000},
                new Employee{Id=2,Name="Asha",Gender="Female",Age=21,Salary=65000},
                new Employee{Id=3,Name="Anu",Gender="Female",Age=22,Salary=56000},
                new Employee{Id=4,Name="Sunil",Gender="Male",Age=33,Salary=89000},
                new Employee{Id=5,Name="Mary",Gender="Female",Age=21,Salary=45000}
            };
        }
    }
}