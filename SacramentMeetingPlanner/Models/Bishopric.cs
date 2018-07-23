using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Bishopric
    {
        [Display(Name = "Bishopric ID")]
        public int BishopricID { get; set; }

        [Display(Name = "Role")]
        public Role Role { get; set; }

        [Display(Name = "Member Name")]
        public Member Member { get; set; }

        [Display(Name = "Released Flag")]
        public bool ReleasedFlag { get; set; } = false;
    }
}
