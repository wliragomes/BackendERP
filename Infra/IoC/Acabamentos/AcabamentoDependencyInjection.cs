using Application.Interfaces.Acabamentos;
using Application.Interfaces.Queries;
using Application.Services.Acabamentos;
using Domain.Commands.Acabamentos;
using Domain.Commands.Acabamentos.Adicionar;
using Domain.Commands.Acabamentos.Atualizar;
using Domain.Commands.Acabamentos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Acabamentos;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Acabamentos
{
    public static class AcabamentoDependencyInjection
    {
        public static void AddAcabamentoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarAcabamentoCommand, FormularioResponse<AdicionarAcabamentoCommand>>, AdicionarAcabamentoCommandHandler>();
            services.AddTransient<IValidator<AdicionarAcabamentoCommand>, AdicionarAcabamentoCommandValidation>();
            services.AddTransient<IValidator<AcabamentoCommand<AdicionarAcabamentoCommand>>, AcabamentoCommandValidation<AdicionarAcabamentoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarAcabamentoCommand, FormularioResponse<AtualizarAcabamentoCommand>>, AtualizarAcabamentoCommandHandler>();
            services.AddTransient<IValidator<AtualizarAcabamentoCommand>, AtualizarAcabamentoCommandValidation>();
            services.AddTransient<IValidator<AcabamentoCommand<AtualizarAcabamentoCommand>>, AcabamentoCommandValidation<AtualizarAcabamentoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirAcabamentoCommand, List<FormularioResponse<ExcluirAcabamentoCommand>>>, ExcluirAcabamentoCommandHandler>();

            services.AddScoped<IAcabamentoService, AcabamentoService>();
            services.AddScoped<IAcabamentoQuery, AcabamentoQuery>();
            services.AddScoped<IAcabamentoRepository, AcabamentoRepository>();
        }
    }
}
