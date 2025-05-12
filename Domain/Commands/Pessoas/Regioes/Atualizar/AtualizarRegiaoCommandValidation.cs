using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Regioes.Atualizar
{
    public class AtualizarRegiaoCommandValidation : AbstractValidator<AtualizarRegiaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarRegiaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new RegiaoCommandValidation<AtualizarRegiaoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.RegiaoRepository.ExisteIdAsync(id.Value);
        }
    }
}
