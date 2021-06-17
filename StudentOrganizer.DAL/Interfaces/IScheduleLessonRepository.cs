using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.DAL.Interfaces
{
    interface IScheduleLessonRepository : IRepository<ScheduleLesson>
    {
        ValueTask<ScheduleLesson> GetByIdAsync(int id, Schedule schedule);
        Task<IEnumerable<ScheduleLesson>> GetAllAsync(Schedule schedule);

        Task AddAsync(ScheduleLesson entity, Schedule schedule);
        void Remove(ScheduleLesson entity, Schedule schedule);
        void Update(ScheduleLesson entity, Schedule schedule );
    }
}
