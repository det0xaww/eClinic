using AspNetCore.Reporting;
using Clinic.Repositories.IRepository;
using Clinic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1;

namespace Clinic.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IPatientReceptionsRepository _patientReceptionsRepository;
        public ReportsController(IPatientReceptionsRepository patientReceptionsRepository)
        {
            _patientReceptionsRepository = patientReceptionsRepository;
        }

        [HttpPost]
        public IActionResult Index(IndexPatientReceptionViewModel model)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            List<DataSetsValues> list = _patientReceptionsRepository.GetAllPatientReceptions(model.StartDateTime, model.EndDateTime)
                .Select(x => new DataSetsValues
                {
                    PatientFirstName = x.PatientFirstName,
                    DateOfReception = x.DateOfReception,
                    DoctorFirstName = x.DoctorFirstName,
                    DoctorLastName = x.DoctorLastName,
                    DoctorLicenseNumber = x.DoctorLicenseNumber,
                    EmergencyCase = x.EmergencyCase,
                    IsThereMedicalReport = x.IsThereMedicalReport,
                    PatientLastName = x.PatientLastName,
                    PatientReceptionId = x.PatientReceptionId,
                    MedicalReport = string.IsNullOrEmpty(x.MedicalReport) ? "Medical report doesn't exist!" : x.MedicalReport
                }).ToList();

            LocalReport _localReport = new LocalReport("Reports/Report1.rdlc");
            _localReport.AddDataSource("DataSet1", list);

            ReportResult result = _localReport.Execute(RenderType.Pdf);

            return File(result.MainStream, "application/pdf");
        }
    }
}
