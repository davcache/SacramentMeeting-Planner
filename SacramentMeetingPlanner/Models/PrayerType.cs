using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class PrayerType
    {
        [Key]
        [Display(Name = "Prayer Type ID ")]
        public int PrayerTypeID { get; set; }

        [Display(Name = "Prayer Type Name")]
        public string PrayerTypeName { get; set; }
    }
}
