using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL.Entities
{
    public enum AssignmentState
    {
        NotStarted,
        InProccess,
        Failed,
        Done
    }
    public class Assignment : DBEntity
    {
        public AssignmentState State { get; set; }
        public DateTime Deadline { get; set; }
        public string Describtion { get; set; }
        public int ScheduleLessonId { get; set; }
        public ScheduleLesson ScheduleLesson { get; set; }
    }
}
