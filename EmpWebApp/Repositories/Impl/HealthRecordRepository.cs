using HealthCareApp.Data;
using HealthCareApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace HealthCareApp.Repositories
{
    public class HealthRecordRepository
        : IHealthRecordRepository
    {
        private readonly
            HealthCareDbContext _context;

        public HealthRecordRepository(
            HealthCareDbContext context)
        {
            _context = context;
        }

        //public List<HealthRecord> GetAll()
        //{
        //    return _context.HealthRecords
        //        .ToList();
        //}
        public List<HealthRecord> GetAll()
        {
            return _context.HealthRecords
                .Include("Doctor")
                .Include("Patient")
                .ToList();
        }

        public HealthRecord GetById(int id)
        {
            return _context.HealthRecords
                .FirstOrDefault(
                    h => h.RecordId == id);
        }

        public HealthRecord GetByAppointmentId(
            int appointmentId)
        {
            return _context.HealthRecords
                .FirstOrDefault(
                    h => h.AppointmentId
                    == appointmentId);
        }

        public void AddRecord(
            HealthRecord record)
        {
            _context.HealthRecords
                .Add(record);

            _context.SaveChanges();
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

            _context.SaveChanges();
        }

        public void DeleteRecord(
            int id)
        {
            HealthRecord record =
                GetById(id);

            if (record != null)
            {
                _context.HealthRecords
                    .Remove(record);

                _context.SaveChanges();
            }
        }
    }
}