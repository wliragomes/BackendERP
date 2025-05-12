using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.SetoresProdutos.Adicionar;
using Domain.Commands.Produtos.SetoresProdutos;
using Domain.Commands.Produtos.SetoresProdutos.Atualizar;
using Domain.Commands.Produtos.SetoresProdutos.Excluir;

namespace Infra.IoC.Produtos
{
    public static class SetorProdutoDependencyInjection
    {
        public static void AddSetorProdutoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarSetorProdutoCommand, FormularioResponse<AdicionarSetorProdutoCommand>>, AdicionarSetorProdutoCommandHandler>();
            services.AddTransient<IValidator<AdicionarSetorProdutoCommand>, AdicionarSetorProdutoCommandValidation>();
            services.AddTransient<IValidator<SetorProdutoCommand<AdicionarSetorProdutoCommand>>, SetorProdutoCommandValidation<AdicionarSetorProdutoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarSetorProdutoCommand, FormularioResponse<AtualizarSetorProdutoCommand>>, AtualizarSetorProdutoCommandHandler>();
            services.AddTransient<IValidator<AtualizarSetorProdutoCommand>, AtualizarSetorProdutoCommandValidation>();
            services.AddTransient<IValidator<SetorProdutoCommand<AtualizarSetorProdutoCommand>>, SetorProdutoCommandValidation<AtualizarSetorProdutoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirSetorProdutoCommand, List<FormularioResponse<ExcluirSetorProdutoCommand>>>, ExcluirSetorProdutoCommandHandler>();

            services.AddScoped<ISetorProdutoRepository, SetorProdutoRepository>();
        }
    }
}
