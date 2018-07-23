using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class PrayerType
    {
        [Display(Name = "Prayer Type ID ")]
        public int PrayerTypeID { get; set; }

        [Display(Name = "Prayer Type Name")]
        public string PrayerTypeName { get; set; }
    }
}
