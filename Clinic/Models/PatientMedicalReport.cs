using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class PatientMedicalReport:IModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime DateTimeCreated { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey(nameof(PatientReception)),Required]
        public int PatientReceptionsId { get; set; }

        public PatientReception PatientReception { get; set; }

        /*public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime DeletedDateTime { get; set; }*/

        public bool IsDeleted { get; set; }
    }
}
