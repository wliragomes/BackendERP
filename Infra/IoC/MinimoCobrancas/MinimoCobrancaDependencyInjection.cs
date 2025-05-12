using Application.Interfaces.MinimoCobrancas;
using Application.Interfaces.Queries;
using Application.Services.MinimoCobrancas;
using Domain.Commands.MinimoCobrancas;
using Domain.Commands.MinimoCobrancas.Adicionar;
using Domain.Commands.MinimoCobrancas.Atualizar;
using Domain.Commands.MinimoCobrancas.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.MinimoCobrancas;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.MinimoCobrancas
{
    public static class MinimoCobrancaDependencyInjection
    {
        public static void AddMinimoCobrancaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarMinimoCobrancaCommand, FormularioResponse<AdicionarMinimoCobrancaCommand>>, AdicionarMinimoCobrancaCommandHandler>();
            services.AddTransient<IValidator<AdicionarMinimoCobrancaCommand>, AdicionarMinimoCobrancaCommandValidation>();
            services.AddTransient<IValidator<MinimoCobrancaCommand<AdicionarMinimoCobrancaCommand>>, MinimoCobrancaCommandValidation<AdicionarMinimoCobrancaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarMinimoCobrancaCommand, FormularioResponse<AtualizarMinimoCobrancaCommand>>, AtualizarMinimoCobrancaCommandHandler>();
            services.AddTransient<IValidator<AtualizarMinimoCobrancaCommand>, AtualizarMinimoCobrancaCommandValidation>();
            services.AddTransient<IValidator<MinimoCobrancaCommand<AtualizarMinimoCobrancaCommand>>, MinimoCobrancaCommandValidation<AtualizarMinimoCobrancaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirMinimoCobrancaCommand, List<FormularioResponse<ExcluirMinimoCobrancaCommand>>>, ExcluirMinimoCobrancaCommandHandler>();

            services.AddScoped<IMinimoCobrancaService, MinimoCobrancaService>();
            services.AddScoped<IMinimoCobrancaQuery, MinimoCobrancaQuery>();
            services.AddScoped<IMinimoCobrancaRepository, MinimoCobrancaRepository>();
        }
    }
}
