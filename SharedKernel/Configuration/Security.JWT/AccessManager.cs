using APIs.Security.JWT;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SharedKernel.Configuration.Security.JWT
{
    public class AccessManager
    {
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;

        public AccessManager(
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations)
        {
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        public Token GenerateToken(User user, Guid redisIdToken)
        {
            ClaimsIdentity identity = new(
                new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim("UserId", user.UserID!),
                new Claim("UserName", user.Name!),
                new Claim("RedisIdToken", redisIdToken.ToString()),
                new Claim("SystemOperation", "Core")
                }
            );

            DateTime today = DateTime.Today;
            DateTime expireDate = DateTime.UtcNow.AddHours(12);
            DateTime createDate = DateTime.Now;

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expireDate
            });
            var token = handler.WriteToken(securityToken);

            return new()
            {
                Authenticated = true,
                Created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = expireDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "OK"
            };
        }
    }
}
