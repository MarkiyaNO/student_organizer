using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;

namespace StudentOrganizer.DAL.Repositories
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(SOrganizerDBContext context)
            :base(context)
        { }

        public async Task AddAsync(Assignment assignment, ScheduleLesson scheduleLesson)
        {
            scheduleLesson.Assignments ??= new List<Assignment>();
            scheduleLesson.Assignments.Add(assignment);
        }

        public async Task UpdateState(Assignment assignment, int state)
        {
            assignment.State = (AssignmentState)state;
        }
    }
}
