using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.MovimentosEstoque.Adicionar
{
    public class AdicionarMovimentoEstoqueCommandValidation : AbstractValidator<AdicionarMovimentoEstoqueCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarMovimentoEstoqueCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new MovimentoEstoqueCommandValidation<AdicionarMovimentoEstoqueCommand>(_unitOfWork));
        }
    }
}
