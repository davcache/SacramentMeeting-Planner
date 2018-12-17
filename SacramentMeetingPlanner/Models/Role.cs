using System.ComponentModel.DataAnnotations;

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