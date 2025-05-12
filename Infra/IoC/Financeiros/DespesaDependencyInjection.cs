using Domain.Interfaces.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC.Despesas
{
    public static class DespesaDependencyInjection
    {
        public static void AddDespesaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDespesaRepository, DespesaRepository>();
        }
    }
}
