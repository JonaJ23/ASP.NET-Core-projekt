using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage_uppgift.Models
{
    public class Event
    {
        public int EventID { get; set; } // PK
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public Organizer Organizer { get; set; }
        public int SpotsAvailable { get; set; }
        public int OrganizerID { get; set; }
    }
}
