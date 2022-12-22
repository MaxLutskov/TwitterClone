

using System.Security.Claims;

namespace TwitterClone.Server.Extensions
{
    public static class HttpContextExtension
    {
        public static Guid GetUserId(this HttpContext context)
        {
            var userClaims = context.User.Identity as ClaimsIdentity;
            if (userClaims == null)
                return Guid.Empty;
            
            var userId = userClaims.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            if (userId == null)
                return Guid.Empty;

            return Guid.Parse(userId.Value);
        }
    }
}
