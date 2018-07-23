using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.PlannerView
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
            return Page();
        }

        public SelectList RoleNameSL { get; set; }
        public string RoleName { get; set; }
        public void PopulateRoleDropDownList(PlannerContext _context)
        {
            var roleQuery = from d in _context.Role
                            orderby d.RoleTypeName // Sort by name.
                            select d.RoleTypeName;
            MemberNameSL = new SelectList(roleQuery, "RoleID", "RoleTypeName");
        }

        public SelectList SongNameSL { get; set; }
        public string SongName { get; set; }
        public void PopulateSongNamesDownList(PlannerContext _context)
        {
            var songQuery = from d in _context.Song
                            orderby d.SongName // Sort by name.
                            select d.SongName;
            MemberNameSL = new SelectList(songQuery, "SongID", "SongName");
        }

        public SelectList MemberNameSL { get; set; }
        public string MemberName { get; set; }
        public void PopulateRoleMembersDownList(PlannerContext _context)
        {
            var memberRoleQuery = from d in _context.Member
                            orderby d.MemberName // Sort by name.
                            select d.MemberName;
            MemberNameSL = new SelectList(memberRoleQuery, "MemberID", "MemberName");
        }

        [BindProperty]
        public Plans Plans { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Plans.Add(Plans);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}