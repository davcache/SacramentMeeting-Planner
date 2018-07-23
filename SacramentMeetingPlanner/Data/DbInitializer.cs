using System;
using System.Linq;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PlannerContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any roles.
            if (context.Role.Any())
            {
                return;   // DB has been seeded
            }

            // ------------------------------------Role----------------------------------
            var roles = new Role[]
            {
                new Role {
                    RoleTypeName = "Bishop"
                },
                new Role {
                    RoleTypeName = "First Counselor"
                },
                new Role {
                    RoleTypeName = "Second Counselor"
                }
            };

            foreach (Role r in roles)
            {
                context.Role.Add(r);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Member----------------------------------
            var members = new Member[]
            {
                new Member {
                    MemberName = "Michael Jordan"
                },
                new Member {
                    MemberName = "Gandhi"
                },
                new Member {
                    MemberName = "Donald Trump Jr."
                },
                new Member {
                    MemberName = "Dick Van Dyke"
                },
                new Member {
                    MemberName = "Benjamin Franklin"
                },
                new Member {
                    MemberName = "Winston Churchill"
                },
                new Member {
                    MemberName = "Bill Gates"
                },
                new Member {
                    MemberName = "Steve Jobs"
                },
                new Member {
                    MemberName = "Elvis Presley"
                },
                new Member {
                    MemberName = "Mother Teresa"
                },
                new Member {
                    MemberName = "Martin Luther King"
                },
                new Member {
                    MemberName = "JFK"
                },
                new Member {
                    MemberName = "Abraham Lincoln"
                },
                new Member {
                    MemberName = "Leonardo da Vinci"
                },
                new Member {
                    MemberName = "Tom Cruise"
                }
            };

            foreach (Member m in members)
            {
                context.Member.Add(m);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------PrayerType----------------------------------
            var prayerTypes = new PrayerType[]
            {
                new PrayerType {
                    PrayerTypeName = "Opening Prayer"
                },
                new PrayerType {
                    PrayerTypeName = "Closing Prayer"
                }
            };

            foreach (PrayerType pt in prayerTypes)
            {
                context.PrayerType.Add(pt);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Songs----------------------------------
            var songs = new Song[]
            {
                new Song {
                    SongName = "I Saw a Mighty Angel Fly",
                    SongNumber = 15
                },
                new Song {
                    SongName = "We Thank Thee, O God, for a Prophet",
                    SongNumber = 19
                },
                new Song {
                    SongName = "While of These Emblems We Partake",
                    SongNumber = 173
                },
                new Song {
                    SongName = "Reverently and Meekly Now",
                    SongNumber = 185
                },
                new Song {
                    SongName = "I Stand All Amazed",
                    SongNumber = 193
                },
                new Song {
                    SongName = "He Is Risen!",
                    SongNumber = 199
                },
                new Song {
                    SongName = "Put Your Shoulder to the Wheel",
                    SongNumber = 252
                },
                new Song {
                    SongName = "Hope of Israel",
                    SongNumber = 259
                },
                new Song {
                    SongName = "Arise, O God, and Shine",
                    SongNumber = 265
                },
                new Song {
                    SongName = "The Iron Rod",
                    SongNumber = 274
                }
            };

            foreach (Song s in songs)
            {
                context.Song.Add(s);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SongType----------------------------------
            var songTypes = new SongType[]
            {
                new SongType {
                    SongTypeName = "Opening Song"
                },
                new SongType {
                    SongTypeName = "Sacrament Song"
                },
                new SongType {
                    SongTypeName = "Intermediate Song"
                },
                new SongType {
                    SongTypeName = "Closing Song"
                }
            };

            foreach (SongType st in songTypes)
            {
                context.SongType.Add(st);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Subject----------------------------------
            var subjects = new Subject[]
            {
                new Subject {
                    SubjectName = "Hope"
                },
                new Subject {
                    SubjectName = "Repentance"
                },
                new Subject {
                    SubjectName = "Love"
                },
                new Subject {
                    SubjectName = "Ministering"
                },
                new Subject {
                    SubjectName = "Family Home Evening"
                },
                new Subject {
                    SubjectName = "Tithing"
                },
                new Subject {
                    SubjectName = "The Atonement"
                },
                new Subject {
                    SubjectName = "The Relief Society"
                },
                new Subject {
                    SubjectName = "The Priesthood"
                },
                new Subject {
                    SubjectName = "Magnifying Callings"
                }
            };

            foreach (Subject s in subjects)
            {
                context.Subject.Add(s);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Bishopric----------------------------------
            var bishopric = new Bishopric[]
            {
                new Bishopric {
                    RoleID = roles.Single( s => s.RoleTypeName == "Bishop").RoleID,
                    MemberID = members.Single( s => s.MemberName == "Michael Jordan").MemberID
                },
                new Bishopric {
                    RoleID = roles.Single( s => s.RoleTypeName == "First Counselor").RoleID,
                    MemberID = members.Single( s => s.MemberName == "Gandhi").MemberID
                },
                new Bishopric {
                    RoleID = roles.Single( s => s.RoleTypeName == "Second Counselor").RoleID,
                    MemberID = members.Single( s => s.MemberName == "Donald Trump Jr.").MemberID
                },
                new Bishopric {
                    RoleID = roles.Single( s => s.RoleTypeName == "Bishop").RoleID,
                    MemberID = members.Single( s => s.MemberName == "Dick Van Dyke").MemberID,
                    ReleasedFlag = true
                },
                new Bishopric {
                    RoleID = roles.Single( s => s.RoleTypeName == "First Counselor").RoleID,
                    MemberID = members.Single( s => s.MemberName == "Benjamin Franklin").MemberID,
                    ReleasedFlag = true
                }
            };

            foreach (Bishopric b in bishopric)
            {
                context.Bishopric.Add(b);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Plans----------------------------------
            var plans = new Plans[]
            {
                new Plans {
                    PlanDate = DateTime.Parse("2018-07-22"),
                    RoleID = roles.Single( s => s.RoleTypeName == "First Counselor").RoleID
                },
                new Plans {
                    PlanDate = DateTime.Parse("2018-07-15"),
                    RoleID = roles.Single( s => s.RoleTypeName == "Bishop").RoleID
                },
                new Plans {
                    PlanDate = DateTime.Parse("2018-07-08"),
                    RoleID = roles.Single( s => s.RoleTypeName == "Second Counselor").RoleID
                },
                new Plans {
                    PlanDate = DateTime.Parse("2018-07-01"),
                    RoleID = roles.Single( s => s.RoleTypeName == "Bishop").RoleID
                },
                new Plans {
                    PlanDate = DateTime.Parse("2018-06-24"),
                    RoleID = roles.Single( s => s.RoleTypeName == "Bishop").RoleID
                },
            };

            foreach (Plans p in plans)
            {
                context.Plans.Add(p);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Prayer----------------------------------
            var prayers = new Prayer[]
            {
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Michael Jordan").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Gandhi").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Donald Trump Jr.").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Dick Van Dyke").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Benjamin Franklin").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Winston Churchill").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Bill Gates").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Steve Jobs").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Elvis Presley").MemberID
                },
                new Prayer {
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Mother Teresa").MemberID
                }
            };

            foreach (Prayer p in prayers)
            {
                context.Prayer.Add(p);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------PrayerToPlan----------------------------------
            var prayerToPlans = new PrayerToPlan[]
            {
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Michael Jordan").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Gandhi").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 2).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Donald Trump Jr.").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 2).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Dick Van Dyke").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Benjamin Franklin").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Winston Churchill").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 4).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Bill Gates").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 4).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Steve Jobs").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Elvis Presley").MemberID
                },
                new PrayerToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    PrayerTypeID = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer").PrayerTypeID,
                    MemberID = members.Single( s => s.MemberName == "Mother Teresa").MemberID
                }
            };

            foreach (PrayerToPlan ptp in prayerToPlans)
            {
                context.PrayerToPlan.Add(ptp);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SongAssignment----------------------------------

            //Opening Song
            //Sacrament Song
            //Intermediate Song
            //Closing Song                

            var songAssignments = new SongAssignment[]
            {
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "I Saw a Mighty Angel Fly").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Opening Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "While of These Emblems We Partake").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Sacrament Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "He Is Risen!").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Intermediate Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "We Thank Thee, O God, for a Prophet").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Closing Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "I Saw a Mighty Angel Fly").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Opening Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "While of These Emblems We Partake").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Sacrament Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "We Thank Thee, O God, for a Prophet").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Closing Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "I Saw a Mighty Angel Fly").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Opening Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "Reverently and Meekly Now").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Sacrament Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "He Is Risen!").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Intermediate Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "Hope of Israel").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Closing Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "I Saw a Mighty Angel Fly").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Opening Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "While of These Emblems We Partake").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Sacrament Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "We Thank Thee, O God, for a Prophet").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Closing Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "Arise, O God, and Shine").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Opening Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "While of These Emblems We Partake").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Sacrament Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "Put Your Shoulder to the Wheel").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Intermediate Song").SongTypeID
                },
                new SongAssignment {
                    SongID = songs.Single( s => s.SongName == "Hope of Israel").SongID,
                    SongTypeID = songTypes.Single( s => s.SongTypeName == "Closing Song").SongTypeID
                }
            };

            foreach (SongAssignment sa in songAssignments)
            {
                context.SongAssignment.Add(sa);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SongToPlan----------------------------------
            var songToPlans = new SongToPlan[]
            {
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 1).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 2).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 3).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 4).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 2).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 5).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 2).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 6).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 2).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 7).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 8).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 9).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 10).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 11).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 4).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 12).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 4).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 13).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 4).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 14).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 15).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 16).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 17).SongAssignmentID
                },
                new SongToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    SongAssignmentID = songAssignments.Single( s => s.SongAssignmentID == 18).SongAssignmentID
                },

            };

            foreach (SongToPlan stp in songToPlans)
            {
                context.SongToPlan.Add(stp);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SpeakAssignment----------------------------------
            var speakAssignments = new SpeakAssignment[]
            {
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Dick Van Dyke").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Hope").SubjectID,
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Benjamin Franklin").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Repentance").SubjectID,
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Winston Churchill").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Love").SubjectID,
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Bill Gates").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Ministering").SubjectID,
                    SpeakerPlacement = 4
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Steve Jobs").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Family Home Evening").SubjectID,
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Elvis Presley").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Tithing").SubjectID,
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Mother Teresa").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "The Atonement").SubjectID,
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Martin Luther King").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "The Relief Society").SubjectID,
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "JFK").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "The Priesthood").SubjectID,
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Abraham Lincoln").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Magnifying Callings").SubjectID,
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Leonardo da Vinci").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Hope").SubjectID,
                    SpeakerPlacement = 4
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Tom Cruise").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Repentance").SubjectID,
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Dick Van Dyke").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Love").SubjectID,
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Benjamin Franklin").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Ministering").SubjectID,
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Winston Churchill").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Family Home Evening").SubjectID,
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Bill Gates").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "Tithing").SubjectID,
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Steve Jobs").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "The Atonement").SubjectID,
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    MemberID = members.Single( s => s.MemberName == "Elvis Presley").MemberID,
                    SubjectID = subjects.Single( s => s.SubjectName == "The Relief Society").SubjectID,
                    SpeakerPlacement = 4
                }
            };

            foreach (SpeakAssignment sa in speakAssignments)
            {
                context.SpeakAssignment.Add(sa);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SpeakToPlan----------------------------------
            var speakToPlans = new SpeakToPlan[]
            {
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 1).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 2).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 3).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 1).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 4).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 2).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 5).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 2).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 6).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 2).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 7).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 8).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 9).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 10).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 3).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 11).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 4).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 12).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 4).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 13).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 4).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 14).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 15).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 16).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 17).SpeakAssignmentID
                },
                new SpeakToPlan {
                    PlansID = plans.Single( s => s.PlansID == 5).PlansID,
                    SpeakAssignmentID = speakAssignments.Single( s => s.SpeakAssignmentID == 18).SpeakAssignmentID
                }
            };

            foreach (SpeakToPlan stp in speakToPlans)
            {
                context.SpeakToPlan.Add(stp);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------
        }
    }
}