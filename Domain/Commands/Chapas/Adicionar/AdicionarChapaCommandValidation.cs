using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Chapas.Adicionar
{
    public class AdicionarChapaCommandValidation : AbstractValidator<AdicionarChapaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarChapaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ChapaCommandValidation<AdicionarChapaCommand>(_unitOfWork));
        }
    }
}
