using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.TiposPrecos.Adicionar;
using Domain.Commands.Produtos.TiposPrecos;
using Domain.Commands.Produtos.TiposPrecos.Atualizar;
using Domain.Commands.Produtos.TiposPrecos.Excluir;

namespace Infra.IoC.Produtos
{
    public static class TipoPrecoDependencyInjection
    {
        public static void AddTipoPrecoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarTipoPrecoCommand, FormularioResponse<AdicionarTipoPrecoCommand>>, AdicionarTipoPrecoCommandHandler>();
            services.AddTransient<IValidator<AdicionarTipoPrecoCommand>, AdicionarTipoPrecoCommandValidation>();
            services.AddTransient<IValidator<TipoPrecoCommand<AdicionarTipoPrecoCommand>>, TipoPrecoCommandValidation<AdicionarTipoPrecoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarTipoPrecoCommand, FormularioResponse<AtualizarTipoPrecoCommand>>, AtualizarTipoPrecoCommandHandler>();
            _ = services.AddTransient<IValidator<AtualizarTipoPrecoCommand>, AtualizarTipoPrecoCommandValidation>();
            services.AddTransient<IValidator<TipoPrecoCommand<AtualizarTipoPrecoCommand>>, TipoPrecoCommandValidation<AtualizarTipoPrecoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirTipoPrecoCommand, List<FormularioResponse<ExcluirTipoPrecoCommand>>>, ExcluirTipoPrecoCommandHandler>();

            services.AddScoped<ITipoPrecoRepository, TipoPrecoRepository>();
        }
    }
}
