using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SpeakerAssignmentView
{
    public class CreateModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public CreateModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MemberID"] = new SelectList(_context.Member, "MemberID", "MemberName");
        ViewData["SubjectID"] = new SelectList(_context.Subject, "SubjectID", "SubjectName");
            return Page();
        }

        [BindProperty]
        public SpeakAssignment SpeakAssignment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SpeakAssignment.Add(SpeakAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}