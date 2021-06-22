using StudentOrganizer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.BLL.Interfaces
{
    public interface IAssignmentService: ICrud<AssignmentDTO>
    {
        Task AddAsync(AssignmentDTO model, int scheduleLessonId);
        Task UpdateState(int assignmentId, int state);
    }
}
