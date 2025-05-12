using Application.Interfaces.NormasAbnts;
using Application.Interfaces.Queries;
using Application.Services.NormasAbtns;
using Domain.Commands.NormasAbnts;
using Domain.Commands.NormasAbnts.Adicionar;
using Domain.Commands.NormasAbnts.Atualizar;
using Domain.Commands.NormasAbnts.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.NormasAbnts;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.NormasAbnts
{
    public static class NormaAbntDependencyInjection
    {
        public static void AddNormaAbntDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarNormaAbntCommand, FormularioResponse<AdicionarNormaAbntCommand>>, AdicionarNormaAbntCommandHandler>();
            services.AddTransient<IValidator<AdicionarNormaAbntCommand>, AdicionarNormaAbntCommandValidation>();
            services.AddTransient<IValidator<NormaAbntCommand<AdicionarNormaAbntCommand>>, NormaAbntCommandValidation<AdicionarNormaAbntCommand>>();

            services.AddScoped<IRequestHandler<AtualizarNormaAbntCommand, FormularioResponse<AtualizarNormaAbntCommand>>, AtualizarNormaAbntCommandHandler>();
            services.AddTransient<IValidator<AtualizarNormaAbntCommand>, AtualizarNormaAbntCommandValidation>();
            services.AddTransient<IValidator<NormaAbntCommand<AtualizarNormaAbntCommand>>, NormaAbntCommandValidation<AtualizarNormaAbntCommand>>();

            services.AddScoped<IRequestHandler<ExcluirNormaAbntCommand, List<FormularioResponse<ExcluirNormaAbntCommand>>>, ExcluirNormaAbntCommandHandler>();

            services.AddScoped<INormaAbntService, NormaAbntService>();
            services.AddScoped<INormaAbntQuery, NormaAbntQuery>();
            services.AddScoped<INormaAbntRepository, NormaAbntRepository>();
        }
    }
}
