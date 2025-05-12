using Domain.Commands.Produtos.Grupos.Atualizar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.OrigemMateriais.Adicionar;
using Domain.Commands.Produtos.OrigemMateriais;
using Domain.Commands.Produtos.OrigemMateriais.Atualizar;
using Domain.Commands.Produtos.OrigemMateriais.Excluir;

namespace Infra.IoC.Produtos
{
    public static class OrigemMaterialDependencyInjection
    {
        public static void AddOrigemMaterialDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarOrigemMaterialCommand, FormularioResponse<AdicionarOrigemMaterialCommand>>, AdicionarOrigemMaterialCommandHandler>();
            services.AddTransient<IValidator<AdicionarOrigemMaterialCommand>, AdicionarOrigemMaterialCommandValidation>();
            services.AddTransient<IValidator<OrigemMaterialCommand<AdicionarOrigemMaterialCommand>>, OrigemMaterialCommandValidation<AdicionarOrigemMaterialCommand>>();

            services.AddScoped<IRequestHandler<AtualizarOrigemMaterialCommand, FormularioResponse<AtualizarOrigemMaterialCommand>>, AtualizarOrigemMaterialCommandHandler>();
            services.AddTransient<IValidator<AtualizarOrigemMaterialCommand>, AtualizarOrigemMaterialCommandValidation>();
            services.AddTransient<IValidator<OrigemMaterialCommand<AtualizarOrigemMaterialCommand>>, OrigemMaterialCommandValidation<AtualizarOrigemMaterialCommand>>();

            services.AddScoped<IRequestHandler<ExcluirOrigemMaterialCommand, List<FormularioResponse<ExcluirOrigemMaterialCommand>>>, ExcluirOrigemMaterialCommandHandler>();

            services.AddScoped<IOrigemMaterialRepository, OrigemMaterialRepository>();
        }
    }
}
