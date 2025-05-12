using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Comissoes.Atualizar
{
    public class AtualizarComissaoCommandValidation : AbstractValidator<AtualizarComissaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarComissaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new ComissaoCommandValidation<AtualizarComissaoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.ComissaoRepository.ExisteIdAsync(id.Value);
        }
    }
}
