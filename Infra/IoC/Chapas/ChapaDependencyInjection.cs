using Application.Interfaces.Chapas;
using Application.Interfaces.Queries;
using Application.Services.Chapas;
using Domain.Commands.Chapas;
using Domain.Commands.Chapas.Adicionar;
using Domain.Commands.Chapas.Atualizar;
using Domain.Commands.Chapas.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Chapas;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Chapas
{
    public static class ChapaDependencyInjection
    {
        public static void AddChapaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarChapaCommand, FormularioResponse<AdicionarChapaCommand>>, AdicionarChapaCommandHandler>();
            services.AddTransient<IValidator<AdicionarChapaCommand>, AdicionarChapaCommandValidation>();
            services.AddTransient<IValidator<ChapaCommand<AdicionarChapaCommand>>, ChapaCommandValidation<AdicionarChapaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarChapaCommand, FormularioResponse<AtualizarChapaCommand>>, AtualizarChapaCommandHandler>();
            services.AddTransient<IValidator<AtualizarChapaCommand>, AtualizarChapaCommandValidation>();
            services.AddTransient<IValidator<ChapaCommand<AtualizarChapaCommand>>, ChapaCommandValidation<AtualizarChapaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirChapaCommand, List<FormularioResponse<ExcluirChapaCommand>>>, ExcluirChapaCommandHandler>();

            services.AddScoped<IChapaService, ChapaService>();
            services.AddScoped<IChapaQuery, ChapaQuery>();
            services.AddScoped<IChapaRepository, ChapaRepository>();
        }
    }
}
