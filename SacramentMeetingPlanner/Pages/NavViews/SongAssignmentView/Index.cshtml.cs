using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SongAssignmentView
{
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public IndexModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IList<SongAssignment> SongAssignment { get;set; }

        public async Task OnGetAsync()
        {
            SongAssignment = await _context.SongAssignment
                .Include(s => s.Song)
                .Include(s => s.SongType).ToListAsync();
        }
    }
}
