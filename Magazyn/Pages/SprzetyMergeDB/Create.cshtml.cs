using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazyn.Data;
using Magazyn.Pages.Models;
using Magazyn.Pages.Sprzety;
using Microsoft.AspNetCore.Authorization;
using Magazyn.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Magazyn.Pages.SprzetyMergeDB
{

    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sprzet Sprzet { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Sprzet == null || Sprzet == null)
            {
                return Page();
            }



            _context.Sprzet.Add(Sprzet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
