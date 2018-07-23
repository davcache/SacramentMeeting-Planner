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
        public int SpeakToPlanID { get; set; }

        [Display(Name = "Plan")]
        public int PlansID { get; set; }

        [Display(Name = "Speaker Assignment")]
        public int? SpeakAssignmentID { get; set; }

        public Plans Plans { get; set; }
        public SpeakAssignment SpeakAssignment { get; set; }
    }
}