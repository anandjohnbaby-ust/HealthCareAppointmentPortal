using HealthCareApp.Database;
using HealthCareApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HealthCareApp.Repositories
{
    public class HealthRecordRepository
        : IHealthRecordRepository
    {
        private readonly
            DataStore _dataStore;

        public HealthRecordRepository(
            DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<HealthRecord> GetAll()
        {
            return _dataStore.HealthRecords;
        }

        public HealthRecord GetById(int id)
        {
            return _dataStore.HealthRecords
                .FirstOrDefault(
                    h => h.RecordId == id);
        }

        public HealthRecord GetByAppointmentId(
            int appointmentId)
        {
            return _dataStore.HealthRecords
                .FirstOrDefault(
                    h => h.AppointmentId
                    == appointmentId);
        }

        public void AddRecord(
            HealthRecord record)
        {
            _dataStore.HealthRecords
                .Add(record);
        }

        public void UpdateRecord(
            int id,
            HealthRecord record)
        {
            HealthRecord existing =
                GetById(id);

            if (existing == null)
            {
                return;
            }

            existing.Diagnosis =
                record.Diagnosis;

            existing.Prescription =
                record.Prescription;

            existing.Notes =
                record.Notes;

            existing.VisitDate =
                record.VisitDate;
        }

        public void DeleteRecord(
            int id)
        {
            HealthRecord record =
                GetById(id);

            if (record != null)
            {
                _dataStore.HealthRecords
                    .Remove(record);
            }
        }
    }
}