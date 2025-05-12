using Application.Interfaces.CodigoDDIs;
using Application.Interfaces.Queries;
using Application.Services.CodigoDDIs;
using Domain.Commands.CodigoDDIs;
using Domain.Commands.CodigoDDIs.Adicionar;
using Domain.Commands.CodigoDDIs.Atualizar;
using Domain.Commands.CodigoDDIs.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.CodigoDDIs;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.CodigoDDIs
{
    public static class CodigoDDIDependencyInjection
    {
        public static void AddCodigoDDIDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCodigoDDICommand, FormularioResponse<AdicionarCodigoDDICommand>>, AdicionarCodigoDDICommandHandler>();
            services.AddTransient<IValidator<AdicionarCodigoDDICommand>, AdicionarCodigoDDICommandValidation>();
            services.AddTransient<IValidator<CodigoDDICommand<AdicionarCodigoDDICommand>>, CodigoDDICommandValidation<AdicionarCodigoDDICommand>>();

            services.AddScoped<IRequestHandler<AtualizarCodigoDDICommand, FormularioResponse<AtualizarCodigoDDICommand>>, AtualizarCodigoDDICommandHandler>();
            services.AddTransient<IValidator<AtualizarCodigoDDICommand>, AtualizarCodigoDDICommandValidation>();
            services.AddTransient<IValidator<CodigoDDICommand<AtualizarCodigoDDICommand>>, CodigoDDICommandValidation<AtualizarCodigoDDICommand>>();

            services.AddScoped<IRequestHandler<ExcluirCodigoDDICommand, List<FormularioResponse<ExcluirCodigoDDICommand>>>, ExcluirCodigoDDICommandHandler>();

            services.AddScoped<ICodigoDDIService, CodigoDDIService>();
            services.AddScoped<ICodigoDDIQuery, CodigoDDIQuery>();
            services.AddScoped<ICodigoDDIRepository, CodigoDDIRepository>();
        }
    }
}
