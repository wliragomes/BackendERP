using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.Subgrupos.Adicionar;
using Domain.Commands.Produtos.Subgrupos;
using Domain.Commands.Produtos.Subgrupos.Atualizar;
using Domain.Commands.Produtos.Subgrupos.Excluir;
using Infra.Repositories;

namespace Infra.IoC.Produtos
{
    public static class SubgrupoDependencyInjection
    {
        public static void AddSubgrupoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarSubgrupoCommand, FormularioResponse<AdicionarSubgrupoCommand>>, AdicionarSubgrupoCommandHandler>();
            services.AddTransient<IValidator<AdicionarSubgrupoCommand>, AdicionarSubgrupoCommandValidation>();
            services.AddTransient<IValidator<SubgrupoCommand<AdicionarSubgrupoCommand>>, SubgrupoCommandValidation<AdicionarSubgrupoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarSubgrupoCommand, FormularioResponse<AtualizarSubgrupoCommand>>, AtualizarSubgrupoCommandHandler>();
            services.AddTransient<IValidator<AtualizarSubgrupoCommand>, AtualizarSubgrupoCommandValidation>();
            services.AddTransient<IValidator<SubgrupoCommand<AtualizarSubgrupoCommand>>, SubgrupoCommandValidation<AtualizarSubgrupoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirSubgrupoCommand, List<FormularioResponse<ExcluirSubgrupoCommand>>>, ExcluirSubgrupoCommandHandler>();

            services.AddScoped<ISubgrupoRepository, SubgrupoRepository>();
        }
    }
}
