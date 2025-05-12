using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Feriados.Atualizar
{
    public class AtualizarFeriadoCommandValidation : AbstractValidator<AtualizarFeriadoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarFeriadoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new FeriadoCommandValidation<AtualizarFeriadoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.FeriadoRepository.ExisteIdAsync(id.Value);
        }
    }
}
