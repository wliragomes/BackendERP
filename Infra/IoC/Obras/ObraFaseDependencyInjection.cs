using Application.Interfaces.Obras;
using Application.Interfaces.Queries;
using Application.Services.Obras;
using Domain.Commands.ObraFases;
using Domain.Commands.ObraFases.Adicionar;
using Domain.Commands.ObraFases.Atualizar;
using Domain.Commands.ObraFases.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.ObraFases;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.ObraFases
{
    public static class ObraFaseDependencyInjection
    {
        public static void AddObraFaseDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarObraFaseCommand, FormularioResponse<AdicionarObraFaseCommand>>, AdicionarObraFaseCommandHandler>();
            services.AddTransient<IValidator<AdicionarObraFaseCommand>, AdicionarObraFaseCommandValidation>();
            services.AddTransient<IValidator<ObraFaseCommand<AdicionarObraFaseCommand>>, ObraFaseCommandValidation<AdicionarObraFaseCommand>>();

            services.AddScoped<IRequestHandler<AtualizarObraFaseCommand, FormularioResponse<AtualizarObraFaseCommand>>, AtualizarObraFaseCommandHandler>();
            services.AddTransient<IValidator<AtualizarObraFaseCommand>, AtualizarObraFaseCommandValidation>();
            services.AddTransient<IValidator<ObraFaseCommand<AtualizarObraFaseCommand>>, ObraFaseCommandValidation<AtualizarObraFaseCommand>>();

            services.AddScoped<IRequestHandler<ExcluirObraFaseCommand, List<FormularioResponse<ExcluirObraFaseCommand>>>, ExcluirObraFaseCommandHandler>();

            services.AddScoped<IObraService, ObraService>();
            services.AddScoped<IObraQuery, ObraQuery>();
            services.AddScoped<IObraFaseRepository, ObraFaseRepository>();
        }
    }
}
