using Domain.Commands.Classificacoes;
using Domain.Commands.Classificacoes;
using Domain.Commands.Classificacoes.Adicionar;
using Domain.Commands.Classificacoes.Atualizar;
using Domain.Commands.Classificacoes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Classificacoes
{
    public static class ClassificacaoDependencyInjection
    {
        public static void AddClassificacaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarClassificacaoCommand, FormularioResponse<AdicionarClassificacaoCommand>>, AdicionarClassificacaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarClassificacaoCommand>, AdicionarClassificacaoCommandValidation>();
            services.AddTransient<IValidator<ClassificacaoCommand<AdicionarClassificacaoCommand>>, ClassificacaoCommandValidation<AdicionarClassificacaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarClassificacaoCommand, FormularioResponse<AtualizarClassificacaoCommand>>, AtualizarClassificacaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarClassificacaoCommand>, AtualizarClassificacaoCommandValidation>();
            services.AddTransient<IValidator<ClassificacaoCommand<AtualizarClassificacaoCommand>>, ClassificacaoCommandValidation<AtualizarClassificacaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirClassificacaoCommand, List<FormularioResponse<ExcluirClassificacaoCommand>>>, ExcluirClassificacaoCommandHandler>();

            services.AddScoped<IClassificacaoRepository, ClassificacaoRepository>();
        }
    }
}
