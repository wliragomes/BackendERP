using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ContasAPagarPago
{
    public class ContaAPagarPagoCommandValidation<T> : AbstractValidator<ContaAPagarPagoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContaAPagarPagoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        // Verificar quais validações serão colocadas
    }
}
