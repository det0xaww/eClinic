using Clinic.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.ViewModels
{
    public class IndexPatientReceptionViewModel
    {
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public List<PatientReceptionDto> PatientReceptionList {get;set;}
    }
}
