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

        Task<IEnumerable<Schedule>> GetAllWithDetailsAsync(Student user);
        
        Task<Schedule> GetByIdWithDetailsAsync(int id, Student user);

        ValueTask<Schedule> GetByIdAsync(int id, Student user);

        Task<IEnumerable<Schedule>> GetAllAsync(Student user);

        Task AddAsync(Schedule entity, Student user);

        void Remove(Schedule entity, Student user);

        void Update(Schedule entity, Student user);
    }
}
