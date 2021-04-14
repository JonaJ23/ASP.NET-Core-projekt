using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage_uppgift.Models
{
    public class MyUser : IdentityUser
    {
<<<<<<< HEAD
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Event> HostedEvents { get; set; }
        public ICollection<Event> JoinedEvents { get; set; }
=======
        public ICollection<Event> Events { get; set;  }
>>>>>>> b922c060bf8ca8b4341d8a850558aec7b7070f4b
    }
}
