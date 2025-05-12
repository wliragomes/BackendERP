using Application.Interfaces.Estados;
using Application.Interfaces.Queries;
using Domain.Commands.Estados.Adicionar;
using Domain.Commands.Estados.Atualizar;
using Domain.Commands.Estados.Excluir;
using Domain.Commands.Estados;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Estados;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Application.Services.Estados;

namespace Infra.IoC.Estados
{
    public static class EstadoDependencyInjection
    {
        public static void AddEstadoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarEstadoCommand, FormularioResponse<AdicionarEstadoCommand>>, AdicionarEstadoCommandHandler>();
            services.AddTransient<IValidator<AdicionarEstadoCommand>, AdicionarEstadoCommandValidation>();
            services.AddTransient<IValidator<EstadoCommand<AdicionarEstadoCommand>>, EstadoCommandValidation<AdicionarEstadoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarEstadoCommand, FormularioResponse<AtualizarEstadoCommand>>, AtualizarEstadoCommandHandler>();
            services.AddTransient<IValidator<AtualizarEstadoCommand>, AtualizarEstadoCommandValidation>();
            services.AddTransient<IValidator<EstadoCommand<AtualizarEstadoCommand>>, EstadoCommandValidation<AtualizarEstadoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirEstadoCommand, List<FormularioResponse<ExcluirEstadoCommand>>>, ExcluirEstadoCommandHandler>();

            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IEstadoQuery, EstadoQuery>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
        }
    }
}
