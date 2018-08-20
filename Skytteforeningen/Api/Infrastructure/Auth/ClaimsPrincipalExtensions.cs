using System.Linq;
using System.Security.Claims;

namespace Api.Infrastructure.Auth
{
    public static class ClaimsPrincipalExtensions
    {
        public static string UserId(this ClaimsPrincipal user)
        {
            return user.Claims.Single(x => x.Type == "sub").Value;
        }
    }
}