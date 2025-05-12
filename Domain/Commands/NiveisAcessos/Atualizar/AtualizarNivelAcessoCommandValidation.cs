using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.NiveisAcessos.Atualizar
{
    public class AtualizarNivelAcessoCommandValidation : AbstractValidator<AtualizarNivelAcessoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarNivelAcessoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new NivelAcessoCommandValidation<AtualizarNivelAcessoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.NivelAcessoRepository.ExisteIdAsync(id.Value);
        }
    }
}
