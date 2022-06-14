using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Magazyn.Authorization
{
    public class OperacjePomocnicze
    {
        public static OperationAuthorizationRequirement Read =
          new OperationAuthorizationRequirement { Name = Constants.ReadOperationName };

    }
    public class Constants
    {
        public static readonly string ReadOperationName = "Details";
        public static readonly string nazwaRoliAdmina = "Admin";
    }
}
