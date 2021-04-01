using Clinic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.ViewModels
{
    public class PatientMedicalReportViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Date time is required"), JsonProperty("datetimecreated")]
        public DateTime DateTimeCreated { get; set; }
        [Required(ErrorMessage = "Description is required"), JsonProperty("description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Patient reception is required"), JsonProperty("patientreceptionsid")]
        public int PatientReceptionsId { get; set; }

        public static implicit operator PatientMedicalReportViewModel(PatientMedicalReport model)
        {
            return new PatientMedicalReportViewModel
            {
                DateTimeCreated = model.DateTimeCreated,
                Description = model.Description,
                Id = model.Id,
                PatientReceptionsId = model.PatientReceptionsId
            };
        }
        public static implicit operator PatientMedicalReport(PatientMedicalReportViewModel model)
        {
            return new PatientMedicalReport
            {
                DateTimeCreated = model.DateTimeCreated,
                Description = model.Description,
                Id = model.Id,
                PatientReceptionsId = model.PatientReceptionsId
            };
        }
    }
}
