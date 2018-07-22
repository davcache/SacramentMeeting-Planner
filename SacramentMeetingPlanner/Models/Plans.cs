using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Plans
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public Bishopric Conducting { get; set; }

        [Display(Name = "Opening Prayer")]
        public Members OpeningPrayer { get; set; }

        [Display(Name = "Opening Hymn")]
        public Songs OpeningSong { get; set; }

        [Display(Name = "Sacrament Hymn")]
        public Songs SacramentSong { get; set; }

        // no need for Songs? since objects are nullable by definition
        // https://stackoverflow.com/questions/35647898/the-type-myobject-must-be-a-non-nullable-value-type-in-order-to-use-it-as-para

        [Display(Name = "Intermediate Hymn (optional)")]
        public Songs OptIntermSong { get; set; }

        [Display(Name = "Closing Hymn")]
        public Songs ClosingSong { get; set; }

        [Display(Name = "Closing Prayer")]
        public Members ClosingPrayer { get; set; }

        [Display(Name = "Speakers")]
        public ICollection<SpeakToPlan> Members { get; set; }
    }
}