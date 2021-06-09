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
        public StudentProfile StudentProfile { get; set; }
    }
}
