using Application.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using JWTUtils = APIs.Security.JWT.Util.Utils;

namespace Application.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var token = GetToken();
            var userId = JWTUtils.GetUserIdFromToken(token);

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("Usuário não autenticado.");

            return Guid.Parse(userId);
        }

        public string GetUserName()
        {
            var token = GetToken();
            return JWTUtils.GetUserNameFromToken(token) ?? throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        private string GetToken()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authorizationHeader))
                throw new UnauthorizedAccessException("Token não encontrado no header.");

            return JWTUtils.GetTokenFromHeader(authorizationHeader);
        }
    }
}
