using Domain.Commands.Bancos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Cfops.Atualizar
{
    public class AtualizarCfopCommandValidation : AbstractValidator<AtualizarCfopCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarCfopCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new CfopCommandValidation<AtualizarCfopCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.CfopRepository.ExisteIdAsync(id.Value);
        }
    }
}
