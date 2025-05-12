using APIs.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Configuration.Security.JWT
{
    public static class JwtSecurityExtension
    {
        public static IServiceCollection AddJwtSecurity(
            this IServiceCollection services,
            TokenConfigurations tokenConfigurations)
        {
            // Configurando a dependência para a classe de validação
            // de credenciais e geração de tokens
            services.AddScoped<AccessManager>();
            services.AddScoped<JwtSecurityExtensionEvents>();

            var signingConfigurations = new SigningConfigurations(
                tokenConfigurations.SecretJwtKey!);

            services.AddSingleton(signingConfigurations);
            services.AddSingleton(tokenConfigurations);

            return services;
        }
    }
}
