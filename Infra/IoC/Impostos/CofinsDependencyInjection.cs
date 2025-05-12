
using Domain.Commands.Impostos.Cofinss;
using Domain.Commands.Impostos.Cofinss.Adicionar;
using Domain.Commands.Impostos.Cofinss.Atualizar;
using Domain.Commands.Impostos.Cofinss.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Impostos
{
    public static class CofinsDependencyInjection
    {
        public static void AddCofinsDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCofinsCommand, FormularioResponse<AdicionarCofinsCommand>>, AdicionarCofinsCommandHandler>();
            services.AddTransient<IValidator<AdicionarCofinsCommand>, AdicionarCofinsCommandValidation>();
            services.AddTransient<IValidator<CofinsCommand<AdicionarCofinsCommand>>, CofinsCommandValidation<AdicionarCofinsCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCofinsCommand, FormularioResponse<AtualizarCofinsCommand>>, AtualizarCofinsCommandHandler>();
            services.AddTransient<IValidator<AtualizarCofinsCommand>, AtualizarCofinsCommandValidation>();
            services.AddTransient<IValidator<CofinsCommand<AtualizarCofinsCommand>>, CofinsCommandValidation<AtualizarCofinsCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCofinsCommand, List<FormularioResponse<ExcluirCofinsCommand>>>, ExcluirCofinsCommandHandler>();

            services.AddScoped<ICofinsRepository, CofinsRepository>();

        }
    }
}
