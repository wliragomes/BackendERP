using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ContasAPagarPago.Adicionar
{
    public class AdicionarContaAPagarPagoCommandValidation : AbstractValidator<AdicionarContaAPagarPagoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarContaAPagarPagoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ContaAPagarPagoCommandValidation<AdicionarContaAPagarPagoCommand>(_unitOfWork));
        }
    }
}
