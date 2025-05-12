using Domain.Commands.ContasAPagarPago;
using Domain.Commands.ContasAPagarPago.Adicionar;
using Domain.Commands.ContasAPagarPago.Atualizar;
using Domain.Commands.ContasAPagarPago.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.ContasAPagarPago
{
    public static class ContaAPagarPagoDependencyInjection
    {
        public static void AddContaAPagarPagoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarContaAPagarPagoCommand, FormularioResponse<AdicionarContaAPagarPagoCommand>>, AdicionarContaAPagarPagoCommandHandler>();
            services.AddTransient<IValidator<AdicionarContaAPagarPagoCommand>, AdicionarContaAPagarPagoCommandValidation>();
            services.AddTransient<IValidator<ContaAPagarPagoCommand<AdicionarContaAPagarPagoCommand>>, ContaAPagarPagoCommandValidation<AdicionarContaAPagarPagoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarContaAPagarPagoCommand, FormularioResponse<AtualizarContaAPagarPagoCommand>>, AtualizarContaAPagarPagoCommandHandler>();
            services.AddTransient<IValidator<AtualizarContaAPagarPagoCommand>, AtualizarContaAPagarPagoCommandValidation>();
            services.AddTransient<IValidator<ContaAPagarPagoCommand<AtualizarContaAPagarPagoCommand>>, ContaAPagarPagoCommandValidation<AtualizarContaAPagarPagoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirContaAPagarPagoCommand, List<FormularioResponse<ExcluirContaAPagarPagoCommand>>>, ExcluirContaAPagarPagoCommandHandler>();

            services.AddScoped<IContaAPagarPagoRepository, ContaAPagarPagoRepository>();
        }
    }
}
