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
            var plans = new Plans();
            plans.SongToPlan = new List<SongToPlan>();
            plans.SpeakToPlan = new List<SpeakToPlan>();
            plans.PrayerToPlan = new List<PrayerToPlan>();

            PopulateRoleDropDownList(_context);
            //PopulateSongNamesDownList(_context); // Works but leads to creation of a multiple select dropdown list
            PopulateSongDataDropDown(_context, plans);
            PopulateRoleMembersDownList(_context);
            return Page();
        }

        public SelectList RoleNameSL { get; set; }
        public void PopulateRoleDropDownList(PlannerContext _context, object selectedRole = null)
        {
            var roleQuery = from d in _context.Role
                            orderby d.RoleTypeName // Sort by name.
                            select d;
            RoleNameSL = new SelectList(roleQuery, "RoleID", "RoleTypeName", selectedRole);
        }

        public SelectList SongNameSL { get; set; }
        public void PopulateSongNamesDownList(PlannerContext _context, object selectedSong = null)
        {
            var songQuery = from d in _context.Song
                            orderby d.SongName // Sort by name.
                            select d;
            SongNameSL = new SelectList(songQuery, "SongID", "SongName", selectedSong);
        }

        public SelectList MemberNameSL { get; set; }
        public void PopulateRoleMembersDownList(PlannerContext _context, object selectedMember = null)
        {
            var memberRoleQuery = from d in _context.Member
                            orderby d.MemberName // Sort by name.
                            select d;
            MemberNameSL = new SelectList(memberRoleQuery, "MemberID", "MemberName", selectedMember);
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

        public List<SongAssignment> AssignedSongDataList;

        public void PopulateSongDataDropDown(PlannerContext context, Plans plans)
        {
            var allSongAssignments = context.SongAssignment;
            var planSongs = new HashSet<int>(
                plans.SongToPlan.Select(s => s.SongAssignmentID));
            AssignedSongDataList = new List<SongAssignment>();
            foreach (var assignment in allSongAssignments)
            {
                AssignedSongDataList.Add(new SongAssignment
                {
                    SongID = assignment.SongID,
                    Song = assignment.Song,
                    SongTypeID = assignment.SongTypeID,
                    SongType = assignment.SongType
                });
            }
        }
    }
}