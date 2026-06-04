using System;

namespace HealthCareApp.Exceptions
{
    public class PastDateException
        : Exception
    {
        public PastDateException()
            : base(
                "Appointment date cannot be in the past.")
        {
        }
    }
}