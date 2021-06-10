using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.BLL.Models
{
    public class StudentProfileDTO
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentPassId { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Group { get; set; }
        public StudentDTO Student { get; set; }
    }
}
