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
    public class PatientMedicalReportsController : Controller
    {
        private readonly IPatientMedicalReportsRepository _patientMedicalReportsRepository;
        private readonly IPatientReceptionsRepository _patientReceptionsRepository;
        public PatientMedicalReportsController(IPatientMedicalReportsRepository patientMedicalReportsRepository, IPatientReceptionsRepository patientReceptionsRepository)
        {
            _patientMedicalReportsRepository = patientMedicalReportsRepository;
            _patientReceptionsRepository = patientReceptionsRepository;
        }
        public IActionResult Index(int id) //patientReceptionId
        {
            PatientMedicalReportViewModel model = _patientMedicalReportsRepository.GetByPatientReceptionId(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult IndexPartial(int id)
        {
            PatientMedicalReportViewModel model = _patientMedicalReportsRepository.GetByPatientReceptionId(id);
            return PartialView("_Index",model);
        }

        [HttpGet]
        public IActionResult Add(int id) //patientReceptionId
        {
            PatientMedicalReportViewModel model = new PatientMedicalReportViewModel();
            model.PatientReceptionsId = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(PatientMedicalReportViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var transaction = _patientMedicalReportsRepository.BeginTransaction())
            {
                try
                {
                    PatientMedicalReport patientMedicalReport = model;
                    patientMedicalReport.DateTimeCreated = DateTime.Now;
                    _patientMedicalReportsRepository.Add(patientMedicalReport);

                    PatientReception patientReception = _patientReceptionsRepository.GetById(patientMedicalReport.PatientReceptionsId);
                    patientReception.IsThereMedicalReport = true;
                    _patientReceptionsRepository.Update(patientReception);

                    _patientMedicalReportsRepository.SaveChanges();
                    _patientReceptionsRepository.SaveChanges();

                    transaction.Commit();

                    return RedirectToAction("Index", "PatientReceptions");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return RedirectToAction("Index", "PatientReceptions");
                }
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PatientMedicalReportViewModel model = _patientMedicalReportsRepository.GetById(id);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(PatientMedicalReportViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                PatientMedicalReport patientMedicalReport = model;
                patientMedicalReport.DateTimeCreated = DateTime.Now;
                _patientMedicalReportsRepository.Update(patientMedicalReport);

                _patientMedicalReportsRepository.SaveChanges();

                return RedirectToAction(nameof(Index),new { id = patientMedicalReport.PatientReceptionsId});
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
