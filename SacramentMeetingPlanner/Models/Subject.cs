using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Subject
    {
        [Key]
        [Display(Name = "Subject ID")]
        public int SubjectID { get; set; }

        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
    }
}
