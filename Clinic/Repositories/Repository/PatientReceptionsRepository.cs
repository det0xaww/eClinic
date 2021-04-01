using Clinic.Context;
using Clinic.Helpers;
using Clinic.Models;
using Clinic.Models.Dtos;
using Clinic.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Repositories.Repository
{
    public class PatientReceptionsRepository:Repository<PatientReception,int>,IPatientReceptionsRepository
    {
        public PatientReceptionsRepository(ClinicContext context):base(context)
        {

        }

        public IEnumerable<PatientReceptionDto> GetAllPatientReceptions(DateTime? pStartDate, DateTime? pEndDate)
        {
            return DbConnection.QueryFunction<PatientReceptionDto>(DbObjects.Functions.PatientReception.patientreception_getallpatientreceptions, new { pStartDate, pEndDate });
        }
    }
}
