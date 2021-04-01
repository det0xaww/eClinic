using Clinic.Context;
using Clinic.Models;
using Clinic.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Repositories.Repository
{
    public class DoctorsRepository:Repository<Doctor,int>,IDoctorsRepository
    {
        public DoctorsRepository(ClinicContext context):base(context)
        {

        }
    }
}
