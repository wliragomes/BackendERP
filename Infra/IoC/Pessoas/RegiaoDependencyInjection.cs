using Domain.Commands.Regioes;
using Domain.Commands.Regioes.Adicionar;
using Domain.Commands.Regioes.Atualizar;
using Domain.Commands.Regioes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.regioes.Atualizar;

namespace Infra.IoC.Pessoas
{
    public static class RegiaoDependencyInjection
    {
        public static void AddRegiaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarRegiaoCommand, FormularioResponse<AdicionarRegiaoCommand>>, AdicionarRegiaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarRegiaoCommand>, AdicionarRegiaoCommandValidation>();
            services.AddTransient<IValidator<RegiaoCommand<AdicionarRegiaoCommand>>, RegiaoCommandValidation<AdicionarRegiaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarRegiaoCommand, FormularioResponse<AtualizarRegiaoCommand>>, AtualizarRegiaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarRegiaoCommand>, AtualizarRegiaoCommandValidation>();
            services.AddTransient<IValidator<RegiaoCommand<AtualizarRegiaoCommand>>, RegiaoCommandValidation<AtualizarRegiaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirRegiaoCommand, List<FormularioResponse<ExcluirRegiaoCommand>>>, ExcluirRegiaoCommandHandler>();

            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
        }
    }
}

