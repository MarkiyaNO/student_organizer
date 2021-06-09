using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;

namespace StudentOrganizer.DAL.Repositories
{
    public class StudentRepository:Repository<Student>,IStudentRepository
    {
        public StudentRepository(SOrganizerDBContext context)
            : base(context)
        {
        }

        public ValueTask<Student> GetByIdAsync(string id)
        {
            return _context.Set<Student>().FindAsync(id);
        }
    }
}
