using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Models
{
    public class PlannerContext : DbContext
    {
        public PlannerContext(DbContextOptions<PlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Bishopric> Bishopric { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<SpeakToPlan> SpeakToPlan { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bishopric>().ToTable("Bishopric");
            modelBuilder.Entity<Plans>().ToTable("Plans");
            modelBuilder.Entity<Songs>().ToTable("Songs");
            modelBuilder.Entity<Members>().ToTable("Speakers");
            modelBuilder.Entity<SpeakToPlan>().ToTable("SpeakToPlan");
            modelBuilder.Entity<Subjects>().ToTable("Subjects");

            //modelBuilder.Entity<Plans>()
            //    .HasKey(c => new { c.SpeakerToPlanId });
            //modelBuilder.Entity<SpeakToPlan>()
            //    .HasKey(c => new { c.SpeakerToPlanId });
        }
    }
}
