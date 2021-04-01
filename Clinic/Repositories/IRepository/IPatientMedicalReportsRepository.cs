using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Repositories.IRepository
{
    public interface IPatientMedicalReportsRepository:IRepository<PatientMedicalReport,int>
    {
        PatientMedicalReport GetByPatientReceptionId(int id);
    }
}
