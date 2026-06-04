using System;

namespace HealthCareApp.Exceptions
{
    public class AppointmentTimeConflictException
        : Exception
    {
        public AppointmentTimeConflictException()
            : base(
                "Doctor already has an appointment at this date and time.")
        {
        }
    }
}