using Application.Interfaces.Bancos;
using Application.Interfaces.Cfops;
using Application.Interfaces.Queries;
using Application.Services.Cfops;
using Domain.Commands.Cfops;
using Domain.Commands.Cfops.Adicionar;
using Domain.Commands.Cfops.Atualizar;
using Domain.Commands.Cfops.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Cfops;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Cfos
{
    public static class CfopDependencyInjection
    {
        public static void AddCfopDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCfopCommand, FormularioResponse<AdicionarCfopCommand>>, AdicionarCfopCommandHandler>();
            services.AddTransient<IValidator<AdicionarCfopCommand>, AdicionarCfopCommandValidation>();
            services.AddTransient<IValidator<CfopCommand<AdicionarCfopCommand>>, CfopCommandValidation<AdicionarCfopCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCfopCommand, FormularioResponse<AtualizarCfopCommand>>, AtualizarCfopCommandHandler>();
            services.AddTransient<IValidator<AtualizarCfopCommand>, AtualizarCfopCommandValidation>();
            services.AddTransient<IValidator<CfopCommand<AtualizarCfopCommand>>, CfopCommandValidation<AtualizarCfopCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCfopCommand, List<FormularioResponse<ExcluirCfopCommand>>>, ExcluirCfopCommandHandler>();

            services.AddScoped<ICfopService, CfopService>();
            services.AddScoped<ICfopQuery, CfopQuery>();
            services.AddScoped<ICfopRepository, CfopRepository>();
        }
    }
}
