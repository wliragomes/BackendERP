using Application.Interfaces.OrdensFabricacoes;
using Application.Interfaces.Queries;
using Application.Services.OrdensFabricacoes;
using Domain.Commands.OrdensFabricacoes;
using Domain.Commands.OrdensFabricacoes.Adicionar;
using Domain.Commands.OrdensFabricacoes.Atualizar;
using Domain.Commands.OrdensFabricacoes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.OrdensFabricacoes;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.OrdensFabricacoes
{
    public static class OrdemFabricacaoDependencyInjection
    {
        public static void AddOrdemFabricacaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarOrdemFabricacaoCommand, FormularioResponse<AdicionarOrdemFabricacaoCommand>>, AdicionarOrdemFabricacaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarOrdemFabricacaoCommand>, AdicionarOrdemFabricacaoCommandValidation>();
            services.AddTransient<IValidator<OrdemFabricacaoCommand<AdicionarOrdemFabricacaoCommand>>, OrdemFabricacaoCommandValidation<AdicionarOrdemFabricacaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarOrdemFabricacaoCommand, FormularioResponse<AtualizarOrdemFabricacaoCommand>>, AtualizarOrdemFabricacaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarOrdemFabricacaoCommand>, AtualizarOrdemFabricacaoCommandValidation>();
            services.AddTransient<IValidator<OrdemFabricacaoCommand<AtualizarOrdemFabricacaoCommand>>, OrdemFabricacaoCommandValidation<AtualizarOrdemFabricacaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirOrdemFabricacaoCommand, List<FormularioResponse<ExcluirOrdemFabricacaoCommand>>>, ExcluirOrdemFabricacaoCommandHandler>();

            services.AddScoped<IOrdemFabricacaoService, OrdemFabricacaoService>();
            services.AddScoped<IOrdemFabricacaoQuery, OrdemFabricacaoQuery>();
            services.AddScoped<IOrdemFabricacaoRepository, OrdemFabricacaoRepository>();
        }
    }
}
