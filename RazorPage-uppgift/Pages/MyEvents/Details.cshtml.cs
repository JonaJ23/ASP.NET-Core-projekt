﻿using System;
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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.EventID == id);

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

            var MyUser = await _context.MyUsers.Where(u => u.Id == userId).Include(u => u.JoinedEvents).FirstOrDefaultAsync();

            if (MyUser == null)
            {
                return NotFound();
            }
            else
            {
                Event.SpotsAvailable++;
                MyUser.JoinedEvents.Remove(Event);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            

        }
    }
}
