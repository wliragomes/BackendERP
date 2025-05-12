using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using MediatR;
using FluentValidation;
using Domain.Commands.Vendas.Atualizar;
using Domain.Commands.Pedidos.Atualizar;
using Domain.Commands.Pedidos;
using Domain.Interfaces.Repositories;
using Infra.Repositories;
using Domain.Commands.DashBoard.Atualizar;

namespace Infra.IoC.DashBoards
{
    public static class PedidoDependencyInjection
    {
        public static void AddPedidoDependencyInjection(this IServiceCollection services)
        {
            
            services.AddScoped<IRequestHandler<AtualizarPedidoCommand, FormularioResponse<AtualizarPedidoCommand>>, AtualizarPedidoCommandHandler>();
            services.AddTransient<IValidator<AtualizarPedidoCommand>, AtualizarPedidoCommandValidation>();
            services.AddTransient<IValidator<PedidoCommand<AtualizarPedidoCommand>>, PedidoCommandValidation<AtualizarPedidoCommand>>();

            services.AddScoped<IDashBoardRepository, DashBoardRepository>();
        }
    }
}
