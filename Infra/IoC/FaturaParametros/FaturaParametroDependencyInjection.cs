using Application.Interfaces.FaturaParametros;
using Application.Interfaces.Queries;
using Application.Services.FaturaParametros;
using Domain.Commands.FaturaParametros;
using Domain.Commands.FaturaParametros.Adicionar;
using Domain.Commands.FaturaParametros.Atualizar;
using Domain.Commands.FaturaParametros.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.FaturaParametros;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.FaturaParametros
{
    public static class FaturaParametroDependencyInjection
    {
        public static void AddFaturaParametroDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarFaturaParametroCommand, FormularioResponse<AdicionarFaturaParametroCommand>>, AdicionarFaturaParametroCommandHandler>();
            services.AddTransient<IValidator<AdicionarFaturaParametroCommand>, AdicionarFaturaParametroCommandValidation>();
            services.AddTransient<IValidator<FaturaParametroCommand<AdicionarFaturaParametroCommand>>, FaturaParametroCommandValidation<AdicionarFaturaParametroCommand>>();

            services.AddScoped<IRequestHandler<AtualizarFaturaParametroCommand, FormularioResponse<AtualizarFaturaParametroCommand>>, AtualizarFaturaParametroCommandHandler>();
            services.AddTransient<IValidator<AtualizarFaturaParametroCommand>, AtualizarFaturaParametroCommandValidation>();
            services.AddTransient<IValidator<FaturaParametroCommand<AtualizarFaturaParametroCommand>>, FaturaParametroCommandValidation<AtualizarFaturaParametroCommand>>();

            services.AddScoped<IRequestHandler<ExcluirFaturaParametroCommand, List<FormularioResponse<ExcluirFaturaParametroCommand>>>, ExcluirFaturaParametroCommandHandler>();

            services.AddScoped<IFaturaParametroService, FaturaParametroService>();
            services.AddScoped<IFaturaParametroQuery, FaturaParametroQuery>();
            services.AddScoped<IFaturaParametroRepository, FaturaParametroRepository>();
        }
    }
}
