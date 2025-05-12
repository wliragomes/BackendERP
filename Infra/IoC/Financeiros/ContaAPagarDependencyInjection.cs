using Domain.Commands.ContasAPagar;
using Domain.Commands.ContasAPagar.Adicionar;
using Domain.Commands.ContasAPagar.Atualizar;
using Domain.Commands.ContasAPagar.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.ContasAPagar
{
    public static class ContaAPagarDependencyInjection
    {
        public static void AddContaAPagarDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarContaAPagarCommand, FormularioResponse<AdicionarContaAPagarCommand>>, AdicionarContaAPagarCommandHandler>();
            services.AddTransient<IValidator<AdicionarContaAPagarCommand>, AdicionarContaAPagarCommandValidation>();
            services.AddTransient<IValidator<ContaAPagarCommand<AdicionarContaAPagarCommand>>, ContaAPagarCommandValidation<AdicionarContaAPagarCommand>>();

            services.AddScoped<IRequestHandler<AtualizarContaAPagarCommand, FormularioResponse<AtualizarContaAPagarCommand>>, AtualizarContaAPagarCommandHandler>();
            services.AddTransient<IValidator<AtualizarContaAPagarCommand>, AtualizarContaAPagarCommandValidation>();
            services.AddTransient<IValidator<ContaAPagarCommand<AtualizarContaAPagarCommand>>, ContaAPagarCommandValidation<AtualizarContaAPagarCommand>>();

            services.AddScoped<IRequestHandler<ExcluirContaAPagarCommand, List<FormularioResponse<ExcluirContaAPagarCommand>>>, ExcluirContaAPagarCommandHandler>();

            services.AddScoped<IContaAPagarRepository, ContaAPagarRepository>();
        }
    }
}
