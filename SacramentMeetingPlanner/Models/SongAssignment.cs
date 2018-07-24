using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SongAssignment
    {
        [Key]
        [Display(Name = "Song Assignment ID ")]
        public int SongAssignmentID { get; set; }

        [Display(Name = "Song")]
        public int SongID { get; set; }

        [Display(Name = "Song Type")]
        public int SongTypeID { get; set; }

        public Song Song { get; set; }
        public SongType SongType { get; set; }

        [Display(Name = "Songs")]
        public ICollection<SongToPlan> SongToPlan { get; set; }
    }
}