using Application.Interfaces.FaturaTemporarias;
using Application.Interfaces.Queries;
using Application.Services.FaturaTemporarias;
using Domain.Commands.FaturaTemporarias;
using Domain.Commands.FaturaTemporarias.Adicionar;
using Domain.Commands.FaturaTemporarias.Excluir;
using Domain.Commands.OrdensFabricacoes.Adicionar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.OrdensFabricacoes;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.OrdensFabricacoes
{
    public static class FaturaTemporariaDependencyInjection
    {
        public static void AddFaturaTemporariaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarFaturaTemporariaCommand, FormularioResponse<AdicionarFaturaTemporariaCommand>>, AdicionarFaturaTemporariaCommandHandler>();
            services.AddTransient<IValidator<AdicionarFaturaTemporariaCommand>, AdicionarFaturaTemporariaCommandValidation>();
            services.AddTransient<IValidator<FaturaTemporariaCommand<AdicionarFaturaTemporariaCommand>>, FaturaTemporariaCommandValidation<AdicionarFaturaTemporariaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirFaturaTemporariaCommand, List<FormularioResponse<ExcluirFaturaTemporariaCommand>>>, ExcluirFaturaTemporariaCommandHandler>();

            services.AddScoped<IFaturaTemporariaService, FaturaTemporariaService>();
            services.AddScoped<IFaturaTemporariaQuery, FaturaTemporariaQuery>();
            services.AddScoped<IFaturaTemporariaRepository, FaturaTemporariaRepository>();
        }
    }
}
