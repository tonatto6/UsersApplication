using System.Security.Claims;

namespace UsersApplication.Helpers
{
    public static class GetClaims
    {
        public static string GetClaimUsername(ClaimsPrincipal user) 
        {
            return user.FindFirst("username").Value;
        }
    }
}
