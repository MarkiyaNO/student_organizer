using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL.Entities
{
    public class StudentProfile : DBEntity
    {
        public DateTime DateOfBirth { get; set; }
        public string StudentPassId { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Group { get; set; }
        public Student Student { get; set; }
    }
}
