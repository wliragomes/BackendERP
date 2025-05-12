using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Duplicatas.Atualizar
{
    public class AtualizarDuplicataCommandValidation : AbstractValidator<AtualizarDuplicataCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarDuplicataCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new DuplicataCommandValidation<AtualizarDuplicataCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.DuplicataRepository.ExisteIdAsync(id.Value);
        }
    }
}
