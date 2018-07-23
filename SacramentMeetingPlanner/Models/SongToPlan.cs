using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SongToPlan
    {
        [Display(Name = "Song To Plan ID")]
        public int SongToPlanID { get; set; }

        [Display(Name = "Plan")]
        public Plans Plans { get; set; }

        [Display(Name = "Song")]
        public Song Song { get; set; }

        [Display(Name = "Song Type")]
        public SongType SongType { get; set; }
    }
}


        
