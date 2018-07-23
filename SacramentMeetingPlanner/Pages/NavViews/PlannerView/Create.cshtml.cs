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
        public void PopulateRoleDropDownList(PlannerContext _context)
        {
            string[] namesValue = Enum.GetNames(typeof(Role));
            string[] namesText = Enum.GetNames(typeof(Role));
            Role[] values = (Role[])Enum.GetValues(typeof(Role));
            for (int i = 0; i < namesText.Length; i++)
            {
                namesText[i] = namesText[i].ToString().Replace("_", " ");
            }

            string result1 = string.Join(",", namesValue);
            string result2 = string.Join(",", namesText);
            Dictionary<string, string> selectObject = new Dictionary<string, string>();
            selectObject.Add(result1, result2);

            RoleNameSL = new SelectList(selectObject, "result1", "result2");
        }

        public SelectList SongNameSL { get; set; }
        public void PopulateSongNamesDownList(PlannerContext _context)
        {
            var songQuery = from d in _context.Song
                            orderby d.SongName // Sort by name.
                            select d.SongName;
            MemberNameSL = new SelectList(songQuery, "SongID", "SongName");
        }

        public SelectList MemberNameSL { get; set; }
        public void PopulateRoleMembersDownList(PlannerContext _context)
        {
            var roleQuery = from d in _context.Member
                            orderby d.MemberName // Sort by name.
                            select d.MemberName;
            MemberNameSL = new SelectList(roleQuery, "MemberID", "MemberName");
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