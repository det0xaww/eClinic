using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class PatientReception:IModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime? DateOfReception { get; set; }
        [Required]
        public bool EmergencyCase { get; set; }
        [ForeignKey(nameof(Doctor)), Required]
        public int DoctorId { get; set; }
        [ForeignKey(nameof(Patient)), Required]
        public int PatientId { get; set; }
        public bool IsThereMedicalReport { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        /*public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime DeletedDateTime { get; set; }*/

        public bool IsDeleted { get; set; }
    }
}
