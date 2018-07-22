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
            if (context.Subjects.Any())
            {
                return;   // DB has been seeded
            }

            // ------------------------------------Members----------------------------------
            var members = new Members[]
            {
                new Members {
                    Name = "Michael Jordan"
                },
                new Members {
                    Name = "Gandhi"
                },
                new Members {
                    Name = "Donald Trump Jr."
                },
                new Members {
                    Name = "Dick Van Dyke"
                },
                new Members {
                    Name = "Benjamin Franklin"
                },
                new Members {
                    Name = "Winston Churchill"
                },
                new Members {
                    Name = "Bill Gates"
                },
                new Members {
                    Name = "Steve Jobs"
                },
                new Members {
                    Name = "Elvis Presley"
                },
                new Members {
                    Name = "Mother Teresa"
                },
                new Members {
                    Name = "Martin Luther King"
                },
                new Members {
                    Name = "JFK"
                },
                new Members {
                    Name = "Abraham Lincoln"
                },
                new Members {
                    Name = "Leonardo da Vinci"
                },
                new Members {
                    Name = "Tom Cruise"
                }
            };

            foreach (Members m in members)
            {
                context.Members.Add(m);
            }
            context.SaveChanges();

            // ------------------------------------Bishopric----------------------------------
            var bishopric = new Bishopric[]
            {
                new Bishopric {
                    Member = members.Single( s => s.Name == "Michael Jordan"),
                    Role = Role.Bishop
                },
                new Bishopric {
                    Member = members.Single( s => s.Name == "Gandhi"),
                    Role = Role.First_Counselor
                },
                new Bishopric {
                    Member = members.Single( s => s.Name == "Donald Trump Jr."),
                    Role = Role.Second_Counselor
                },
                new Bishopric {
                    Member = members.Single( s => s.Name == "Dick Van Dyke"),
                    Role = Role.Bishop,
                    ReleasedFlag = true
                },
                new Bishopric {
                    Member = members.Single( s => s.Name == "Benjamin Franklin"),
                    Role = Role.First_Counselor,
                    ReleasedFlag = true
                }
            };

            foreach (Bishopric b in bishopric)
            {
                context.Bishopric.Add(b);
            }
            context.SaveChanges();

            // ------------------------------------Songs----------------------------------
            var songs = new Songs[]
            {
                new Songs {
                    Name = "I Saw a Mighty Angel Fly",
                    Number = 15
                },
                new Songs {
                    Name = "We Thank Thee, O God, for a Prophet",
                    Number = 19
                },
                new Songs {
                    Name = "While of These Emblems We Partake",
                    Number = 173
                },
                new Songs {
                    Name = "Reverently and Meekly Now",
                    Number = 185
                },
                new Songs {
                    Name = "I Stand All Amazed",
                    Number = 193
                },
                new Songs {
                    Name = "He Is Risen!",
                    Number = 199
                },
                new Songs {
                    Name = "Put Your Shoulder to the Wheel",
                    Number = 252
                },
                new Songs {
                    Name = "Hope of Israel",
                    Number = 259
                },
                new Songs {
                    Name = "Arise, O God, and Shine",
                    Number = 265
                },
                new Songs {
                    Name = "The Iron Rod",
                    Number = 274
                }
            };

            foreach (Songs so in songs)
            {
                context.Songs.Add(so);
            }
            context.SaveChanges();

            // ------------------------------------Subjects----------------------------------
            var subjects = new Subjects[]
            {
                new Subjects {
                    SubjectName = "Hope"
                },
                new Subjects {
                    SubjectName = "Repentance"
                },
                new Subjects {
                    SubjectName = "Love"
                },
                new Subjects {
                    SubjectName = "Ministering"
                },
                new Subjects {
                    SubjectName = "Family Home Evening"
                },
                new Subjects {
                    SubjectName = "Tithing"
                },
                new Subjects {
                    SubjectName = "The Atonement"
                },
                new Subjects {
                    SubjectName = "The Relief Society"
                },
                new Subjects {
                    SubjectName = "The Priesthood"
                },
                new Subjects {
                    SubjectName = "Magnifying Callings"
                }
            };

            foreach (Subjects su in subjects)
            {
                context.Subjects.Add(su);
            }
            context.SaveChanges();

            // ------------------------------------SpeakToPlan----------------------------------
            //public int SpeakerToPlanId { get; set; }
            //public Members SpeakerName { get; set; }
            //public int SpeakerPlacement { get; set; }
            //public Subjects Subject { get; set; }
            var speakToPlan = new SpeakToPlan[]
            {
                new SpeakToPlan {
                    SpeakerToPlanId = 321,
                    SpeakerName = members.Single( s => s.Name == "Dick Van Dyke"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "Hope")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 321,
                    SpeakerName = members.Single( s => s.Name == "Benjamin Franklin"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "Repentance")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 321,
                    SpeakerName = members.Single( s => s.Name == "Winston Churchill"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "Love")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 321,
                    SpeakerName = members.Single( s => s.Name == "Bill Gates"),
                    SpeakerPlacement = 4,
                    Subject = subjects.Single( s => s.SubjectName == "Ministering")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 322,
                    SpeakerName = members.Single( s => s.Name == "Steve Jobs"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "Family Home Evening")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 322,
                    SpeakerName = members.Single( s => s.Name == "Elvis Presley"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "Tithing")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 322,
                    SpeakerName = members.Single( s => s.Name == "Mother Teresa"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "The Atonement")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 323,
                    SpeakerName = members.Single( s => s.Name == "Martin Luther King"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 323,
                    SpeakerName = members.Single( s => s.Name == "JFK"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "The Priesthood")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 323,
                    SpeakerName = members.Single( s => s.Name == "Abraham Lincoln"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "Magnifying Callings")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 323,
                    SpeakerName = members.Single( s => s.Name == "Leonardo da Vinci"),
                    SpeakerPlacement = 4,
                    Subject = subjects.Single( s => s.SubjectName == "Hope")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 324,
                    SpeakerName = members.Single( s => s.Name == "Tom Cruise"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "Repentance")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 324,
                    SpeakerName = members.Single( s => s.Name == "Dick Van Dyke"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "Love")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 324,
                    SpeakerName = members.Single( s => s.Name == "Benjamin Franklin"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "Ministering")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 325,
                    SpeakerName = members.Single( s => s.Name == "Winston Churchill"),
                    SpeakerPlacement = 1,
                    Subject = subjects.Single( s => s.SubjectName == "Family Home Evening")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 325,
                    SpeakerName = members.Single( s => s.Name == "Bill Gates"),
                    SpeakerPlacement = 2,
                    Subject = subjects.Single( s => s.SubjectName == "Tithing")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 325,
                    SpeakerName = members.Single( s => s.Name == "Steve Jobs"),
                    SpeakerPlacement = 3,
                    Subject = subjects.Single( s => s.SubjectName == "The Atonement")
                },
                new SpeakToPlan {
                    SpeakerToPlanId = 325,
                    SpeakerName = members.Single( s => s.Name == "Elvis Presley"),
                    SpeakerPlacement = 4,
                    Subject = subjects.Single( s => s.SubjectName == "The Relief Society")
                }
            };

            foreach (SpeakToPlan stp in speakToPlan)
            {
                context.SpeakToPlan.Add(stp);
            }
            context.SaveChanges();

            // ------------------------------------SpeakToPlan----------------------------------
            //public DateTime Date { get; set; }
            //public Bishopric Conducting { get; set; }
            //public Members OpeningPrayer { get; set; }
            //public Songs OpeningSong { get; set; }
            //public Songs SacramentSong { get; set; }
            //public Songs OptIntermSong { get; set; }
            //public Members ClosingPrayer { get; set; }

            //var plans = new Plans[]
            //{
            //    new Plans {
            //        Date = DateTime.Parse("2018-22-07"),
            //        Conducting = bishopric.Single( s => s.Name == "Michael Jordan"),
            //        OpeningPrayer = members.Single( s => s.Name == "_____"),
            //        OpeningSong = songs.Single( s => s.Name == "_____"),
            //        SacramentSong = songs.Single( s => s.Name == "_____"),
            //        OptIntermSong = songs.Single( s => s.Name == "_____"),
            //        ClosingPrayer = members.Single( s => s.Name == "_____")
            //    },
            //};

            //foreach (Plans p in plans)
            //{
            //    context.Plans.Add(p);
            //}
            //context.SaveChanges();

        }
    }
}
