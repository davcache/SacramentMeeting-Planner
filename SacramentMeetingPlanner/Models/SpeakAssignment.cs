using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SpeakAssignment
    {
        [Key]
        [Display(Name = "Speaker Assignment ID")]
        public int SpeakerAssignmentID { get; set; }

        [Display(Name = "Member")]
        public Member Member { get; set; }

        [Display(Name = "Subject")]
        public Subject Subject { get; set; }

        [Display(Name = "Speaker Placement")]
        public int SpeakerPlacement { get; set; }
    }
}
