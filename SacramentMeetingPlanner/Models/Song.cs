using System.ComponentModel.DataAnnotations;

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
