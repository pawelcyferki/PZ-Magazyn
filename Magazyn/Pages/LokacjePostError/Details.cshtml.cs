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

namespace Magazyn.Pages.LokacjePostError
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly Magazyn.Data.ApplicationDbContext _context;

        public DetailsModel(Magazyn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Lokacja Lokacja { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lokacja == null)
            {
                return NotFound();
            }

            var lokacja = await _context.Lokacja.FirstOrDefaultAsync(m => m.Id == id);
            if (lokacja == null)
            {
                return NotFound();
            }
            else 
            {
                Lokacja = lokacja;
            }
            return Page();
        }
    }
}
