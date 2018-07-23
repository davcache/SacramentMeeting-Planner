using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class PrayerToPlan
    {
        [Display(Name = "Prayer To Plan ID")]
        public int PrayerToPlanID { get; set; }

        [Display(Name = "Plan")]
        public Plans Plans { get; set; }

        [Display(Name = "Prayer Type")]
        public PrayerType PrayerType { get; set; }

        [Display(Name = "Member")]
        public Member Member { get; set; }
    }
}
