using StudentOrganizer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.BLL.Interfaces
{
    public interface IScheduleLessonService : ICrud<ScheduleLessonDTO>
    {
        Task<IEnumerable<ScheduleLessonDTO>> GetAllAsync(ScheduleDTO schedule);
        Task<ScheduleLessonDTO> GetByIdAsync(int id, ScheduleDTO schedule);
        Task AddAsync(ScheduleLessonDTO model, ScheduleDTO schedule);
        Task UpdateAsync(ScheduleLessonDTO model, ScheduleDTO schedule);
        Task DeleteByIdAsync(int modelId, ScheduleDTO schedule);
    }
}
