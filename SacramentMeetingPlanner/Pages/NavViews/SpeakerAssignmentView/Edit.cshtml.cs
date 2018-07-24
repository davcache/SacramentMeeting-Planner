using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SpeakerAssignmentView
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SpeakAssignment SpeakAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SpeakAssignment = await _context.SpeakAssignment
                .Include(s => s.Member)
                .Include(s => s.Subject).FirstOrDefaultAsync(m => m.SpeakAssignmentID == id);

            if (SpeakAssignment == null)
            {
                return NotFound();
            }
           ViewData["MemberID"] = new SelectList(_context.Member, "MemberID", "MemberName");
           ViewData["SubjectID"] = new SelectList(_context.Subject, "SubjectID", "SubjectName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SpeakAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakAssignmentExists(SpeakAssignment.SpeakAssignmentID))
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

        private bool SpeakAssignmentExists(int id)
        {
            return _context.SpeakAssignment.Any(e => e.SpeakAssignmentID == id);
        }
    }
}
