using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Produtos.TiposPrecos.Atualizar
{
    public class AtualizarTipoPrecoCommandValidation : AbstractValidator<AtualizarTipoPrecoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarTipoPrecoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new TipoPrecoCommandValidation<AtualizarTipoPrecoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.TipoPrecoRepository.ExisteIdAsync(id.Value);
        }
    }
}
