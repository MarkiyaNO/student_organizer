using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL
{
    public class SOrganizerDBContext : ApiAuthorizationDbContext<Student>
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleLesson> ScheduleLessons { get; set; }
        //public DbSet<StudentProfile> StudentProfiles { get; set; }

        public SOrganizerDBContext(DbContextOptions<SOrganizerDBContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options,operationalStoreOptions)
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
                        .HasPrincipalKey(x => x.StudentId)
                        .OnDelete(DeleteBehavior.Cascade);


            // Assignment
            modelBuilder.Entity<Assignment>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Assignment>()
                        .Property(x => x.State)
                        .HasConversion<string>();

            modelBuilder.Entity<Assignment>()
                        .HasOne(x => x.ScheduleLesson)
                        .WithMany(x => x.Assignments)
                        .OnDelete(DeleteBehavior.Cascade);

            // Lesson
            modelBuilder.Entity<Lesson>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Lesson>()
                        .HasOne(x => x.Student)
                        .WithMany(x => x.Lessons)
                        .HasPrincipalKey(x => x.StudentId);
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
                        .HasForeignKey(x => x.ScheduleId)
                        .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
