using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.Adicionar
{
    public class AdicionarProdutoCommandValidation : AbstractValidator<AdicionarProdutoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarProdutoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c)
                .SetValidator(new ProdutoCommandValidation<AdicionarProdutoCommand>(_unitOfWork));
        }
    }
}
