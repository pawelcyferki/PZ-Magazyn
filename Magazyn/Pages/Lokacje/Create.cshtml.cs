using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazyn.Data;
using Magazyn.Pages.Models;

namespace Magazyn.Pages.Lokacje
{
    public class CreateModel : PageModel
    {
        private readonly Magazyn.Data.ApplicationDbContext _context;

        public CreateModel(Magazyn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lokacja Lokacja { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Lokacja == null || Lokacja == null)
            {
                return Page();
            }

            _context.Lokacja.Add(Lokacja);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
