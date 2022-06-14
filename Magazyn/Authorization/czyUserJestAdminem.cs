using System.Threading.Tasks;
using Magazyn.Pages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Magazyn.Authorization
{
    public class czyUserJestAdminem :
        AuthorizationHandler<OperationAuthorizationRequirement, Sprzet>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                     Sprzet resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.nazwaRoliAdmina))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
