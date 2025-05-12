using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Produtos.Subgrupos.Atualizar
{
    public class AtualizarSubgrupoCommandValidation : AbstractValidator<AtualizarSubgrupoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarSubgrupoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new SubgrupoCommandValidation<AtualizarSubgrupoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.SubgrupoRepository.ExisteIdAsync(id.Value);
        }
    }
}
