using Domain.Commands.TiposRodados;
using Domain.Commands.TiposRodados.Adicionar;
using Domain.Commands.TiposRodados.Atualizar;
using Domain.Commands.TiposRodados.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.TiposRodados
{
    public static class TipoRodadoDependencyInjection
    {
        public static void AddTipoRodadoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarTipoRodadoCommand, FormularioResponse<AdicionarTipoRodadoCommand>>, AdicionarTipoRodadoCommandHandler>();
            services.AddTransient<IValidator<AdicionarTipoRodadoCommand>, AdicionarTipoRodadoCommandValidation>();
            services.AddTransient<IValidator<TipoRodadoCommand<AdicionarTipoRodadoCommand>>, TipoRodadoCommandValidation<AdicionarTipoRodadoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarTipoRodadoCommand, FormularioResponse<AtualizarTipoRodadoCommand>>, AtualizarTipoRodadoCommandHandler>();
            services.AddTransient<IValidator<AtualizarTipoRodadoCommand>, AtualizarTipoRodadoCommandValidation>();
            services.AddTransient<IValidator<TipoRodadoCommand<AtualizarTipoRodadoCommand>>, TipoRodadoCommandValidation<AtualizarTipoRodadoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirTipoRodadoCommand, List<FormularioResponse<ExcluirTipoRodadoCommand>>>, ExcluirTipoRodadoCommandHandler>();

            services.AddScoped<ITipoRodadoRepository, TipoRodadoRepository>();
        }
    }
}
