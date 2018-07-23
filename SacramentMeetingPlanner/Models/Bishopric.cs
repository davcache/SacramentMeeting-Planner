using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [Display(Name = "Released Flag")]
        public bool ReleasedFlag { get; set; } = false;

        public Role Role { get; set; }
        public Member Member { get; set; }
    }
}