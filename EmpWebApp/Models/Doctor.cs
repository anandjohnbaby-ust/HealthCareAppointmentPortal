using HealthCareApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace HealthCareApp.Models
{
    public class Doctor
    {
        private static int _doctorCounter = 1;

        public int DoctorId { get; set; }
            = _doctorCounter++;

        public static void SetDoctorCounter(int value)
        {
            _doctorCounter = value;
        }

        [Required(ErrorMessage = "Full Name is required")]
        [RegularExpression(
            @"^[a-zA-Z.\s]+$",
            ErrorMessage =
            "Only letters, spaces and dots are allowed")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Specialisation is required")]
        public Specialisation Specialisation { get; set; }

        [Range(
            0,
            50,
            ErrorMessage =
            "Experience must be between 0 and 50 years")]
        public int YearsOfExperience { get; set; }

        [Range(
            0,
            10000,
            ErrorMessage =
            "Consultation Fee must be between 0 and 10000")]
        public decimal ConsultationFee { get; set; }

        public bool IsActive { get; set; }

        public string GetDoctorSummary()
        {
            return string.Format(
                "Id: {0}, Name: {1}, Specialisation: {2}, Experience: {3}, Fee: {4}",
                DoctorId,
                FullName,
                Specialisation,
                YearsOfExperience,
                ConsultationFee);
        }
    }
}