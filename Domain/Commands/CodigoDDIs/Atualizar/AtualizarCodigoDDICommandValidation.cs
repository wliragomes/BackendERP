using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.CodigoDDIs.Atualizar
{
    public class AtualizarCodigoDDICommandValidation : AbstractValidator<AtualizarCodigoDDICommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarCodigoDDICommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new CodigoDDICommandValidation<AtualizarCodigoDDICommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.CodigoDDIRepository.ExisteIdAsync(id.Value);
        }
    }
}
