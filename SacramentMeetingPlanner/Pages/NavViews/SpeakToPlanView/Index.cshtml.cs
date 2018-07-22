using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SpeakToPlanView
{
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public IndexModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IList<SpeakToPlan> SpeakToPlan { get;set; }

        public async Task OnGetAsync()
        {
            SpeakToPlan = await _context.SpeakToPlan.ToListAsync();
        }
    }
}
