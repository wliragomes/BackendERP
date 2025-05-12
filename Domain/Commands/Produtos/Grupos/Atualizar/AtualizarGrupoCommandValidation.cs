using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Produtos.Grupos.Atualizar
{
    public class AtualizarGrupoCommandValidation : AbstractValidator<AtualizarGrupoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarGrupoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new GrupoCommandValidation<AtualizarGrupoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.GrupoRepository.ExisteIdAsync(id.Value);
        }
    }
}
