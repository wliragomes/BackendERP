using Application.Interfaces.PlanejamentoProducaos;
using Application.Interfaces.Queries;
using Application.Services.PlanejamentoProducaos;
using Domain.Commands.PlanejamentoProducaos;
using Domain.Commands.PlanejamentoProducaos.Atualizar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.PlanejamentoProducaos;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.PlanejamentoProducaos
{
    public static class PlanejamentoProducaoDependencyInjection
    {
        public static void AddPlanejamentoProducaoDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<AtualizarPlanejamentoProducaoCommand, FormularioResponse<AtualizarPlanejamentoProducaoCommand>>, AtualizarPlanejamentoProducaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarPlanejamentoProducaoCommand>, AtualizarPlanejamentoProducaoCommandValidation>();
            services.AddTransient<IValidator<PlanejamentoProducaoCommand<AtualizarPlanejamentoProducaoCommand>>, PlanejamentoProducaoCommandValidation<AtualizarPlanejamentoProducaoCommand>>();

            services.AddScoped<IPlanejamentoProducaoService, PlanejamentoProducaoService>();
            services.AddScoped<IPlanejamentoProducaoQuery, PlanejamentoProducaoQuery>();
            services.AddScoped<IPlanejamentoProducaoRepository, PlanejamentoProducaoRepository>();
        }
    }
}
