using Domain.Commands.Impostos.IcstIcmsOrigemMateriais;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Adicionar;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Atualizar;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Impostos
{
    public static class CstIcmsOrigemMaterialDependencyInjection
    {
        public static void AddCstIcmsOrigemMaterialDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarIcstIcmsOrigemMaterialCommand, FormularioResponse<AdicionarIcstIcmsOrigemMaterialCommand>>, AdicionarIcstIcmsOrigemMaterialCommandHandler>();
            services.AddTransient<IValidator<AdicionarIcstIcmsOrigemMaterialCommand>, AdicionarIcstIcmsOrigemMaterialCommandValidation>();
            services.AddTransient<IValidator<IcstIcmsOrigemMaterialCommand<AdicionarIcstIcmsOrigemMaterialCommand>>, IcstIcmsOrigemMaterialCommandValidation<AdicionarIcstIcmsOrigemMaterialCommand>>();

            services.AddScoped<IRequestHandler<AtualizarIcstIcmsOrigemMaterialCommand, FormularioResponse<AtualizarIcstIcmsOrigemMaterialCommand>>, AtualizarIcstIcmsOrigemMaterialCommandHandler>();
            services.AddTransient<IValidator<AtualizarIcstIcmsOrigemMaterialCommand>, AtualizarIcstIcmsOrigemMaterialCommandValidation>();
            services.AddTransient<IValidator<IcstIcmsOrigemMaterialCommand<AtualizarIcstIcmsOrigemMaterialCommand>>, IcstIcmsOrigemMaterialCommandValidation<AtualizarIcstIcmsOrigemMaterialCommand>>();

            services.AddScoped<IRequestHandler<ExcluirIcstIcmsOrigemMaterialCommand, List<FormularioResponse<ExcluirIcstIcmsOrigemMaterialCommand>>>, ExcluirIcstIcmsOrigemMaterialCommandHandler>();
                        
            services.AddScoped<ICstIcmsOrigemMaterialRepository, CstIcmsOrigemMaterialRepository>();
        }
    }
}

