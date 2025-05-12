using Domain.Commands.Produtos.AtualizarDesgastes.Atualizar;
using Domain.Commands.Produtos.ClasseReajustes;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Produtos.DesgastePolimentos.Atualizar
{
    public class AtualizarDesgastePolimentoCommandValidation : AbstractValidator<AtualizarDesgastePolimentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarDesgastePolimentoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new DesgastePolimentoCommandValidation<AtualizarDesgastePolimentoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.DesgastePolimentoRepository.ExisteIdAsync(id.Value);
        }
    }
}