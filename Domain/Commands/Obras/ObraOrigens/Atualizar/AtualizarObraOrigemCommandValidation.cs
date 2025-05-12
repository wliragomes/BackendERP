using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.ObraOrigems.Atualizar
{
    public class AtualizarObraOrigemCommandValidation : AbstractValidator<AtualizarObraOrigemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarObraOrigemCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new ObraOrigemCommandValidation<AtualizarObraOrigemCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.ObraOrigemRepository.ExisteIdAsync(id.Value);
        }
    }
}
