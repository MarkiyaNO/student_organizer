using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.BL.Interfaces
{
    public interface ICrud<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteByIdAsync(int modelId);
    }
}
