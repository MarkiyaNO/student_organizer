using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.DAL.Interfaces
{
    public interface IAssignmentRepository :IRepository<Assignment>
    {
        Task AddAsync(Assignment assignment, ScheduleLesson scheduleLesson);
        Task UpdateState(Assignment assignment, int state);
    }
}
