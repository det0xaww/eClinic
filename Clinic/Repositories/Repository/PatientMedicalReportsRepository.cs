using Clinic.Context;
using Clinic.Models;
using Clinic.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Repositories.Repository
{
    public class PatientMedicalReportsRepository:Repository<PatientMedicalReport,int>,IPatientMedicalReportsRepository
    {
        public PatientMedicalReportsRepository(ClinicContext context):base(context)
        {

        }

        public PatientMedicalReport GetByPatientReceptionId(int id)
        {
            return Context.PatientMedicalReports.Include(x => x.PatientReception)
                          .SingleOrDefault(x => x.PatientReceptionsId.Equals(id));
        }
    }
}
