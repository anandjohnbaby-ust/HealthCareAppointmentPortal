using HealthCareApp.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCareApp.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }


        [Required(ErrorMessage = "Patient is required")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor is required")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Appointment Date is required")]
        [DataType(DataType.Date)]
        public DateTime ScheduledDate { get; set; }

        [Required(ErrorMessage = "Time Slot is required")]
        public string TimeSlot { get; set; }

        public AppointmentStatus Status { get; set; }
            = AppointmentStatus.Pending;

        public string CancellationReason { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }
    }
}