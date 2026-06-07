using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCareApp.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [RegularExpression(
            @"^[a-zA-Z\s]+$",
            ErrorMessage = "Only letters and spaces are allowed")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [CustomValidation(
            typeof(Patient),
            nameof(ValidateDateOfBirth))]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(
            @"^\d{10}$",
            ErrorMessage = "Phone Number must be 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(
            ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insurance Id is required")]
        public string InsuranceId { get; set; }

        public DateTime CreatedDate { get; private set; }
            = DateTime.Now;

        public int Age
        {
            get
            {
                int age =
                    DateTime.Now.Year -
                    DateOfBirth.Year;

                if (DateTime.Now <
                    DateOfBirth.AddYears(age))
                {
                    age--;
                }

                return age;
            }
        }

        public string GetProfileSummary()
        {
            return string.Format(
                "Id: {0}, Name: {1}, Age: {2}, Phone: {3}",
                PatientId,
                FullName,
                Age,
                PhoneNumber);
        }

        public static ValidationResult ValidateDateOfBirth(
            DateTime date,
            ValidationContext context)
        {
            if (date > DateTime.Now)
            {
                return new ValidationResult(
                    "Date of Birth cannot be a future date");
            }

            return ValidationResult.Success;
        }
    }
}