using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SpeakToPlan
    {
        public int ID { get; set; }
        public int SpeakerToPlanId { get; set; }
        public Members SpeakerName { get; set; }
        public int SpeakerPlacement { get; set; }
        public Subjects Subject { get; set; }
    }
}
