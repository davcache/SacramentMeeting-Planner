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
    public class DetailsModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public DetailsModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public SongAssignment SongAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SongAssignment = await _context.SongAssignment
                .Include(s => s.Song)
                .Include(s => s.SongType).FirstOrDefaultAsync(m => m.SongAssignmentID == id);

            if (SongAssignment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
