using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPage_uppgift.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace RazorPage_uppgift.Data
{
public class RazorPage_uppgiftContext : IdentityDbContext<IdentityUser>  //DbContext
    {

        public RazorPage_uppgiftContext(DbContextOptions<RazorPage_uppgiftContext> options)
               : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<JoinedEvent> JoinedEvents { get; set; }
        public DbSet<Organizer> Organizers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Attendee>().ToTable("Attendee");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<JoinedEvent>().ToTable("JoinedEvent");
            modelBuilder.Entity<Organizer>().ToTable("Organizer");
        }
    }
}

