using Application.Interfaces.MotivoReposicaos;
using Application.Interfaces.Queries;
using Application.Services.MotivoReposições;
using Domain.Commands.MotivoReposições;
using Domain.Commands.MotivoReposições.Adicionar;
using Domain.Commands.MotivoReposições.Atualizar;
using Domain.Commands.MotivoReposições.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.MotivoReposições;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.MotivoReposições
{
    public static class MotivoReposicaoDependencyInjection
    {
        public static void AddMotivoReposicaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarMotivoReposicaoCommand, FormularioResponse<AdicionarMotivoReposicaoCommand>>, AdicionarMotivoReposicaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarMotivoReposicaoCommand>, AdicionarMotivoReposicaoCommandValidation>();
            services.AddTransient<IValidator<MotivoReposicaoCommand<AdicionarMotivoReposicaoCommand>>, MotivoReposicaoCommandValidation<AdicionarMotivoReposicaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarMotivoReposicaoCommand, FormularioResponse<AtualizarMotivoReposicaoCommand>>, AtualizarMotivoReposicaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarMotivoReposicaoCommand>, AtualizarMotivoReposicaoCommandValidation>();
            services.AddTransient<IValidator<MotivoReposicaoCommand<AtualizarMotivoReposicaoCommand>>, MotivoReposicaoCommandValidation<AtualizarMotivoReposicaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirMotivoReposicaoCommand, List<FormularioResponse<ExcluirMotivoReposicaoCommand>>>, ExcluirMotivoReposicaoCommandHandler>();

            services.AddScoped<IMotivoReposicaoService, MotivoReposicaoService>();
            services.AddScoped<IMotivoReposicaoQuery, MotivoReposicaoQuery>();
            services.AddScoped<IMotivoReposicaoRepository, MotivoReposicaoRepository>();
        }
    }
}
