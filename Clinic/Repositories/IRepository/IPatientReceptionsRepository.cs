using Clinic.Models;
using Clinic.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Repositories.IRepository
{
    public interface IPatientReceptionsRepository:IRepository<PatientReception,int>
    {
        IEnumerable<PatientReceptionDto> GetAllPatientReceptions(DateTime? pStartDate,DateTime? pEndDate);
    }
}
