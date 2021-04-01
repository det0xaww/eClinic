using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Context
{
    public class ClinicContext:DbContext
    {
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<PatientMedicalReport> PatientMedicalReports { get; set; }
        public virtual DbSet<PatientReception> PatientReceptions { get; set; }

        public ClinicContext(DbContextOptions options):base(options)
        {

        }
    }
}
