using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Role
    {
        [Key]
        [Display(Name = "Role ID")]
        public int RoleID { get; set; }

        [Display(Name = "Role")]
        public string RoleTypeName { get; set; }
    }
}