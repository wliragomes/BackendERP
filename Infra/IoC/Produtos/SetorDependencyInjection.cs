using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.Setores.Adicionar;
using Domain.Commands.Produtos.Setores;
using Domain.Commands.Produtos.Setores.Atualizar;
using Domain.Commands.Produtos.Setores.Excluir;
using Infra.Repositories;

namespace Infra.IoC.Produtos
{
    public static class SetorDependencyInjection
    {
        public static void AddSetorDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarSetorCommand, FormularioResponse<AdicionarSetorCommand>>, AdicionarSetorCommandHandler>();
            services.AddTransient<IValidator<AdicionarSetorCommand>, AdicionarSetorCommandValidation>();
            services.AddTransient<IValidator<SetorCommand<AdicionarSetorCommand>>, SetorCommandValidation<AdicionarSetorCommand>>();

            services.AddScoped<IRequestHandler<AtualizarSetorCommand, FormularioResponse<AtualizarSetorCommand>>, AtualizarSetorCommandHandler>();
            services.AddTransient<IValidator<AtualizarSetorCommand>, AtualizarSetorCommandValidation>();
            services.AddTransient<IValidator<SetorCommand<AtualizarSetorCommand>>, SetorCommandValidation<AtualizarSetorCommand>>();

            services.AddScoped<IRequestHandler<ExcluirSetorCommand, List<FormularioResponse<ExcluirSetorCommand>>>, ExcluirSetorCommandHandler>();

            services.AddScoped<ISetorRepository, SetorRepository>();
        }
    }
}