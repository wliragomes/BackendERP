using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.FaturaParametros.Atualizar
{
    public class AtualizarFaturaParametroCommandValidation : AbstractValidator<AtualizarFaturaParametroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarFaturaParametroCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new FaturaParametroCommandValidation<AtualizarFaturaParametroCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.FaturaParametroRepository.ExisteIdAsync(id.Value);
        }
    }
}
