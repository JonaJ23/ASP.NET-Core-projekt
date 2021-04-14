using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPage_uppgift.Models;
using RazorPage_uppgift.Data;
using Microsoft.AspNetCore.Identity;

namespace RazorPage_uppgift 
{
    public static class Seeding // This class is used to seed the database when the application is launched.
    {
        public static void Initialize(RazorPage_uppgiftContext context, UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            {
                SeedRoles(context, roleManager);
                SeedUsers(userManager);
                SeedEvent(context, userManager);
            }
        }


        // USERS

        static void SeedUsers(UserManager<MyUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@live.com").Result == null)
            {
                MyUser user = new MyUser();
                user.UserName = "admin@live.com";
                user.Email = "admin@live.com";
                user.FirstName = "Admin";
                user.LastName = "Johnson";
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, "Admin@12").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (userManager.FindByEmailAsync("organizer@live.com").Result == null)
            {
                MyUser user = new MyUser();
                user.UserName = "organizer@live.com";
                user.Email = "organizer@live.com";
                user.FirstName = "Codeboss";
                user.LastName = "Johnson";
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, "Organ@12").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Organizer").Wait();
                }
            }
            if (userManager.FindByEmailAsync("attendee@live.com").Result == null)
            {
                MyUser user = new MyUser();
                user.UserName = "attendee@live.com";
                user.Email = "attendee@live.com";
                user.FirstName = "Attendee";
                user.LastName = "Johnson";
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, "Attend@12").Result;

<<<<<<< HEAD
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "attendee").Wait();
                }
            }
        }

=======
            // Attendees
           
            /*Attendee[] attendees = new Attendee[] {
            new Attendee{Name="John Stranger", Email="John.Stranger@here.com", PhoneNumber="2222111121" }
            };
            context.AddRange(attendees);
            context.SaveChanges();*/
>>>>>>> b922c060bf8ca8b4341d8a850558aec7b7070f4b

        // ROLES

        static void SeedRoles(RazorPage_uppgiftContext context, RoleManager<IdentityRole> roleManager)
        {

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();

            string[] roleNames = { "Admin", "Organizer", "Attendee" };


            foreach (var roleName in roleNames)
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = roleName;
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }
            }
        }

        // EVENTS

        static void SeedEvent(RazorPage_uppgiftContext context, UserManager<MyUser> userManager)
        {
            context.Events.RemoveRange(context.Events);
            context.SaveChanges();

            var organizerUser = context.MyUsers.Where(u => u.FirstName == "Codeboss").FirstOrDefault();

            var events = new Event[]
            {
                new Event{Title="Stuff N Things", 
                    Description="Doing fun stuff and things that everybody likes.", 
                    Place="Fun Arena", 
                    Address="20 Fun Street, Bean City", 
                    Date=DateTime.Parse("2021-06-19"), 
                    SpotsAvailable=0,
                    Organizer=organizerUser},

                new Event{Title="Awful Event",
                    Description="Come to this awful event if you dare.",
                    Place="Awful Arena",
                    Address="127 Awful Ave, Bean City",
                    Date=DateTime.Parse("2021-09-01"),
                    SpotsAvailable=97,
                    Organizer=organizerUser},

                new Event{Title="Llama spitting", 
                    Description="Wanna get spit by a Llama? Welcome to Llama Park.", 
                    Place="Llama Park", 
                    Address="89 Llama Street, SimCity", 
                    Date=DateTime.Parse("2021-05-11"), 
                    SpotsAvailable=25, 
                    Organizer=organizerUser},

                new Event{Title="Dankey Kongs banana party",
                    Description="Lots of bananas collected by an infamous ape will be shared to everyone who attends.", 
                    Place="Munky Cheez", 
                    Address="100 Jungle Lane, Bananaland", 
                    Date=DateTime.Parse("2021-08-13"), 
                    SpotsAvailable=1, 
                    Organizer=organizerUser},
            };

            context.Events.AddRange(events);
            context.SaveChanges();
        }
    }
}
