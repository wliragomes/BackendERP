using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.TiposProdutos.Adicionar;
using Domain.Commands.Produtos.TiposProdutos;
using Domain.Commands.Produtos.TiposProdutos.Atualizar;
using Domain.Commands.Produtos.TiposProdutos.Excluir;

namespace Infra.IoC.Produtos
{
    public static class TipoProdutoDependencyInjection
    {
        public static void AddTipoProdutoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarTipoProdutoCommand, FormularioResponse<AdicionarTipoProdutoCommand>>, AdicionarTipoProdutoCommandHandler>();
            services.AddTransient<IValidator<AdicionarTipoProdutoCommand>, AdicionarTipoProdutoCommandValidation>();
            services.AddTransient<IValidator<TipoProdutoCommand<AdicionarTipoProdutoCommand>>, TipoProdutoCommandValidation<AdicionarTipoProdutoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarTipoProdutoCommand, FormularioResponse<AtualizarTipoProdutoCommand>>, AtualizarTipoProdutoCommandHandler>();
            services.AddTransient<IValidator<AtualizarTipoProdutoCommand>, AtualizarTipoProdutoCommandValidation>();
            services.AddTransient<IValidator<TipoProdutoCommand<AtualizarTipoProdutoCommand>>, TipoProdutoCommandValidation<AtualizarTipoProdutoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirTipoProdutoCommand, List<FormularioResponse<ExcluirTipoProdutoCommand>>>, ExcluirTipoProdutoCommandHandler>();

            services.AddScoped<ITipoProdutoRepository, TipoProdutoRepository>();
        }
    }
}
