using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SubjectsView
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Subjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsExists(Subjects.ID))
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

        private bool SubjectsExists(int id)
        {
            return _context.Subjects.Any(e => e.ID == id);
        }
    }
}
