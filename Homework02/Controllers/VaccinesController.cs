using Homework02.Models;
using Homework02.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02.Controllers
{
    public class VaccinesController : Controller
    {
        private readonly IVaccineService _vacccineService;

        public VaccinesController(IVaccineService vaccineService)
        {
            _vacccineService = vaccineService;
        }

        public IActionResult Index()
        {
            return View(_vacccineService.GetVaccines());
        }

        public IActionResult Details(int id)
        {
            return View(_vacccineService.GetVaccine(id));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Vaccine vaccine)
        {
            _vacccineService.AddVaccine(vaccine);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult NewDoses()
        {
            return View(_vacccineService.GetVaccines());
        }

        [HttpPost]
        public IActionResult NewDoses(int id, int doses)
        {
            _vacccineService.AddDoses(id, doses);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_vacccineService.GetVaccine(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, string Name, int DosesRequired, int DaysBetween)
        {
            _vacccineService.EditVaccine(id, Name, DosesRequired, DaysBetween);
            return RedirectToAction("Index");
        }

    }
}
