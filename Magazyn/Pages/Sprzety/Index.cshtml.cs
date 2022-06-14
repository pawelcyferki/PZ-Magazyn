using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazyn.Data;
using Magazyn.Pages.Models;
using Microsoft.AspNetCore.Authorization;

namespace Magazyn.Pages.Sprzety
{
    [Authorize(Roles = "Admin,Operator")]
    public class IndexModel : PageModel
    {
        
        private readonly Magazyn.Data.MagazynContext _context;

        public IndexModel(Magazyn.Data.MagazynContext context)
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
