using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;

namespace RazorPage_uppgift.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPage_uppgiftContext _context;

        public DetailsModel(RazorPage_uppgiftContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }
        public bool EventIsListed { get; set; }

        [BindProperty]
        public JoinedEvent JoinedEvent { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventIsListed = await _context.JoinedEvents
                .Where(e => e.EventID == id)
                .FirstOrDefaultAsync(a => a.MyUserId == 1) == default ? false : true;

            Event = await _context.Events
               // .Include(e => e.Organizer)
                .FirstOrDefaultAsync(m => m.EventID == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            //JoinedEvent.MyUser = await _context.MyUsers.Where(a => a.MyUserId == 1).FirstOrDefaultAsync();
            JoinedEvent.Event = await _context.Events.Where(e => e.EventID == id).FirstOrDefaultAsync();

            _context.JoinedEvents.Add(JoinedEvent);
            _context.Events.Where(e => e.EventID == id).First().SpotsAvailable--;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = id });
        }
    }
}
