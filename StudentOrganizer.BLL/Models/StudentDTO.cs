using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.BLL.Models
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<ScheduleDTO> Schedules { get; set; }
        public StudentProfileDTO StudentProfile { get; set; }
    }
}
