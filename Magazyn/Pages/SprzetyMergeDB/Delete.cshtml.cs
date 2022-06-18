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

namespace Magazyn.Pages.SprzetyMergeDB
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sprzet == null)
            {
                return NotFound();
            }
            var sprzet = await _context.Sprzet.FindAsync(id);

            if (sprzet != null)
            {
                Sprzet = sprzet;
                _context.Sprzet.Remove(Sprzet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
