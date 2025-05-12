using APIs.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SharedKernel.SharedObjects;
using System.Net;
using SharedKernel.Configuration.Cache;
using SharedKernel.Configuration.Security.JWT;
using SharedKernel.Helpers.Authorization;

namespace SharedKernel.Configuration.Extensions
{
    public static class AuthExtension
    {
        public static void AddAuthExtension(this IServiceCollection services, IConfigurationSection tokenConfiguration, ICacheProvider cacheProvider)
        {
            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                tokenConfiguration)
                    .Configure(tokenConfigurations);

            services.AddAuthentication(opts =>
            {
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
                {
                    opts.SaveToken = true;
                    opts.Audience = tokenConfigurations.Audience;
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfigurations.SecretJwtKey!)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = tokenConfigurations.Issuer,
                    };
                    opts.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                        {
                            context.HandleResponse();

                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";

                            var serializerSettings = new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            };

                            var response = JsonConvert.SerializeObject(new NewResponse()
                            {
                                StatusCode = (int)HttpStatusCode.Unauthorized,
                                Errors = "Houve um problema na sua autorização."
                            }, serializerSettings);

                            await context.Response.WriteAsync(response);
                        }
                    };
                });

            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidateJwtTokenFilter(tokenConfigurations, cacheProvider)); // Adiciona o filtro personalizado
            });

            services.AddAuthorization();

            services.AddScoped<IClaimsTransformation, CustomClaimsTransformation>();
        }
    }
}
