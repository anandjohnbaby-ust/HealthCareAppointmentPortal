using System;

namespace HealthCareApp.Exceptions
{
    public class PatientAppException : Exception
    {
        public PatientAppException(string message)
            : base(message)
        {
        }
    }
}