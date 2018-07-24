using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.NavViews.PlannerView
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateRoleDropDownList(_context);
            PopulateSongNamesDownList(_context);
            PopulateRoleMembersDownList(_context);
            PopulateSubjectsDownList(_context);
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

        public SelectList SubjectNameSL { get; set; }
        public void PopulateSubjectsDownList(PlannerContext _context, object selectedSubject = null)
        {
            var subjectNameQuery = from d in _context.Subject
                                   orderby d.SubjectName // Sort by name.
                                   select d;
            SubjectNameSL = new SelectList(subjectNameQuery, "SubjectID", "SubjectName", selectedSubject);
        }

        [BindProperty]
        public Plans Plans { get; set; }

        [BindProperty]
        public SongAssignment SongAssignment { get; set; }

        [BindProperty]
        public SpeakAssignment SpeakAssignment { get; set; }

        [BindProperty]
        public Prayer Prayer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Plans).State = EntityState.Modified;
            _context.Attach(SongAssignment).State = EntityState.Modified;
            _context.Attach(SpeakAssignment).State = EntityState.Modified;
            _context.Attach(Prayer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlansExists(Plans.PlansID))
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

        private bool PlansExists(int id)
        {
            return _context.Plans.Any(e => e.PlansID == id);
        }
    }
}