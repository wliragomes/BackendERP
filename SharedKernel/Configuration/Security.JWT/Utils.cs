using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace APIs.Security.JWT.Util
{
    public class Utils
    {
        public static string GetTokenFromHeader(string authHeader)
        {
            var jwtToken = authHeader;
            var bearerKeyword = "Bearer ";
            var hasBearerPrefix = authHeader.StartsWith(bearerKeyword, StringComparison.OrdinalIgnoreCase);
            if (hasBearerPrefix)
                jwtToken = authHeader.Substring(bearerKeyword.Length);

            return jwtToken;
        }

        public static string GetUserIdFromToken(string token)
        {
            return GetItemFromToken(token, "UserId");
        }

        public static string GetUserCodeFromToken(string token)
        {
            return GetItemFromToken(token, "UserCode");
        }

        public static string GetUserNameFromToken(string token)
        {
            return GetItemFromToken(token, "UserName");
        }
        public static string GetIdAdministradorFromToken(string token)
        {
            return GetItemFromToken(token, "AdministratorId");
        }

        public static string GetItemFromToken(string token, string type)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = tokenHandler.ReadJwtToken(token).Claims.ToList();

            var userId = claims.FirstOrDefault(x => x.Type == type)?.Value;

            return userId!;
        }

        public static string GetTokenFromCookie(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Cookies.ContainsKey("accessToken"))
                return context.HttpContext.Request.Cookies["accessToken"]!;

            return "";
        }

        public static Guid? GetUserId(string authHeader)
        {
            var token = GetTokenFromHeader(authHeader);
            var user = GetUserIdFromToken(token);
            return Guid.Parse(user);
        }
    }
}
