using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Origens.Atualizar
{
    public class AtualizarOrigemCommandValidation : AbstractValidator<AtualizarOrigemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarOrigemCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new OrigemCommandValidation<AtualizarOrigemCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.OrigemRepository.ExisteIdAsync(id.Value);
        }
    }
}
