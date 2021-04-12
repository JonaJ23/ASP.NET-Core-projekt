using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;

namespace RazorPage_uppgift.Pages.JoinedEvents
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPage_uppgiftContext _context;

        public DeleteModel(RazorPage_uppgiftContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JoinedEvent JoinedEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JoinedEvent = await _context.JoinedEvents
            .Where(re => re.JoinedEventID == id).FirstOrDefaultAsync();

            JoinedEvent = await _context.JoinedEvents
            .Include(j => j.MyUser)
            .Include(j => j.Event).FirstOrDefaultAsync(m => m.JoinedEventID == id);

            if (JoinedEvent == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JoinedEvent = await _context.JoinedEvents.FindAsync(id);

            if (JoinedEvent != null)
            {
                _context.Events.Where(e => e.EventID == JoinedEvent.EventID).First().SpotsAvailable++;
                _context.JoinedEvents.Remove(JoinedEvent);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
