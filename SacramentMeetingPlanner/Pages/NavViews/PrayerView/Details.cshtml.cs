using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.PrayerView
{
    public class DetailsModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public DetailsModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public Prayer Prayer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prayer = await _context.Prayer
                .Include(p => p.Member)
                .Include(p => p.PrayerType).FirstOrDefaultAsync(m => m.PrayerID == id);

            if (Prayer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
