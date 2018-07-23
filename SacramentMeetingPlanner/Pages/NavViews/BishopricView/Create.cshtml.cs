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
                 "bishopric",   // Prefix for form value.
                 s => s.ReleasedFlag, s => s.RoleID, s => s.MemberID))
            {
                _context.Bishopric.Add(emptyBishopric);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateRoleMembersDropDownList(_context);
            PopulateRoleDropDownList(_context);
            return Page();
        }
    }
}