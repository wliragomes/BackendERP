using Domain.Commands.TiposCarrocerias;
using Domain.Commands.TiposCarrocerias.Adicionar;
using Domain.Commands.TiposCarrocerias.Atualizar;
using Domain.Commands.TiposCarrocerias.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.TiposCarrocerias
{
    public static class TipoCarroceriaDependencyInjection
    {
        public static void AddTipoCarroceriaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarTipoCarroceriaCommand, FormularioResponse<AdicionarTipoCarroceriaCommand>>, AdicionarTipoCarroceriaCommandHandler>();
            services.AddTransient<IValidator<AdicionarTipoCarroceriaCommand>, AdicionarTipoCarroceriaCommandValidation>();
            services.AddTransient<IValidator<TipoCarroceriaCommand<AdicionarTipoCarroceriaCommand>>, TipoCarroceriaCommandValidation<AdicionarTipoCarroceriaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarTipoCarroceriaCommand, FormularioResponse<AtualizarTipoCarroceriaCommand>>, AtualizarTipoCarroceriaCommandHandler>();
            services.AddTransient<IValidator<AtualizarTipoCarroceriaCommand>, AtualizarTipoCarroceriaCommandValidation>();
            services.AddTransient<IValidator<TipoCarroceriaCommand<AtualizarTipoCarroceriaCommand>>, TipoCarroceriaCommandValidation<AtualizarTipoCarroceriaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirTipoCarroceriaCommand, List<FormularioResponse<ExcluirTipoCarroceriaCommand>>>, ExcluirTipoCarroceriaCommandHandler>();

            services.AddScoped<ITipoCarroceriaRepository, TipoCarroceriaRepository>();
        }
    }
}
