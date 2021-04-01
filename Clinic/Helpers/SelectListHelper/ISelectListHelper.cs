using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Helpers.SelectListHelper
{
    public interface ISelectListHelper
    {
        List<SelectListItem> DoctorsSelectList(bool includeEmpty = true);
        List<SelectListItem> PatientsSelectList(bool includeEmpty = true);
    }
}
