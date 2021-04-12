using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;

namespace RazorPage_uppgift.Pages.JoinedEvents
{
    public class CreateModel : PageModel
    {


        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;

        public CreateModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context)
        {
            _context = context;
        }




        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JoinThisEvent = _context.Events.Where(e => e.EventID == id).FirstOrDefault();

            return Page();
        }



        [BindProperty]
        public JoinedEvent JoinedEvent { get; set; }
        public Event JoinThisEvent { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD



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


            JoinedEvent.MyUser = _context.MyUsers.Where(a => a.MyUserId == 0).First();
            JoinedEvent.Event = _context.Events.Where(e => e.EventID == id).First();


            _context.JoinedEvents.Add(JoinedEvent);
            _context.Events.Where(e => e.EventID == id).First().SpotsAvailable--;


            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
