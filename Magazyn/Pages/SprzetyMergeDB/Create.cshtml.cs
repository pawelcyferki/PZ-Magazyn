using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazyn.Data;
using Magazyn.Pages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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

        [BindProperty]
        public Sprzet Sprzet { get; set; } = default!;
        public IdentityUser UserData { get; set; }

        public string wybranyId { get; set; }
        public SelectList UserIdList { get; set; }
     

     /*   public IActionResult OnGet()
        {
    
            return Page();
        }
     */
        public async Task OnGetAsync()
        {
       

            IQueryable<string> UserIdListQuery = from m in _context.Users
                                                 orderby m.Email
                                                 select m.Email;
      
            UserIdList = new SelectList( await UserIdListQuery.Distinct().ToListAsync());

           
       

           
            }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Sprzet == null || Sprzet == null)
            {
                return Page();
            }
      
            Sprzet.osobaPrzypisana = wybranyId;

            _context.Sprzet.Add(Sprzet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
