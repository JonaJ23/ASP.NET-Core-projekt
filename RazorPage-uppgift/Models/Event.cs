using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPage_uppgift.Models
{
    public class Event
    {
        public int EventID { get; set; } // PK
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int SpotsAvailable { get; set; }
        [InverseProperty("HostedEvents")]
        public MyUser Organizer { get; set; }
        [InverseProperty("JoinedEvents")]
        public ICollection<MyUser> MyUsers { get; set; }
    }
}
