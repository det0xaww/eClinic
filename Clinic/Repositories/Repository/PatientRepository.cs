using Clinic.Context;
using Clinic.Models;
using Clinic.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Repositories.Repository
{
    public class PatientRepository:Repository<Patient,int>,IPatientRepository
    {
        public PatientRepository(ClinicContext context):base(context)
        {

        }
    }
}
