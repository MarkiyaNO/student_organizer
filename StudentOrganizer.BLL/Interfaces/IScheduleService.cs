using StudentOrganizer.BL.Interfaces;
using StudentOrganizer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.BLL.Interfaces
{
    public interface IScheduleService : ICrud<ScheduleDTO>
    {
        public Task<IEnumerable<ScheduleDTO>> GetAllWithDetailsAsync();
        public Task<ScheduleDTO> GetByIdWithDetailsAsync(int id);
    }
}
