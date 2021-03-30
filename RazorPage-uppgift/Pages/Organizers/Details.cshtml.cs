using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;

namespace RazorPage_uppgift.Pages.Organizers
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;

        public DetailsModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context)
        {
            _context = context;
        }

        public Organizer Organizer { get; set; }
        public IEnumerable<Event> Events { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Events = _context.Events.Where(e => e.OrganizerID == id);
            Organizer = await _context.Organizers.FirstOrDefaultAsync(m => m.OrganizerID == id);

            if (Organizer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
