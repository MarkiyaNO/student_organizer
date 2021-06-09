using System;
using System.Collections.Generic;
using System.Text;
using StudentOrganizer.DAL.Entities;

namespace StudentOrganizer.DAL.Repositories
{
    public class StudentProfileRepository:Repository<StudentProfile>
    {
        public StudentProfileRepository(SOrganizerDBContext context)
            : base(context)
        { }
       
    }
}
