using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;

namespace StudentOrganizer.DAL.Repositories
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleReposiotry
    {
        public ScheduleRepository(SOrganizerDBContext context)
            : base(context)
        { }

        public async Task AddAsync(Schedule entity, Student user)
        {
            user.Schedules ??= new List<Schedule>();
            user.Schedules.Add(entity);
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync(Student user)
        {
            return await _context.Schedules.Include(x => x.Student)
                                           .Where(s => s.Student.StudentId == user.StudentId)
                                           .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetAllWithDetailsAsync()
        {
            return await _context.Schedules.Include(x => x.ScheduleLessons).ThenInclude(x => x.Assignments)
                                           .Include(x => x.ScheduleLessons).ThenInclude(x => x.Lesson)
                                           .Include(x => x.Student).ToListAsync();
                                           
        }

        public async Task<IEnumerable<Schedule>> GetAllWithDetailsAsync(Student user)
        {
            return await _context.Schedules.Include(x => x.Student)
                                           .Where(s => s.Student.StudentId == user.StudentId)
                                           .Include(x => x.ScheduleLessons).ThenInclude(x => x.Assignments)
                                           .Include(x => x.ScheduleLessons).ThenInclude(x => x.Lesson)
                                           .ToListAsync();
        }

        public async ValueTask<Schedule> GetByIdAsync(int id, Student user)
        {
            return await _context.Schedules.Include(s => s.Student)
                                            .Where(s => s.Student.StudentId == user.StudentId)
                                            .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Schedule> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Schedules.Include(x => x.ScheduleLessons).ThenInclude(x => x.Assignments)
                                           .Include(x => x.ScheduleLessons).ThenInclude(x => x.Lesson)
                                           .Include(x=>x.Student)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Schedule> GetByIdWithDetailsAsync(int id, Student user)
        {
            return await _context.Schedules.Include(x => x.Student).Where(s=>s.Student.StudentId==user.StudentId)
                                           .Include(x => x.ScheduleLessons).ThenInclude(x => x.Assignments)
                                           .Include(x => x.ScheduleLessons).ThenInclude(x => x.Lesson)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Schedule entity, Student user)
        {
            if(entity?.Student?.StudentId==user?.StudentId)
            {
                _context.Schedules.Remove(entity);
            }
        }

        public void Update(Schedule entity, Student user)
        {
            if(entity?.Student?.StudentId==user?.StudentId)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
