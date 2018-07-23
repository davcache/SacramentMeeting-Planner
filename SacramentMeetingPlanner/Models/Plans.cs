using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Plans
    {
        [Display(Name = "Plan ID")]
        public int PlansID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Plan Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PlanDate { get; set; }

        [Display(Name = "Conducting")]
        public Bishopric Bishopric { get; set; }

        [Display(Name = "Prayers")]
        public ICollection<PrayerToPlan> PrayerToPlan { get; set; }

        [Display(Name = "Songs")]
        public ICollection<SongToPlan> SongToPlan { get; set; }

        [Display(Name = "Speakers")]
        public ICollection<SpeakToPlan> SpeakToPlan { get; set; }
    }
}