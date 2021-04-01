using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DataSetsValues
    {
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientFullName => $"{PatientFirstName} {PatientLastName}";
        public DateTime? DateOfReception { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorLicenseNumber { get; set; }
        public string DoctorFullNameAndLicenseNumber => $"{DoctorFirstName} {DoctorLastName} - {DoctorLicenseNumber}";
        public bool EmergencyCase { get; set; }
        public int PatientReceptionId { get; set; }
        public bool IsThereMedicalReport { get; set; }
        public string MedicalReport { get; set; }


        public static List<DataSetsValues> Get()
        {
            return new List<DataSetsValues> { };
        }
    }
}