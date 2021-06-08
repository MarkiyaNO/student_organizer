using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.DAL
{
    public class SOrganizerDBContext : DbContext
    {
        // public DbSet

        public SOrganizerDBContext(DbContextOptions<SOrganizerDBContext> options) : base(options)
        { }

        // protected override void OnModelCreating(ModelBuilder modelbuilder)
    }

}
