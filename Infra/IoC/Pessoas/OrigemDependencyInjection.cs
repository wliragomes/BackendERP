using Domain.Commands.Origens;
using Domain.Commands.Origens.Adicionar;
using Domain.Commands.Origens.Atualizar;
using Domain.Commands.Origens.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Pessoas
{
    public static class OrigemDependencyInjection
    {
        public static void AddOrigemDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarOrigemCommand, FormularioResponse<AdicionarOrigemCommand>>, AdicionarOrigemCommandHandler>();
            services.AddTransient<IValidator<AdicionarOrigemCommand>, AdicionarOrigemCommandValidation>();
            services.AddTransient<IValidator<OrigemCommand<AdicionarOrigemCommand>>, OrigemCommandValidation<AdicionarOrigemCommand>>();

            services.AddScoped<IRequestHandler<AtualizarOrigemCommand, FormularioResponse<AtualizarOrigemCommand>>, AtualizarOrigemCommandHandler>();
            services.AddTransient<IValidator<AtualizarOrigemCommand>, AtualizarOrigemCommandValidation>();
            services.AddTransient<IValidator<OrigemCommand<AtualizarOrigemCommand>>, OrigemCommandValidation<AtualizarOrigemCommand>>();

            services.AddScoped<IRequestHandler<ExcluirOrigemCommand, List<FormularioResponse<ExcluirOrigemCommand>>>, ExcluirOrigemCommandHandler>();

            services.AddScoped<IOrigemRepository, OrigemRepository>();
        }
    }
}
