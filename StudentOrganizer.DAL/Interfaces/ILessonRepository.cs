using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.DAL.Interfaces
{
    interface ILessonRepository : IRepository<Lesson>
    {
        ValueTask<Lesson> GetByIdAsync(int id, Student user);

        Task<IEnumerable<Lesson>> GetAllAsync(Student user);

        Task AddAsync(Lesson entity, Student user);

        void Remove(Lesson entity, Student user);

        void Update(Lesson entity, Student user);
    }
}
