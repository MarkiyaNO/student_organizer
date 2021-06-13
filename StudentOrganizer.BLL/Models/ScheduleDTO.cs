using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.BLL.Models
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ScheduleLessonDTO> ScheduleLessons { get; set; }
        public StudentDTO Student { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }
    }
}
