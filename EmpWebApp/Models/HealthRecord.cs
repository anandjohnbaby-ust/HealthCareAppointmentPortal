using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HealthCareApp.Models
{
    [ExcludeFromCodeCoverage]
    public class HealthRecord
    {

        [Key]
        public int RecordId { get; set; }

        [Required(
            ErrorMessage =
            "Appointment is required")]
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public Patient Patient { get; set; }

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