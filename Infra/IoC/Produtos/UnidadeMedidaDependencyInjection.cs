using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.UnidadesMedidas.Adicionar;
using Domain.Commands.Produtos.UnidadesMedidas.Atualizar;
using Domain.Commands.Produtos.UnidadesMedidas.Excluir;
using Domain.Commands.Produtos.UnidadesMedidas;

namespace Infra.IoC.Produtos
{
    public static class UnidadeMedidaDependencyInjection
    {
        public static void AddUnidadeMedidaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarUnidadeMedidaCommand, FormularioResponse<AdicionarUnidadeMedidaCommand>>, AdicionarUnidadeMedidaCommandHandler>();
            services.AddTransient<IValidator<AdicionarUnidadeMedidaCommand>, AdicionarUnidadeMedidaCommandValidation>();
            services.AddTransient<IValidator<UnidadeMedidaCommand<AdicionarUnidadeMedidaCommand>>, UnidadeMedidaCommandValidation<AdicionarUnidadeMedidaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarUnidadeMedidaCommand, FormularioResponse<AtualizarUnidadeMedidaCommand>>, AtualizarUnidadeMedidaCommandHandler>();
            services.AddTransient<IValidator<AtualizarUnidadeMedidaCommand>, AtualizarUnidadeMedidaCommandValidation>();
            services.AddTransient<IValidator<UnidadeMedidaCommand<AtualizarUnidadeMedidaCommand>>, UnidadeMedidaCommandValidation<AtualizarUnidadeMedidaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirUnidadeMedidaCommand, List<FormularioResponse<ExcluirUnidadeMedidaCommand>>>, ExcluirUnidadeMedidaCommandHandler>();

            services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
        }
    }
}
