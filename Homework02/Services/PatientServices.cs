using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Homework02.Models;


namespace Homework02.Services
{
    public interface IPatientService
    {
        List<Patient> GetPatients();
        Patient GetPatient(int id);
        void AddPatient(Patient patient, int vaccineId);

        List<Vaccine> GetVaccines();
        void RecieveDose(int id);
    }

    public class PatientService : IPatientService
    {
        private readonly AppDbContext _db;
        
        public PatientService(AppDbContext db)
        {
            _db = db;
        }

        public List<Patient> GetPatients()
        {
            var patients = _db.Patients
                .Include(pat => pat.Vaccine)
                .ToList();
            return patients;
        }


        public Patient GetPatient(int id)
        {
            return _db.Patients.Include(pat => pat.Vaccine).Where(v => v.Id == id).SingleOrDefault();
        }

        public void AddPatient(Patient patient, int vaccineId)
        {
            Console.WriteLine(vaccineId);
            patient.Vaccine = _db.Vaccines.Where(v => v.Id == vaccineId).SingleOrDefault();
            _db.Patients.Add(patient);

            Vaccine vaccine = _db.Vaccines
                .Where(v => v.Id == vaccineId)
                .SingleOrDefault();
            int decr = vaccine.TotalDosesLeft - 1;
            vaccine.TotalDosesLeft = decr;
            _db.SaveChanges();
        }

        public List<Vaccine> GetVaccines()
        {
            return _db.Vaccines.ToList();
        }

        public void RecieveDose(int id)
        {
            Patient patient = _db.Patients
                .Where(p => p.Id == id)
                .SingleOrDefault();

            patient.SecondDose = DateTime.Now;

            int vaccineId = GetPatient(id).Vaccine.Id;

            Vaccine vaccine = _db.Vaccines
                .Where(v => v.Id == vaccineId)
                .SingleOrDefault();

            int decr = vaccine.TotalDosesLeft - 1;
            vaccine.TotalDosesLeft = decr;

            _db.SaveChanges();
        }

    }

}
