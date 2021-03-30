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
    public class IndexModel : PageModel
    {
        private readonly RazorPage_uppgift.Data.RazorPage_uppgiftContext _context;

        public IndexModel(RazorPage_uppgift.Data.RazorPage_uppgiftContext context)
        {
            _context = context;
        }

        public IList<Organizer> Organizer { get;set; }

        public async Task OnGetAsync()
        {
            Organizer = await _context.Organizers.ToListAsync();
        }
    }
}
