using Microsoft.AspNetCore.Http;

namespace SharedKernel.Configuration.Security.JWT
{
    public class TokenMissingMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMissingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"];

            if (string.IsNullOrWhiteSpace(token))
            {
                if (context.Request.Cookies.ContainsKey("accessToken"))
                {
                    token = context.Request.Cookies["accessToken"]!;
                    context.Request.Headers.Add("Authorization", $"Bearer {token}");
                }
            }

            await _next(context);
        }
    }
}
