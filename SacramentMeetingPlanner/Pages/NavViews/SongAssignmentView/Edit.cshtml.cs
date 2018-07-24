using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.SongAssignmentView
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["SongID"] = new SelectList(_context.Song, "SongID", "SongName");
           ViewData["SongTypeID"] = new SelectList(_context.SongType, "SongTypeID", "SongTypeName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SongAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongAssignmentExists(SongAssignment.SongAssignmentID))
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

        private bool SongAssignmentExists(int id)
        {
            return _context.SongAssignment.Any(e => e.SongAssignmentID == id);
        }
    }
}
