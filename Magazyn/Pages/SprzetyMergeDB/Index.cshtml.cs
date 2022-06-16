using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazyn.Data;
using Magazyn.Pages.Models;
using Microsoft.AspNetCore.Authorization;


namespace Magazyn.Pages.SprzetyMergeDB
{
    [Authorize(Roles = "Admin,Operator")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Sprzet> Sprzet { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Lokalizacje { get; set; }
        [BindProperty(SupportsGet = true)]
        public string wybranaLokalizacja { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> lokalizacjaQuery = from m in _context.Sprzet
                                            orderby m.lokalizacja
                                            select m.lokalizacja;
            var sprzety = from m in _context.Sprzet
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                sprzety = sprzety.Where(s => s.SN.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(wybranaLokalizacja))
            {
                sprzety = sprzety.Where(x => x.lokalizacja == wybranaLokalizacja);
            }
            Lokalizacje = new SelectList(await lokalizacjaQuery.Distinct().ToListAsync());
            Sprzet = await sprzety.ToListAsync();

            if (_context.Sprzet != null)
            {
                Sprzet = await _context.Sprzet.ToListAsync();
            }
        }
    }
}
