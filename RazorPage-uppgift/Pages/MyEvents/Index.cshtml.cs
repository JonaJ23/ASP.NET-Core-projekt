using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;
using Microsoft.AspNetCore.Identity;

namespace RazorPage_uppgift.Pages.MyEvents
{
    public class IndexModel : PageModel
    {
        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;
        private readonly UserManager<MyUser> _userManager;

        public IndexModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ICollection<Event> Event { get; set; }
        public MyUser MyUser { get; set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            var CurrentUser = await _context.MyUsers.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (_userManager.IsInRoleAsync(CurrentUser, "Organizer").Result)
            {
                var MyUser = await _context.MyUsers.Where(u => u.Id == userId).Include(u => u.HostedEvents).FirstOrDefaultAsync();
                Event = MyUser.HostedEvents;
            }
            else
            {
                var MyUser = await _context.MyUsers.Where(u => u.Id == userId).Include(u => u.JoinedEvents).FirstOrDefaultAsync();
                Event = MyUser.JoinedEvents;
            }



        }
    }
}
