using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Clinic.Constants.Enumerations;

namespace Clinic.Models
{
    public class Doctor:IModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string LicenseNumber { get; set; }

        /*public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime DeletedDateTime { get; set; }*/

        public bool IsDeleted { get; set; }
    }
}
