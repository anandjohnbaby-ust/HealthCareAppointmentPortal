using HealthCareApp.Models;
using System.Collections.Generic;

namespace HealthCareApp.Services
{
    public interface IHealthRecordService
    {
        List<HealthRecord> GetAll();

        HealthRecord GetById(int id);

        HealthRecord GetByAppointmentId(
            int appointmentId);

        void AddRecord(
            HealthRecord record);

        void UpdateRecord(
            int id,
            HealthRecord record);

        void DeleteRecord(
            int id);

        List<HealthRecord> GetByPatientId(int patientId);
    }
}