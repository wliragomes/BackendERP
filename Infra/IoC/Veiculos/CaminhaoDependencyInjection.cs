using Application.Interfaces.Queries;
using Application.Interfaces.Veiculos;
using Application.Services.Veiculos;
using Domain.Commands.Caminhoes;
using Domain.Commands.Caminhoes.Adicionar;
using Domain.Commands.Caminhoes.Atualizar;
using Domain.Commands.Caminhoes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Caminhoes;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Caminhoes
{
    public static class CaminhaoDependencyInjection
    {
        public static void AddCaminhaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCaminhaoCommand, FormularioResponse<AdicionarCaminhaoCommand>>, AdicionarCaminhaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarCaminhaoCommand>, AdicionarCaminhaoCommandValidation>();
            services.AddTransient<IValidator<CaminhaoCommand<AdicionarCaminhaoCommand>>, CaminhaoCommandValidation<AdicionarCaminhaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCaminhaoCommand, FormularioResponse<AtualizarCaminhaoCommand>>, AtualizarCaminhaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarCaminhaoCommand>, AtualizarCaminhaoCommandValidation>();
            services.AddTransient<IValidator<CaminhaoCommand<AtualizarCaminhaoCommand>>, CaminhaoCommandValidation<AtualizarCaminhaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCaminhaoCommand, List<FormularioResponse<ExcluirCaminhaoCommand>>>, ExcluirCaminhaoCommandHandler>();

            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IVeiculoQuery, VeiculoQuery>();
            services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();
        }
    }
}
