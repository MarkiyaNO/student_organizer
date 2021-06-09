using System;
using System.Collections.Generic;
using System.Text;
using StudentOrganizer.DAL.Entities;

namespace StudentOrganizer.DAL.Repositories
{
    public class AssignmentRepository : Repository<Assignment>
    {
        public AssignmentRepository(SOrganizerDBContext context)
            :base(context)
        { }
    }
}
