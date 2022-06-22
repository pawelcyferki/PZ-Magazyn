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

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Magazyn.Pages.SprzetyMergeDB
{
    [Authorize(Roles = "Admin,Operator, User")]
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
        public int GetIdSprzetu(int? IdSprzetu)
        {
            var user = GetCurrentUserAsync();
            IdSprzetu = user?.Id;
            int sprzetIdQuery = 0;

            IEnumerable<int> SprzetIdUserSprzetQuery = from m in _context.UserSprzet
                                                       where IdSprzetu == m.SprzetId
                                                       select m.SprzetId;
            foreach (int sprzetId in SprzetIdUserSprzetQuery)
            {
                if (sprzetId != null)
                {
                    sprzetIdQuery = sprzetId;
                }
             
            }
            return 0;
        }
        public Sprzet Sprzet { get; set; } = default;
        public AspNetUserSprzet UserSprzet { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
     
        
          
     
                IQueryable<int> IdSprzetuQuery = from m in _context.Sprzet
                                            select m.Id;
     
            if (id == null || _context.Sprzet == null)
            {
                return NotFound();
            }
     
            
        var sprzet = await _context.Sprzet.FirstOrDefaultAsync(m => m.Id == id);
            if (sprzet == null )
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
