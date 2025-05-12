using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.MotivoReposições.Atualizar
{
    public class AtualizarMotivoReposicaoCommandValidation : AbstractValidator<AtualizarMotivoReposicaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarMotivoReposicaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new MotivoReposicaoCommandValidation<AtualizarMotivoReposicaoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.MotivoReposicaoRepository.ExisteIdAsync(id.Value);
        }
    }
}
