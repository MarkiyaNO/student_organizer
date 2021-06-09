using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL.Entities
{
    public enum DayOfTheWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public class ScheduleLesson : DBEntity
    {
        public int LessonNumber { get; set; } // номер пари
        public DayOfTheWeek DayOfTheWeek { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
