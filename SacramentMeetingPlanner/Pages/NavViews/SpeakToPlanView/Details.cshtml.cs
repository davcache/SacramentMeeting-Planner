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
    public class DetailsModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public DetailsModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public SpeakToPlan SpeakToPlan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SpeakToPlan = await _context.SpeakToPlan.FirstOrDefaultAsync(m => m.ID == id);

            if (SpeakToPlan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
