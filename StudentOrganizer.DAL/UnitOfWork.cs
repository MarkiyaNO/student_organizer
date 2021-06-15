using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;
using StudentOrganizer.DAL.Repositories;

namespace StudentOrganizer.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SOrganizerDBContext _context;

        private AssignmentRepository assignmentRepository;
        private LessonRepository lessonRepository;
        private ScheduleRepository scheduleRepository;
        private ScheduleLessonRepository scheduleLessonRepository;
        private StudentRepository studentRepository;

        public UnitOfWork(SOrganizerDBContext context)
        {
            _context = context;
        }


        public AssignmentRepository Assignments => assignmentRepository ??= new AssignmentRepository(_context);

        public LessonRepository Lessons => lessonRepository ??= new LessonRepository(_context);

        public ScheduleLessonRepository ScheduleLessons => scheduleLessonRepository ??= new ScheduleLessonRepository(_context);

        public ScheduleRepository Schedules => scheduleRepository ??= new ScheduleRepository(_context);

        public StudentRepository Students => studentRepository ??= new StudentRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        //Dispose pattern
        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            _context.Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
