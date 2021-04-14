using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RazorPage_uppgift.Pages.ManageUsers
{
    [Authorize(Policy = "RequireAdminRole")]
    public class IndexModel : PageModel
    {
        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;
        private readonly UserManager<MyUser> _ManageUsers;

        public IndexModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context, UserManager<MyUser> ManageUsers)
        {
            _context = context;
            _ManageUsers = ManageUsers;
        }

        public IList<MyUser> MyUsers { get; set; }
        public MyUser MyUser { get; set; }
        public async Task OnGetAsync()
        {
            MyUsers = await _context.MyUsers.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {

            MyUsers = await _context.MyUsers.ToListAsync();
            MyUser = await _context.MyUsers.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (MyUser != null)
            {
                if (!_ManageUsers.IsInRoleAsync(MyUser, "Organizer").Result)
                {
                    await _ManageUsers.AddToRoleAsync(MyUser, "Organizer");
                    await _ManageUsers.RemoveFromRoleAsync(MyUser, "Attendee");
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/ManageUsers/Index");
                }
                else
                {
                    await _ManageUsers.RemoveFromRoleAsync(MyUser, "Organizer");
                    await _ManageUsers.AddToRoleAsync(MyUser, "Attendee");
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/ManageUsers/Index");
                }
            }
            return Page();
        }

    }
}


