using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Pessoas.TipoConsumidores;
using Domain.Commands.Pessoas.TipoConsumidores.Atualizar;

namespace Infra.IoC.Pessoas
{
    public static class TipoConsumidorDependencyInjection
    {
        public static void AddTipoConsumidorDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AtualizarTipoConsumidorCommand, FormularioResponse<AtualizarTipoConsumidorCommand>>, AtualizarTipoConsumidorCommandHandler>();
            services.AddTransient<IValidator<AtualizarTipoConsumidorCommand>, AtualizarTipoConsumidorCommandValidation>();
            services.AddTransient<IValidator<TipoConsumidorCommand<AtualizarTipoConsumidorCommand>>, TipoConsumidorCommandValidation<AtualizarTipoConsumidorCommand>>();

                        
            services.AddScoped<ITipoConsumidorRepository, TipoConsumidorRepository>();
        }
    }
}

