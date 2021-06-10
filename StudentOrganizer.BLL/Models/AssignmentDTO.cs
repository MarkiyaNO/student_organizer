using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.BLL.Models
{
    public class AssignmentDTO
    {
        public int Id { get; set; }
        public AssignmentState State { get; set; }
        public DateTime Deadline { get; set; }
        public string Describtion { get; set; }
        public ScheduleLessonDTO ScheduleLesson { get; set; }
    }
}
