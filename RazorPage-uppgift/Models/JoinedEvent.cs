using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage_uppgift.Models
{
    public class JoinedEvent
    {
        public int JoinedEventID { get; set; }
        public int EventID { get; set; }
        public int MyUserId { get; set; }
        public Event Event { get; set; }
        public MyUser MyUser { get; set; }
    }
}
