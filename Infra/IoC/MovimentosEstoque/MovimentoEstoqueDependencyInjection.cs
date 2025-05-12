using Application.Interfaces.MovimentosEstoque;
using Application.Interfaces.Queries;
using Application.Services.MovimentosEstoque;
using Domain.Commands.MovimentosEstoque;
using Domain.Commands.MovimentosEstoque.Adicionar;
using Domain.Commands.MovimentosEstoque.Atualizar;
using Domain.Commands.MovimentosEstoque.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.MovimentosEstoque;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.MovimentosEstoque
{
    public static class MovimentoEstoqueDependencyInjection
    {
        public static void AddMovimentoEstoqueDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarMovimentoEstoqueCommand, FormularioResponse<AdicionarMovimentoEstoqueCommand>>, AdicionarMovimentoEstoqueCommandHandler>();
            services.AddTransient<IValidator<AdicionarMovimentoEstoqueCommand>, AdicionarMovimentoEstoqueCommandValidation>();
            services.AddTransient<IValidator<MovimentoEstoqueCommand<AdicionarMovimentoEstoqueCommand>>, MovimentoEstoqueCommandValidation<AdicionarMovimentoEstoqueCommand>>();

            services.AddScoped<IRequestHandler<AtualizarMovimentoEstoqueCommand, FormularioResponse<AtualizarMovimentoEstoqueCommand>>, AtualizarMovimentoEstoqueCommandHandler>();
            services.AddTransient<IValidator<AtualizarMovimentoEstoqueCommand>, AtualizarMovimentoEstoqueCommandValidation>();
            services.AddTransient<IValidator<MovimentoEstoqueCommand<AtualizarMovimentoEstoqueCommand>>, MovimentoEstoqueCommandValidation<AtualizarMovimentoEstoqueCommand>>();

            services.AddScoped<IRequestHandler<ExcluirMovimentoEstoqueCommand, List<FormularioResponse<ExcluirMovimentoEstoqueCommand>>>, ExcluirMovimentoEstoqueCommandHandler>();

            services.AddScoped<IMovimentoEstoqueService, MovimentoEstoqueService>();
            services.AddScoped<IMovimentoEstoqueQuery, MovimentoEstoqueQuery>();
            services.AddScoped<IMovimentoEstoqueRepository, MovimentoEstoqueRepository>();
        }
    }
}
