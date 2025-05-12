using Application.Interfaces.Moedas;
using Application.Interfaces.Queries;
using Application.Services.Moedas;
using Domain.Commands.Moedas;
using Domain.Commands.Moedas.Adicionar;
using Domain.Commands.Moedas.Atualizar;
using Domain.Commands.Moedas.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Moedas;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Moedas
{
    public static class MoedaDependencyInjection
    {
        public static void AddMoedaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarMoedaCommand, FormularioResponse<AdicionarMoedaCommand>>, AdicionarMoedaCommandHandler>();
            services.AddTransient<IValidator<AdicionarMoedaCommand>, AdicionarMoedaCommandValidation>();
            services.AddTransient<IValidator<MoedaCommand<AdicionarMoedaCommand>>, MoedaCommandValidation<AdicionarMoedaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarMoedaCommand, FormularioResponse<AtualizarMoedaCommand>>, AtualizarMoedaCommandHandler>();
            services.AddTransient<IValidator<AtualizarMoedaCommand>, AtualizarMoedaCommandValidation>();
            services.AddTransient<IValidator<MoedaCommand<AtualizarMoedaCommand>>, MoedaCommandValidation<AtualizarMoedaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirMoedaCommand, List<FormularioResponse<ExcluirMoedaCommand>>>, ExcluirMoedaCommandHandler>();

            services.AddScoped<IMoedaService, MoedaService>();
            services.AddScoped<IMoedaQuery, MoedaQuery>();
            services.AddScoped<IMoedaRepository, MoedaRepository>();
        }
    }
}
