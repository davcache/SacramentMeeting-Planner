using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Plans
    {
        [Key]
        [Display(Name = "Plan ID")]
        public int PlansID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Plan Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PlanDate { get; set; }

        [Display(Name = "Conducting")]
        public int RoleID { get; set; }

        public Role Role { get; set; }

        [Display(Name = "Prayers")]
        public ICollection<PrayerToPlan> PrayerToPlan { get; set; }

        [Display(Name = "Songs")]
        public ICollection<SongToPlan> SongToPlan { get; set; }

        [Display(Name = "Speakers")]
        public ICollection<SpeakToPlan> SpeakToPlan { get; set; }
    }
}