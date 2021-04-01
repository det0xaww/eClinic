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
    public class DoctorsController : Controller
    {
        private readonly IDoctorsRepository _doctorsRepository;
        public DoctorsController(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }
        #region Index
        public IActionResult Index()
        {
            var model = _doctorsRepository.GetAll();

            return View(model);
        }
        #endregion
        #region Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new DoctorViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(DoctorViewModel model)
        {
            if (_doctorsRepository.GetAll().ToList().Any(x => x.FirstName.Equals(model.FirstName) && x.LastName.Equals(model.LastName)))
                ModelState.AddModelError("", "Doctor with same first name and last name already exist");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                Doctor doctor = model;
                doctor.Title = Enum.GetName(typeof(Title), model.Title);
                _doctorsRepository.Add(doctor);

                _doctorsRepository.SaveChanges();

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
                DoctorViewModel model = _doctorsRepository.GetById(id);

                return View(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(DoctorViewModel model)
        {
            if (_doctorsRepository.GetAll().ToList().Any(x => x.FirstName.Equals(model.FirstName) && x.LastName.Equals(model.LastName)))
                ModelState.AddModelError("", "Doctor with same first name and last name already exist");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                Doctor doctor = model;
                doctor.Title = Enum.GetName(typeof(Title), model.Title);
                _doctorsRepository.Update(doctor);

                _doctorsRepository.SaveChanges();

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
                _doctorsRepository.RemoveById(id);

                _doctorsRepository.SaveChanges();

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
