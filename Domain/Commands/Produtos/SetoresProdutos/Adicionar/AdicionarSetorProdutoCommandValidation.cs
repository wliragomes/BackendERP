using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.SetoresProdutos.Adicionar
{
    public class AdicionarSetorProdutoCommandValidation : AbstractValidator<AdicionarSetorProdutoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarSetorProdutoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new SetorProdutoCommandValidation<AdicionarSetorProdutoCommand>(_unitOfWork));
        }
    }
}
