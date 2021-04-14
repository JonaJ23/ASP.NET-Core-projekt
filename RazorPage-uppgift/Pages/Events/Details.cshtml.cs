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

namespace RazorPage_uppgift.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;
        private readonly UserManager<MyUser> _userManager;

        public DetailsModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Event Event { get; set; }
        public MyUser MyUser { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.EventID == id);

            var userId = _userManager.GetUserId(User);

            MyUser = await _context.MyUsers.Where(u => u.Id == userId).Include(u => u.JoinedEvents).FirstOrDefaultAsync();

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Event = await _context.Events.FirstOrDefaultAsync(m => m.EventID == id);

            var userId = _userManager.GetUserId(User);

            MyUser = await _context.MyUsers.Where(u => u.Id == userId).Include(u=>u.JoinedEvents).FirstOrDefaultAsync();

            if (MyUser == null)
            {
                return NotFound();
            }
            else
            {
                Event.SpotsAvailable --;
                MyUser.JoinedEvents.Add(Event);
                await _context.SaveChangesAsync();
            }
<<<<<<< HEAD
            return Page();
=======

            //JoinedEvent.MyUser = await _context.MyUsers.Where(a => a.MyUserId == 1).FirstOrDefaultAsync();
            JoinedEvent.Event = await _context.Events.Where(e => e.EventID == id).FirstOrDefaultAsync();

            _context.JoinedEvents.Add(JoinedEvent);
            _context.Events.Where(e => e.EventID == id).First().SpotsAvailable--;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = id });
>>>>>>> b922c060bf8ca8b4341d8a850558aec7b7070f4b
        }
    }
}
