using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.ObrasProjetos.Atualizar
{
    public class AtualizarObraProjetoCommandValidation : AbstractValidator<AtualizarObraProjetoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarObraProjetoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new ObraProjetoCommandValidation<AtualizarObraProjetoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.ObraProjetoRepository.ExisteIdAsync(id.Value);
        }
    }
}
