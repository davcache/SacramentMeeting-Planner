using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Models;
using SacramentMeetingPlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Pages.NavViews.BishopricView
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
            PopulateRoleMembersDropDownList(_context);
            PopulateRoleDropDownList(_context);
            return Page();
        }

        public SelectList MemberNameSL { get; set; }
        public void PopulateRoleMembersDropDownList(PlannerContext _context, object selectedMember = null)
        {
            var memberQuery = from m in _context.Member
                              orderby m.MemberName // Sort by MemberName.
                              select m.MemberName;
            MemberNameSL = new SelectList(memberQuery.AsNoTracking(), "MemberID", "MemberName", selectedMember);
        }

        public SelectList RoleNameSL { get; set; }
        public void PopulateRoleDropDownList(PlannerContext _context, object selectedRole = null)
        {
            var roleQuery = from r in _context.Role
                            orderby r.RoleTypeName // Sort by RoleTypeName.
                            select r.RoleTypeName;
            RoleNameSL = new SelectList(roleQuery.AsNoTracking(), "RoleID", "RoleTypeName", selectedRole);
        }

        [BindProperty]
        public Bishopric Bishopric { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyBishopric = new Bishopric();

            if (await TryUpdateModelAsync<Bishopric>(
                emptyBishopric,
                "bishopric",
                b => b.MemberID, b => b.RoleID, b => b.ReleasedFlag))
            {
                _context.Bishopric.Add(emptyBishopric);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select MemberID and RoleID if TryUpdateModelAsync fails.
            PopulateRoleMembersDropDownList(_context, emptyBishopric.MemberID);
            PopulateRoleDropDownList(_context, emptyBishopric.RoleID);
            return RedirectToPage("./Index");
        }
    }
}