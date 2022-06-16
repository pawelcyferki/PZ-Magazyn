using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Magazyn.Data;
using Magazyn.Pages.Models;
using Microsoft.AspNetCore.Authorization;

namespace Magazyn.Pages.LokacjePostError
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Magazyn.Data.ApplicationDbContext _context;

        public EditModel(Magazyn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lokacja Lokacja { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lokacja == null)
            {
                return NotFound();
            }

            var lokacja =  await _context.Lokacja.FirstOrDefaultAsync(m => m.Id == id);
            if (lokacja == null)
            {
                return NotFound();
            }
            Lokacja = lokacja;
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

            _context.Attach(Lokacja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokacjaExists(Lokacja.Id))
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

        private bool LokacjaExists(int id)
        {
          return (_context.Lokacja?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
