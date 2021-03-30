using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPage_uppgift.Models;
using RazorPage_uppgift.Data;

namespace RazorPage_uppgift
{
    public static class Seeding // This class is used to seed the database when the application is launched.
    {
        public static void Initialize(RazorPage_uppgiftContext context)
        {
            if (context.Attendees.Any() ||
                context.Events.Any() ||
                context.Organizers.Any() ||
                context.JoinedEvents.Any())
            {
                Console.WriteLine("Data found in db, if you want the mock data provided in seed, open pmc " +
                    "and type : 'Drop-Database -Confirm'");
                return;
            }


            // Attendees

            Attendee[] attendees = new Attendee[] {
            new Attendee{Name="John Stranger", Email="John.Stranger@here.com", PhoneNumber="2222111121" }
            };
            context.AddRange(attendees);
            context.SaveChanges();


            // Organizers

            Organizer[] organizers = new Organizer[] {
            new Organizer{Name="JonaZ", Email="Jonaz.Jonsson@hothacking.se", PhoneNumber="1555555555"},
            new Organizer{Name="The Plumbers", Email="Yes.MarioLuigi@supah.com", PhoneNumber="0766666666"},
            };
            context.AddRange(organizers);
            context.SaveChanges();


            // Events

            Event[] events = new Event[] {
            new Event{
                Title="Stuff N things", 
                Organizer=organizers[0], 
                Description="Doing fun stuff and things that everybody likes.",
                Address="20 Fun Street, Bean City", 
                Date=DateTime.Parse("2021-06-19 12:00"),
                SpotsAvailable=0},


            new Event{
                Title="Awful event", 
                Organizer=organizers[0], 
                Description="Come to this awful event if you dare.",
                Address="127 Awful Ave, Bean City",
                Date=DateTime.Parse("2021-04-01 14:00"),
                SpotsAvailable=97},

            new Event{
                Title="Llama spitting", 
                Organizer=organizers[1], 
                Description="Wanna get spit by a Llama? Welcome to Llama Street.",
                Address="Llama Street, Bean City",
                Date=DateTime.Parse("2021-05-11 12:00"),
                SpotsAvailable=18},

            new Event{
                Title="Dankey Kongs banana party",
                Organizer=organizers[1],
                Description="Lots of bananas collected by an infamous ape will be shared to everyone who attends.",
                Address="100 Jungle Lane, Bananaland",
                Date=DateTime.Parse("2021-05-03 18:00"),
                SpotsAvailable=1},
            };
            context.AddRange(events);
            context.SaveChanges();
        }
    }
}
