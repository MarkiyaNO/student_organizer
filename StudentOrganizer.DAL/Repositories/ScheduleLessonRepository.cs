using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;

namespace StudentOrganizer.DAL.Repositories
{
    public class ScheduleLessonRepository: Repository<ScheduleLesson>,IScheduleLessonRepository
    {
        public ScheduleLessonRepository(SOrganizerDBContext context)
            : base(context)
        { }

        public async Task AddAsync(ScheduleLesson entity, Schedule schedule)
        {
            if (schedule == null)
                return;
            schedule.ScheduleLessons ??= new List<ScheduleLesson>();
            schedule.ScheduleLessons.Add(entity);
        }

        public async Task<IEnumerable<ScheduleLesson>> GetAllAsync(Schedule schedule)
        {
            return await _context.ScheduleLessons.Include(x => x.Schedule)
                                                 .Where(x => x.Schedule.Id == schedule.Id)
                                                 .ToListAsync();
        }

        public async ValueTask<ScheduleLesson> GetByIdAsync(int id, Schedule schedule)
        {
            return await _context.ScheduleLessons.Include(x => x.Schedule)
                                     .Where(x => x.Schedule.Id == schedule.Id)
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(ScheduleLesson entity, Schedule schedule)
        {
            schedule?.ScheduleLessons?.Remove(entity);
        }

        public void Update(ScheduleLesson entity, Schedule schedule)
        {
            if (entity?.Schedule?.Id ==schedule?.Id)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
