﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Plans
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Bishopric Bishopric { get; set; }
        public Members Member { get; set; }
        public Songs Song { get; set; } 
        public Songs SacramentSong { get; set; }

        // no need for Songs? since objects are nullable by definition
        // https://stackoverflow.com/questions/35647898/the-type-myobject-must-be-a-non-nullable-value-type-in-order-to-use-it-as-para
        public Songs OptIntermSong { get; set; }

        public Members ClosingPrayer { get; set; }

        public ICollection<SpeakToPlan> Members { get; set; }
        public ICollection<SongToPlan> Songs { get; set; }
    }
}
