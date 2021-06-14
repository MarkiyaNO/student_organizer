using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.BLL.Validation
{
    public class StudentOrganizerException : Exception
    {
        public StudentOrganizerException() : base() { }
        public StudentOrganizerException(string msg) : base(msg)
        {
        }
        public StudentOrganizerException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
