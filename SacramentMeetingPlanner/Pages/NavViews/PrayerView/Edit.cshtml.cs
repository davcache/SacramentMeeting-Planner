using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.PrayerView
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["MemberID"] = new SelectList(_context.Member, "MemberID", "MemberID");
           ViewData["PrayerTypeID"] = new SelectList(_context.PrayerType, "PrayerTypeID", "PrayerTypeID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Prayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrayerExists(Prayer.PrayerID))
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

        private bool PrayerExists(int id)
        {
            return _context.Prayer.Any(e => e.PrayerID == id);
        }
    }
}
