using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SpeakToPlanView
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SpeakToPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakToPlanExists(SpeakToPlan.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpeakToPlanExists(int id)
        {
            return _context.SpeakToPlan.Any(e => e.ID == id);
        }
    }
}
