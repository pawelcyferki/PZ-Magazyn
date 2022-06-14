using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazyn.Data;
using Magazyn.Pages.Models;
using Magazyn.Pages.SprzetyMergeDB;
using Microsoft.AspNetCore.Authorization;
using Magazyn.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Magazyn.Pages.SorzetyMergeDB
{
    public class DetailsModel : Klasa_Bazowa
    {
        private readonly Magazyn.Data.ApplicationDbContext _context;

        public DetailsModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
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
