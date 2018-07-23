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

            //Bishopric = await _context.Bishopric
            //    .Include(m => m.Member).ThenInclude(m => m.MemberName)
            //    .Include(m => m.Role).ThenInclude(m => m.RoleTypeName)
            //    .FirstOrDefaultAsync(m => m.BishopricID == id);

            Bishopric = await _context.Bishopric.FirstOrDefaultAsync(m => m.BishopricID == id);

            if (Bishopric == null)
            {
                return NotFound();
            }

            PopulateRoleMembersDropDownList(_context);
            PopulateRoleDropDownList(_context);

            return Page();
        }

        public SelectList MemberNameSL { get; set; }
        public void PopulateRoleMembersDropDownList(PlannerContext _context)
        {
            var memberQuery = from m in _context.Member
                              orderby m.MemberName // Sort by MemberName.
                              select m;
            MemberNameSL = new SelectList(memberQuery.AsNoTracking(), "MemberID", "MemberName");
        }

        public SelectList RoleNameSL { get; set; }
        //public string RoleName { get; set; }
        public void PopulateRoleDropDownList(PlannerContext _context)
        {
            var roleQuery = from d in _context.Role
                            orderby d.RoleTypeName // Sort by name.
                            select d;
            RoleNameSL = new SelectList(roleQuery, "RoleID", "RoleTypeName");
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
