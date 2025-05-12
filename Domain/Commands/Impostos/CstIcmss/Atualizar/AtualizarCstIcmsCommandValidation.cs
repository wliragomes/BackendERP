using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Impostos.CstIcmss.Atualizar
{
    public class AtualizarCST_ICMSCommandValidation : AbstractValidator<AtualizarCST_ICMSCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarCST_ICMSCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new CstIcmsCommandValidation<AtualizarCST_ICMSCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.CST_ICMSRepository.ExisteIdAsync(id.Value);
        }
    }
}

