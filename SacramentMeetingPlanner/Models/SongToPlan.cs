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
        public int ID { get; set; }

        [Display(Name = "Plan")]
        public Plans Plans { get; set; }

        [Display(Name = "Song Assignment")]
        public SongAssignment SongAssignment { get; set; }
    }
}


        
