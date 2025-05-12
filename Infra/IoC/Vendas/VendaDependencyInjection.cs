using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using MediatR;
using FluentValidation;
using Domain.Commands.Vendas.Adicionar;
using Domain.Commands.Vendas;
using Domain.Commands.Vendas.Atualizar;
using Application.Interfaces.Vendas;
using Application.Services.Vendas;
using Application.Interfaces.Queries;
using Infra.Queries.Vendas;
using Domain.Interfaces.Repositories;
using Infra.Repositories;
using Domain.Commands.Vendas.Excluir;
using Domain.Commands.NormasAbnts.Excluir;

namespace Infra.IoC.Vendas
{
    public static class VendaDependencyInjection
    {
        public static void AddVendaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarVendaCommand, FormularioResponse<AdicionarVendaCommand>>, AdicionarVendaCommandHandler>();
            services.AddTransient<IValidator<AdicionarVendaCommand>, AdicionarVendaCommandValidation>();
            services.AddTransient<IValidator<VendaCommand<AdicionarVendaCommand>>, VendaCommandValidation<AdicionarVendaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarVendaCommand, FormularioResponse<AtualizarVendaCommand>>, AtualizarVendaCommandHandler>();
            services.AddTransient<IValidator<AtualizarVendaCommand>, AtualizarVendaCommandValidation>();
            services.AddTransient<IValidator<VendaCommand<AtualizarVendaCommand>>, VendaCommandValidation<AtualizarVendaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirVendaCommand, List<FormularioResponse<ExcluirVendaCommand>>>, ExcluirVendaCommandHandler>();

            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaQuery, VendaQuery>();
            services.AddScoped<IVendaRepository, VendaRepository>();
        }
    }
}
