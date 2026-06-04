using System;

namespace HealthCareApp.Exceptions
{
    public class HealthRecordAlreadyExistsException
        : Exception
    {
        public HealthRecordAlreadyExistsException()
            : base(
                "Health Record already exists for this appointment.")
        {
        }
    }
}