using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SongToPlan
    {
        public int ID { get; set; }
        public int SongToPlanId { get; set; }
        public Members SpeakerName { get; set; }
        public int SpeakerPlacement { get; set; }
        public Subjects Subject { get; set; }

        public ICollection<SongToPlan> Plans { get; set; }
    }
}


        
