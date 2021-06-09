using System;
using System.Collections.Generic;
using System.Text;
using StudentOrganizer.DAL.Entities;

namespace StudentOrganizer.DAL.Repositories
{
    public class ScheduleLessonRepository:Repository<ScheduleLesson>
    {
        public ScheduleLessonRepository(SOrganizerDBContext context)
            : base(context)
        { }
    }
}
