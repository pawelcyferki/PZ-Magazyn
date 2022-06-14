using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazyn.Data;
using Magazyn.Pages.Models;

namespace Magazyn.Pages.Sprzety
{
    public class DetailsModel : PageModel
    {
        private readonly Magazyn.Data.MagazynContext _context;

        public DetailsModel(Magazyn.Data.MagazynContext context)
        {
            _context = context;
        }

      public Sprzet Sprzet { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sprzet == null)
            {
                return NotFound();
            }

            var sprzet = await _context.Sprzet.FirstOrDefaultAsync(m => m.Id == id);
            if (sprzet == null)
            {
                return NotFound();
            }
            else 
            {
                Sprzet = sprzet;
            }
            return Page();
        }
    }
}
