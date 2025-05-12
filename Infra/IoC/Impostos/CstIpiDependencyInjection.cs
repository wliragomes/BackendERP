using Domain.Commands.Impostos.CstIpis;
using Domain.Commands.Impostos.CstIpis.Adicionar;
using Domain.Commands.Impostos.CstIpis.Atualizar;
using Domain.Commands.Impostos.CstIpis.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Impostos
{
    public static class CstIpiDependencyInjection
    {
        public static void AddCstIpiDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCstIpiCommand, FormularioResponse<AdicionarCstIpiCommand>>, AdicionarCstIpiCommandHandler>();
            services.AddTransient<IValidator<AdicionarCstIpiCommand>, AdicionarCstIpiCommandValidation>();
            services.AddTransient<IValidator<CstIpiCommand<AdicionarCstIpiCommand>>, CstIpiCommandValidation<AdicionarCstIpiCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCstIpiCommand, FormularioResponse<AtualizarCstIpiCommand>>, AtualizarCstIpiCommandHandler>();
            services.AddTransient<IValidator<AtualizarCstIpiCommand>, AtualizarCstIpiCommandValidation>();
            services.AddTransient<IValidator<CstIpiCommand<AtualizarCstIpiCommand>>, CstIpiCommandValidation<AtualizarCstIpiCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCstIpiCommand, List<FormularioResponse<ExcluirCstIpiCommand>>>, ExcluirCstIpiCommandHandler>();

            services.AddScoped<ICstIpiRepository, CstIpiRepository>();
        }
    }
}