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
            var container =
                new UnityContainer();


            // Patient
            container.RegisterType<
                IPatientRepository,
                PatientRepository>();

            container.RegisterType<
                IPatientService,
                PatientService>();

            // Doctor
            container.RegisterType<
                IDoctorRepository,
                DoctorRepository>();

            container.RegisterType<
                IDoctorService,
                DoctorService>();

            // Appointment
            container.RegisterType<
                IAppointmentRepository,
                AppointmentRepository>();

            container.RegisterType<
                IAppointmentService,
                AppointmentService>();

            // Health Record
            container.RegisterType<
                IHealthRecordRepository,
                HealthRecordRepository>();

            container.RegisterType<
                IHealthRecordService,
                HealthRecordService>();

            DependencyResolver.SetResolver(
                new UnityDependencyResolver(
                    container));
        }
    }
}