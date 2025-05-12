using Application.Interfaces.Obras;
using Application.Interfaces.Queries;
using Application.Services.Obras;
using Domain.Commands.ObrasProjetos;
using Domain.Commands.ObrasProjetos.Adicionar;
using Domain.Commands.ObrasProjetos.Atualizar;
using Domain.Commands.ObrasProjetos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.ObraFases;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.ObrasProjetos
{
    public static class ObraProjetoDependencyInjection
    {
        public static void AddObraProjetoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarObraProjetoCommand, FormularioResponse<AdicionarObraProjetoCommand>>, AdicionarObraProjetoCommandHandler>();
            services.AddTransient<IValidator<AdicionarObraProjetoCommand>, AdicionarObraProjetoCommandValidation>();
            services.AddTransient<IValidator<ObraProjetoCommand<AdicionarObraProjetoCommand>>, ObraProjetoCommandValidation<AdicionarObraProjetoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarObraProjetoCommand, FormularioResponse<AtualizarObraProjetoCommand>>, AtualizarObraProjetoCommandHandler>();
            services.AddTransient<IValidator<AtualizarObraProjetoCommand>, AtualizarObraProjetoCommandValidation>();
            services.AddTransient<IValidator<ObraProjetoCommand<AtualizarObraProjetoCommand>>, ObraProjetoCommandValidation<AtualizarObraProjetoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirObraProjetoCommand, List<FormularioResponse<ExcluirObraProjetoCommand>>>, ExcluirObraProjetoCommandHandler>();

            services.AddScoped<IObraService, ObraService>();
            services.AddScoped<IObraQuery, ObraQuery>();
            services.AddScoped<IObraProjetoRepository, ObraProjetoRepository>();
        }
    }
}
