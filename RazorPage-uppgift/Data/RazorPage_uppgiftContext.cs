using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPage_uppgift.Models;

namespace RazorPage_uppgift.Data
{
    public class RazorPage_uppgiftContext : DbContext
    {
        public RazorPage_uppgiftContext (DbContextOptions<RazorPage_uppgiftContext> options)
            : base(options)
        {
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<JoinedEvent> JoinedEvents { get; set; }
        public DbSet<Organizer> Organizers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>().ToTable("Attendee");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<JoinedEvent>().ToTable("JoinedEvent");
            modelBuilder.Entity<Organizer>().ToTable("Organizer");
        }
    }
}
