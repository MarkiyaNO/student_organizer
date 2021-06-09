using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;

namespace StudentOrganizer.DAL.Repositories
{
    public class ScheduleRepository : Repository<Schedule>
    {
        public ScheduleRepository(SOrganizerDBContext context)
            : base(context)
        { }
    }
}
