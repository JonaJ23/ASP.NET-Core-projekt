using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage_uppgift.Models
{
    public class JoinedEvent
    {
        public int AttendeeID { get; set; }
        public int EventID { get; set; }
        public int JoinedEventID { get; set; }
        public Attendee Attendee { get; set; }
        public Event Event { get; set; }
    }
}
