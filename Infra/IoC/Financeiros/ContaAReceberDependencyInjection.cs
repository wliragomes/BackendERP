using Domain.Commands.ContasAReceber;
using Domain.Commands.ContasAReceber.Adicionar;
using Domain.Commands.ContasAReceber.Atualizar;
using Domain.Commands.ContasAReceber.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.ContasAReceber
{
    public static class ContaAReceberDependencyInjection
    {
        public static void AddContaAReceberDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarContaAReceberCommand, FormularioResponse<AdicionarContaAReceberCommand>>, AdicionarContaAReceberCommandHandler>();
            services.AddTransient<IValidator<AdicionarContaAReceberCommand>, AdicionarContaAReceberCommandValidation>();
            services.AddTransient<IValidator<ContaAReceberCommand<AdicionarContaAReceberCommand>>, ContaAReceberCommandValidation<AdicionarContaAReceberCommand>>();

            services.AddScoped<IRequestHandler<AtualizarContaAReceberCommand, FormularioResponse<AtualizarContaAReceberCommand>>, AtualizarContaAReceberCommandHandler>();
            services.AddTransient<IValidator<AtualizarContaAReceberCommand>, AtualizarContaAReceberCommandValidation>();
            services.AddTransient<IValidator<ContaAReceberCommand<AtualizarContaAReceberCommand>>, ContaAReceberCommandValidation<AtualizarContaAReceberCommand>>();

            services.AddScoped<IRequestHandler<ExcluirContaAReceberCommand, List<FormularioResponse<ExcluirContaAReceberCommand>>>, ExcluirContaAReceberCommandHandler>();

            services.AddScoped<IContaAReceberRepository, ContaAReceberRepository>();
        }
    }
}
