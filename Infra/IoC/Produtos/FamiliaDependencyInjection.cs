using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.Familias.Adicionar;
using Domain.Commands.Produtos.Familias;
using Domain.Commands.Produtos.Familias.Atualizar;
using Domain.Commands.Produtos.Familias.Excluir;
using Infra.Repositories;

namespace Infra.IoC.Produtos
{
    public static class FamiliaDependencyInjection
    {
        public static void AddFamiliaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarFamiliaCommand, FormularioResponse<AdicionarFamiliaCommand>>, AdicionarFamiliaCommandHandler>();
            services.AddTransient<IValidator<AdicionarFamiliaCommand>, AdicionarFamiliaCommandValidation>();
            services.AddTransient<IValidator<FamiliaCommand<AdicionarFamiliaCommand>>, FamiliaCommandValidation<AdicionarFamiliaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarFamiliaCommand, FormularioResponse<AtualizarFamiliaCommand>>, AtualizarFamiliaCommandHandler>();
            services.AddTransient<IValidator<AtualizarFamiliaCommand>, AtualizarFamiliaCommandValidation>();
            services.AddTransient<IValidator<FamiliaCommand<AtualizarFamiliaCommand>>, FamiliaCommandValidation<AtualizarFamiliaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirFamiliaCommand, List<FormularioResponse<ExcluirFamiliaCommand>>>, ExcluirFamiliaCommandHandler>();

            services.AddScoped<IFamiliaRepository, FamiliaRepository>();
        }
    }
}
