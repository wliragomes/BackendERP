using Application.Interfaces.Obras;
using Application.Interfaces.Queries;
using Application.Services.Obras;
using Domain.Commands.ObraOrigems;
using Domain.Commands.ObraOrigems.Adicionar;
using Domain.Commands.ObraOrigems.Atualizar;
using Domain.Commands.ObraOrigems.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.ObraFases;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.ObraOrigems
{
    public static class ObraOrigemDependencyInjection
    {
        public static void AddObraOrigemDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarObraOrigemCommand, FormularioResponse<AdicionarObraOrigemCommand>>, AdicionarObraOrigemCommandHandler>();
            services.AddTransient<IValidator<AdicionarObraOrigemCommand>, AdicionarObraOrigemCommandValidation>();
            services.AddTransient<IValidator<ObraOrigemCommand<AdicionarObraOrigemCommand>>, ObraOrigemCommandValidation<AdicionarObraOrigemCommand>>();

            services.AddScoped<IRequestHandler<AtualizarObraOrigemCommand, FormularioResponse<AtualizarObraOrigemCommand>>, AtualizarObraOrigemCommandHandler>();
            services.AddTransient<IValidator<AtualizarObraOrigemCommand>, AtualizarObraOrigemCommandValidation>();
            services.AddTransient<IValidator<ObraOrigemCommand<AtualizarObraOrigemCommand>>, ObraOrigemCommandValidation<AtualizarObraOrigemCommand>>();

            services.AddScoped<IRequestHandler<ExcluirObraOrigemCommand, List<FormularioResponse<ExcluirObraOrigemCommand>>>, ExcluirObraOrigemCommandHandler>();

            services.AddScoped<IObraService, ObraService>();
            services.AddScoped<IObraQuery, ObraQuery>();
            services.AddScoped<IObraOrigemRepository, ObraOrigemRepository>();
        }
    }
}
