using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Modalidades.Atualizar
{
    public class AtualizarModalidadeCommandValidation : AbstractValidator<AtualizarModalidadeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarModalidadeCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new ModalidadeCommandValidation<AtualizarModalidadeCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.ModalidadeRepository.ExisteIdAsync(id.Value);
        }
    }
}
