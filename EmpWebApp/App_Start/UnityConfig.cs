using HealthCareApp.Database;
using HealthCareApp.Repositories;
using HealthCareApp.Repositories.Impl;
using HealthCareApp.Services;
using HealthCareApp.Services.Impl;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace HealthCareApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IPatientRepository, PatientRepository>();

            container.RegisterType<IPatientService, PatientService>();

            container.RegisterSingleton<DataStore>();

            container.RegisterType<
                IDoctorRepository,
                DoctorRepository>();

            container.RegisterType<
                IDoctorService,
                DoctorService>();

            container.RegisterType<
                IPatientRepository,
                PatientRepository>();

            container.RegisterType<
                IPatientService,
                PatientService>();

            container.RegisterType<
    IAppointmentRepository,
    AppointmentRepository>();

            container.RegisterType<
                IAppointmentService,
                AppointmentService>();

            DependencyResolver.SetResolver(
                new UnityDependencyResolver(container));
        }
    }
}