using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Impostos.Piss.Atualizar
{
    public class AtualizarPisCommandValidation : AbstractValidator<AtualizarPisCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarPisCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c)
               .SetValidator(new PisCommandValidation<AtualizarPisCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.PisRepository.ExisteIdAsync(id.Value);
        }
    }
}

