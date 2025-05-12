using Application.Interfaces.MotivoCancelamentos;
using Application.Interfaces.Queries;
using Application.Services.MotivoCancelamentos;
using Domain.Commands.MotivoCancelamentos;
using Domain.Commands.MotivoCancelamentos.Adicionar;
using Domain.Commands.MotivoCancelamentos.Atualizar;
using Domain.Commands.MotivoCancelamentos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.MotivoCancelamentos;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.MotivoCancelamentos
{
    public static class MotivoCancelamentoDependencyInjection
    {
        public static void AddMotivoCancelamentoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarMotivoCancelamentoCommand, FormularioResponse<AdicionarMotivoCancelamentoCommand>>, AdicionarMotivoCancelamentoCommandHandler>();
            services.AddTransient<IValidator<AdicionarMotivoCancelamentoCommand>, AdicionarMotivoCancelamentoCommandValidation>();
            services.AddTransient<IValidator<MotivoCancelamentoCommand<AdicionarMotivoCancelamentoCommand>>, MotivoCancelamentoCommandValidation<AdicionarMotivoCancelamentoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarMotivoCancelamentoCommand, FormularioResponse<AtualizarMotivoCancelamentoCommand>>, AtualizarMotivoCancelamentoCommandHandler>();
            services.AddTransient<IValidator<AtualizarMotivoCancelamentoCommand>, AtualizarMotivoCancelamentoCommandValidation>();
            services.AddTransient<IValidator<MotivoCancelamentoCommand<AtualizarMotivoCancelamentoCommand>>, MotivoCancelamentoCommandValidation<AtualizarMotivoCancelamentoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirMotivoCancelamentoCommand, List<FormularioResponse<ExcluirMotivoCancelamentoCommand>>>, ExcluirMotivoCancelamentoCommandHandler>();

            services.AddScoped<IMotivoCancelamentoService, MotivoCancelamentoService>();
            services.AddScoped<IMotivoCancelamentoQuery, MotivoCancelamentoQuery>();
            services.AddScoped<IMotivoCancelamentoRepository, MotivoCancelamentoRepository>();
        }
    }
}
