using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;

namespace StudentOrganizer.DAL.Repositories
{
    public class LessonRepository:Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(SOrganizerDBContext context)
            : base(context)
        { }

        public async Task AddAsync(Lesson entity, Student user)
        {
            user.Lessons ??= new List<Lesson>();
            user.Lessons.Add(entity);
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync(Student user)
        {
            return await _context.Lessons.Include(x=>x.Student)
                               .Where(s => s.Student.StudentId == user.StudentId)
                               .ToListAsync();
        }

        public async ValueTask<Lesson> GetByIdAsync(int id, Student user)
        {
            return await _context.Lessons.Include(s => s.Student)
                                .Where(s => s.Student.StudentId == user.StudentId)
                                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Remove(Lesson entity, Student user)
        {
            if (entity?.Student?.StudentId == user?.StudentId)
            {
                _context.Lessons.Remove(entity);
            }
        }

        public void Update(Lesson entity, Student user)
        {
            if (entity?.Student?.StudentId == user?.StudentId)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
