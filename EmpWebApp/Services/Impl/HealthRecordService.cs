using HealthCareApp.Models;
using HealthCareApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HealthCareApp.Services
{
    public class HealthRecordService
        : IHealthRecordService
    {
        private readonly
            IHealthRecordRepository _repository;

        public HealthRecordService(
            IHealthRecordRepository repository)
        {
            _repository = repository;
        }

        public List<HealthRecord> GetAll()
        {
            return _repository.GetAll();
        }

        public HealthRecord GetById(int id)
        {
            return _repository.GetById(id);
        }

        public HealthRecord GetByAppointmentId(
            int appointmentId)
        {
            return _repository
                .GetByAppointmentId(
                    appointmentId);
        }

        public void AddRecord(
            HealthRecord record)
        {
            HealthRecord existing =
                _repository
                .GetByAppointmentId(
                    record.AppointmentId);

            if (existing != null)
            {
                return;
            }

            _repository.AddRecord(record);
        }

        public void UpdateRecord(
            int id,
            HealthRecord record)
        {
            _repository.UpdateRecord(
                id,
                record);
        }

        public void DeleteRecord(
            int id)
        {
            _repository.DeleteRecord(id);
        }
        public List<HealthRecord> GetByPatientId(int patientId)
        {
            return _repository
                .GetAll()
                .Where(r => r.PatientId == patientId)
                .OrderByDescending(r => r.VisitDate)
                .ToList();
        }
    }
}