using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.BLL.Interfaces
{
    public interface IScheduleService : ICrud<ScheduleDTO>
    {
        Task<IEnumerable<ScheduleDTO>> GetAllWithDetailsAsync(ClaimsPrincipal user);
        Task<ScheduleDTO> GetByIdWithDetailsAsync(int id, ClaimsPrincipal user);
        Task<IEnumerable<ScheduleDTO>> GetAllWithDetailsAsync();
        Task<ScheduleDTO> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<ScheduleDTO>> GetAllAsync(ClaimsPrincipal user);
        Task<ScheduleDTO> GetByIdAsync(int id, ClaimsPrincipal user);
        Task AddAsync(ScheduleDTO model, ClaimsPrincipal user);
        Task UpdateAsync(ScheduleDTO model, ClaimsPrincipal user);
        Task DeleteByIdAsync(int modelId, ClaimsPrincipal user);
    }
}
