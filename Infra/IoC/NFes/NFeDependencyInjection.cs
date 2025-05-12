using Application.Interfaces.Queries;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.NFes;
using Application.Services.NFes;
using Infra.Queries.NFes;
using Infra.NFes.Processors;

namespace Infra.IoC.NFes
{
    public static class NFeDependencyInjection
    {
        public static void AddNFeDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<INFeProcessor, NFeProcessor>();

            services.AddScoped<INFeService, NFeService>();
            services.AddScoped<INFeQuery, NFeQuery>();
        }
    }
}
