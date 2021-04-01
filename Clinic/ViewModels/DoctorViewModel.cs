using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Models;
using static Clinic.Constants.Enumerations;

namespace Clinic.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public int Title { get; set; }
        [Required(ErrorMessage = "License number is required")]
        public string LicenseNumber { get; set; }

        public static implicit operator DoctorViewModel(Doctor model)
        {
            return new DoctorViewModel { 
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                LicenseNumber = model.LicenseNumber,
            };
        }

        public static implicit operator Doctor(DoctorViewModel model)
        {
            return new Doctor
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                LicenseNumber = model.LicenseNumber,
            };
        }
    }
}
