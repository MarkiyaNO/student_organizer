using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentOrganizer.DAL.Interfaces;
using StudentOrganizer.DAL.Repositories;

namespace StudentOrganizer.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        // TODO: replace repositories with interfaces : StudentRepository=>IStudentRepository
        public AssignmentRepository Assignments { get; }
        public LessonRepository Lessons { get; }
        public ScheduleLessonRepository ScheduleLessons { get; }
        public ScheduleRepository Schedules { get; }
        public StudentRepository Students {get;}

        Task<int> SaveAsync();
    }
}
