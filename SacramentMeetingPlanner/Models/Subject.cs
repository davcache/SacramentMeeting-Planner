using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Subject
    {
        [Display(Name = "Subject ID")]
        public int SubjectID { get; set; }

        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
    }
}
