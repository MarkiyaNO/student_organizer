using System;
using System.Collections.Generic;
using StudentOrganizer.DAL.Entities;

namespace StudentOrganizer.BLL.Models
{
    public class ScheduleLessonDTO
    {
        public int Id { get; set; }
        public int LessonNumber { get; set; }
        public DayOfTheWeek DayOfTheWeek { get; set; }
        public int ScheduleId { get; set; }
        public ScheduleDTO Schedule { get; set; }
        public int LessonId { get; set; }
        public LessonDTO Lesson { get; set; }
        public ICollection<AssignmentDTO> Assignments { get; set; }
        public string Place { get; set; }
        public string Link { get; set; }
        public LessonType LessonType { get; set; }
        public TimeSpan Time { get; set; }
    }
}
