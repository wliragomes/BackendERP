using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.Subgrupos.Adicionar
{
    public class AdicionarSubgrupoCommandValidation : AbstractValidator<AdicionarSubgrupoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarSubgrupoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new SubgrupoCommandValidation<AdicionarSubgrupoCommand>(_unitOfWork));
        }
    }
}
