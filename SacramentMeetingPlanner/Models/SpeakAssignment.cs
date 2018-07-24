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
        [Display(Name = "Speak Assignment ID")]
        public int SpeakAssignmentID { get; set; }

        [Display(Name = "Member")]
        public int MemberID { get; set; }

        public Member Member { get; set; }

        [Display(Name = "Subject")]
        public int SubjectID { get; set; }

        public Subject Subject { get; set; }

        [Display(Name = "Speaker Placement")]
        public int SpeakerPlacement { get; set; }

        [Display(Name = "Speakers")]
        public ICollection<SpeakToPlan> SpeakToPlan { get; set; }

    }
}
