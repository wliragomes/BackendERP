using Domain.Commands.Produtos.ClasseReajustes;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.DesgastePolimentos.Adicionar
{
    public class AdicionarDesgastePolimentoCommandValidation : AbstractValidator<AdicionarDesgastePolimentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarDesgastePolimentoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new DesgastePolimentoCommandValidation<AdicionarDesgastePolimentoCommand>(_unitOfWork));
        }

    }
}
