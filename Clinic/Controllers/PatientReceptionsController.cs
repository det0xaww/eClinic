using Clinic.Models;
using Clinic.Repositories.IRepository;
using Clinic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class PatientReceptionsController : Controller
    {
        private readonly IPatientReceptionsRepository _PatientReceptionsRepository;
        private readonly IDoctorsRepository _doctorsRepository;
        public PatientReceptionsController(IPatientReceptionsRepository PatientReceptionsRepository, IDoctorsRepository doctorsRepository)
        {
            _PatientReceptionsRepository = PatientReceptionsRepository;
            _doctorsRepository = doctorsRepository;
        }
        #region Index
        public IActionResult Index()
        {
            IndexPatientReceptionViewModel model = new IndexPatientReceptionViewModel();
            model.StartDateTime = DateTime.Now.AddMonths(-1);
            model.EndDateTime = DateTime.Now;
            model.PatientReceptionList = _PatientReceptionsRepository.GetAllPatientReceptions(model.StartDateTime, model.EndDateTime).ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Index(IndexPatientReceptionViewModel model)
        {
            if (!model.StartDateTime.HasValue || !model.EndDateTime.HasValue)
                ModelState.AddModelError("", "Start date time and end date time must have a value");
            if (model.StartDateTime.GetValueOrDefault() > model.EndDateTime.GetValueOrDefault())
                ModelState.AddModelError("", "Please check input of dates");
            if (!ModelState.IsValid)
            {
                model.PatientReceptionList = new List<Models.Dtos.PatientReceptionDto>();
                return View(model);
            }

            model.PatientReceptionList = _PatientReceptionsRepository.GetAllPatientReceptions(model.StartDateTime,model.EndDateTime).ToList();

            return View(model);
        }
        #endregion
        #region Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new PatientReceptionViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(PatientReceptionViewModel model)
        {
            if(model.DateOfReception < DateTime.Now)
                ModelState.AddModelError("", "Minimum date and time must be today's day");

            var doctor = _doctorsRepository.GetById(model.DoctorId);
            if (!doctor.Title.Equals("Specialist"))
                ModelState.AddModelError("", "Doctor's title must be Specialist!");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                PatientReception patientReception = model;
                _PatientReceptionsRepository.Add(patientReception);

                _PatientReceptionsRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        #endregion
        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                PatientReceptionViewModel model = _PatientReceptionsRepository.GetById(id);

                if(model.IsThereMedicalReport)
                    return RedirectToAction("Index");

                return View(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(PatientReceptionViewModel model)
        {
            if (model.DateOfReception < DateTime.Now)
                ModelState.AddModelError("", "Minimum date and time must be today's day");

            var doctor = _doctorsRepository.GetById(model.DoctorId);
            if (!doctor.Title.Equals("Specialist"))
                ModelState.AddModelError("", "Doctor's title must be Specialist!");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                PatientReception patientReception = model;
                _PatientReceptionsRepository.Update(patientReception);

                _PatientReceptionsRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        #endregion
        #region Delete
        public IActionResult Delete(int id)
        {
            try
            {
                PatientReception patientReception = _PatientReceptionsRepository.GetById(id);

                if (patientReception.IsThereMedicalReport)
                    return RedirectToAction("Index");

                _PatientReceptionsRepository.RemoveById(id);

                _PatientReceptionsRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
