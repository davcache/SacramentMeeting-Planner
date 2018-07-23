using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SongType
    {
        [Key]
        public int SongTypeID { get; set; }

        [Display(Name = "Song Type")]
        public string SongTypeName { get; set; }
    }
}
