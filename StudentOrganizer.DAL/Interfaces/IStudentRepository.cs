using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentOrganizer.DAL.Entities;

namespace StudentOrganizer.DAL.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        ValueTask<Student> GetByIdAsync(string id);
    }
}
