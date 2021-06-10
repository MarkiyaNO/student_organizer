using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.BLL.Models
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeacherFullName { get; set; }
        public ICollection<ScheduleLessonDTO> ScheduleLessons { get; set; }
    }
}
