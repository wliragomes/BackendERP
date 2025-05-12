using Microsoft.AspNetCore.Authentication;
using SharedKernel.Configuration.Cache;
using System.Security.Claims;

namespace SharedKernel.Helpers.Authorization
{
    public class CustomClaimsTransformation : IClaimsTransformation
    {
        private readonly ICacheProvider _cacheProvider;

        public CustomClaimsTransformation(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity?.IsAuthenticated is false)
            {
                return principal;
            }

            var userClaim = principal.Claims.FirstOrDefault(c => c.Type == "RedisIdToken");
            var redisIdToken = userClaim?.Value;

            if (redisIdToken is null)
                return principal;

            var userPermissions = await _cacheProvider.GetAsync<Credentials?>(redisIdToken);

            if (userPermissions is null || userPermissions.Claims is null)
                return principal;

            var claimsIdentity = new ClaimsIdentity();

            foreach (var claim in userPermissions.Claims)
            {
                claimsIdentity.AddClaim(new Claim("AccessControl", claim));
            }

            principal.AddIdentity(claimsIdentity);
            return principal;
        }
    }

    public class Credentials
    {
        public List<string>? Claims { get; set; }
    }
}
