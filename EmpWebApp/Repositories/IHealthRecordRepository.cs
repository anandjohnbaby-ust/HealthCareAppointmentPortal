using HealthCareApp.Models;
using System.Collections.Generic;

namespace HealthCareApp.Repositories
{
    public interface IHealthRecordRepository
    {
        List<HealthRecord> GetAll();

        HealthRecord GetById(int id);

        void AddRecord(
            HealthRecord record);

        void UpdateRecord(
            int id,
            HealthRecord record);

        void DeleteRecord(int id);

        HealthRecord GetByAppointmentId(
            int appointmentId);
    }
}