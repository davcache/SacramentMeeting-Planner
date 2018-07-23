using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Song
    {
        [Key]
        [Display(Name = "Song ID")]
        public int SongID { get; set; }

        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Display(Name = "Song Number")]
        public int SongNumber { get; set; }
    }
}
