﻿using System;
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
            PopulateRoleMembersDownList(_context);
            PopulateRoleDropDownList(_context);
            return Page();
        }

        public SelectList RoleNameSL { get; set; }
        public void PopulateRoleDropDownList(PlannerContext _context)
        {
            var roleQuery = from d in _context.Role
                            orderby d.RoleTypeName // Sort by RoleTypeName.
                            select d.RoleTypeName;
            RoleNameSL = new SelectList(roleQuery.AsNoTracking(), "RoleID", "RoleTypeName");
        }

        public SelectList MemberNameSL { get; set; }
        public void PopulateRoleMembersDownList(PlannerContext _context)
        {
            var memberQuery = from d in _context.Member
                            orderby d.MemberName // Sort by name.
                            select d.MemberName;
            MemberNameSL = new SelectList(memberQuery.AsNoTracking(), "MemberID", "MemberName");
        }

        [BindProperty]
        public Bishopric Bishopric { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bishopric.Add(Bishopric);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}