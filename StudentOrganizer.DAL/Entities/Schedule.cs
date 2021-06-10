using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL.Entities
{
    public enum ScheduleType
    {
        Personal,
        Work,
        Studing
    }
    public class Schedule : DBEntity
    {
        public string Name { get; set; }
        public ICollection<ScheduleLesson> ScheduleLessons { get; set; }
        
        public Student Student { get; set; }
        public ScheduleType ScheduleType { get; set; }

        public bool IsFinished { get; set; }
    }
}
