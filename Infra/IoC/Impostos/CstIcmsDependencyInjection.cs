using Domain.Commands.Impostos.CstIcmss;
using Domain.Commands.Impostos.CstIcmss.Adicionar;
using Domain.Commands.Impostos.CstIcmss.Atualizar;
using Domain.Commands.Impostos.CstIcmss.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Impostos
{
    public static class CstIcmsDependencyInjection
    {
        public static void AddCstIcmsDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCstIcmsCommand, FormularioResponse<AdicionarCstIcmsCommand>>, AdicionarCstIcmsCommandHandler>();
            services.AddTransient<IValidator<AdicionarCstIcmsCommand>, AdicionarCstIcmsCommandValidation>();
            services.AddTransient<IValidator<CstIcmsCommand<AdicionarCstIcmsCommand>>, CstIcmsCommandValidation<AdicionarCstIcmsCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCST_ICMSCommand, FormularioResponse<AtualizarCST_ICMSCommand>>, AtualizarCST_ICMSCommandHandler>();
            services.AddTransient<IValidator<AtualizarCST_ICMSCommand>, AtualizarCST_ICMSCommandValidation>();
            services.AddTransient<IValidator<CstIcmsCommand<AtualizarCST_ICMSCommand>>, CstIcmsCommandValidation<AtualizarCST_ICMSCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCstIcmsCommand, List<FormularioResponse<ExcluirCstIcmsCommand>>>, ExcluirCstIcmsCommandHandler>();

            services.AddScoped<ICstIcmsRepository, CstIcmsRepository>();

        }
    }
}
