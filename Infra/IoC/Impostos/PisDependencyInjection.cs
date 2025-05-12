using Domain.Commands.Impostos.Piss;
using Domain.Commands.Impostos.Piss.Adicionar;
using Domain.Commands.Impostos.Piss.Atualizar;
using Domain.Commands.Impostos.Piss.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Impostos
{
    public static class PisDependencyInjection
    {
        public static void AddPisDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarPisCommand, FormularioResponse<AdicionarPisCommand>>, AdicionarPisCommandHandler>();
            services.AddTransient<IValidator<AdicionarPisCommand>, AdicionarPisCommandValidation>();
            services.AddTransient<IValidator<PisCommand<AdicionarPisCommand>>, PisCommandValidation<AdicionarPisCommand>>();

            services.AddScoped<IRequestHandler<AtualizarPisCommand, FormularioResponse<AtualizarPisCommand>>, AtualizarPisCommandHandler>();
            services.AddTransient<IValidator<AtualizarPisCommand>, AtualizarPisCommandValidation>();
            services.AddTransient<IValidator<PisCommand<AtualizarPisCommand>>, PisCommandValidation<AtualizarPisCommand>>();

            services.AddScoped<IRequestHandler<ExcluirPisCommand, List<FormularioResponse<ExcluirPisCommand>>>, ExcluirPisCommandHandler>();

            services.AddScoped<IPisRepository, PisRepository>();

        }
    }
}
