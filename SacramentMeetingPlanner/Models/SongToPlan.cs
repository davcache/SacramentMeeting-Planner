using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SongToPlan
    {
        [Key]
        public int SongToPlanID { get; set; }

        [Display(Name = "Plan")]
        public int PlansID { get; set; }

        [Display(Name = "Song Assignment")]
        public int SongAssignmentID { get; set; }

        public Plans Plans { get; set; }
        public SongAssignment SongAssignment { get; set; }
    }
}


        
