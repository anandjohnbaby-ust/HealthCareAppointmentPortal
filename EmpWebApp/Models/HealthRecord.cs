using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HealthCareApp.Models
{
    [ExcludeFromCodeCoverage]
    public class HealthRecord
    {
        private static int _recordCounter = 1;

        public int RecordId { get; set; }
            = _recordCounter++;

        public static void SetRecordCounter(
            int value)
        {
            _recordCounter = value;
        }

        [Required(
            ErrorMessage =
            "Appointment is required")]
        public int AppointmentId { get; set; }

        //[Required(
        //    ErrorMessage =
        //    "Patient is required")]
        public Patient Patient { get; set; }

        //[Required(
        //    ErrorMessage =
        //    "Doctor is required")]
        public Doctor Doctor { get; set; }

        [Required(
            ErrorMessage =
            "Visit Date is required")]
        [DataType(
            DataType.Date)]
        public DateTime VisitDate { get; set; }

        [Required(
            ErrorMessage =
            "Diagnosis is required")]
        public string Diagnosis { get; set; }
            = string.Empty;

        [Required(
            ErrorMessage =
            "Prescription is required")]
        public string Prescription { get; set; }
            = string.Empty;

        public string Notes { get; set; }
            = string.Empty;

        public string GetSummary()
        {
            return string.Format(
                "Record Id: {0}, Appointment Id: {1}, Patient: {2}, Doctor: {3}, Diagnosis: {4}",
                RecordId,
                AppointmentId,
                Patient?.FullName,
                Doctor?.FullName,
                Diagnosis);
        }
    }
}