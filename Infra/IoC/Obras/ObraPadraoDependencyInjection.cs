using Application.Interfaces.Obras;
using Application.Interfaces.Queries;
using Application.Services.Obras;
using Domain.Commands.ObrasPadrao;
using Domain.Commands.ObrasPadrao.Adicionar;
using Domain.Commands.ObrasPadrao.Atualizar;
using Domain.Commands.ObrasPadrao.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.ObraFases;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.ObrasPadrao
{
    public static class ObraPadraoDependencyInjection
    {
        public static void AddObraPadraoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarObraPadraoCommand, FormularioResponse<AdicionarObraPadraoCommand>>, AdicionarObraPadraoCommandHandler>();
            services.AddTransient<IValidator<AdicionarObraPadraoCommand>, AdicionarObraPadraoCommandValidation>();
            services.AddTransient<IValidator<ObraPadraoCommand<AdicionarObraPadraoCommand>>, ObraPadraoCommandValidation<AdicionarObraPadraoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarObraPadraoCommand, FormularioResponse<AtualizarObraPadraoCommand>>, AtualizarObraPadraoCommandHandler>();
            services.AddTransient<IValidator<AtualizarObraPadraoCommand>, AtualizarObraPadraoCommandValidation>();
            services.AddTransient<IValidator<ObraPadraoCommand<AtualizarObraPadraoCommand>>, ObraPadraoCommandValidation<AtualizarObraPadraoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirObraPadraoCommand, List<FormularioResponse<ExcluirObraPadraoCommand>>>, ExcluirObraPadraoCommandHandler>();

            services.AddScoped<IObraService, ObraService>();
            services.AddScoped<IObraQuery, ObraQuery>();
            services.AddScoped<IObraPadraoRepository, ObraPadraoRepository>();
        }
    }
}
