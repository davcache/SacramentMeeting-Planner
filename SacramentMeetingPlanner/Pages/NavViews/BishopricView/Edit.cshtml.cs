using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.BishopricView
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bishopric Bishopric { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bishopric = await _context.Bishopric
                .Include(m => m.Member).ThenInclude(m => m.MemberName)
                .Include(m => m.Role).ThenInclude(m => m.RoleTypeName)
                .FirstOrDefaultAsync(m => m.BishopricID == id);

            if (Bishopric == null)
            {
                return NotFound();
            }
            //PopulateRoleDropDownList(_context);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bishopric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BishopricExists(Bishopric.BishopricID))
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

        private bool BishopricExists(int id)
        {
            return _context.Bishopric.Any(e => e.BishopricID == id);
        }
    }
}
