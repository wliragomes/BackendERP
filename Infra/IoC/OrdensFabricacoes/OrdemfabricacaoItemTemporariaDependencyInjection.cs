using Domain.Commands.OrdensFabricacoes;
using Domain.Commands.OrdensFabricacoes.Adicionar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.OrdensFabricacoes
{
    public static class OrdemFabricacaoItemTemporariaDependencyInjection
    {
        public static void AddOrdemFabricacaoItemTemporariaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarOrdemFabricacaoTemporariaCommand, FormularioResponse<AdicionarOrdemFabricacaoTemporariaCommand>>, AdicionarOrdemFabricacaoTemporariaCommandHandler>();
            services.AddTransient<IValidator<AdicionarOrdemFabricacaoTemporariaCommand>, AdicionarOrdemFabricacaoTemporariaCommandValidation>();
            services.AddTransient<IValidator<OrdemFabricacaoTemporariaCommand<AdicionarOrdemFabricacaoTemporariaCommand>>, OrdemFabricacaoTemporariaCommandValidation<AdicionarOrdemFabricacaoTemporariaCommand>>();

            services.AddScoped<IOrdemFabricacaoItemTemporariaRepository, OrdemFabricacaoItemTemporariaRepository>();
        }
    }
}
