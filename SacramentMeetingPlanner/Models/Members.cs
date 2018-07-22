using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Members
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public string Name { get; set; }

        public ICollection<SpeakToPlan> Plans { get; set; }
    }
}
