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
                    Date = DateTime.Parse("2018-22-07"),
                    Bishopric = bishopric.Single( s => s.Name == "Michael Jordan"),
                    PrayerToPlan = ,
                    SongToPlan = ,
                    SpeakToPlan = 
                },
            };

            foreach (Plans plan in plans)
            {
                context.Plans.Add(plan);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------PrayerToPlan----------------------------------
            var prayerToPlans = new PrayerToPlan[]
            {
                new PrayerToPlan {
                    Plans = ,
                    PrayerType = ,
                    Member = ,
                },

            };

            foreach (PrayerToPlan prayerToPlan in prayerToPlans)
            {
                context.PrayerToPlan.Add(prayerToPlan);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------

            // ------------------------------------SongToPlan----------------------------------
            var songToPlans = new SongToPlan[]
            {
                new SongToPlan {
                    Plans = ,
                    Song = ,
                    SongType = 
                },

            };

            foreach (SongToPlan songToPlan in songToPlans)
            {
                context.SongToPlan.Add(songToPlan);
            }
            context.SaveChanges();
            // ----------------------------------------------------------------------------



















            // ------------------------------------SpeakToPlan----------------------------------
            var speakToPlan = new SpeakToPlan[]
            {
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 1),
                    Member = members.Single( s => s.MemberName == "Dick Van Dyke"),
                    Subject = subjects.Single( s => s.SubjectName == "Hope")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 2,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Benjamin Franklin"),
                    Subject = subjects.Single( s => s.SubjectName == "Repentance")

                    SpeakerToPlanId = 321,
                    SpeakerName = members.Single( s => s.MemberName == ""),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 321,
                    SpeakerName = members.Single( s => s.MemberName == "Winston Churchill"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "Love")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 321,
                    SpeakerName = members.Single( s => s.MemberName == "Bill Gates"),
                    SpeakerPlacement = 4,
                    Subject = subjects.Single( s => s.SubjectName == "Ministering")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 322,
                    SpeakerName = members.Single( s => s.MemberName == "Steve Jobs"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "Family Home Evening")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 322,
                    SpeakerName = members.Single( s => s.MemberName == "Elvis Presley"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "Tithing")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 322,
                    SpeakerName = members.Single( s => s.MemberName == "Mother Teresa"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "The Atonement")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 323,
                    SpeakerName = members.Single( s => s.MemberName == "Martin Luther King"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 323,
                    SpeakerName = members.Single( s => s.MemberName == "JFK"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "The Priesthood")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 323,
                    SpeakerName = members.Single( s => s.MemberName == "Abraham Lincoln"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "Magnifying Callings")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 323,
                    SpeakerName = members.Single( s => s.MemberName == "Leonardo da Vinci"),
                    SpeakerPlacement = 4,
                    Subject = subjects.Single( s => s.SubjectName == "Hope")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 324,
                    SpeakerName = members.Single( s => s.MemberName == "Tom Cruise"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "Repentance")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 324,
                    SpeakerName = members.Single( s => s.MemberName == "Dick Van Dyke"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "Love")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 324,
                    SpeakerName = members.Single( s => s.MemberName == "Benjamin Franklin"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "Ministering")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 325,
                    SpeakerName = members.Single( s => s.MemberName == "Winston Churchill"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "Family Home Evening")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 325,
                    SpeakerName = members.Single( s => s.MemberName == "Bill Gates"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "Tithing")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                    SpeakerToPlanId = 325,
                    SpeakerName = members.Single( s => s.MemberName == "Steve Jobs"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "The Atonement")
                },
                new SpeakToPlan {
                    SpeakerPlacement = 1,
                    Plans = plans.Single( s => s.PlansID == 10000),
                    Member = members.Single( s => s.MemberName == "Elvis Presley"),
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")

                }
            };

            foreach (SpeakToPlan stp in speakToPlan)
            {
                context.SpeakToPlan.Add(stp);
            }
            context.SaveChanges();

            

        }
    }
}
