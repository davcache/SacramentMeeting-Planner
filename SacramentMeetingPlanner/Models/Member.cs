using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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