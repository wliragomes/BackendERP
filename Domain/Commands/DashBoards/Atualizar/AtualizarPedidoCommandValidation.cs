using Domain.Commands.Vendas.Atualizar;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Pedidos.Atualizar
{
    public class AtualizarPedidoCommandValidation : AbstractValidator<AtualizarPedidoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarPedidoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }       
    }
}
