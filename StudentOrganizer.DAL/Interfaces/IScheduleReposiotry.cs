using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.DAL.Interfaces
{
    public interface IScheduleReposiotry : IRepository<Schedule>
    {
        Task<IEnumerable<Schedule>> GetAllWithDetailsAsync();

        Task<Schedule> GetByIdWithDetailsAsync(int id);
    }
}
