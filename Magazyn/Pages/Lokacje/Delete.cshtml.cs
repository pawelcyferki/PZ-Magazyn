﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazyn.Data;
using Magazyn.Pages.Models;

namespace Magazyn.Pages.Lokacje
{
    public class DeleteModel : PageModel
    {
        private readonly Magazyn.Data.MagazynContext _context;

        public DeleteModel(Magazyn.Data.MagazynContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Lokacja == null)
            {
                return NotFound();
            }
            var lokacja = await _context.Lokacja.FindAsync(id);

            if (lokacja != null)
            {
                Lokacja = lokacja;
                _context.Lokacja.Remove(Lokacja);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
