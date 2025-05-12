using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Emails;
using Application.Services.Emails;

namespace Infra.IoC.Emails
{
    public static class EmailDependencyInjection
    {
        public static void AddEmailoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
