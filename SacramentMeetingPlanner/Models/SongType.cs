using System.ComponentModel.DataAnnotations;

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
