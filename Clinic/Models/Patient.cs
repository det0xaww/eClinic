using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Patient:IModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        /*public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }*/

        public bool IsDeleted { get; set; }
    }
}
