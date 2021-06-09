using System;
using System.Collections.Generic;
using System.Text;
using StudentOrganizer.DAL.Entities;

namespace StudentOrganizer.DAL.Repositories
{
    public class LessonRepository:Repository<Lesson>
    {
        public LessonRepository(SOrganizerDBContext context)
            : base(context)
        { }
    }
}
