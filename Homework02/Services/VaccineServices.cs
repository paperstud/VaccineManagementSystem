using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Homework02.Models;


namespace Homework02.Services
{
    public interface IVaccineService
    {
        List<Vaccine> GetVaccines();
        Vaccine GetVaccine(int id);
        void AddVaccine(Vaccine vaccine);

        void AddDoses(int id, int doses);

        void EditVaccine(int id, string name, int dosesRequired, int daysBetween);
    }

    public class VaccineService : IVaccineService
    {
        private readonly AppDbContext _db;
        
        public VaccineService(AppDbContext db)
        {
            _db = db;
        }

        public List<Vaccine> GetVaccines()
        {
            return _db.Vaccines.ToList();
        }

        public Vaccine GetVaccine(int id)
        {
            return _db.Vaccines.Where(v => v.Id == id).SingleOrDefault();
        }

        public void AddVaccine(Vaccine vaccine)
        {

            _db.Vaccines.Add(vaccine);
            _db.SaveChanges();
        }

        public void AddDoses(int id, int doses)
        {
            var vax = _db.Vaccines.Find(id);
            int currentRecieved = vax.TotalDosesRecieved;
            vax.TotalDosesRecieved = currentRecieved + doses;

            int currentLeft = vax.TotalDosesLeft;
            vax.TotalDosesLeft = doses + currentLeft;
            _db.SaveChanges();
        }

        public void RemoveDoses(int id, int doses)
        {
            var vax = _db.Vaccines.Find(id);
            int current = vax.TotalDosesLeft;

            vax.TotalDosesLeft = current - doses;

            _db.SaveChanges();
        }

        public void EditVaccine(int id, string name, int dosesRequired, int daysBetween)
        {
            var vax = _db.Vaccines.Find(id);
            vax.Name = name;
            vax.DosesRequired = dosesRequired;
            vax.DaysBetween = daysBetween;

            _db.SaveChanges();

        }
    }

}
