using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SubjectsView
{
    public class DetailsModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public DetailsModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public Subjects Subjects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subjects = await _context.Subjects.FirstOrDefaultAsync(m => m.ID == id);

            if (Subjects == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
