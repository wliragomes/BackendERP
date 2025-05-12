using Application.Interfaces.FluxoCaixas;
using Application.Interfaces.Queries;
using Application.Services.FluxoCaixas;
using Domain.Commands.FluxoCaixas;
using Domain.Commands.FluxoCaixas.Adicionar;
using Domain.Commands.FluxoCaixas.Atualizar;
using Domain.Commands.FluxoCaixas.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.FluxoCaixas;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.FluxoCaixas
{
    public static class FluxoCaixaDependencyInjection
    {
        public static void AddFluxoCaixaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarFluxoCaixaCommand, FormularioResponse<AdicionarFluxoCaixaCommand>>, AdicionarFluxoCaixaCommandHandler>();
            services.AddTransient<IValidator<AdicionarFluxoCaixaCommand>, AdicionarFluxoCaixaCommandValidation>();
            services.AddTransient<IValidator<FluxoCaixaCommand<AdicionarFluxoCaixaCommand>>, FluxoCaixaCommandValidation<AdicionarFluxoCaixaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarFluxoCaixaCommand, FormularioResponse<AtualizarFluxoCaixaCommand>>, AtualizarFluxoCaixaCommandHandler>();
            services.AddTransient<IValidator<AtualizarFluxoCaixaCommand>, AtualizarFluxoCaixaCommandValidation>();
            services.AddTransient<IValidator<FluxoCaixaCommand<AtualizarFluxoCaixaCommand>>, FluxoCaixaCommandValidation<AtualizarFluxoCaixaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirFluxoCaixaCommand, List<FormularioResponse<ExcluirFluxoCaixaCommand>>>, ExcluirFluxoCaixaCommandHandler>();

            services.AddScoped<IFluxoCaixaService, FluxoCaixaService>();
            services.AddScoped<IFluxoCaixaQuery, FluxoCaixaQuery>();
            services.AddScoped<IFluxoCaixaRepository, FluxoCaixaRepository>();
        }
    }
}
