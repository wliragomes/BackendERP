using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ContasAPagar.Adicionar
{
    public class AdicionarContaAPagarCommandValidation : AbstractValidator<AdicionarContaAPagarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarContaAPagarCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ContaAPagarCommandValidation<AdicionarContaAPagarCommand>(_unitOfWork));
        }
    }
}
