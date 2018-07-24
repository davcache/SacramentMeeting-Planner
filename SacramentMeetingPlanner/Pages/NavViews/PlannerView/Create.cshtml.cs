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
    public class CreateModel : PlannerPageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerContext _context;

        public CreateModel(SacramentMeetingPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var plan = new Plans();
            plan.SongToPlan = new List<SongToPlan>();
            plan.SpeakToPlan = new List<SpeakToPlan>();
            plan.PrayerToPlan = new List<PrayerToPlan>();

            // Conducting Drop Down
            PopulateRoleDropDownList(_context);

            // Song checkboxes
            PopulateSongCheckboxes(_context, plan);

            // Speaker checkboxes
            PopulateSpeakerCheckboxes(_context, plan);

            // Prayer checkboxes
            PopulatePrayerCheckboxes(_context, plan);
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

        //public SelectList SongNameSL { get; set; }
        //public void PopulateSongNamesDownList(PlannerContext _context, object selectedSong = null)
        //{
        //    var songQuery = from d in _context.Song
        //                    orderby d.SongName // Sort by name.
        //                    select d;
        //    SongNameSL = new SelectList(songQuery, "SongID", "SongName", selectedSong);
        //}

        //public SelectList MemberNameSL { get; set; }
        //public void PopulateRoleMembersDownList(PlannerContext _context, object selectedMember = null)
        //{
        //    var memberRoleQuery = from d in _context.Member
        //                    orderby d.MemberName // Sort by name.
        //                    select d;
        //    MemberNameSL = new SelectList(memberRoleQuery, "MemberID", "MemberName", selectedMember);
        //}

        //public SelectList SubjectNameSL { get; set; }
        //public void PopulateSubjectsDownList(PlannerContext _context, object selectedSubject = null)
        //{
        //    var subjectNameQuery = from d in _context.Subject
        //                          orderby d.SubjectName // Sort by name.
        //                          select d;
        //    SubjectNameSL = new SelectList(subjectNameQuery, "SubjectID", "SubjectName", selectedSubject);
        //}






        [BindProperty]
        public Plans Plans { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedSongs, string[] selectedSpeakers, string[] selectedPrayers)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var plan = new Plans();

            if (selectedSongs != null)
            {
                plan.SongToPlan = new List<SongToPlan>();
                foreach (var song in selectedSongs)
                {
                    var songToAdd = new SongToPlan
                    {
                        SongAssignmentID = int.Parse(song)
                    };
                    plan.SongToPlan.Add(songToAdd);
                }
            }

            if (selectedSpeakers != null)
            {
                plan.SpeakToPlan = new List<SpeakToPlan>();
                foreach (var speaker in selectedSpeakers)
                {
                    var speakerToAdd = new SpeakToPlan
                    {
                        SpeakAssignmentID = int.Parse(speaker)
                    };
                    plan.SpeakToPlan.Add(speakerToAdd);
                }
            }

            if (selectedPrayers != null)
            {
                plan.PrayerToPlan = new List<PrayerToPlan>();
                foreach (var pray in selectedPrayers)
                {
                    var prayToAdd = new PrayerToPlan
                    {
                        PrayerToPlanID = int.Parse(pray)
                    };
                    plan.PrayerToPlan.Add(prayToAdd);
                }
            }

            if (await TryUpdateModelAsync<Plans>(
                plan,
                "plans",
                i => i.PlansID,
                i => i.PlanDate,
                i => i.RoleID))
            {
                _context.Plans.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Conducting Drop Down
            PopulateRoleDropDownList(_context);

            // Song checkboxes
            PopulateSongCheckboxes(_context, plan);

            // Speaker checkboxes
            PopulateSpeakerCheckboxes(_context, plan);

            // Prayer checkboxes
            PopulatePrayerCheckboxes(_context, plan); 

            _context.Plans.Add(Plans);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}