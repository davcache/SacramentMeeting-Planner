using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SongAssignment
    {
        [Display(Name = "Song Assignment ID ")]
        public int SongAssignmentID { get; set; }

        [Display(Name = "Song")]
        public Song Song { get; set; }

        [Display(Name = "Song Type")]
        public SongType SongType { get; set; }
    }
}
