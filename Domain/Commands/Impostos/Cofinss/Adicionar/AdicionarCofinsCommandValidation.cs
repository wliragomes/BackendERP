using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.Cofinss.Adicionar
{
    public class AdicionarCofinsCommandValidation : AbstractValidator<AdicionarCofinsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCofinsCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c)
                .SetValidator(new CofinsCommandValidation<AdicionarCofinsCommand>(_unitOfWork));
        }
    }
}
