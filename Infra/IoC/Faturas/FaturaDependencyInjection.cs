using Application.Interfaces.Queries;
using Application.Interfaces.Faturas;
using Application.Services.Faturas;
using Domain.Commands.Faturas.Adicionar;
using Domain.Commands.Faturas.Atualizar;
using Domain.Commands.Faturas;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Faturas;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Faturas.Excluir;

namespace Infra.IoC.Faturas
{
    public static class FaturaDependencyInjection
    {
        public static void AddFaturaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarFaturaCommand, FormularioResponse<AdicionarFaturaCommand>>, AdicionarFaturaCommandHandler>();
            services.AddTransient<IValidator<AdicionarFaturaCommand>, AdicionarFaturaCommandValidation>();
            services.AddTransient<IValidator<FaturaCommand<AdicionarFaturaCommand>>, FaturaCommandValidation<AdicionarFaturaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarFaturaCommand, FormularioResponse<AtualizarFaturaCommand>>, AtualizarFaturaCommandHandler>();
            services.AddTransient<IValidator<AtualizarFaturaCommand>, AtualizarFaturaCommandValidation>();
            services.AddTransient<IValidator<FaturaCommand<AtualizarFaturaCommand>>, FaturaCommandValidation<AtualizarFaturaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirFaturaCommand, List<FormularioResponse<ExcluirFaturaCommand>>>, ExcluirFaturaCommandHandler>();

            services.AddScoped<IFaturaService, FaturaService>();
            services.AddScoped<IFaturaQuery, FaturaQuery>();
            services.AddScoped<IFaturaRepository, FaturaRepository>();
        }

    }
}

