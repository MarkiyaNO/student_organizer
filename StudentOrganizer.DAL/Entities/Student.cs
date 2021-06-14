using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL.Entities
{
    public class Student : IdentityUser
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        //StudentProfile part
        public DateTime DateOfBirth { get; set; }
        public string StudentPassId { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Group { get; set; }
    }
}
