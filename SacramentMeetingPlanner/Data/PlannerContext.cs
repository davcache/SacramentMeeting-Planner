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

        public DbSet<Role> Role { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<PrayerType> PrayerType { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<SongType> SongType { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Bishopric> Bishopric { get; set; }
        public DbSet<PrayerToPlan> PrayerToPlan { get; set; }
        public DbSet<Prayer> Prayer { get; set; }
        public DbSet<SongToPlan> SongToPlan { get; set; }
        public DbSet<SongAssignment> SongAssignment { get; set; }
        public DbSet<SpeakToPlan> SpeakToPlan { get; set; }
        public DbSet<SpeakAssignment> SpeakAssignment { get; set; }
        public DbSet<Plans> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<PrayerType>().ToTable("PrayerType");
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<SongType>().ToTable("SongType");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Bishopric>().ToTable("Bishopric");
            modelBuilder.Entity<PrayerToPlan>().ToTable("PrayerToPlan");
            modelBuilder.Entity<Prayer>().ToTable("Prayer");
            modelBuilder.Entity<SongToPlan>().ToTable("SongToPlan");
            modelBuilder.Entity<SongAssignment>().ToTable("SongAssignment");
            modelBuilder.Entity<SpeakToPlan>().ToTable("SpeakToPlan");
            modelBuilder.Entity<SpeakAssignment>().ToTable("SpeakAssignment");
            modelBuilder.Entity<Plans>().ToTable("Plans");

            //modelBuilder.Entity<Plans>()
            //    .HasKey(c => new { c.SpeakerToPlanId });
            //modelBuilder.Entity<SpeakToPlan>()
            //    .HasKey(c => new { c.SpeakerToPlanId });
        }
    }
}
