using Magazyn.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Magazyn.Pages;

namespace Magazyn.Pages.SprzetyMergeDB
{
    public class Klasa_Bazowa : PageModel
    {
        protected ApplicationDbContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        public Klasa_Bazowa(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }
        public Task<IdentityUser> GetCurrentUserAsync() => UserManager.GetUserAsync(HttpContext.User);
    }
}
