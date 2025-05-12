using Application.Interfaces.Queries;
using Application.Interfaces.Vendas;
using Application.Services.Vendas;
using Domain.Commands.TipoFretes;
using Domain.Commands.TipoFretes.Adicionar;
using Domain.Commands.TipoFretes.Atualizar;
using Domain.Commands.TipoFretes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Vendas;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.TiposFretes
{
    public static class TipoFreteDependencyInjection
    {
        public static void AddTipoFreteDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarTipoFreteCommand, FormularioResponse<AdicionarTipoFreteCommand>>, AdicionarTipoFreteCommandHandler>();
            services.AddTransient<IValidator<AdicionarTipoFreteCommand>, AdicionarTipoFreteCommandValidation>();
            services.AddTransient<IValidator<TipoFreteCommand<AdicionarTipoFreteCommand>>, TipoFreteCommandValidation<AdicionarTipoFreteCommand>>();

            services.AddScoped<IRequestHandler<AtualizarTipoFreteCommand, FormularioResponse<AtualizarTipoFreteCommand>>, AtualizarTipoFreteCommandHandler>();
            services.AddTransient<IValidator<AtualizarTipoFreteCommand>, AtualizarTipoFreteCommandValidation>();
            services.AddTransient<IValidator<TipoFreteCommand<AtualizarTipoFreteCommand>>, TipoFreteCommandValidation<AtualizarTipoFreteCommand>>();

            services.AddScoped<IRequestHandler<ExcluirTipoFreteCommand, List<FormularioResponse<ExcluirTipoFreteCommand>>>, ExcluirTipoFreteCommandHandler>();

            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaQuery, VendaQuery>();
            services.AddScoped<ITipoFreteRepository, TipoFreteRepository>();
        }
    }
}
