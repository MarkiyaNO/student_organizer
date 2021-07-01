using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentOrganizer.DAL.Entities
{
    public class Student : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        //StudentProfile part
        public DateTime DateOfBirth { get; set; }
        public string StudentPassId { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Group { get; set; }
    }
}
