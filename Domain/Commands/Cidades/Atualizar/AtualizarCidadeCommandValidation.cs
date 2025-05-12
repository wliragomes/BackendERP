using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Cidades.Atualizar
{
    public class AtualizarCidadeCommandValidation : AbstractValidator<AtualizarCidadeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarCidadeCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CidadeCommandValidation<AtualizarCidadeCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.CidadeRepository.ExisteIdAsync(id.Value);
        }
    }
}
