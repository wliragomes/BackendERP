using Domain.Commands.Produtos.Grupos.Adicionar;
using Domain.Commands.Produtos.Grupos.Atualizar;
using Domain.Commands.Produtos.Grupos.Excluir;
using Domain.Commands.Produtos.Grupos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Produtos
{
    public static class GrupoDependencyInjection
    {
        public static void AddGrupoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarGrupoCommand, FormularioResponse<AdicionarGrupoCommand>>, AdicionarGrupoCommandHandler>();
            services.AddTransient<IValidator<AdicionarGrupoCommand>, AdicionarGrupoCommandValidation>();
            services.AddTransient<IValidator<GrupoCommand<AdicionarGrupoCommand>>, GrupoCommandValidation<AdicionarGrupoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarGrupoCommand, FormularioResponse<AtualizarGrupoCommand>>, AtualizarGrupoCommandHandler>();
            services.AddTransient<IValidator<AtualizarGrupoCommand>, AtualizarGrupoCommandValidation>();
            services.AddTransient<IValidator<GrupoCommand<AtualizarGrupoCommand>>, GrupoCommandValidation<AtualizarGrupoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirGrupoCommand, List<FormularioResponse<ExcluirGrupoCommand>>>, ExcluirGrupoCommandHandler>();

            services.AddScoped<IGrupoRepository, GrupoRepository>();
        }
    }
}
