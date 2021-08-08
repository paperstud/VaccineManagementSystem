using Homework02.Services;
using Homework02.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            return View(_patientService.GetPatients());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View( _patientService.GetVaccines() );
        }
        [HttpPost]
        public IActionResult Add(Patient patient,int vaccineId)
        {
            patient.FirstDose = DateTime.Now;
            _patientService.AddPatient(patient, vaccineId);
            return RedirectToAction("Index");
        }


        
        [HttpGet]
        public IActionResult Recieve([FromRoute] int id)
        {
            _patientService.RecieveDose(id);
            return RedirectToAction("Index");
        }



    }
}
