using EmpWebApp.Repositories;
using EmpWebApp.Repositories.Impl;
using EmpWebApp.Services;
using EmpWebApp.Services.Impl;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace EmpWebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmployeeService,EmployeeService>();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}