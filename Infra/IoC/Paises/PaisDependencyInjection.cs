using Application.Interfaces.Paises;
using Application.Interfaces.Queries;
using Application.Services.Paises;
using Domain.Commands.Paises;
using Domain.Commands.Paises.Adicionar;
using Domain.Commands.Paises.Atualizar;
using Domain.Commands.Paises.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Paises;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Paises
{
    public static class PaisDependencyInjection
    {
        public static void AddPaisDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarPaisCommand, FormularioResponse<AdicionarPaisCommand>>, AdicionarPaisCommandHandler>();
            services.AddTransient<IValidator<AdicionarPaisCommand>, AdicionarPaisCommandValidation>();
            services.AddTransient<IValidator<PaisCommand<AdicionarPaisCommand>>, PaisCommandValidation<AdicionarPaisCommand>>();

            services.AddScoped<IRequestHandler<AtualizarPaisCommand, FormularioResponse<AtualizarPaisCommand>>, AtualizarPaisCommandHandler>();
            services.AddTransient<IValidator<AtualizarPaisCommand>, AtualizarPaisCommandValidation>();
            services.AddTransient<IValidator<PaisCommand<AtualizarPaisCommand>>, PaisCommandValidation<AtualizarPaisCommand>>();

            services.AddScoped<IRequestHandler<ExcluirPaisCommand, List<FormularioResponse<ExcluirPaisCommand>>>, ExcluirPaisCommandHandler>();

            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<IPaisQuery, PaisQuery>();
            services.AddScoped<IPaisRepository, PaisRepository>();
        }
    }
}
