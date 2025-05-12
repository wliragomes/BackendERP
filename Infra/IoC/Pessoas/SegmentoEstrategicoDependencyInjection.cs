using Domain.Commands.SegmentoEstrategicos;
using Domain.Commands.SegmentoEstrategicos.Adicionar;
using Domain.Commands.SegmentoEstrategicos.Atualizar;
using Domain.Commands.SegmentoEstrategicos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Pessoas
{
    public static class SegmentoEstrategicoDependencyInjection
    {
        public static void AddSegmentoEstrategicoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarSegmentoEstrategicoCommand, FormularioResponse<AdicionarSegmentoEstrategicoCommand>>, AdicionarSegmentoEstrategicoCommandHandler>();
            services.AddTransient<IValidator<AdicionarSegmentoEstrategicoCommand>, AdicionarSegmentoEstrategicoCommandValidation>();
            services.AddTransient<IValidator<SegmentoEstrategicoCommand<AdicionarSegmentoEstrategicoCommand>>, SegmentoEstrategicoCommandValidation<AdicionarSegmentoEstrategicoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarSegmentoEstrategicoCommand, FormularioResponse<AtualizarSegmentoEstrategicoCommand>>, AtualizarSegmentoEstrategicoCommandHandler>();
            services.AddTransient<IValidator<AtualizarSegmentoEstrategicoCommand>, AtualizarSegmentoEstrategicoCommandValidation>();
            services.AddTransient<IValidator<SegmentoEstrategicoCommand<AtualizarSegmentoEstrategicoCommand>>, SegmentoEstrategicoCommandValidation<AtualizarSegmentoEstrategicoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirSegmentoEstrategicoCommand, List<FormularioResponse<ExcluirSegmentoEstrategicoCommand>>>, ExcluirSegmentoEstrategicoCommandHandler>();

            services.AddScoped<ISegmentoEstrategicoRepository, SegmentoEstrategicoRepository>();
        }
    }
}

