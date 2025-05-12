using Domain.Commands.Cargos;
using Domain.Commands.Cargos.Adicionar;
using Domain.Commands.Cargos.Atualizar;
using Domain.Commands.Cargos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Pessoas
{
    public static class CargoDependencyInjection
    {
        public static void AddCargoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCargoCommand, FormularioResponse<AdicionarCargoCommand>>, AdicionarCargoCommandHandler>();
            services.AddTransient<IValidator<AdicionarCargoCommand>, AdicionarCargoCommandValidation>();
            services.AddTransient<IValidator<CargoCommand<AdicionarCargoCommand>>, CargoCommandValidation<AdicionarCargoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCargoCommand, FormularioResponse<AtualizarCargoCommand>>, AtualizarCargoCommandHandler>();
            services.AddTransient<IValidator<AtualizarCargoCommand>, AtualizarCargoCommandValidation>();
            services.AddTransient<IValidator<CargoCommand<AtualizarCargoCommand>>, CargoCommandValidation<AtualizarCargoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCargoCommand, List<FormularioResponse<ExcluirCargoCommand>>>, ExcluirCargoCommandHandler>();

            services.AddScoped<ICargoRepository, CargoRepository>();
        }
    }
}
