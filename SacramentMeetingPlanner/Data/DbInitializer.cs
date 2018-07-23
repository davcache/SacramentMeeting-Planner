using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PlannerContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any subjects.
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

            foreach (Role role in roles)
            {
                context.Role.Add(role);
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

            foreach (PrayerType prayerType in prayerTypes)
            {
                context.PrayerType.Add(prayerType);
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

            foreach (Song song in songs)
            {
                context.Song.Add(song);
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

            foreach (SongType songType in songTypes)
            {
                context.SongType.Add(songType);
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

            foreach (Subject subject in subjects)
            {
                context.Subject.Add(subject);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Bishopric----------------------------------
            var bishopric = new Bishopric[]
            {
                new Bishopric {
                    Role = roles.Single( s => s.RoleTypeName == "Bishop"),
                    Member = members.Single( s => s.MemberName == "Michael Jordan")
                },
                new Bishopric {
                    Role = roles.Single( s => s.RoleTypeName == "First Counselor"),
                    Member = members.Single( s => s.MemberName == "Gandhi")
                },
                new Bishopric {
                    Role = roles.Single( s => s.RoleTypeName == "Second Counselor"),
                    Member = members.Single( s => s.MemberName == "Donald Trump Jr.")
                },
                new Bishopric {
                    Role = roles.Single( s => s.RoleTypeName == "Bishop"),
                    Member = members.Single( s => s.MemberName == "Dick Van Dyke"),
                    ReleasedFlag = true
                },
                new Bishopric {
                    Role = roles.Single( s => s.RoleTypeName == "First Counselor"),
                    Member = members.Single( s => s.MemberName == "Benjamin Franklin"),
                    ReleasedFlag = true
                }
            };

            foreach (Bishopric bishopricPeeps in bishopric)
            {
                context.Bishopric.Add(bishopricPeeps);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Plans----------------------------------
            var plans = new Plans[]
            {
                new Plans {
                    PlanDate = DateTime.Parse("2018-22-07"),
                    Bishopric = bishopric.Single( s => s.BishopricID == 1)
                },
                new Plans {
                    PlanDate = DateTime.Parse("2018-15-07"),
                    Bishopric = bishopric.Single( s => s.BishopricID == 2)
                },
                new Plans {
                    PlanDate = DateTime.Parse("2018-08-07"),
                    Bishopric = bishopric.Single( s => s.BishopricID == 3)
                },
                new Plans {
                    PlanDate = DateTime.Parse("2018-01-07"),
                    Bishopric = bishopric.Single( s => s.BishopricID == 4)
                },
                new Plans {
                    PlanDate = DateTime.Parse("2018-24-06"),
                    Bishopric = bishopric.Single( s => s.BishopricID == 5)
                },
            };

            foreach (Plans plan in plans)
            {
                context.Plans.Add(plan);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------Prayer----------------------------------
            var prayers = new Prayer[]
            {
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer"),
                    Member = members.Single( s => s.MemberName == "Michael Jordan")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer"),
                    Member = members.Single( s => s.MemberName == "Gandhi")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer"),
                    Member = members.Single( s => s.MemberName == "Donald Trump Jr.")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer"),
                    Member = members.Single( s => s.MemberName == "Dick Van Dyke")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer"),
                    Member = members.Single( s => s.MemberName == "Benjamin Franklin")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer"),
                    Member = members.Single( s => s.MemberName == "Winston Churchill")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer"),
                    Member = members.Single( s => s.MemberName == "Bill Gates")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer"),
                    Member = members.Single( s => s.MemberName == "Steve Jobs")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Opening Prayer"),
                    Member = members.Single( s => s.MemberName == "Elvis Presley")
                },
                new Prayer {
                    PrayerType = prayerTypes.Single( s => s.PrayerTypeName == "Closing Prayer"),
                    Member = members.Single( s => s.MemberName == "Mother Teresa")
                }
            };

            foreach (Prayer prayer in prayers)
            {
                context.Prayer.Add(prayer);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------PrayerToPlan----------------------------------
            var prayerToPlans = new PrayerToPlan[]
            {
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    Prayer = prayers.Single( s => s.PrayerID == 1)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    Prayer = prayers.Single( s => s.PrayerID == 2)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 2),
                    Prayer = prayers.Single( s => s.PrayerID == 3)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 2),
                    Prayer = prayers.Single( s => s.PrayerID == 4)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    Prayer = prayers.Single( s => s.PrayerID == 5)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    Prayer = prayers.Single( s => s.PrayerID == 6)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 4),
                    Prayer = prayers.Single( s => s.PrayerID == 7)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 4),
                    Prayer = prayers.Single( s => s.PrayerID == 8)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    Prayer = prayers.Single( s => s.PrayerID == 9)
                },
                new PrayerToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    Prayer = prayers.Single( s => s.PrayerID == 10)
                }
            };

            foreach (PrayerToPlan prayerToPlan in prayerToPlans)
            {
                context.PrayerToPlan.Add(prayerToPlan);
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
                    Song = songs.Single( s => s.SongName == "I Saw a Mighty Angel Fly"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Opening Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "While of These Emblems We Partake"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Sacrament Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "He Is Risen!"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Intermediate Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "We Thank Thee, O God, for a Prophet"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Closing Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "I Saw a Mighty Angel Fly"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Opening Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "While of These Emblems We Partake"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Sacrament Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "We Thank Thee, O God, for a Prophet"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Closing Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "I Saw a Mighty Angel Fly"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Opening Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "Reverently and Meekly Now"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Sacrament Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "He Is Risen!"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Intermediate Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "Hope of Israel"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Closing Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "I Saw a Mighty Angel Fly"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Opening Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "While of These Emblems We Partake"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Sacrament Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "We Thank Thee, O God, for a Prophet"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Closing Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "Arise, O God, and Shine"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Opening Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "While of These Emblems We Partake"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Sacrament Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "Put Your Shoulder to the Wheel"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Intermediate Song")
                },
                new SongAssignment {
                    Song = songs.Single( s => s.SongName == "Hope of Israel"),
                    SongType = songTypes.Single( s => s.SongTypeName == "Closing Song")
                }
            };

            foreach (SongAssignment songAssignment in songAssignments)
            {
                context.SongAssignment.Add(songAssignment);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SongToPlan----------------------------------
            var songToPlans = new SongToPlan[]
            {
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 1)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 2)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 3)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 4)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 2),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 5)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 2),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 6)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 2),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 7)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 8)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 9)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 10)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 11)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 4),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 12)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 4),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 13)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 4),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 14)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 15)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 16)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 17)
                },
                new SongToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    SongAssignment = songAssignments.Single( s => s.SongAssignmentID == 18)
                },

            };

            foreach (SongToPlan songToPlan in songToPlans)
            {
                context.SongToPlan.Add(songToPlan);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SpeakAssignment----------------------------------
            var speakAssignments = new SpeakAssignment[]
            {
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Dick Van Dyke"),
                    Subject = subjects.Single( s => s.SubjectName == "Hope"),
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Benjamin Franklin"),
                    Subject = subjects.Single( s => s.SubjectName == "Repentance"),
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Winston Churchill"),
                    Subject = subjects.Single( s => s.SubjectName == "Love"),
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Bill Gates"),
                    Subject = subjects.Single( s => s.SubjectName == "Ministering"),
                    SpeakerPlacement = 4
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Steve Jobs"),
                    Subject = subjects.Single( s => s.SubjectName == "Family Home Evening"),
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "Tithing"),
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Mother Teresa"),
                    Subject = subjects.Single( s => s.SubjectName == "The Atonement"),
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Martin Luther King"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society"),
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "JFK"),
                    Subject = subjects.Single( s => s.SubjectName == "The Priesthood"),
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Abraham Lincoln"),
                    Subject = subjects.Single( s => s.SubjectName == "Magnifying Callings"),
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Leonardo da Vinci"),
                    Subject = subjects.Single( s => s.SubjectName == "Hope"),
                    SpeakerPlacement = 4
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Tom Cruise"),
                    Subject = subjects.Single( s => s.SubjectName == "Repentance"),
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Dick Van Dyke"),
                    Subject = subjects.Single( s => s.SubjectName == "Love"),
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Benjamin Franklin"),
                    Subject = subjects.Single( s => s.SubjectName == "Ministering"),
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Winston Churchill"),
                    Subject = subjects.Single( s => s.SubjectName == "Family Home Evening"),
                    SpeakerPlacement = 1
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Bill Gates"),
                    Subject = subjects.Single( s => s.SubjectName == "Tithing"),
                    SpeakerPlacement = 2
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Steve Jobs"),
                    Subject = subjects.Single( s => s.SubjectName == "The Atonement"),
                    SpeakerPlacement = 3
                },
                new SpeakAssignment {
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society"),
                    SpeakerPlacement = 4

                }
            };

            foreach (SpeakAssignment speakAssignment in speakAssignments)
            {
                context.SpeakAssignment.Add(speakAssignment);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SpeakToPlan----------------------------------
            var speakToPlans = new SpeakToPlan[]
            {
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 1)            
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 2)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 3)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 1),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 4)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 2),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 5)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 2),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 6)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 2),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 7)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 8)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 9)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 10)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 3),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 11)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 4),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 12)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 4),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 13)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 4),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 14)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 15)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 16)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 17)
                },
                new SpeakToPlan {
                    Plans = plans.Single( s => s.PlansID == 5),
                    SpeakAssignment = speakAssignments.Single( s => s.SpeakerAssignmentID == 18)
                }
            };

            foreach (SpeakToPlan speakToPlan in speakToPlans)
            {
                context.SpeakToPlan.Add(speakToPlan);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------
        }
    }
}
