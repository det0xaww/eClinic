using Clinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.ViewModels
{
    public class PatientReceptionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Date of reception is required")]
        public DateTime? DateOfReception { get; set; }
        [Required(ErrorMessage="Emergancy case is required")]
        public bool EmergencyCase { get; set; }
        [Required(ErrorMessage="Doctor is required")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage="Patient is required")]
        public int PatientId { get; set; }
        public bool IsThereMedicalReport { get; set; }


        public static implicit operator PatientReceptionViewModel( PatientReception model)
        {
            return new PatientReceptionViewModel
            {
                Id = model.Id,
                DateOfReception = model.DateOfReception,
                DoctorId = model.DoctorId,
                EmergencyCase = model.EmergencyCase,
                PatientId = model.PatientId,
                IsThereMedicalReport=model.IsThereMedicalReport
            };
        }
        public static implicit operator PatientReception(PatientReceptionViewModel model)
        {
            return new PatientReception
            {
                Id = model.Id,
                DateOfReception = model.DateOfReception,
                DoctorId = model.DoctorId,
                EmergencyCase = model.EmergencyCase,
                PatientId = model.PatientId,
                IsThereMedicalReport = model.IsThereMedicalReport
            };
        }
    }
}
