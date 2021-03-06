using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Magazyn.Data;
using Microsoft.AspNetCore.Authorization;
using Magazyn.Pages.Models;

namespace Magazyn.Pages.SprzetyMergeDB
{
    [Authorize(Roles = "Admin,Operator")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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
            Sprzet = sprzet;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sprzet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprzetExists(Sprzet.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SprzetExists(int id)
        {
            return (_context.Sprzet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
