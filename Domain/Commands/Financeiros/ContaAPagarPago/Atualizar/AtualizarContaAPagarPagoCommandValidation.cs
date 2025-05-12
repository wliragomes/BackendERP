using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.ContasAPagarPago.Atualizar
{
    public class AtualizarContaAPagarPagoCommandValidation : AbstractValidator<AtualizarContaAPagarPagoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarContaAPagarPagoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new ContaAPagarPagoCommandValidation<AtualizarContaAPagarPagoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.ContaAPagarPagoRepository.ExisteIdAsync(id.Value);
        }
    }
}
