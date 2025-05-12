using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Cartoes.Atualizar
{
    public class AtualizarCartaoCommandValidation : AbstractValidator<AtualizarCartaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarCartaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new CartaoCommandValidation<AtualizarCartaoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.CartaoRepository.ExisteIdAsync(id.Value);
        }
    }
}
