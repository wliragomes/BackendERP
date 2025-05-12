using Domain.Commands.Operacoes;
using Domain.Commands.Operacoes.Adicionar;
using Domain.Commands.Operacoes.Atualizar;
using Domain.Commands.Operacoes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Operacoes
{
    public static class OperacaoDependencyInjection
    {
        public static void AddOperacaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarOperacaoCommand, FormularioResponse<AdicionarOperacaoCommand>>, AdicionarOperacaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarOperacaoCommand>, AdicionarOperacaoCommandValidation>();
            services.AddTransient<IValidator<OperacaoCommand<AdicionarOperacaoCommand>>, OperacaoCommandValidation<AdicionarOperacaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarOperacaoCommand, FormularioResponse<AtualizarOperacaoCommand>>, AtualizarOperacaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarOperacaoCommand>, AtualizarOperacaoCommandValidation>();
            services.AddTransient<IValidator<OperacaoCommand<AtualizarOperacaoCommand>>, OperacaoCommandValidation<AtualizarOperacaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirOperacaoCommand, List<FormularioResponse<ExcluirOperacaoCommand>>>, ExcluirOperacaoCommandHandler>();

            services.AddScoped<IOperacaoRepository, OperacaoRepository>();
        }
    }
}
