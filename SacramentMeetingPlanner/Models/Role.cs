using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Role
    {
        [Display(Name = "Role ID")]
        public int RoleID { get; set; }

        [Display(Name = "Role Type")]
        public string RoleTypeName { get; set; }
    }
}
