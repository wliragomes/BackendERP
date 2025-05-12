using Application.Interfaces.Queries;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Produtos;
using Application.Services.Produtos;
using Infra.Queries.Produtos;
using Domain.Commands.Produtos.Adicionar;
using SharedKernel.SharedObjects;
using MediatR;
using FluentValidation;
using Domain.Commands.Produtos;
using Domain.Commands.Produtos.Atualizar;
using Domain.Commands.Produtos.Excluir;
using Infra.Repositories;
using Domain.Interfaces.Repositories;

namespace Infra.IoC.Produtos
{
    public static class ProdutoDependencyInjection
    {
        public static void AddProdutoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarProdutoCommand, FormularioResponse<AdicionarProdutoCommand>>, AdicionarProdutoCommandHandler>();
            services.AddTransient<IValidator<AdicionarProdutoCommand>, AdicionarProdutoCommandValidation>();
            services.AddTransient<IValidator<ProdutoCommand<AdicionarProdutoCommand>>, ProdutoCommandValidation<AdicionarProdutoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarProdutoCommand, FormularioResponse<AtualizarProdutoCommand>>, AtualizarProdutoCommandHandler>();
            services.AddTransient<IValidator<AtualizarProdutoCommand>, AtualizarProdutoCommandValidation>();
            services.AddTransient<IValidator<ProdutoCommand<AtualizarProdutoCommand>>, ProdutoCommandValidation<AtualizarProdutoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirProdutoCommand, List<FormularioResponse<ExcluirProdutoCommand>>>, ExcluirProdutoCommandHandler>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoQuery, ProdutoQuery>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
