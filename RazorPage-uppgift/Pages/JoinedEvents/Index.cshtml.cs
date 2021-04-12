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
    public class IndexModel : PageModel
    {
        private readonly RazorPage_uppgiftContext _context;
        public IndexModel(RazorPage_uppgiftContext context)
        {
            _context = context;
        }

        public IList<JoinedEvent> JoinedEvent { get;set; }
        public async Task OnGetAsync()
        {
            JoinedEvent = await _context.JoinedEvents
                .Include(j => j.MyUser)
                .Include(j => j.Event).ToListAsync();
        }
    }
}
