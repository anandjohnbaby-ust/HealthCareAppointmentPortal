using System;

namespace HealthCareApp.Exceptions
{
    public class AppointmentNotCompletedException
        : Exception
    {
        public AppointmentNotCompletedException()
            : base(
                "Health Record can only be added for completed appointments.")
        {
        }
    }
}