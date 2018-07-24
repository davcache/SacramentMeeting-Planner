using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.PlannerView
{
    public class DetailsModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public DetailsModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public Plans Plans { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plans = await _context.Plans
                .Include(p => p.Role)
                .Include(p => p.SongToPlan)
                    .ThenInclude(p => p.SongAssignment)
                        .ThenInclude(p => p.Song)
                .Include(p => p.SongToPlan)
                    .ThenInclude(p => p.SongAssignment)
                        .ThenInclude(p => p.SongType)
                .Include(p => p.PrayerToPlan)
                    .ThenInclude(p => p.PrayerType)
                .Include(p => p.PrayerToPlan)
                    .ThenInclude(p => p.Member)
                .Include(p => p.SpeakToPlan)
                    .ThenInclude(p => p.SpeakAssignment)
                        .ThenInclude(p => p.Member)
                .Include(p => p.SpeakToPlan)
                    .ThenInclude(p => p.SpeakAssignment)
                        .ThenInclude(p => p.Subject)
                .FirstOrDefaultAsync(m => m.PlansID == id);

            if (Plans == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
