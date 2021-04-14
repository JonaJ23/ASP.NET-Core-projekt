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
public class RazorPage_uppgiftContext : IdentityDbContext<MyUser>  //DbContext
    {

        public RazorPage_uppgiftContext(DbContextOptions<RazorPage_uppgiftContext> options)
               : base(options)
        {
        }

        public DbSet<MyUser> MyUsers { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}

