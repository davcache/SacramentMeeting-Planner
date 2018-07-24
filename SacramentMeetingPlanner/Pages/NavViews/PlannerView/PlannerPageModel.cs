using Microsoft.AspNetCore.Mvc.RazorPages;
using SacramentMeetingPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Pages.NavViews.PlannerView
{
    public class PlannerPageModel : PageModel
    {
        public List<Models.SongAssignment> SongAssignment;

        public void PopulateSongCheckboxes(PlannerContext context, Plans plan)
        {
            var allSongAssignments = context.SongAssignment;

            SongAssignment = new List<SongAssignment>();

            foreach (var assignment in allSongAssignments)
            {
                SongAssignment.Add(new SongAssignment
                {
                    SongAssignmentID = assignment.SongAssignmentID,
                    SongID = assignment.SongID,
                    Song = assignment.Song,
                    SongTypeID = assignment.SongTypeID,
                    SongType = assignment.SongType,
                    SongToPlan = assignment.SongToPlan
                });
            }
        }

        public List<SpeakAssignment> SpeakAssignment;
        public void PopulateSpeakerCheckboxes(PlannerContext context, Plans plan)
        {
            var allSpeakAssignments = context.SpeakAssignment;

            SpeakAssignment = new List<SpeakAssignment>();

            foreach (var assignment in allSpeakAssignments)
            {
                SpeakAssignment.Add(new SpeakAssignment
                {
                    SpeakAssignmentID = assignment.SpeakAssignmentID,
                    MemberID = assignment.MemberID,
                    Member = assignment.Member,
                    SubjectID = assignment.SubjectID,
                    Subject = assignment.Subject,
                    SpeakerPlacement = assignment.SpeakerPlacement,
                    SpeakToPlan = assignment.SpeakToPlan
                });
            }
        }

        public List<Prayer> Prayer;
        public void PopulatePrayerCheckboxes(PlannerContext context, Plans plan)
        {
            var allPrayerAssignments = context.Prayer;

            Prayer = new List<Prayer>();

            foreach (var assignment in allPrayerAssignments)
            {
                Prayer.Add(new Prayer
                {
                    PrayerID = assignment.PrayerID,
                    PrayerTypeID = assignment.PrayerTypeID,
                    PrayerType = assignment.PrayerType,
                    MemberID = assignment.MemberID,
                    Member = assignment.Member,
                    PrayerToPlan = assignment.PrayerToPlan
                });
            }
        }








        //public void UpdateInstructorCourses(SchoolContext context,
        //    string[] selectedCourses, Instructor instructorToUpdate)
        //{
        //    if (selectedCourses == null)
        //    {
        //        instructorToUpdate.CourseAssignments = new List<CourseAssignment>();
        //        return;
        //    }

        //    var selectedCoursesHS = new HashSet<string>(selectedCourses);
        //    var instructorCourses = new HashSet<int>
        //        (instructorToUpdate.CourseAssignments.Select(c => c.Course.CourseID));
        //    foreach (var course in context.Courses)
        //    {
        //        if (selectedCoursesHS.Contains(course.CourseID.ToString()))
        //        {
        //            if (!instructorCourses.Contains(course.CourseID))
        //            {
        //                instructorToUpdate.CourseAssignments.Add(
        //                    new CourseAssignment
        //                    {
        //                        InstructorID = instructorToUpdate.ID,
        //                        CourseID = course.CourseID
        //                    });
        //            }
        //        }
        //        else
        //        {
        //            if (instructorCourses.Contains(course.CourseID))
        //            {
        //                CourseAssignment courseToRemove
        //                    = instructorToUpdate
        //                        .CourseAssignments
        //                        .SingleOrDefault(i => i.CourseID == course.CourseID);
        //                context.Remove(courseToRemove);
        //            }
        //        }
        //    }
        //}
    }
}
