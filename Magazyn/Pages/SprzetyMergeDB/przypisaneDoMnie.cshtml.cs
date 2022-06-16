using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazyn.Data;
using Magazyn.Pages.Models;
using Microsoft.AspNetCore.Authorization;
using Magazyn.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Magazyn.Pages.SprzetyMergeDB
{
    [Authorize(Roles = "Admin,Operator")]
    public class przypisanySprzet : Klasa_Bazowa
    {
        private readonly ApplicationDbContext _context;

        public przypisanySprzet(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
            _context = context;
        }

        public Sprzet Sprzet { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
             IQueryable<int> IdSprzetuQuery = from m in _context.Sprzet
                                            select m.Id;
            if (id == null || _context.Sprzet == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            var sprzet = await _context.Sprzet.FirstOrDefaultAsync(m => m.Id == id);
            if (sprzet == null || user == null)
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
