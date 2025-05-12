using Application.Interfaces.Duplicatas;
using Application.Interfaces.Queries;
using Application.Services.Duplicatas;
using Domain.Commands.ContasAPagar.Excluir;
using Domain.Commands.Duplicatas;
using Domain.Commands.Duplicatas.Adicionar;
using Domain.Commands.Duplicatas.Atualizar;
using Domain.Commands.Duplicatas.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Duplicatas;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Duplicatas
{
    public static class DuplicataDependencyInjection
    {
        public static void AddDuplicataDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarDuplicataCommand, FormularioResponse<AdicionarDuplicataCommand>>, AdicionarDuplicataCommandHandler>();
            services.AddTransient<IValidator<AdicionarDuplicataCommand>, AdicionarDuplicataCommandValidation>();
            services.AddTransient<IValidator<DuplicataCommand<AdicionarDuplicataCommand>>, DuplicataCommandValidation<AdicionarDuplicataCommand>>();

            services.AddScoped<IRequestHandler<AtualizarDuplicataCommand, FormularioResponse<AtualizarDuplicataCommand>>, AtualizarDuplicataCommandHandler>();
            services.AddTransient<IValidator<AtualizarDuplicataCommand>, AtualizarDuplicataCommandValidation>();
            services.AddTransient<IValidator<DuplicataCommand<AtualizarDuplicataCommand>>, DuplicataCommandValidation<AtualizarDuplicataCommand>>();

            services.AddScoped<IRequestHandler<ExcluirDuplicataCommand, List<FormularioResponse<ExcluirDuplicataCommand>>>, ExcluirDuplicataCommandHandler>();

            services.AddScoped<IDuplicataService, DuplicataService>();
            services.AddScoped<IDuplicataQuery, DuplicataQuery>();
            services.AddScoped<IDuplicataRepository, DuplicataRepository>();
        }
    }
}
