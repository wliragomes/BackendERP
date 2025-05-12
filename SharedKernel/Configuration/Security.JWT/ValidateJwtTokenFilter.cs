using APIs.Security.JWT;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Configuration.Cache;


namespace SharedKernel.Configuration.Security.JWT
{
    public class ValidateJwtTokenFilter : IAsyncAuthorizationFilter
    {
        private TokenConfigurations _tokenConfigurations;
        private readonly ICacheProvider _cacheProvider;

        public ValidateJwtTokenFilter(TokenConfigurations tokenConfigurations, ICacheProvider cacheProvider)
        {
            _tokenConfigurations = tokenConfigurations;
            _cacheProvider = cacheProvider;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Path.Value == "/api/Auth") //api/Login
                return;

            var token = APIs.Security.JWT.Util.Utils.GetTokenFromHeader(context.HttpContext.Request.Headers["Authorization"].ToString());

            if (!string.IsNullOrWhiteSpace(token))
            {
                if (await TokenBlacklist.IsTokenBlacklisted(token, _cacheProvider))
                    context.Result = new UnauthorizedResult();
                else
                    await Task.CompletedTask;
            }
        }
    }
}
