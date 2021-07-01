using StudentOrganizer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.BLL.Interfaces
{
    public interface ILessonService : ICrud<LessonDTO> 
    {
        Task<IEnumerable<LessonDTO>> GetAllAsync(ClaimsPrincipal user);
        Task<LessonDTO> GetByIdAsync(int id, ClaimsPrincipal user);
        Task AddAsync(LessonDTO model, ClaimsPrincipal user);
        Task UpdateAsync(LessonDTO model, ClaimsPrincipal user);
        Task DeleteByIdAsync(int modelId, ClaimsPrincipal user);
    }
}
