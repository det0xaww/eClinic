using Clinic.Models;
using Clinic.Repositories.IRepository;
using Clinic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Clinic.Constants.Enumerations;

namespace Clinic.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        #region Index
        public IActionResult Index()
        {
            var model = _patientRepository.GetAll();

            return View(model);
        }
        #endregion
        #region Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new PatientViewModel());
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Add(PatientViewModel model)
        {
            if (_patientRepository.GetAll().ToList().Any(x => x.FirstName.Equals(model.FirstName) && x.LastName.Equals(model.LastName)))
                ModelState.AddModelError("", "Patient with same first name and last name already exist");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                Patient patient = model;
                patient.Gender = Enum.GetName(typeof(Gender), model.Gender);
                _patientRepository.Add(patient);

                _patientRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
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
                PatientViewModel model = _patientRepository.GetById(id);

                return View(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(PatientViewModel model)
        {
            if (_patientRepository.GetAll().ToList().Any(x => x.FirstName.Equals(model.FirstName) && x.LastName.Equals(model.LastName)))
                ModelState.AddModelError("", "Patient with same first name and last name already exist");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                Patient patient = model;
                patient.Gender = Enum.GetName(typeof(Gender), model.Gender);
                _patientRepository.Update(patient);

                _patientRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
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
                _patientRepository.RemoveById(id);

                _patientRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
