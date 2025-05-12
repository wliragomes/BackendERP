using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Pedidos
{
    public class PedidoCommandValidation<T> : AbstractValidator<PedidoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PedidoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
    }
}
