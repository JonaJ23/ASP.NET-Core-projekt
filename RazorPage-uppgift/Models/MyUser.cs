﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage_uppgift.Models
{
    public class MyUser : IdentityUser
    {
        public int MyUserId { get; set; }
        public ICollection<Event> Events { get; set;  }
    }
}
