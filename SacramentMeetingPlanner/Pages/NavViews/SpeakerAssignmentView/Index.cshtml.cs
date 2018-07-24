using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SpeakerAssignmentView
{
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public IndexModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IList<SpeakAssignment> SpeakAssignment { get;set; }

        public async Task OnGetAsync()
        {
            SpeakAssignment = await _context.SpeakAssignment
                .Include(s => s.Member)
                .Include(s => s.Subject).ToListAsync();
        }
    }
}
