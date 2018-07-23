using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SpeakToPlan
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Plan")]
        public Plans Plans { get; set; }

        [Display(Name = "Speaker Assignment")]
        public SpeakAssignment SpeakAssignment { get; set; }
    }
}
