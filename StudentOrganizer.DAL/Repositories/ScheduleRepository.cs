using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Schedule>> GetAllWithDetailsAsync()
        {
            return await _context.Schedules.Include(x => x.ScheduleLessons).ThenInclude(x => x.Assignments)
                                           .Include(x => x.ScheduleLessons).ThenInclude(x => x.Lesson).ToListAsync();
        }

        public async Task<Schedule> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Schedules.Include(x => x.ScheduleLessons).ThenInclude(x => x.Assignments)
                                           .Include(x => x.ScheduleLessons).ThenInclude(x => x.Lesson)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
