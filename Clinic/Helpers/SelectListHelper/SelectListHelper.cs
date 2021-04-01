using Clinic.Models;
using Clinic.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Helpers.SelectListHelper
{
    public class SelectListHelper:ISelectListHelper
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorsRepository _doctorsRepository;
        public SelectListHelper(IPatientRepository patientRepository, IDoctorsRepository doctorsRepository)
        {
            _patientRepository = patientRepository;
            _doctorsRepository = doctorsRepository;
        }

        public List<SelectListItem> PatientsSelectList(bool includeEmpty = true)
        {
            var model = _patientRepository.GetAll();
            var list = new List<SelectListItem>();

            if (includeEmpty)
                list.Add(new SelectListItem { Value = null, Text = "Select patient" });

            foreach(var item in model)
            {
                list.Add(new SelectListItem { Value = item.Id.ToString(), Text = $"{item.FirstName} {item.LastName}" });
            }

            return list;
        }

        public List<SelectListItem> DoctorsSelectList(bool includeEmpty = true)
        {
            var model = _doctorsRepository.GetAll().Where(x => x.Title.Equals("Specialist")).ToList();
            var list = new List<SelectListItem>();

            if (includeEmpty)
                list.Add(new SelectListItem { Value = null, Text = "Select doctor" });

            foreach (var item in model)
            {
                list.Add(new SelectListItem { Value = item.Id.ToString(), Text = $"{item.FirstName} {item.LastName}" });
            }

            return list;
        }
    }
}
