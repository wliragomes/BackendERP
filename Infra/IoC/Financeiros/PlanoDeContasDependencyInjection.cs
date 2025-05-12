using Domain.Commands.PlanosDeContas;
using Domain.Commands.PlanosDeContas.Adicionar;
using Domain.Commands.PlanosDeContas.Atualizar;
using Domain.Commands.PlanosDeContas.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.PlanosDeContas
{
    public static class PlanoDeContasDependencyInjection
    {
        public static void AddPlanoDeContasDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarPlanoDeContasCommand, FormularioResponse<AdicionarPlanoDeContasCommand>>, AdicionarPlanoDeContasCommandHandler>();
            services.AddTransient<IValidator<AdicionarPlanoDeContasCommand>, AdicionarPlanoDeContasCommandValidation>();
            services.AddTransient<IValidator<PlanoDeContasCommand<AdicionarPlanoDeContasCommand>>, PlanoDeContasCommandValidation<AdicionarPlanoDeContasCommand>>();

            services.AddScoped<IRequestHandler<AtualizarPlanoDeContasCommand, FormularioResponse<AtualizarPlanoDeContasCommand>>, AtualizarPlanoDeContasCommandHandler>();
            services.AddTransient<IValidator<AtualizarPlanoDeContasCommand>, AtualizarPlanoDeContasCommandValidation>();
            services.AddTransient<IValidator<PlanoDeContasCommand<AtualizarPlanoDeContasCommand>>, PlanoDeContasCommandValidation<AtualizarPlanoDeContasCommand>>();

            services.AddScoped<IRequestHandler<ExcluirPlanoDeContasCommand, List<FormularioResponse<ExcluirPlanoDeContasCommand>>>, ExcluirPlanoDeContasCommandHandler>();

            services.AddScoped<IPlanoDeContasRepository, PlanoDeContasRepository>();
        }
    }
}
