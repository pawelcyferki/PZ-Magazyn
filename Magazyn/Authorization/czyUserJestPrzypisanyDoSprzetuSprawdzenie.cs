using Magazyn.Pages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Magazyn.Authorization
{
    public class czyUserJestPrzypisanyDoSprzetuSprawdzenie
        : AuthorizationHandler<OperationAuthorizationRequirement, Sprzet>
    {
        UserManager<IdentityUser> _userManager;
        public czyUserJestPrzypisanyDoSprzetuSprawdzenie(UserManager<IdentityUser>
           userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Sprzet resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for CRUD permission, return.

            if (  requirement.Name != Constants.ReadOperationName )

            {
                return Task.CompletedTask;
            }

            if (resource.osobaPrzypisanaID == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
