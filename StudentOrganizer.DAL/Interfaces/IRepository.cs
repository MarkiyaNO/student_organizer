using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.DAL.Interfaces
{
    public interface IRepository<T> where T : DBEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteByIdAsync(int id);
    }
}
