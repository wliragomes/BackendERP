using Application.Interfaces.Representantes;
using Application.Interfaces.Queries;
using Application.Services.Representantes;
using Domain.Commands.Representantes;
using Domain.Commands.Representantes.Adicionar;
using Domain.Commands.Representantes.Atualizar;
using Domain.Commands.Representantes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Representantes;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Representantes
{
    public static class RepresentanteDependencyInjection
    {
        public static void AddRepresentanteDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarRepresentanteCommand, FormularioResponse<AdicionarRepresentanteCommand>>, AdicionarRepresentanteCommandHandler>();
            services.AddTransient<IValidator<AdicionarRepresentanteCommand>, AdicionarRepresentanteCommandValidation>();
            services.AddTransient<IValidator<RepresentanteCommand<AdicionarRepresentanteCommand>>, RepresentanteCommandValidation<AdicionarRepresentanteCommand>>();

            services.AddScoped<IRequestHandler<AtualizarRepresentanteCommand, FormularioResponse<AtualizarRepresentanteCommand>>, AtualizarRepresentanteCommandHandler>();
            services.AddTransient<IValidator<AtualizarRepresentanteCommand>, AtualizarRepresentanteCommandValidation>();
            services.AddTransient<IValidator<RepresentanteCommand<AtualizarRepresentanteCommand>>, RepresentanteCommandValidation<AtualizarRepresentanteCommand>>();

            services.AddScoped<IRequestHandler<ExcluirRepresentanteCommand, List<FormularioResponse<ExcluirRepresentanteCommand>>>, ExcluirRepresentanteCommandHandler>();

            services.AddScoped<IRepresentanteService, RepresentanteService>();
            services.AddScoped<IRepresentanteQuery, RepresentanteQuery>();
            services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
        }
    }
}
