using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Member
    {
        [Key]
        [Display(Name = "Member ID")]
        public int MemberID { get; set; }

        [Display(Name = "Member Name")]
        public string MemberName { get; set; }
    }
}