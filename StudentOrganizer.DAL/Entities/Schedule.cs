using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL.Entities
{
    public class Schedule : DBEntity
    {
        public string Name { get; set; }
        public ICollection<ScheduleLesson> ScheduleLessons { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
