using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.TiposProdutos.Adicionar
{
    public class AdicionarTipoProdutoCommandValidation : AbstractValidator<AdicionarTipoProdutoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarTipoProdutoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new TipoProdutoCommandValidation<AdicionarTipoProdutoCommand>(_unitOfWork));
        }
    }
}
