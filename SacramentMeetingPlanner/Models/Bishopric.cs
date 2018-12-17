using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Bishopric
    {
        [Key]
        [Display(Name = "Bishopric ID")]
        public int BishopricID { get; set; }

        [Display(Name = "Role")]
        public int RoleID { get; set; }

        [Display(Name = "Member Name")]
        public int MemberID { get; set; }

        [Display(Name = "Released")]
        public bool ReleasedFlag { get; set; } = false;

        public Role Role { get; set; }
        public Member Member { get; set; }
    }
}