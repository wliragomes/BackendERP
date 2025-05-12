using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.Financeiros;
using Application.Interfaces.Financeiros;
using Infra.Repositories;
using Application.Interfaces.Queries;
using Infra.Queries.Financeiros;

namespace Infra.IoC.Financeiros
{
    public static class CentroCustoDependencyInjection
    {
        public static void AddCentroCustoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IFinanceiroService, FinanceiroService>();
            services.AddScoped<IFinanceiroQuery, FinanceiroQuery>();
            services.AddScoped<ICentroCustoRepository, CentroCustoRepository>();
        }
    }
}
