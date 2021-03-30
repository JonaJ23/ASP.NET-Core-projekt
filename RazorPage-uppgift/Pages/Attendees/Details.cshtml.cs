using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;

namespace RazorPage_uppgift.Pages.Attendees
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;

        public DetailsModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context)
        {
            _context = context;
        }

        public Attendee Attendee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Attendee = await _context.Attendees.FirstOrDefaultAsync(m => m.AttendeeID == id);

            if (Attendee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
