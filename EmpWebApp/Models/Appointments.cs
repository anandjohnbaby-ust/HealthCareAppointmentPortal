using HealthCareApp.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCareApp.Models
{
    public class Appointment
    {
        private static int _appointmentCounter = 1;

        public int AppointmentId { get; set; }
            = _appointmentCounter++;

        public static void SetAppointmentCounter(int value)
        {
            _appointmentCounter = value;
        }

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