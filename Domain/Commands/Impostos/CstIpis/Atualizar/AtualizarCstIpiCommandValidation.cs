using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Impostos.CstIpis.Atualizar
{
    public class AtualizarCstIpiCommandValidation : AbstractValidator<AtualizarCstIpiCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarCstIpiCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new CstIpiCommandValidation<AtualizarCstIpiCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.CST_IPIRepository.ExisteIdAsync(id.Value);
        }
    }
}
