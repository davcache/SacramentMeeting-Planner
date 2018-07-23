using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Prayer
    {
        [Display(Name = "Prayer ID")]
        public int PrayerID { get; set; }

        [Display(Name = "Prayer Type")]
        public PrayerType PrayerType { get; set; }

        [Display(Name = "Member")]
        public Member Member { get; set; }
    }
}
