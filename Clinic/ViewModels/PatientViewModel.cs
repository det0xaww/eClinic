using Clinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Date of birth is required")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage="Gender is required")]
        public int Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public static implicit operator PatientViewModel(Patient model)
        {
            return new PatientViewModel
            {
                Id = model.Id,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
        }
        public static implicit operator Patient(PatientViewModel model)
        {
            return new Patient
            {
                Id = model.Id,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
        }
    }
}
