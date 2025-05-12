using Domain.Commands.Produtos.Atualizar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Produtos.TiposProdutos.Atualizar
{
    public class AtualizarTipoProdutoCommandValidation : AbstractValidator<AtualizarTipoProdutoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarTipoProdutoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new TipoProdutoCommandValidation<AtualizarTipoProdutoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.TipoProdutoRepository.ExisteIdAsync(id.Value);
        }
    }
}
