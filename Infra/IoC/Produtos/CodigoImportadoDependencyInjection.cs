using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.CodigosImportacoes.Adicionar;
using Domain.Commands.Produtos.CodigosImportacoes.Atualizar;
using Domain.Commands.Produtos.CodigosImportacoes.Excluir;
using Infra.Repositories;
using Domain.Commands.Produtos.CodigosImportacoes;

namespace Infra.IoC.Produtos
{
    public static class CodigoImportacaoDependencyInjection
    {
        public static void AddCodigoImportacaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCodigoImportacaoCommand, FormularioResponse<AdicionarCodigoImportacaoCommand>>, AdicionarCodigoImportacaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarCodigoImportacaoCommand>, AdicionarCodigoImportacaoCommandValidation>();
            services.AddTransient<IValidator<CodigoImportacaoCommand<AdicionarCodigoImportacaoCommand>>, CodigoImportacaoCommandValidation<AdicionarCodigoImportacaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCodigoImportacaoCommand, FormularioResponse<AtualizarCodigoImportacaoCommand>>, AtualizarCodigoImportacaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarCodigoImportacaoCommand>, AtualizarCodigoImportacaoCommandValidation>();
            services.AddTransient<IValidator<CodigoImportacaoCommand<AtualizarCodigoImportacaoCommand>>, CodigoImportacaoCommandValidation<AtualizarCodigoImportacaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCodigoImportacaoCommand, List<FormularioResponse<ExcluirCodigoImportacaoCommand>>>, ExcluirCodigoImportacaoCommandHandler>();

            services.AddScoped<ICodigoImportacaoRepository, CodigoImportacaoRepository>();
        }
    }
}
