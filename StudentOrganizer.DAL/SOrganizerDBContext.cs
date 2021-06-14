using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL
{
    public class SOrganizerDBContext : IdentityDbContext<Student>
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleLesson> ScheduleLessons { get; set; }
        //public DbSet<StudentProfile> StudentProfiles { get; set; }

        public SOrganizerDBContext(DbContextOptions<SOrganizerDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Schedule
            modelBuilder.Entity<Schedule>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Schedule>()
                        .HasOne(x => x.Student)
                        .WithMany(x => x.Schedules)
                        .HasPrincipalKey(x => x.StudentId);

            // Assignment
            modelBuilder.Entity<Assignment>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Assignment>()
                        .Property(x => x.State)
                        .HasConversion<string>();

            // Lesson
            modelBuilder.Entity<Lesson>()
                        .HasKey(x => x.Id);

            // StudentProfile
            //modelBuilder.Entity<StudentProfile>()
            //            .HasKey(x => x.Id);

            //modelBuilder.Entity<StudentProfile>()
            //            .HasOne(x => x.Student)
            //            .WithOne(x => x.StudentProfile)
            //            .HasPrincipalKey<Student>(x => x.StudentId)
            //            .HasForeignKey<StudentProfile>(x => x.Id); /// !
            //Student
            modelBuilder.Entity<Student>()
                .ToTable("Students");
            // ScheduleLesson
            modelBuilder.Entity<ScheduleLesson>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<ScheduleLesson>()
                        .Property(x => x.DayOfTheWeek)
                        .HasConversion<string>();

            modelBuilder.Entity<ScheduleLesson>()
                        .HasOne(x => x.Lesson)
                        .WithMany(x => x.ScheduleLessons)
                        .HasForeignKey(x => x.LessonId);

            modelBuilder.Entity<ScheduleLesson>()
                        .HasOne(x => x.Schedule)
                        .WithMany(x => x.ScheduleLessons)
                        .HasForeignKey(x => x.ScheduleId);

        }
    }

}
