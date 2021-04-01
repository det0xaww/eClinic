using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Constants
{
    public static class Enumerations
    {
        public enum Gender
        {
            Female = 1,
            Male,
            Unknown
        }

        public enum Title
        { 
            Specialist = 1,
            Resident,
            Nurse
        }
    }
}
