using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Prayer
    {
        [Key]
        [Display(Name = "Prayer ID")]
        public int PrayerID { get; set; }

        [Display(Name = "Prayer Type")]
        public int PrayerTypeID { get; set; }

        public PrayerType PrayerType { get; set; }

        [Display(Name = "Member")]
        public int MemberID { get; set; }

        public Member Member { get; set; }
    }
}
