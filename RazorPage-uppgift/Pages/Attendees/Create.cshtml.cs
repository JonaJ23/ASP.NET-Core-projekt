using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;

namespace RazorPage_uppgift.Pages.Attendees
{
    public class CreateModel : PageModel
    {
        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;

        public CreateModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Attendee Attendee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attendees.Add(Attendee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
