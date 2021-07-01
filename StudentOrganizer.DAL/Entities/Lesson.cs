using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL.Entities
{
    public class Lesson : DBEntity
    {
        public string Name { get; set; }
        public string TeacherFullName { get; set; }
        public ICollection<ScheduleLesson> ScheduleLessons { get; set; }
        public Student Student { get; set; }
    }
}
