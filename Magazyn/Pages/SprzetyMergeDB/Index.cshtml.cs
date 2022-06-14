using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazyn.Data;
using Magazyn.Pages.Models;

namespace Magazyn.Pages.SorzetyMergeDB
{
    public class IndexModel : PageModel
    {
        private readonly Magazyn.Data.ApplicationDbContext _context;

        public IndexModel(Magazyn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Sprzet> Sprzet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sprzet != null)
            {
                Sprzet = await _context.Sprzet.ToListAsync();
            }
        }
    }
}
