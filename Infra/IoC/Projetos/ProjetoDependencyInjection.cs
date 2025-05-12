using Application.Interfaces.Projetos;
using Application.Interfaces.Queries;
using Application.Services.Projetos;
using Domain.Commands.Projetos;
using Domain.Commands.Projetos.Adicionar;
using Domain.Commands.Projetos.Atualizar;
using Domain.Commands.Projetos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Projetos;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Projetos
{
    public static class ProjetoDependencyInjection
    {
        public static void AddProjetoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarProjetoCommand, FormularioResponse<AdicionarProjetoCommand>>, AdicionarProjetoCommandHandler>();
            services.AddTransient<IValidator<AdicionarProjetoCommand>, AdicionarProjetoCommandValidation>();
            services.AddTransient<IValidator<ProjetoCommand<AdicionarProjetoCommand>>, ProjetoCommandValidation<AdicionarProjetoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarProjetoCommand, FormularioResponse<AtualizarProjetoCommand>>, AtualizarProjetoCommandHandler>();
            services.AddTransient<IValidator<AtualizarProjetoCommand>, AtualizarProjetoCommandValidation>();
            services.AddTransient<IValidator<ProjetoCommand<AtualizarProjetoCommand>>, ProjetoCommandValidation<AtualizarProjetoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirProjetoCommand, List<FormularioResponse<ExcluirProjetoCommand>>>, ExcluirProjetoCommandHandler>();

            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IProjetoQuery, ProjetoQuery>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
        }
    }
}
