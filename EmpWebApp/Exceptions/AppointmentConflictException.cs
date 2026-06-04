using System;

namespace HealthCareApp.Exceptions
{
    public class AppointmentConflictException
        : Exception
    {
        public AppointmentConflictException()
            : base(
                "Doctor already has an appointment at the selected date and time.")
        {
        }
    }
}