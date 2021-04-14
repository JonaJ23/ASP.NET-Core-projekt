using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RazorPage_uppgift.Pages.Events
{   [Authorize(Policy="RequireOrganizerRole")]
    public class CreateModel : PageModel
    {
        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;
        private readonly UserManager<MyUser> _userManager;

        public CreateModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }
        public MyUser CurrentUser { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = _userManager.GetUserId(User);

<<<<<<< HEAD:RazorPage-uppgift/Pages/Events/Create.cshtml.cs
            CurrentUser = await _context.MyUsers.Where(u => u.Id == userId).FirstOrDefaultAsync();
=======
            if (id == null)
            {
                return NotFound();
            }


            //JoinedEvent.MyUser = _context.MyUsers.Where(a => a.MyUserId == 0).First();
            JoinedEvent.Event = _context.Events.Where(e => e.EventID == id).First();


            _context.JoinedEvents.Add(JoinedEvent);
            _context.Events.Where(e => e.EventID == id).First().SpotsAvailable--;

>>>>>>> b922c060bf8ca8b4341d8a850558aec7b7070f4b:RazorPage-uppgift/Pages/JoinedEvents/Create.cshtml.cs

            Event.Organizer = CurrentUser;
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
