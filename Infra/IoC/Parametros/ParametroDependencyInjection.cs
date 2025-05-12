using Application.Interfaces.Parametros;
using Application.Interfaces.Queries;
using Application.Services.Parametros;
using Domain.Commands.Parametros;
using Domain.Commands.Parametros.Adicionar;
using Domain.Commands.Parametros.Atualizar;
using Domain.Commands.Parametros.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Parametros;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Parametros
{
    public static class ParametroDependencyInjection
    {
        public static void AddParametroDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarParametroCommand, FormularioResponse<AdicionarParametroCommand>>, AdicionarParametroCommandHandler>();
            services.AddTransient<IValidator<AdicionarParametroCommand>, AdicionarParametroCommandValidation>();
            services.AddTransient<IValidator<ParametroCommand<AdicionarParametroCommand>>, ParametroCommandValidation<AdicionarParametroCommand>>();

            services.AddScoped<IRequestHandler<AtualizarParametroCommand, FormularioResponse<AtualizarParametroCommand>>, AtualizarParametroCommandHandler>();
            services.AddTransient<IValidator<AtualizarParametroCommand>, AtualizarParametroCommandValidation>();
            services.AddTransient<IValidator<ParametroCommand<AtualizarParametroCommand>>, ParametroCommandValidation<AtualizarParametroCommand>>();

            services.AddScoped<IRequestHandler<ExcluirParametroCommand, List<FormularioResponse<ExcluirParametroCommand>>>, ExcluirParametroCommandHandler>();

            services.AddScoped<IParametroService, ParametroService>();
            services.AddScoped<IParametroQuery, ParametroQuery>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
        }
    }
}
