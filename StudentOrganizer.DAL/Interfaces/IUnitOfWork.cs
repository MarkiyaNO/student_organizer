using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.DAL.Interfaces
{
    public interface IUnitOfWork
    { 
        // add repository properties with get only
        // public StudentRepository studentRepository { get; }
        Task<int> SaveAsync();
    }
}
