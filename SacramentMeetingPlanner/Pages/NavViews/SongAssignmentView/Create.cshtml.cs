using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SongAssignmentView
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
        ViewData["SongID"] = new SelectList(_context.Song, "SongID", "SongName");
        ViewData["SongTypeID"] = new SelectList(_context.SongType, "SongTypeID", "SongTypeName");
            return Page();
        }

        [BindProperty]
        public SongAssignment SongAssignment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SongAssignment.Add(SongAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}